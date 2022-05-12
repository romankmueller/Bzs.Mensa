using System;
using Bzs.Mensa.App.ViewModels;
using Bzs.Mensa.App.Views;
using Xamarin.Forms;

namespace Bzs.Mensa.App
{
    /// <summary>
    /// Represents the interaction logic of the main page.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            // Add the view model to the view.
            this.BindingContext = new MainViewModel(this.Navigation);
            
            // TODO: Remove resp. change
            this.Navigation.PushAsync(new Login());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Essen());
        }
    }
}
