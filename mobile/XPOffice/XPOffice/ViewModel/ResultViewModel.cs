using System.Windows.Input;
using Xamarin.Forms;
using XPOffice.View;

namespace XPOffice.ViewModel
{
    public class ResultViewModel : BaseViewModel
    {
        private ICommand goImprove;
        private ICommand restart;

        public ICommand GoImprove => goImprove ?? (goImprove = new Command(async () =>
            await PushAsync(new ImprovePage())));

        public ICommand Restart => restart ?? (restart = new Command(async () =>
            await PushAsync(new StartPage())));
    }
}
