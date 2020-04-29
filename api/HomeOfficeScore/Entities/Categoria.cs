using System;
using System.Collections;
using System.Collections.Generic;

namespace HomeOfficeScore.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Peso { get; set; }
        public Boolean MultiSelecao { get; set; }
        public List<Item> Items { get; set; }

        public Categoria()
        {
        }
    }
}
