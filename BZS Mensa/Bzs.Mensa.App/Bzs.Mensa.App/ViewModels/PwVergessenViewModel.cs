using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a password forgot view model.
    /// </summary>
    public sealed class PwVergessenViewModel : ObservableObject
    {
        private INavigation navigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="PwVergessenViewModel" /> class.
        /// </summary>
        public PwVergessenViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PwVergessenViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public PwVergessenViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}