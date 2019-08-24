using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PastQuestionPapers_JavaScript.ViewModels
{
    class Page_003ViewModel : BaseViewModel
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
result1.innerHTML = 'fn(3) = ' + fn(3);   
result2.innerHTML = 'fn(12) = ' + fn(12);
result3.innerHTML = 'fn(0) = ' + fn(0);

result5.innerHTML = 'NG'; 

if (fn(3) == 3) if (fn(12) == 233) if (fn(0) == 1) 
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
"function fn(x){\r\n" +
"   //まだ子供は生まれません\r\n" +
"   if(x == 0 || x == 1) return 1;\r\n" +
"\r\n" +
"   //一カ月前の数に増分を足します\r\n" +
"   return fn(x - 1) + fn(x - 2);\r\n" +
"}";
        });

        public Page_003ViewModel(ScrollView scroll)
        {
            this.scroll = scroll;
            IsVisibleButton = true;

            Execute = "実行";
            AnswerButton = "回答例を上書きします";

            Text = $@"
フィボナッチ数

function fn(x)の実装を行ってください。

・引数xは整数です。
・1つがいの兎は、産まれて2か月後から毎月1つがいずつの兎を産みます。
・兎が死ぬことはありません。
・上記の条件のもとで、産まれたばかりの1つがいの兎はxヶ月後に何つがいの兎になるか整数で返却してください。

【例】
0ヶ月後 1ペア(つがい)
1ヶ月後 1ペア
2ヶ月後 2ペア 最初の1ペアが成長し、子供を産みました。産まれた子供はペアです。
3ヶ月後 3ペア
4ヶ月後 5ペア 2ヶ月後に産まれたペアが成長し、この月は子供が2ペア産まれました。
:
:
となります。
";
            Answer = $@"
function fn(x) 
" + "{\r\n\r\nreturn;\r\n}";


            IsVisibleResult = false;

        }
    }
}
