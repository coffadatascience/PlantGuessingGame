using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PlantGuessingGame.DataModels;
using System.Collections.Generic;
using PlantGuessingGame.Interfaces;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Input;
using PlantGuessingGame.Enums;
using System.Linq;
using System;

namespace PlantGuessingGame.ViewModels
{

    /// <summary>
    /// view model for plant
    /// </summary>
    public class PlantOverviewViewModel : BindableBase
    {


        #region private variables


        /// <summary>
        /// constant for all phyla
        /// </summary>
        private const string AllPhyla = "All";

        /// <summary>
        /// local selected plant variable
        /// </summary>
        private Plant selectedPlant;

        /// <summary>
        /// selected phylum
        /// </summary>
        private string selectedPhylum;

        /// <summary>
        /// observable collection to display list of plants (private)
        /// </summary>
        private ObservableCollection<Plant> plants = new ObservableCollection<Plant>();

        /// <summary>
        /// Ilist for Plant types for the combo box
        /// </summary>
        private ObservableCollection<Plant> allPlants;

        /// <summary>
        /// Ilist for phyla for the combo box
        /// </summary>
        private IList<string> phyla;

        #endregion

        #region "Filtering collections"

        /// <summary>
        /// observable collection of plant types that we can use for the combo box
        /// </summary>
        public ObservableCollection<PlantType> PlantTypes { get; } =
            new ObservableCollection<PlantType>(Enum.GetValues(typeof(PlantType)).Cast<PlantType>());

        private PlantType? _selectedPlantType;
        public PlantType? SelectedPlantType
        {
            get => _selectedPlantType;
            set => SetProperty(ref _selectedPlantType, value);
        }

        /// <summary>
        /// filtered collectoin
        /// </summary>
        public ObservableCollection<Plant> FilteredPlants { get; set; } = new ObservableCollection<Plant>();

        /// <summary>
        /// command to filter
        /// </summary>
        public ICommand FilterPlantsCommand { get; }

        /// <summary>
        /// filter list function for command
        /// </summary>
        /// <param name="parameter"></param>
        private void OnFilterPlants(object parameter)
        {
            var selectedType = SelectedPlantType ?? PlantType.Unknown;
            var filtered = Plants.Where(p => p.PlantType == selectedType).ToList();
            FilteredPlants.Clear();
            foreach (var plant in filtered)
                FilteredPlants.Add(plant);
        }

        #endregion

        #region public variables

