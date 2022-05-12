using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a new password view model.
    /// </summary>
    public sealed class NeuesPwViewModel : ObservableObject
    {
        private INavigation navigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="NeuesPwViewModel" /> class.
        /// </summary>
        public NeuesPwViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NeuesPwViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public NeuesPwViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}
