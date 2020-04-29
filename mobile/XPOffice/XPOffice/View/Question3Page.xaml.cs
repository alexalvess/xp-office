
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XPOffice.ViewModel;

namespace XPOffice.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Question3Page : ContentPage
    {
        public Question3Page()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new QuestionViewModel(3);
        }
    }
}