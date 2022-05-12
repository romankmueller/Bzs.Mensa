using Bzs.Mensa.App.Services;
using Bzs.Mensa.App.Views;
using Bzs.Mensa.Shared.DataTransferObjects;
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
        private INavigation navigation;

        private RelayCommand sendenCommand;
        private string email;

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

        public RelayCommand Senden
        {
            get
            {
                return this.sendenCommand ?? (this.sendenCommand = new RelayCommand(this.ExecuteSendenCommand));
            }
        }

        private async void ExecuteSendenCommand()
        {
            BenutzerServiceProxy service = new BenutzerServiceProxy();
            ResultDto result = await service.SendTokenEmail(this.email).ConfigureAwait(true);
            if (result.Succsessful)
            {
                await this.navigation.PopAsync();
                await this.navigation.PushAsync(new NeuesPw()).ConfigureAwait(true);
            }
        }
    }
}