using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PlantGuessingGame.DataModels;
using System.Collections.Generic;
using PlantGuessingGame.Interfaces;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Input;

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
            // Sample plants with Dutch names as common names and full botanical information
            var plantsToAdd = new List<Plant>
            {
                new Plant(0, "Nandina", "Nandina", "domestica", "Heavenly Bamboo", "A popular ornamental shrub with beautiful red berries.", "path_to_picture.jpg"),
                new Plant(1, "HaagBeuk", "Carpinus", "betulus", "European Hornbeam", "A tree often used for hedging, with a dense, narrow crown.", "path_to_picture.jpg"),
                new Plant(2,"BeukHaag", "Carpinus", "betulus", "European Hornbeam", "A tree commonly used for hedges with small, serrated leaves.", "path_to_picture.jpg"),
                new Plant(3, "Hortensia", "Hydrangea", "macrophylla", "Bigleaf Hydrangea", "A flowering shrub with large, colorful blooms.", "path_to_picture.jpg"),
                new Plant(4,"Plataan", "Platanus", "acerifolia", "London Plane", "A large deciduous tree with exfoliating bark.", "path_to_picture.jpg"),
                new Plant(6,"Appeltree", "Malus", "domestica", "Apple Tree", "A deciduous tree known for producing apples.", "path_to_picture.jpg"),
                new Plant(7, "Els", "Alnus", "glutinosa", "Black Alder", "A tree that thrives in wet soils and has a dark bark.", "path_to_picture.jpg"),
                new Plant(8, "Tulip", "Tulipa", "spp.", "Tulip", "A bulbous spring-flowering plant, known for its vibrant flowers.", "path_to_picture.jpg"),
                new Plant(9, "Narcis", "Narcissus", "spp.", "Daffodil", "A spring perennial with trumpet-shaped flowers.", "path_to_picture.jpg"),
                new Plant(10, "Korkus", "Quercus", "robur", "English Oak", "A large deciduous tree known for its strong wood and acorns.", "path_to_picture.jpg"),
                new Plant(11, "Aardbei", "Fragaria", "x ananassa", "Strawberry", "A low-growing plant with sweet, red, edible fruit.", "path_to_picture.jpg")
            };

            // Add each plant to the collection
            foreach (var plant in plantsToAdd)
            {
                Plants.Add(plant);
            }
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
