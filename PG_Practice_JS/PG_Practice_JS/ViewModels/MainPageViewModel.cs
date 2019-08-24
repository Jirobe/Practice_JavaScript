using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;

namespace PastQuestionPapers_JavaScript.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        private bool checkTos = false;

        private string list1_Title;
        private string list1_sub;
        private ObservableCollection<MainPageItem> items;


        public Action TosTask;

        public ObservableCollection<MainPageItem> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }
        public string List1_Title
        {
            get { return list1_Title; }
            set { SetProperty(ref list1_Title, value); }
        }

        public string List1_Sub
        {
            get { return list1_sub; }
            set { SetProperty(ref list1_sub, value); }
        }

        public MainPageViewModel()
        {
            List1_Title = "プログラムの練習_JavaScript";
            List1_Sub = "回答例の確認は各ページの最下部にボタンを用意しています";

            //@ページ追加時 記述箇所
            Items = new ObservableCollection<MainPageItem>()
            {
                 new MainPageItem(){ Number="001_自由", Title="" , NextPageMessage="Page_001"},
                 new MainPageItem(){ Number="002_Fizz Buzz", Title="" , NextPageMessage="Page_002"},
                 new MainPageItem(){ Number="003_フィボナッチ数", Title="" , NextPageMessage="Page_003"},
                 //new MainPageItem(){ Number="004_ソート", Title="" , NextPageMessage="Page_004"},
            };

            TosTask = () =>
            {
                if (checkTos == false)
                {
                    checkTos = true;

                    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".IAgree.txt");

                    if (File.Exists(filePath))
                    {
                        string agree = File.ReadAllText(filePath);

                        if (agree == "1") return;
                    }

                    Device.BeginInvokeOnMainThread(() => MessagingCenter.Send(this, "Tos"));
                }
            };
        }

    }
}
