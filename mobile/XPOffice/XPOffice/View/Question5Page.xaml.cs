
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XPOffice.ViewModel;

namespace XPOffice.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Question5Page : ContentPage
    {
        public Question5Page()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new QuestionViewModel(5);
        }
    }
}