using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PastQuestionPapers_JavaScript.ViewModels
{
    class Page_001ViewModel : BaseViewModel
    {

        private string question;
        private string text;
        private string answer;
        private string execute;
        private HtmlWebViewSource result;
        private bool isVisibleResult;

        private bool isVisibleButton;

        public string Question
        {
            get { return question; }
            set { SetProperty(ref question, value); }
        }
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }
        public string Answer
        {
            get { return answer; }
            set { SetProperty(ref answer, value); }
        }
        public string Execute
        {
            get { return execute; }
            set { SetProperty(ref execute, value); }
        }
        public HtmlWebViewSource Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }
        public bool IsVisibleResult
        {
            get { return isVisibleResult; }
            set { SetProperty(ref isVisibleResult, value); }
        }

        public bool IsVisibleButton
        {
            get { return isVisibleButton; }
            set { SetProperty(ref isVisibleButton, value); }
        }


        public ICommand ExecuteCommand => new Command(() =>
        {
            IsVisibleResult = true;

            IsVisibleButton = false;

            //現在のコードを実行しているAssemblyを取得
            System.Reflection.Assembly myAssembly =
                System.Reflection.Assembly.GetExecutingAssembly();
            //指定されたマニフェストリソースを読み込む
            System.IO.StreamReader sr =
                new System.IO.StreamReader(
                myAssembly.GetManifestResourceStream("PG_Practice_JS.Resources.ResultPage.html"),
                    System.Text.Encoding.GetEncoding("utf-8"));
            //内容を読み込む
            string s = sr.ReadToEnd();
            //後始末
            sr.Close();

            s = s.Replace("①", Answer);
            s = s.Replace("②", "");
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = s;
            Result = htmlSource;
        });

        public ICommand CloseCommand => new Command(() =>
        {
            IsVisibleResult = false;
            IsVisibleButton = true;
        });

        public ICommand EqualCommand => new Command(async () =>
        {
            string target = "=";
            await Clipboard.SetTextAsync(target);
            MessagingCenter.Send(this, "ExecCopyMessage", target);
        });

        public ICommand SingleQuotationCommand => new Command(async () =>
        {
            string target = "'";
            await Clipboard.SetTextAsync(target);
            MessagingCenter.Send(this, "ExecCopyMessage", target);
        });

        public ICommand ParenthesisStartCommand => new Command(async () =>
        {
            string target = "(";
            await Clipboard.SetTextAsync(target);
            MessagingCenter.Send(this, "ExecCopyMessage", target);
        });

        public ICommand ParenthesisEndCommand => new Command(async () =>
        {
            string target = ")";
            await Clipboard.SetTextAsync(target);
            MessagingCenter.Send(this, "ExecCopyMessage", target);
        });

        public ICommand SemicolonCommand => new Command(async () =>
        {
            string target = ";";
            await Clipboard.SetTextAsync(target);
            MessagingCenter.Send(this, "ExecCopyMessage", target);
        });

        public Page_001ViewModel()
        {

            IsVisibleButton = true;

            Execute = "実行";

            Text = $@"
自由
";
            Answer = $@"
let x = 1;
let y = 2;
alert('x + y = ' + (x + y));
";

            IsVisibleResult = false;

        }
    }
}
