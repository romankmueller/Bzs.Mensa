using Bzs.Mensa.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bzs.Mensa.App.Views
{
    /// <summary>
    /// Represents the interaction logic of the register view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Register" /> view.
        /// </summary>
        public Register()
        {
            this.InitializeComponent();
            this.BindingContext = new RegisterViewModel(this.Navigation);
        }
    }
}