using System.Windows.Input;
using Xamarin.Forms;
using XPOffice.View;

namespace XPOffice.ViewModel
{
    public class ImproveViewModel : BaseViewModel
    {
        private ICommand alreadyDo;
        private ICommand goBack;
        private ICommand restart;

        public ICommand AlreadyDo => alreadyDo ?? (alreadyDo = new Command(async () =>
            await PushAsync(new StartPage())));

        public ICommand GoBack => goBack ?? (goBack = new Command(async () =>
            await PushAsync(new ResultPage())));

        public ICommand Restart => restart ?? (restart = new Command(async () =>
            await PushAsync(new StartPage())));
    }
}
