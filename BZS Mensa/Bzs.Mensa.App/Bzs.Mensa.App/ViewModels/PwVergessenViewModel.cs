using Bzs.Mensa.App.Services;
using Bzs.Mensa.App.Views;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a password forgot view model.
    /// </summary>
    public sealed class PwVergessenViewModel : ObservableObject
    {
        private readonly IBenutzerService benutzerService;
        private INavigation navigation;
        private string email;
        private RelayCommand sendenCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="PwVergessenViewModel" /> class.
        /// </summary>
        public PwVergessenViewModel()
        {
            this.benutzerService = new BenutzerServiceProxy();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PwVergessenViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public PwVergessenViewModel(INavigation navigation)
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
        /// Gets the send command.
        /// </summary>
        public RelayCommand SendenCommand
        {
            get
            {
                return this.sendenCommand ?? (this.sendenCommand = new RelayCommand(this.ExecuteSendenCommand, this.CanExecuteSendenCommand));
            }
        }

        private void OnChangedEmail()
        {

        }

        /// <summary>
        /// Returns a value indicating whether the send command can execute.
        /// </summary>
        /// <returns>The command can execute.</returns>
        private bool CanExecuteSendenCommand()
        {
            return !string.IsNullOrEmpty(this.Email);
        }

        /// <summary>
        /// Executes the send command.
        /// </summary>
        private async void ExecuteSendenCommand()
        {
            BenutzerPasswortVergessenDto data = new BenutzerPasswortVergessenDto(this.Email);
            ResultDto result = await this.benutzerService.SendTokenEmail(data).ConfigureAwait(true);
            if (result.Succsessful)
            {
                await this.navigation.PopAsync();
                await this.navigation.PushAsync(new NeuesPw()).ConfigureAwait(true);
                await App.Current.MainPage.DisplayAlert("E-Mail", "Bitte konsultieren Sie Ihre E-Mails.", "Ok").ConfigureAwait(true);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Fehler", "Bitte überprüfen Sie Ihre E-Mail-Adresse.", "Ok").ConfigureAwait(true);
            }
        }
    }
}