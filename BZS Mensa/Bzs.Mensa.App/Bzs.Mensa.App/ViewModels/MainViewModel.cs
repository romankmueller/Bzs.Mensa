using Bzs.Mensa.App.Views;
using Bzs.Mensa.Shared.DataTransferObjects;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        public MainViewModel()
        {
            this.Items = new ObservableCollection<EssenEditDto>();
            EssenEditDto essen1 = new EssenEditDto();
            essen1.Id = new System.Guid();
            essen1.Essen = true;
            essen1.Datum = System.DateTime.Today;
            this.Items.Add(essen1);

            EssenEditDto essen2 = new EssenEditDto();
            essen2.Id = new System.Guid();
            essen2.Essen = true;
            essen2.Datum = System.DateTime.Today.AddDays(1);
            this.Items.Add(essen2);
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
        public ObservableCollection<EssenEditDto> Items { get; }

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
