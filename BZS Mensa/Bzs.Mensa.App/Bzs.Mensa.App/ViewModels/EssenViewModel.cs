using Bzs.Mensa.App.Services;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a meal view model.
    /// </summary>
    public sealed class EssenViewModel : ObservableObject
    {
        private readonly IEssenMenuService essenMenuService;
        private INavigation navigation;
        private RelayCommand backCommand;
        private DateTime datum;
        private string menuText;

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenViewModel" /> class.
        /// </summary>
        public EssenViewModel()
        {
            this.essenMenuService = new EssenMenuServiceProxy();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public EssenViewModel(INavigation navigation)
            : this()
        {
            this.navigation = navigation;
            this.datum = DateTime.Today;
            this.RefreshEssenAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Gets the back command.
        /// </summary>
        public RelayCommand BackCommand
        {
            get
            {
                return this.backCommand ?? (this.backCommand = new RelayCommand(this.ExecuteBackCommand));
            }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Datum
        {
            get
            {
                return this.datum;
                
            }

            set
            {
                if (this.SetProperty(ref this.datum, value))
                {
                    this.OnChangedDatum();
                }
            }
        }

        public string DatumString
        {
            get
            {
                return this.Datum.ToString("dd MMM yyyy");
            }
        }

        /// <summary>
        /// Gets the menu text.
        /// </summary>
        public string MenuText
        {
            get
            {
                return this.menuText;
            }

            private set
            {
                this.SetProperty(ref this.menuText, value);
            }
        }

        /// <summary>
        /// Called when the date changed.
        /// </summary>
        private void OnChangedDatum()
        {
            this.RefreshEssenAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Executes the back command.
        /// </summary>
        private async void ExecuteBackCommand()
        {
            await this.navigation.PopAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Refreshes the meal.
        /// </summary>
        /// <returns>The task.</returns>
        private async Task RefreshEssenAsync()
        {
            EssenMenuRequestDto request = new EssenMenuRequestDto(this.Datum);
            EssenMenuEditDto data = await this.essenMenuService.EssenMenuAsync(request).ConfigureAwait(true);
            Application.Current.Dispatcher?.BeginInvokeOnMainThread(() =>
            {
                this.MenuText = data?.MenuBeschreibung ?? string.Empty;
            });
        }
    }
}
