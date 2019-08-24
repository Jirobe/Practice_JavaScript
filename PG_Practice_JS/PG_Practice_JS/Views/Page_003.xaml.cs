﻿using PastQuestionPapers_JavaScript.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PastQuestionPapers_JavaScript.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page_003 : ContentPage
	{
		public Page_003 ()
		{
			InitializeComponent ();

            BindingContext = new Page_003ViewModel(Scroll);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Page_003ViewModel, string>(this, "ExecCopyMessage",
                (_, s) => DisplayAlert("", $"クリップボードに「{s}」をコピーしました", "OK")
            );
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Page_003ViewModel, string>(this, "ExecCopyMessage");
        }
    }
}