using Bzs.Mensa.App.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a main view model.
    /// </summary>
    public sealed class MainViewModel : ObservableObject
    {
        private INavigation navigation;
        private RelayCommand benutzerEinstellungenCommand;

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

        /// <summary>
        /// Gets the user settings command.
        /// </summary>
        public RelayCommand BenutzerEinstellungenCommand
        {
            get
            {
                return this.benutzerEinstellungenCommand ?? (this.benutzerEinstellungenCommand = new RelayCommand(this.ExecuteBenutzerEinstellungenCommand, this.CanExecuteBenutzerEinstellungenCommand));
            }
        }

        /// <summary>
        /// Returns a value indicating whether the user settings command can execute.
        /// </summary>
        /// <returns>The command can execute.</returns>
        private bool CanExecuteBenutzerEinstellungenCommand()
        {
            return true;
        }

        /// <summary>
        /// Executes the user settings command.
        /// </summary>
        private async void ExecuteBenutzerEinstellungenCommand()
        {
            if (this.CanExecuteBenutzerEinstellungenCommand())
            {
                await this.navigation.PushAsync(new BenutzerEinstellungen()).ConfigureAwait(true);
            }
        }
    }
}
