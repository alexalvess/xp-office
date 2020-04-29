using Xamarin.Forms;
using XPOffice.View;

namespace XPOffice
{
    public partial class App : Application
    {
        public static INavigation Navigation;

        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new StartPage());

            Navigation = MainPage.Navigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
