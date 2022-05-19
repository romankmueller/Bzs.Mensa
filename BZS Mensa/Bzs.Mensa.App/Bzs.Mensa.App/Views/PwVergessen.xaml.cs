using Bzs.Mensa.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bzs.Mensa.App.Views
{
    /// <summary>
    /// Represents the interaction logic of the password forgot view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PwVergessen : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PwVergessen" /> view.
        /// </summary>
        public PwVergessen()
        {
            this.InitializeComponent();
            this.BindingContext = new PwVergessenViewModel(this.Navigation);
        }
    }
}