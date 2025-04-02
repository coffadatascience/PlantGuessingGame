using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PlantGuessingGame.DataModels;

namespace PlantGuessingGame.ViewModels
{

    /// <summary>
    /// view model for plant
    /// </summary>
    public class PlantViewModel : INotifyPropertyChanged
    {

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
        public PlantViewModel()
        {
            // Initialize the plant collection
            Plants = new ObservableCollection<Plant>();

            // Initialize the AddPlantCommand
            AddPlantCommand = new RelayCommand(AddPlant);
        }

        // Method to add a plant to the collection
        private void AddPlant()
        {
            // Sample plant for demonstration purposes
            var newPlant = new Plant("Rosaceae", "Rosa", "gallica", "French Rose", "A beautiful and fragrant rose.", "path_to_picture.jpg");
            Plants.Add(newPlant);
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
