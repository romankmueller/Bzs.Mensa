using Bzs.Mensa.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bzs.Mensa.App.Views
{
    /// <summary>
    /// Represents the interaction logic of the login.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Login" /> class.
        /// </summary>
        public Login()
        {
            this.InitializeComponent();
            this.BindingContext = new LoginViewModel(this.Navigation);
        }
    }
}