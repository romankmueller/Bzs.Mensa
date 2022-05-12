using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a meal view model.
    /// </summary>
    public sealed class EssenViewModel : ObservableObject
    {
        private INavigation navigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenViewModel" /> class.
        /// </summary>
        public EssenViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public EssenViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}
