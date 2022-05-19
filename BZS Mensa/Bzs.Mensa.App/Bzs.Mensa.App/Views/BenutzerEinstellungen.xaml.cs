using Bzs.Mensa.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bzs.Mensa.App.Views
{
    /// <summary>
    /// Represents the interaction logic of the user setting view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BenutzerEinstellungen : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerEinstellungen" /> view.
        /// </summary>
        public BenutzerEinstellungen()
        {
            this.InitializeComponent();
            this.BindingContext = new BenutzerEinstellungenViewModel(this.Navigation);
        }
    }
}