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
        private string email;
        private string passwort1;
        private string passwort2;
        private string token;
        private RelayCommand passwortAendern;
        private INavigation navigation;

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
        {
            this.navigation = navigation;
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public string Passwort1
        {
            get
            {
                return this.passwort1;
            }

            set
            {
                this.passwort1 = value;
            }
        }

        public string Passwort2
        {
            get
            {
                return this.passwort2;
            }

            set
            {
                this.passwort2 = value;
            }
        }

        public string Token
        {
            get
            {
                return this.token;
            }

            set
            {
                this.token = value;
            }
        }
        public RelayCommand PasswortAendern
        {
            get
            {
                return this.passwortAendern ?? (this.passwortAendern = new RelayCommand(this.ExecutePasswortAendernCommand));
            }
        }

        private async void ExecutePasswortAendernCommand()
        {
            if(this.passwort1 == this.passwort2)
            {
                BenutzerNeuesPasswortDto abfrage = new BenutzerNeuesPasswortDto();
                abfrage.Email = this.email;
                abfrage.Token = this.Token;
                abfrage.PasswortNeu = this.Passwort1;
                
                BenutzerServiceProxy service = new BenutzerServiceProxy();
                ResultDto result = await service.SetChangeBenutzerPasswort(abfrage).ConfigureAwait(true);

                if (result.Succsessful)
                {
                    await this.navigation.PopAsync().ConfigureAwait(true);
                }
                else
                {
                    //TO-DO Messagebox anzeigen
                }
            }
            else
            {
                //To-Do Passwort nicht gleich zeigen
            }
        }
    }
}
