﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Bzs.Mensa.App.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    public sealed class LoginViewModel : ObservableObject
    {
        private INavigation navigation;
        private bool inProgress;
        private string email;
        private string passwort;
        private bool anmeldedatenMerken;
        private RelayCommand anmeldenCommand;
        private RelayCommand registrierenCommand;
        private RelayCommand passwortVergessenCommand;

        public LoginViewModel()
        {
        }

        public LoginViewModel(INavigation navigation)
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
        }

        /// <summary>
        /// Called when the password changed.
        /// </summary>
        private void OnChangedPassword()
        {
        }

        private bool CanExecuteAnmeldenCommand()
        {
            return !this.InProgress && !string.IsNullOrEmpty(this.Email);
        }

        private async void ExecuteAnmeldenCommand()
        {
            if (this.CanExecuteAnmeldenCommand())
            {
                await this.AnmeldenAsync().ConfigureAwait(true);
            }
        }

        private bool CanExecuteRegistrierenCommand()
        {
            return !this.InProgress;
        }

        private async void ExecuteRegistrierenCommand()
        {
            if (this.CanExecuteRegistrierenCommand())
            {
                await this.navigation.PushAsync(new Register()).ConfigureAwait(true);
            }
        }

        private bool CanExecutePasswortVergessenCommand()
        {
            return !this.InProgress;
        }

        private async void ExecutePasswortVergessenCommand()
        {
            if (this.CanExecutePasswortVergessenCommand())
            {
                await this.navigation.PushAsync(new PwVergessen()).ConfigureAwait(true);
            }
        }

        private async Task AnmeldenAsync()
        {
            this.InProgress = true;
            try
            {

                await this.navigation.PopAsync().ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                this.InProgress = false;
            }
        }
    }
}
