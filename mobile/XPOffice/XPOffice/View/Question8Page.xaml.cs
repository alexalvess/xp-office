
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XPOffice.ViewModel;

namespace XPOffice.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Question8Page : ContentPage
    {
        public Question8Page()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new QuestionViewModel(8);
        }
    }
}