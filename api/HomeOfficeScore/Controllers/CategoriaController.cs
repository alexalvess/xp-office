using System;
using System.Collections.Generic;
using HomeOfficeScore.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace HomeOfficeScore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private List<Categoria> _categorias;
        public List<Categoria> Categorias
        {
            get
            {
                if (_categorias == null)
                {
                    _categorias = ReadAllCategorias();
                }
                return _categorias;
            }
        }

        public CategoriaController()
        {
        }

        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return Categorias;
        }

        [HttpPost("result")]
        public dynamic GetResult(List<Categoria> categorias)
        {
            var pontos = 0;
            categorias.ForEach(categoria =>
            {
                pontos += categoria.Items.Sum(i => i.Peso);
            });

            var itemsAux = new List<Item>();

            for (int i = 0; i < Categorias.Count; i ++)
            {
                var items = Categorias[i].Items.OrderByDescending(p => p.Peso).ToList();
                for (int j = 0; j < items.Count; j++)
                {
                    // Já possuí o melhor item da categoria que não é multiseleção
                    var item = items[j];
                    if (!Categorias[i].MultiSelecao && j == 0 &&
                        categorias.Any(p => p.Id == Categorias[i].Id &&
                                            p.Items.Any(i => i.Id == item.Id)))
                    {
                        break;
                    }

                    if (categorias.Any(p => p.Id == Categorias[i].Id &&
                                            p.Items.Any(i => i.Id == item.Id)))
                        continue;

                    item.Peso *= Categorias[i].Peso;
                    itemsAux.Add(item);
                    break;
                }
            }

            var itemSugerido = itemsAux.OrderByDescending(i => i.Peso).FirstOrDefault();
            var categoriaSugerida = this.Categorias.Where(p => p.Items.Any(i => i.Id == itemSugerido.Id)).FirstOrDefault();
            categoriaSugerida.Items.RemoveAll(i => i.Id != itemSugerido.Id);
            return new
            {
                Pontos = pontos,
                Categoria = categoriaSugerida
            };
        }

        private List<Categoria> ReadAllCategorias()
        {
            var file = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/categorias.json");
            var categorias = JsonConvert.DeserializeObject<RootCategoria>(file);
            return categorias.Categorias;
        }
    }
}
