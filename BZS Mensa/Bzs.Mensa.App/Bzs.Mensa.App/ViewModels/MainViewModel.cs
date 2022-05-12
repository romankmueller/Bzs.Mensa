using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a main view model.
    /// </summary>
    public sealed class MainViewModel : ObservableObject
    {
        private INavigation navigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        public MainViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public MainViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}
