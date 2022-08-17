using Bzs.Mensa.App.Services;
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
        private async Task RefreshItemsAsync()
        {
            EssenServiceProxy proxy = new EssenServiceProxy();
            EssenUebersichtDto data = null;
            try 
            { 
                data = await proxy.GetEssenUebersichtAsync(new Guid("BEB1D92A-44BC-443D-92EE-2CCE50F6A902")).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            foreach(EssenWocheDto item in data.EssenWoche)
            {
                this.Items.Add(item);
            }
        }

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
