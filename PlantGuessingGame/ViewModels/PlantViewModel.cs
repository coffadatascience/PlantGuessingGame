using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PlantGuessingGame.DataModels;
using System.Collections.Generic;
using PlantGuessingGame.Interfaces;

namespace PlantGuessingGame.ViewModels
{

    /// <summary>
    /// view model for plant
    /// </summary>
    public class PlantViewModel : INotifyPropertyChanged
    {

        private Plant _selectedPlant;
        private readonly INavigationService _navigationService; // Assuming you have a navigation service to handle page navigation
        // The NavigateBackCommand to navigate back
        public ICommand NavigateBackCommand { get; set; }

        // The SelectedPlant property, which will hold the plant details.
        public Plant SelectedPlant
        {
            get { return _selectedPlant; }
            set
            {
                if (_selectedPlant != value)
                {
                    _selectedPlant = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Plant> _plants;

        // Collection of plants that the View will bind to
        public ObservableCollection<Plant> Plants
        {
            get { return _plants; }
            set
            {
                _plants = value;
                OnPropertyChanged();
            }
        }

        // Command to add a new plant
        public ICommand AddPlantCommand { get; set; }

        // Constructor
        public PlantViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            NavigateBackCommand = new RelayCommand(NavigateBack);

            // Initialize the plant collection
            Plants = new ObservableCollection<Plant>();

            // Initialize the AddPlantCommand
            AddPlantCommand = new RelayCommand(AddPlant);

            // Add plants on initialization
            AddPlant();
        }

        // Method to add a plant to the collection
        private void AddPlant()
        {
            // Sample plants with Dutch names as common names and full botanical information
            var plantsToAdd = new List<Plant>
    {
        new Plant("Nandina", "Nandina", "domestica", "Heavenly Bamboo", "A popular ornamental shrub with beautiful red berries.", "path_to_picture.jpg"),
        new Plant("HaagBeuk", "Carpinus", "betulus", "European Hornbeam", "A tree often used for hedging, with a dense, narrow crown.", "path_to_picture.jpg"),
        new Plant("BeukHaag", "Carpinus", "betulus", "European Hornbeam", "A tree commonly used for hedges with small, serrated leaves.", "path_to_picture.jpg"),
        new Plant("Hortensia", "Hydrangea", "macrophylla", "Bigleaf Hydrangea", "A flowering shrub with large, colorful blooms.", "path_to_picture.jpg"),
        new Plant("Plataan", "Platanus", "acerifolia", "London Plane", "A large deciduous tree with exfoliating bark.", "path_to_picture.jpg"),
        new Plant("Appeltree", "Malus", "domestica", "Apple Tree", "A deciduous tree known for producing apples.", "path_to_picture.jpg"),
        new Plant("Els", "Alnus", "glutinosa", "Black Alder", "A tree that thrives in wet soils and has a dark bark.", "path_to_picture.jpg"),
        new Plant("Tulip", "Tulipa", "spp.", "Tulip", "A bulbous spring-flowering plant, known for its vibrant flowers.", "path_to_picture.jpg"),
        new Plant("Narcis", "Narcissus", "spp.", "Daffodil", "A spring perennial with trumpet-shaped flowers.", "path_to_picture.jpg"),
        new Plant("Korkus", "Quercus", "robur", "English Oak", "A large deciduous tree known for its strong wood and acorns.", "path_to_picture.jpg"),
        new Plant("Aardbei", "Fragaria", "x ananassa", "Strawberry", "A low-growing plant with sweet, red, edible fruit.", "path_to_picture.jpg")
    };

            // Add each plant to the collection
            foreach (var plant in plantsToAdd)
            {
                Plants.Add(plant);
            }
        }



        // Method to handle the logic of navigating back
        private void NavigateBack()
        {
            // Call the navigation service to navigate back
            _navigationService.GoBack();
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
