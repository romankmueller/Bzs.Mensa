using Bzs.Mensa.App.Services;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a register view model.
    /// </summary>
    public sealed class RegisterViewModel : ObservableObject
    {
        private readonly IBenutzerService benutzerService;
        private INavigation navigation;
        private int registerCounter;
        private bool inProgress;
        private string vorname;
        private string nachname;
        private string email;
        private string passwort;
        private RelayCommand registrierenCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterViewModel" /> class.
        /// </summary>
        public RegisterViewModel()
        {
            this.benutzerService = new BenutzerServiceProxy();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public RegisterViewModel(INavigation navigation)
            : this()
        {
            this.navigation = navigation;
        }

        /// <summary>
        /// Gets a value indicating whether the view model is in progress.
        /// </summary>
        public bool InProgress
        {
            get
            {
                return this.inProgress;
            }

            private set
            {
                this.SetProperty(ref this.inProgress, value);
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string Vorname
        {
            get
            {
                return this.vorname;
            }

            set
            {
                if (this.SetProperty(ref this.vorname, value))
                {
                    this.OnChangedVorname();
                }
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string Nachname
        {
            get
            {
                return this.nachname;
            }

            set
            {
                if (this.SetProperty(ref this.nachname, value))
                {
                    this.OnChangedNachname();
                }
            }
        }

        /// <summary>
        /// Gets or sets the first name.
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
        /// Gets or sets the first name.
        /// </summary>
        public string Passwort
        {
            get
            {
                return this.passwort;
            }

            set
            {
                if (this.SetProperty(ref this.passwort, value))
                {
                    this.OnChangedPasswort();
                }
            }
        }

        /// <summary>
        /// Gets the register command.
        /// </summary>
        public RelayCommand RegistrierenCommand
        {
            get
            {
                return this.registrierenCommand ?? (this.registrierenCommand = new RelayCommand(this.ExecuteRegistrierenCommand, this.CanExecuteRegistrierenCommand));
            }
        }

        /// <summary>
        /// Called when the first name changed.
        /// </summary>
        private void OnChangedVorname()
        {
            this.RegistrierenCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Called when the last name changed.
        /// </summary>
        private void OnChangedNachname()
        {
            this.RegistrierenCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Called when the email changed.
        /// </summary>
        private void OnChangedEmail()
        {
            this.RegistrierenCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Called when the password changed.
        /// </summary>
        private void OnChangedPasswort()
        {
            this.RegistrierenCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Returns a value indicating whether the register command can execute.
        /// </summary>
        /// <returns>The command can execute.</returns>
        private bool CanExecuteRegistrierenCommand()
        {
            return !string.IsNullOrEmpty(this.Nachname) && !string.IsNullOrEmpty(this.Vorname) && !string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.Passwort);
        }

        /// <summary>
        /// Executes the register command.
        /// </summary>
        private async void ExecuteRegistrierenCommand()
        {
            if (this.CanExecuteRegistrierenCommand())
            {
                bool registriert = await this.RegisterAsync().ConfigureAwait(true);
                if (registriert)
                {
                    await App.Current.MainPage.DisplayAlert("Registrieren", "Ihr Benutzer wurde registriert.", "Ok").ConfigureAwait(true);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Fehler", "Fehler beim Registrieren des Benutzers.", "Ok").ConfigureAwait(true);
                }
            }
        }

        /// <summary>
        /// Increases the register counter.
        /// </summary>
        private void IncreaseRegisterCounter()
        {
            this.registerCounter++;
            this.InProgress = this.registerCounter > 0;
        }

        /// <summary>
        /// Decreases the register counter.
        /// </summary>
        private void DecreaseRegisterCounter()
        {
            if (this.registerCounter > 0)
            {
                this.registerCounter--;
                this.InProgress = this.registerCounter > 0;
            }
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <returns>The task.</returns>
        private async Task<bool> RegisterAsync()
        {
            this.IncreaseRegisterCounter();
            BenutzerEditDto benutzer = new BenutzerEditDto(Guid.NewGuid(), this.Email, this.Email, this.Nachname, this.Vorname, Guid.Empty, false);
            ResultDto resultat = null;
            try
            {
                resultat = await this.benutzerService.SaveBenutzerAsync(benutzer).ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
            finally
            {
                this.DecreaseRegisterCounter();
            }

            if (resultat != null && resultat.Succsessful)
            {
                return true;
            }

            return false;
        }
    }
}