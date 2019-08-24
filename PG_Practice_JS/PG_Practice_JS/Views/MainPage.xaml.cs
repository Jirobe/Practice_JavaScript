using PastQuestionPapers_JavaScript.ViewModels;
using PG_Practice_JS.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PastQuestionPapers_JavaScript.Views
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();

            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //@ページ追加時 記述箇所
            MessagingCenter.Subscribe<MainPageItem>(this, "Page_001",
                async (_) =>
                {
                    await Navigation.PushAsync(new Page_001(), true);
                });
            MessagingCenter.Subscribe<MainPageItem>(this, "Page_002",
                async (_) =>
                {
                    await Navigation.PushAsync(new Page_002(), true);
                });
            MessagingCenter.Subscribe<MainPageItem>(this, "Page_003",
                async (_) =>
                {
                    await Navigation.PushAsync(new Page_003(), true);
                });
            MessagingCenter.Subscribe<MainPageItem>(this, "Page_004",
                async (_) =>
                {
                    await Navigation.PushAsync(new Page_004(), true);
                });

            //規約用
            MessagingCenter.Subscribe<MainPageViewModel>(this, "Tos",
            async (_) =>
                {
                    viewModel.TosTask();
                    await Navigation.PushModalAsync(new TosView(), true);
                });

            //なぜか二回呼ばれる
            viewModel.TosTask?.Invoke();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //@ページ追加時 記述箇所
            //イベントの破棄
            MessagingCenter.Unsubscribe<MainPageItem>(this, "Page_001");
            MessagingCenter.Unsubscribe<MainPageItem>(this, "Page_002");
            MessagingCenter.Unsubscribe<MainPageItem>(this, "Page_003");
            MessagingCenter.Unsubscribe<MainPageItem>(this, "Page_004");
            MessagingCenter.Unsubscribe<MainPageViewModel>(this, "Tos");
        }
    }
}
