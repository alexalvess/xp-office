
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XPOffice.ViewModel;

namespace XPOffice.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Question7Page : ContentPage
    {
        public Question7Page()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new QuestionViewModel(7);
        }
    }
}