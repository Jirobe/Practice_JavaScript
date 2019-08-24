using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PastQuestionPapers_JavaScript.ViewModels
{
    class Page_004ViewModel : BaseViewModel
    {

        private string question;
        private string text;
        private string answer;
        private string answerButton;
        private string execute;
        private HtmlWebViewSource result;
        private bool isVisibleResult;
        private bool isVisibleButton;

        private ScrollView scroll;

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
        public string AnswerButton
        {
            get { return answerButton; }
            set { SetProperty(ref answerButton, value); }
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


        public ICommand ExecuteCommand => new Command(async () =>
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

            s = s.Replace("①",
$@"
var in11111111111111111111 = [5,2,7,3,4];
var out11111111111111111111 = [2,3,4,5,7];
result1.innerHTML = 'sort([5,2,7,3,4]) = ' + sort(in11111111111111111111);   


result5.innerHTML = 'NG'; 

if (sort(in11111111111111111111) == out11111111111111111111)
result5.innerHTML = 'OK'; 
"
                );
            s = s.Replace("②", Answer);

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = s;
            Result = htmlSource;

            await scroll.ScrollToAsync(0, 0, true);

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

        public ICommand AnswerButtonCommand => new Command(() =>
        {
            Answer =
"function sort(a){\r\n" +
"   for(var i=0; i<a.length; i++)\r\n" +
"       for(var j=a.length-1; j>i; j--)\r\n" +
"           if(a[j]<a[j-1]){\r\n" +
"               var t = a[j];r\n" +
"               a[j] = a[j-1];\r\n" +
"               a[j-1] = t;\r\n" +
"               }\r\n" +
"}";
        });

        public Page_004ViewModel(ScrollView scroll)
        {
            this.scroll = scroll;
            IsVisibleButton = true;

            Execute = "実行";
            AnswerButton = "回答例を上書きします";

            Text = $@"
ソート

配列を引数とするfunction sort(a)の実装を行ってください。

・引数を降順でソートした配列を返却してください。

";
            Answer = $@"
function sort(a) 
" + "{\r\n\r\nreturn a;\r\n}";


            IsVisibleResult = false;

        }
    }
}
