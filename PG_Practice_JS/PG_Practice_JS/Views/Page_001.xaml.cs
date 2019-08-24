using PastQuestionPapers_JavaScript.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PastQuestionPapers_JavaScript.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_001 : ContentPage
    {
        public Page_001()
        {
            InitializeComponent();

            BindingContext = new Page_001ViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Page_001ViewModel, string>(this, "ExecCopyMessage", 
                (_, s) => DisplayAlert("", $"クリップボードに「{s}」をコピーしました", "OK")
            );
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Page_001ViewModel, string>(this, "ExecCopyMessage");
        }
    }


}