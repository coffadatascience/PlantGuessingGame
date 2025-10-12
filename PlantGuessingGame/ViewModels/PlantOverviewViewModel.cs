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
        /// local selected plant variable
        /// </summary>
        private Plant selectedPlant;

        /// <summary>
        /// observable collection to display list of plants (private)
        /// </summary>
        private ObservableCollection<Plant> plants = new ObservableCollection<Plant>();

        /// <summary>
        /// Ilist for Plant types for the combo box
        /// </summary>
        private ObservableCollection<Plant> allPlants;

        /// <summary>
        /// constant for all types
        /// </summary>
        private const string AllPlantTypes = "All";

        /// <summary>
        /// selected plant type
        /// </summary>
        private string selectedPlantType;

        /// <summary>
        /// Ilist for plant types for the combo box
        /// --> we use an Ilist of strings so "All can also be part of it"
        /// </summary>
        private IList<string> plantTypes;

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
                ((RelayCommand)DeleteCommand).RaiseCanExecuteChanged();


            }
        }

        /// <summary>
        /// changes plant type placed filter
        /// </summary>
        public string? SelectedPlantType
        {
            get => selectedPlantType;
            set
            {
                //set
                SetProperty(ref selectedPlantType, value);

                //call the filter method
                plants.Clear();

                //filter the items
                foreach (var item in allPlants)
                {
                    //check if the selected medium is all or the same as the item
                    if (string.IsNullOrWhiteSpace(selectedPlantType) ||
                        selectedPlantType == "All" ||
                        selectedPlantType == item.PlantType.ToString())
                    {
                        plants.Add(item);
                    }
                }
            }

        }

        /// <summary>
        /// public property for the selected plantType
        /// --> this property is used to filter the items
        /// note that the set method calls the OnPropertyChanged method
        /// </summary>
        public IList<string> PlantTypes
        {
            get { return plantTypes; }
            set
            {
                //set the value
                SetProperty(ref plantTypes, value); 

                //call the filter method
                plants.Clear();

                //filter the items
                foreach (var item in allPlants)
                {
                    //check if the selected medium is all or the same as the item
                    if (string.IsNullOrWhiteSpace(selectedPlantType) ||
                        selectedPlantType == "All" ||
                        selectedPlantType == item.PlantType.ToString())
                    {
                        plants.Add(item);
                    }
                }
            }
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
        /// sort command
        /// </summary>
        public ICommand SortPlantListCommand { get; set; }

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
            //sort command
            SortPlantListCommand = new RelayCommand(SortPlantList);

            // Add plants on initialization
            _ = PopulateDataAsync();
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


        /// <summary>
        /// Function to sort command
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void SortPlantList()
        {
            // Sort the plants by CommonName
            var sortedPlants = Plants.OrderBy(p => p.CommonName).ToList();

            // Clear the existing collection
            Plants.Clear();

            // Re-add the sorted items
            foreach (var plant in sortedPlants)
            {
                Plants.Add(plant);
            }
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
            plantTypes = new ObservableCollection<string>
            {
                AllPlantTypes
            };

            //add the rest of the items
            foreach (var itemType in _dataService.GetItemTypes())
            {
                plantTypes.Add(itemType.ToString());
            }

            //set selected phylum
            selectedPlantType = plantTypes[0];

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
