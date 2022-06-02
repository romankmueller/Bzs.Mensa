using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Bzs.Mensa.App.Services;
using Bzs.Mensa.Shared.DataTransferObjects;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;

namespace Bzs.Mensa.App.ViewModels
{
    /// <summary>
    /// Represents a class selection view model.
    /// </summary>
    public sealed class KlassenAuswahlViewModel : ObservableObject
    {
        private INavigation navigation;
        private bool inProgress;
        private RelayCommand refreshCommand;
        private KlasseEditDto selectedKlasse;

        /// <summary>
        /// Initializes a new instance of the <see cref="KlassenAuswahlViewModel" /> class.
        /// </summary>
        public KlassenAuswahlViewModel()
        {
            this.KlasseItems = new ObservableCollection<KlasseEditDto>();

            this.RefreshKlasseItemsAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KlassenAuswahlViewModel" /> class.
        /// </summary>
        /// <param name="navigation">The navigation.</param>
        public KlassenAuswahlViewModel(INavigation navigation)
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
        /// Gets the refresh command.
        /// </summary>
        public RelayCommand RefreshCommand
        {
            get
            {
                return this.refreshCommand ?? (this.refreshCommand = new RelayCommand(this.ExecuteRefreshCommand));
            }
        }

        /// <summary>
        /// Gets the class items.
        /// </summary>
        public ObservableCollection<KlasseEditDto> KlasseItems { get; private set; }

        /// <summary>
        /// Gets or sets the selected class.
        /// </summary>
        public KlasseEditDto SelectedKlasse
        {
            get
            {
                return this.selectedKlasse;
            }

            set
            {
                if (this.SetProperty(ref this.selectedKlasse, value))
                {
                    this.OnChangedSelectedKlasse();
                }
            }
        }

        /// <summary>
        /// Refreshes the class items.
        /// </summary>
        /// <returns>The task.</returns>
        private async Task RefreshKlasseItemsAsync()
        {
            if (!this.InProgress)
            {
                this.InProgress = true;
                KlasseServiceProxy service = new KlasseServiceProxy();
                List<KlasseEditDto> data = await service.GetKlassenAsync().ConfigureAwait(true);
                Application.Current.Dispatcher?.BeginInvokeOnMainThread(() =>
                {
                    this.KlasseItems.Clear();
                    if (data != null)
                    {
                        this.KlasseItems = new ObservableCollection<KlasseEditDto>(data);
                    }
                });

                this.InProgress = false;
            }
        }

        /// <summary>
        /// Executes the refresh command.
        /// </summary>
        private async void ExecuteRefreshCommand()
        {
            await this.RefreshKlasseItemsAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Called when the selected class changed.
        /// </summary>
        private async void OnChangedSelectedKlasse()
        {
            await this.navigation.PopAsync().ConfigureAwait(true);
        }
    }
}
