using Bzs.Mensa.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bzs.Mensa.App.Views
{
    /// <summary>
    /// Represents the interaction logic of the new password view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NeuesPw : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NeuesPw" /> view.
        /// </summary>
        public NeuesPw()
        {
            this.InitializeComponent();
            this.BindingContext = new NeuesPwViewModel(this.Navigation);
        }
    }
}