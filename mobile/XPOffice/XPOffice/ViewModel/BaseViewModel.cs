using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XPOffice.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private ICommand homeCommand;

        public async Task PushModalAsync(Page page)
        {
            if (App.Navigation != null)
                await App.Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (App.Navigation != null)
                await App.Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            if (App.Navigation != null)
                await App.Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            if (App.Navigation != null)
                await App.Navigation.PopAsync();
        }

        public void RemoveStackPages(Page exceptedPage = null)
        {
            var existingPages = App.Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page != null && page == exceptedPage)
                    continue;

                App.Navigation.RemovePage(page);
            }
        }

        public void RemovePagesByType(Type[] pages)
        {
            App.Navigation.NavigationStack
                .Where(w => pages.Contains(w.GetType()))
                .ToList()
                .ForEach(s => App.Navigation.RemovePage(s));
        }

        public void RemovePage(Page page)
        {
            if (App.Navigation != null)
                App.Navigation.RemovePage(page);
        }

        #region INotifyPropertyChanging implementation

        public event Xamarin.Forms.PropertyChangingEventHandler PropertyChanging;

        #endregion

        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging == null)
                return;

            PropertyChanging(this, new Xamarin.Forms.PropertyChangingEventArgs(propertyName));
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
