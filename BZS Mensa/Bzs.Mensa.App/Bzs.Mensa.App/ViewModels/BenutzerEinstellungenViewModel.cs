using Bzs.Mensa.App.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a user settings view model.
    /// </summary>
    public sealed class BenutzerEinstellungenViewModel : ObservableObject
    {
        private INavigation navigation;
        private RelayCommand passwortAendernCommand;
        private RelayCommand speichernCommand;

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
            : this()
        {
            this.navigation = navigation;
        }

        /// <summary>
        /// Gets the password change command.
        /// </summary>
        public RelayCommand PasswortAendernCommand
        {
            get
            {
                return this.passwortAendernCommand ?? (this.passwortAendernCommand = new RelayCommand(this.ExecutePasswortAendernCommand, this.CanExecutePasswortAendernCommand));
            }
        }

        public RelayCommand SpeichernCommand
        {
            get
            {
                return this.speichernCommand ?? (this.speichernCommand = new RelayCommand(this.ExecuteSpeichernCommand, this.CanExecuteSpeichernCommand));
            }
        }

        private bool CanExecuteSpeichernCommand()
        {
            return true;
        }

        private async void ExecuteSpeichernCommand()
        {
            await App.Current.MainPage.DisplayAlert("Gespeichert", "Ihr Benutzer wurde gespeichert.", "Ok").ConfigureAwait(true);
        }

        /// <summary>
        /// Returns a value indicating whether the password change command can execute.
        /// </summary>
        /// <returns>The command can execute.</returns>
        private bool CanExecutePasswortAendernCommand()
        {
            return true;
        }

        /// <summary>
        /// Executes the password change command.
        /// </summary>
        private void ExecutePasswortAendernCommand()
        {
            this.navigation.PushAsync(new NeuesPw());
        }
    }
}
