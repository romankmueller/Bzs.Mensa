using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Bzs.Mensa.App.Services;
using Bzs.Mensa.App.Views;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a login view model.
    /// </summary>
    public sealed class LoginViewModel : ObservableObject
    {
        private readonly ISecurityService securityService;
        private INavigation navigation;
        private bool inProgress;
        private string email;
        private string passwort;
        private bool anmeldedatenMerken;
        private RelayCommand anmeldenCommand;
        private RelayCommand registrierenCommand;
        private RelayCommand passwortVergessenCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel" /> class.
        /// </summary>
        public LoginViewModel()
        {
            this.securityService = new SecurityServiceProxy();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public LoginViewModel(INavigation navigation)
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
        /// Gets or sets the email address.
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
        /// Gets or sets the password.
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
                    this.OnChangedPassword();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the credentials should be remembered.
        /// </summary>
        public bool AnmeldedatenMerken
        {
            get
            {
                return this.anmeldedatenMerken;
            }

            set
            {
                this.SetProperty(ref this.anmeldedatenMerken, value);
            }
        }

        /// <summary>
        /// Gets the login command.
        /// </summary>
        public RelayCommand AnmeldenCommand
        {
            get
            {
                return this.anmeldenCommand ?? (this.anmeldenCommand = new RelayCommand(this.ExecuteAnmeldenCommand, this.CanExecuteAnmeldenCommand));
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
        /// Gets the password lost command.
        /// </summary>
        public RelayCommand PasswortVergessenCommand
        {
            get
            {
                return this.passwortVergessenCommand ?? (this.passwortVergessenCommand = new RelayCommand(this.ExecutePasswortVergessenCommand, this.CanExecutePasswortVergessenCommand));
            }
        }

        /// <summary>
        /// Called when the email address was changed.
        /// </summary>
        private void OnChangedEmail()
        {
            this.AnmeldenCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Called when the password changed.
        /// </summary>
        private void OnChangedPassword()
        {
            this.AnmeldenCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Returns a value indicating whether the login command can execute.
        /// </summary>
        /// <returns>The command can execute.</returns>
        private bool CanExecuteAnmeldenCommand()
        {
            return !this.InProgress && !string.IsNullOrEmpty(this.Email);
        }

        /// <summary>
        /// Executes the login command.
        /// </summary>
        private async void ExecuteAnmeldenCommand()
        {
            if (this.CanExecuteAnmeldenCommand())
            {
                await this.AnmeldenAsync().ConfigureAwait(true);
            }
        }

        /// <summary>
        /// Returns a value indicating whether the register command can execute.
        /// </summary>
        /// <returns>The command can execute.</returns>
        private bool CanExecuteRegistrierenCommand()
        {
            return !this.InProgress;
        }

        /// <summary>
        /// Executes the register command.
        /// </summary>
        private async void ExecuteRegistrierenCommand()
        {
            if (this.CanExecuteRegistrierenCommand())
            {
                await this.navigation.PushAsync(new Register()).ConfigureAwait(true);
            }
        }

        /// <summary>
        /// Returns a value indicating whether the password forgot command can execute.
        /// </summary>
        /// <returns>The command can execute.</returns>
        private bool CanExecutePasswortVergessenCommand()
        {
            return !this.InProgress;
        }

        /// <summary>
        /// Executes the password forgot command.
        /// </summary>
        private async void ExecutePasswortVergessenCommand()
        {
            if (this.CanExecutePasswortVergessenCommand())
            {
                await this.navigation.PushAsync(new PwVergessen()).ConfigureAwait(true);
            }
        }

        /// <summary>
        /// Login.
        /// </summary>
        /// <returns>The task.</returns>
        private async Task AnmeldenAsync()
        {
            this.InProgress = true;
            try
            {
                LoginResultDto resultat = await this.securityService.LoginAsync(this.Email, this.Passwort).ConfigureAwait(true);
                if (resultat != null && resultat.Succsessful)
                {
                    await this.navigation.PopAsync().ConfigureAwait(true);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Fehler", "Fehler beim Anmelden.", "Ok").ConfigureAwait(true);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                await App.Current.MainPage.DisplayAlert("Fehler", "Fehler beim Anmelden.", "Ok").ConfigureAwait(true);
            }
            finally
            {
                this.InProgress = false;
            }
        }
    }
}
