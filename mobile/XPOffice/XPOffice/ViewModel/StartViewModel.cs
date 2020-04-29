using System.Windows.Input;
using Xamarin.Forms;
using XPOffice.View;

namespace XPOffice.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        private ICommand nextCommand;

        public ICommand NextCommand => nextCommand ??
            (nextCommand = new Command(async () => await PushAsync(new Question1Page())));
    }
}
