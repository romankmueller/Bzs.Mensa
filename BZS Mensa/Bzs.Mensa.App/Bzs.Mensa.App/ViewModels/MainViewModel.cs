﻿using Bzs.Mensa.App.Services;
using Bzs.Mensa.App.Views;
using Bzs.Mensa.Shared.DataTransferObjects;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
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
        private EssenWocheDto selectedItem;
        private RelayCommand anmeldenCommand;
        private RelayCommand abmeldenCommand;
        private Guid benutzerId = new Guid("AF02063C-EE6A-4C82-A15D-40A121B9315B");
        private string daumenRunter = String.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        public MainViewModel()
        {
            this.Items = new ObservableCollection<EssenWocheDto>();
            this.RefreshItemsAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public MainViewModel(INavigation navigation)
            :this()
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
        /// Gets the items.
        /// </summary>
        public ObservableCollection<EssenWocheDto> Items { get; }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        public EssenWocheDto SelectedItem
        {
            get
            {
                return this.selectedItem;
            }

            set
            {
                this.selectedItem = value;
            }
        }


        /// <summary>
        /// Gets the login command.
        /// </summary>
        public RelayCommand AnmeldenCommand
        {
            get
            {
                return this.anmeldenCommand ?? (this.anmeldenCommand = new RelayCommand(this.ExecuteAnmeldenCommand));
            }
        }

        /// <summary>
        /// Gets the logout command.
        /// </summary>
        public RelayCommand AbmeldenCommand
        {
            get
            {
                return this.abmeldenCommand ?? (this.abmeldenCommand = new RelayCommand(this.ExecuteAbmeldenCommand));
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

        /// <summary>
        /// Executes the login command.
        /// </summary>
        private async void ExecuteAnmeldenCommand()
        {
            EssenEditDto essenEditDto = new EssenEditDto();
            essenEditDto.Essen = true;
            essenEditDto.Datum = this.selectedItem.Datum;
            essenEditDto.BenutzerId = benutzerId;
            essenEditDto.DatumIso = this.selectedItem.DatumIso;
            EssenServiceProxy proxy = new EssenServiceProxy();
            ResultDto result = await proxy.SaveEssenAsync(essenEditDto);
            if (result.Succsessful)
            {
                this.selectedItem.Angemeldet = true;
            }
        }



        /// <summary>
        /// Executes the logout command.
        /// </summary>
        private async void ExecuteAbmeldenCommand()
        {
            EssenEditDto essenEditDto = new EssenEditDto();
            essenEditDto.Essen = false;
            essenEditDto.BenutzerId = benutzerId;
            essenEditDto.Datum = selectedItem.Datum;
            EssenServiceProxy proxy = new EssenServiceProxy();
            ResultDto result = await proxy.DeleteEssenAsync1(essenEditDto);
            if (result.Succsessful)
            {
                this.selectedItem.Angemeldet = false;
            }
        }

        /// <summary>
        /// Refreshes the items.
        /// </summary>
        /// <returns>The task.</returns>
        private async Task RefreshItemsAsync()
        {
            EssenServiceProxy proxy = new EssenServiceProxy();
            EssenUebersichtDto data = null;
            try
            {
                data = await proxy.GetEssenUebersichtAsync(benutzerId).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            foreach (EssenWocheDto item in data.EssenWoche)
            {
                this.Items.Add(item);
            }
        } 
    }
}
