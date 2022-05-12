using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a user settings view model.
    /// </summary>
    public sealed class BenutzerEinstellungenViewModel : ObservableObject
    {
        private INavigation navigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerEinstellungenViewModel" /> class.
        /// </summary>
        public BenutzerEinstellungenViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerEinstellungenViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public BenutzerEinstellungenViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}
