using System.Windows.Input;
using Xamarin.Forms;

namespace PastQuestionPapers_JavaScript.ViewModels
{
    class MainPageItem : BaseViewModel
    {
        private string number;
        private string title;

        public string Number
        {
            get { return number; }
            set { SetProperty(ref number, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public string NextPageMessage { get; set; }

        public ICommand StartCommand => new Command(() =>
        {
            MessagingCenter.Send(this, NextPageMessage);
        });

    }
}
