using Bzs.Mensa.App.Services;
using Bzs.Mensa.Shared.DataTransferObjects;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a new password view model.
    /// </summary>
    public sealed class NeuesPwViewModel : ObservableObject
    {
        private INavigation navigation;
        private string email;
        private string passwort1;
        private string passwort2;
        private string token;
        private RelayCommand passwortAendernCommand;

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
            : this()
        {
            this.navigation = navigation;
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.SetProperty(ref this.email, value))
                {
                    this.OnChangedEmail();
                }
            }
        }

        /// <summary>
        /// Gets or sets the password 1.
        /// </summary>
        public string Passwort1
        {
            get
            {
                return this.passwort1;
            }

            set
            {
                if (this.SetProperty(ref this.passwort1, value))
                {
                    this.OnChangedPasswort1();
                }
            }
        }

        /// <summary>
        /// Gets or sets the password 2.
        /// </summary>
        public string Passwort2
        {
            get
            {
                return this.passwort2;
            }

            set
            {
                if (this.SetProperty(ref this.passwort2, value))
                {
                    this.OnChangedPasswort2();
                }
            }
        }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string Token
        {
            get
            {
                return this.token;
            }

            set
            {
                if (this.SetProperty(ref this.token, value))
                {
                    this.OnChangedToken();
                }
            }
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

        /// <summary>
        /// Called when the email changed.
        /// </summary>
        private void OnChangedEmail()
        {
            this.PasswortAendernCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Called when the password 1 changed.
        /// </summary>
        private void OnChangedPasswort1()
        {
            this.PasswortAendernCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Called when the password 2 changed.
        /// </summary>
        private void OnChangedPasswort2()
        {
            this.PasswortAendernCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Called when the token changed.
        /// </summary>
        private void OnChangedToken()
        {
            this.PasswortAendernCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Returns a value indicating whether the password change command can execute.
        /// </summary>
        /// <returns>The command can execute.</returns>
        private bool CanExecutePasswortAendernCommand()
        {
            return !string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.Passwort1) && !string.IsNullOrEmpty(this.Passwort2) && this.Passwort1 == this.Passwort2 && !string.IsNullOrEmpty(this.Token);
        }

        /// <summary>
        /// Executes the password change command.
        /// </summary>
        private async void ExecutePasswortAendernCommand()
        {
            if (this.CanExecutePasswortAendernCommand())
            {
                BenutzerNeuesPasswortDto abfrage = new BenutzerNeuesPasswortDto();
                abfrage.Email = this.email;
                abfrage.Token = this.Token;
                abfrage.PasswortNeu = this.Passwort1;
                
                BenutzerServiceProxy service = new BenutzerServiceProxy();
                ResultDto result = await service.SetChangeBenutzerPasswort(abfrage).ConfigureAwait(true);
                if (result.Succsessful)
                {
                    await App.Current.MainPage.DisplayAlert("Passwort", "Das neue Passwort wurde gesetzt.", "Ok").ConfigureAwait(true);
                    await this.navigation.PopAsync().ConfigureAwait(true);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Fehler", "Fehler beim Ändern des Passwortes.", "Ok").ConfigureAwait(true);
                }
            }
        }
    }
}
