using Bzs.Mensa.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bzs.Mensa.App.Views
{
    /// <summary>
    /// Represents the interaction logic of a class selection view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KlassenAuswahl : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KlassenAuswahl" /> view.
        /// </summary>
        public KlassenAuswahl()
        {
            this.InitializeComponent();
            this.BindingContext = new KlassenAuswahlViewModel(this.Navigation);
        }
    }
}