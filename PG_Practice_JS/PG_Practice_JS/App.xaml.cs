using PastQuestionPapers_JavaScript.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PG_Practice_JS
{
    public partial class App : Application
    {
        public static Action OnStartAction;
        public static Action OnSleepAction;
        public static Action OnResumeAction;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            OnStartAction?.Invoke();
        }

        protected override void OnSleep()
        {
            OnSleepAction?.Invoke();
        }

        protected override void OnResume()
        {
            OnResumeAction?.Invoke();
        }
    }
}