        /// <summary>
        /// Collection of plants that the View will bind to
        /// </summary>
        public ObservableCollection<Plant> Plants
        {
            get { return plants; }
            set
            {
                plants = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectedPlant property, which will hold the plant details.
        /// </summary>
        public Plant SelectedPlant
        {
            get => selectedPlant;
            set
            {
                //sets property
                SetProperty(ref selectedPlant, value);

                // Adjust a relay Icommand (in this case we make a relay command delete for the selected item)
                // --> note that as such the button is prepped with what is selected
                // --> the presence of a selection determines if the deleted button is visible
                // --> Different than in the constructor where Delecommand is initialized, here the DeleteCommand is parsed to a RelayCommand Class and then the function
                //     Raise Can Execute Changes is ran, leading to the button being able to execute or not

                // --> 20250102 Note that this doesnt work because the Interface ICommand does not have the method RaiseCanExecuteChanged
                //     This interface has been recently changed and now works different (with the eventhandler CanExecuteChanged)
                ((RelayCommand)DeleteCommand).RaiseCanexecuteChanged();


            }
        }

        /// <summary>
        /// public property for the selected phyla
        /// --> this property is used to filter the items
        /// note that the set method calls the OnPropertyChanged method
        /// </summary>
        public IList<string> Phyla
        {
            get { return phyla; }
            set { SetProperty(ref phyla, value); }
        }

        /// <summary>
        /// Command to add a new plant
        /// </summary>
        public ICommand AddEditCommand { get; set; }

        /// <summary>
        /// The NavigateBackCommand to navigate back
        /// </summary>
        public ICommand NavigateBackCommand { get; set; }

        /// <summary>
        /// command for delete
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// public property for the selected phylum
        /// </summary>
        public string SelectedPhylum
        {
            get
            {
                return selectedPhylum;
            }
            set
            {
                //set the value
                SetProperty(ref selectedPhylum, value);

                //call the filter method
                plants.Clear();

                //filter the items
                foreach (var item in allPlants)
                {
                    //check if the selected medium is all or the same as the item
                    if (string.IsNullOrWhiteSpace(selectedPhylum) ||
                        selectedPhylum == "All" ||
                        selectedPhylum == item.PhylumInfo.Name)
                    {
                        plants.Add(item);
                    }
                }
            }
        }

        #endregion


        #region constructors

        /// <summary>
        /// Constructor
        /// --> gets navigation service from DI
        /// --> preps command
        /// --> add list of default plant information (we will make these collection later in a data service)
        /// </summary>
        /// <param name="navigationService"></param>
        public PlantOverviewViewModel(INavigationService navigationService, IDataService dataService)
        {
            //set nav
            _navigationServices = navigationService;
            _dataService = dataService;

            // Initialize the plant collection
            Plants = [];

            //command back
            NavigateBackCommand = new RelayCommand(NavigateBack);
            // Initialize the AddPlantCommand
            AddEditCommand = new RelayCommand(AddPlant);
            //delete command
            DeleteCommand = new RelayCommand(async () => await DeleteItemAsync(), CanDeleteItem);

            //command to filter base don plant type (this is a command with a parameter, and uses a different relay command class)
            FilterPlantsCommand = new RelayCommand<object>(OnFilterPlants);

            //20250405 --> replace this for a population of the local items using the data serice
            // ---> we also do the intial data population via the service (not in the viewmodel)

            // Add plants on initialization
            PopulateDataAsync();
        }

        #endregion

        #region events

        /// <summary>
        /// event for double tapping the list view
        /// --> note here we have an event, in the ViewModel that we can now link via X:Bind to the ListView action
        /// --> Its binding is still loose, but we can now link the event to the ListView
        /// --> the ViewModel is now linked to the View but does not know about the View (dependency is minimal) 
        ///     The view in this case depends on the ViewModel, but the ViewModel does not depend on the View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListViewDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //add or edit item
            AddOrEditItem();
        }

        #endregion

        #region procedures


        /// <summary>
        /// Method to add a plant to the collection
        /// --> Change this for an edit, or an add but awaits the return info
        /// JCO --> we can create a relay command here that is passed with an update of the screen via an delegate
        /// </summary>
        private void AddPlant()
        {
            //rather than having here a mockup add, we will get the selected item and navigate to the items details pages
            var selectedItemId = -1;
            if (selectedPlant != null)
            {
                selectedItemId = selectedPlant.Id;
            }

            //navigate to the edit page by passing the selected item
            _navigationServices.NavigateTo("PlantDetailPage", selectedItemId);
        }

        /// <summary>
        /// retrieves list of plants from data service
        /// </summary>
        /// <returns></returns>
        private async Task PopulateDataAsync()
        {

            //clear the items
            plants.Clear();
            foreach (var item in await _dataService.GetItemsAsync())
            {
                plants.Add(item);
            }

            //new observable collection with all items
            allPlants = new ObservableCollection<Plant>(plants);

            //create a list with mediums and add "All" to it
            phyla = new ObservableCollection<string>
            {
                AllPhyla
            };

            //add the rest of the items
            foreach (var itemType in _dataService.GetPhyla())
            {
                phyla.Add(itemType.ToString());
            }

            //set selected phylum
            SelectedPhylum = Phyla[0];

        }

        /// <summary>
        /// Method to handle the logic of navigating back
        /// </summary>
        private void NavigateBack()
        {
            // Call the navigation service to navigate back
            _navigationServices.GoBack();
        }

        /// <summary>
        /// INotifyPropertyChanged implementation
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// async method to delete item (replace above sync method)
        /// </summary>
        /// <returns></returns>
        private async Task DeleteItemAsync()
        {
            //call the data service to delete the item
            await _dataService.DeleteItemAsync(SelectedPlant);
            //remove the item from the list
            allPlants.Remove(SelectedPlant);
            plants.Remove(SelectedPlant);
        }

        /// <summary>
        /// check if we can remove the item
        /// </summary>
        /// <returns></returns>
        private bool CanDeleteItem() => selectedPlant != null;


        /// <summary>
        /// add or edit (test function to add an item)
        /// </summary>
        public void AddOrEditItem()
        {

            ////test for editing items
            //const int startingItemCount = 3;
            //var newItem = new MediaItem
            //{
            //    Id = startingItemCount + additionalItemCount,
            //    Location = LocationType.InCollection,
            //    MediaType = ItemType.Music,
            //    MediumInfo = new Medium { Id = 1, MediaType = ItemType.Music, Name = "CD" },
            //    Name = $"CD {additionalItemCount}"
            //};

            ////add new item
            //allItems.Add(newItem);
            ////add item also to item list
            //items.Add(newItem);
            ////count
            //additionalItemCount++;


            //rather than having here a mockup add, we will get the selected item and navigate to the items details pages
            var selectedItemId = -1;
            if (selectedPlant != null)
            {
                selectedItemId = selectedPlant.Id;
            }

            //navigate to the edit page by passing the selected item (therefore the item detail page should process the selected item and load the content)
            _navigationServices.NavigateTo("PlantDetailPage", selectedItemId);

        }

        #endregion
    }





}
