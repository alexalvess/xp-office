
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XPOffice.ViewModel;

namespace XPOffice.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImprovePage : ContentPage
    {
        public ImprovePage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new ImproveViewModel();
        }
    }
}