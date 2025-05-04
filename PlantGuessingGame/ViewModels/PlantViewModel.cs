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
    public class PlantViewModel : BindableBase
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

        #endregion


        #region constructors

        /// <summary>
        /// Constructor
        /// --> gets navigation service from DI
        /// --> preps command
        /// --> add list of default plant information (we will make these collection later in a data service)
        /// </summary>
        /// <param name="navigationService"></param>
        public PlantViewModel(INavigationService navigationService)
        {
            //set nav
            _navigationServices = navigationService;

            // Initialize the plant collection
            Plants = [];

            //command back
            NavigateBackCommand = new RelayCommand(NavigateBack);
            // Initialize the AddPlantCommand
            AddEditCommand = new RelayCommand(AddPlant);
            //delete command
            DeleteCommand = new RelayCommand(async () => await DeleteItemAsync(), CanDeleteItem);

            // Add plants on initialization
            AddPlant();
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
