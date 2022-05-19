using Bzs.Mensa.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bzs.Mensa.App.Views
{
    /// <summary>
    /// Represents the interaction logic of the meal view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Essen : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Essen" /> view.
        /// </summary>
        public Essen()
        {
            this.InitializeComponent();
            this.BindingContext = new EssenViewModel(this.Navigation);
        }
    }
}