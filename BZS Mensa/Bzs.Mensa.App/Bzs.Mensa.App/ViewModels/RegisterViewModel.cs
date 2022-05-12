using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a register view model.
    /// </summary>
    public sealed class RegisterViewModel : ObservableObject
    {
        private INavigation navigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterViewModel" /> class.
        /// </summary>
        public RegisterViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public RegisterViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}