using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PG_Practice_JS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TosView : ContentPage
	{
		public TosView ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".IAgree.txt");

            File.WriteAllText(filePath, "1");

            Navigation.PopModalAsync();
        }

        protected override bool OnBackButtonPressed() => true;
    }
}