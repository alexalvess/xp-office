using System;
using System.Windows.Input;
using Xamarin.Forms;
using XPOffice.View;

namespace XPOffice.ViewModel
{
    public class QuestionViewModel : BaseViewModel
    {
        private ICommand nextCommand;
        private ICommand backCommand;
        private int _pageNumber;

        public QuestionViewModel(int pageNumber) =>
            _pageNumber = pageNumber;

        public ICommand NextCommand => nextCommand ?? (nextCommand = new Command(async () =>
        {
            await PushAsync(GetPage().Item2);
        }));

        public ICommand BackCommand => backCommand ?? (backCommand = new Command(async () =>
        {
            await PushAsync(GetPage().Item1);
        }));

        private Tuple<Page, Page> GetPage()
        {
            switch (_pageNumber)
            {
                case 1:
                    return new Tuple<Page, Page>(new StartPage(), new Question2Page());
                case 2:
                    return new Tuple<Page, Page>(new Question1Page(), new Question3Page());
                case 3:
                    return new Tuple<Page, Page>(new Question2Page(), new Question4Page());
                case 4:
                    return new Tuple<Page, Page>(new Question3Page(), new Question5Page());
                case 5:
                    return new Tuple<Page, Page>(new Question4Page(), new Question6Page());
                case 6:
                    return new Tuple<Page, Page>(new Question5Page(), new Question7Page());
                case 7:
                    return new Tuple<Page, Page>(new Question6Page(), new Question8Page());
                case 8:
                    return new Tuple<Page, Page>(new Question7Page(), new ResultPage());
                default:
                    return null;
            }
        }
    }
}
