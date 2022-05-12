using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a class selection view model.
    /// </summary>
    public sealed class KlassenAuswahlViewModel : ObservableObject
    {
        private INavigation navigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="KlassenAuswahlViewModel" /> class.
        /// </summary>
        public KlassenAuswahlViewModel()
        {
            this.KlasseItems = new ObservableCollection<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KlassenAuswahlViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public KlassenAuswahlViewModel(INavigation navigation)
            : this()
        {
            this.navigation = navigation;
        }

        /// <summary>
        /// Gets the class items.
        /// </summary>
        public ObservableCollection<string> KlasseItems { get; }
    }
}
