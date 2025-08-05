using Microsoft.UI.Xaml.Media.Imaging;
using PlantGuessingGame.DataModels;
using PlantGuessingGame.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlantGuessingGame.ViewModels
{
    public class PlantProblemsViewModel : BindableBase
    {

        #region private variables

        // Services
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;

        // Selected item ID
        private int _selectedItemId = -1;

        // Dirty flag
        private bool _isDirty;

        // Observable collection of plant problems
        private ObservableCollection<PlantProblem> _plantProblems = new ObservableCollection<PlantProblem>();

        // Selected plant problem (for ComboBox)
        private PlantProblem _selectedPlantProblem;

        // Fields for selected plant problem details
        private int _selectedProblemId;
        private string _selectedName;
        private string _selectedDescription;
        private string _selectedSymptoms;
        private string _selectedCauses;
        private string _selectedSolutions;
        private string _selectedSeverity;
        private string _selectedCategory;

        #endregion


        #region public variables

        //image source collection of images
        public ObservableCollection<BitmapImage> SelectedPlantImages = new ObservableCollection<BitmapImage>();

        // Public properties for binding
        public ObservableCollection<PlantProblem> PlantProblems
        {
            get => _plantProblems;
            set => SetProperty(ref _plantProblems, value);
        }

        public PlantProblem SelectedPlantProblem
        {
            get => _selectedPlantProblem;
            set
            {
                if (SetProperty(ref _selectedPlantProblem, value))
                {
                    // Update all selected fields when selection changes
                    UpdateSelectedProblemFields();
                }
            }
        }

        public int SelectedProblemId
        {
            get => _selectedProblemId;
            set => SetProperty(ref _selectedProblemId, value);
        }

        public string SelectedName
        {
            get => _selectedName;
            set => SetProperty(ref _selectedName, value);
        }

        public string SelectedDescription
        {
            get => _selectedDescription;
            set => SetProperty(ref _selectedDescription, value);
        }

        public string SelectedSymptoms
        {
            get => _selectedSymptoms;
            set => SetProperty(ref _selectedSymptoms, value);
        }

        public string SelectedCauses
        {
            get => _selectedCauses;
            set => SetProperty(ref _selectedCauses, value);
        }

        public string SelectedSolutions
        {
            get => _selectedSolutions;
            set => SetProperty(ref _selectedSolutions, value);
        }

        public string SelectedSeverity
        {
            get => _selectedSeverity;
            set => SetProperty(ref _selectedSeverity, value);
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        public bool IsDirty
        {
            get => _isDirty;
            set => SetProperty(ref _isDirty, value);
        }

        public ICommand NavigateBackCommand { get; }



        #endregion



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="dataService"></param>
        public PlantProblemsViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            PlantProblems = new ObservableCollection<PlantProblem>();
            NavigateBackCommand = new RelayCommand(NavigateBack);
        }

        /// <summary>
        /// Helper to update all selected fields when selection changes
        /// </summary>
        private void UpdateSelectedProblemFields()
        {
            SelectedProblemId = _selectedPlantProblem?.Id ?? 0;
            SelectedName = _selectedPlantProblem?.Name ?? string.Empty;
            SelectedDescription = _selectedPlantProblem?.Description ?? string.Empty;
            SelectedSymptoms = _selectedPlantProblem?.Symptoms ?? string.Empty;
            SelectedCauses = _selectedPlantProblem?.Causes ?? string.Empty;
            SelectedSolutions = _selectedPlantProblem?.Solutions ?? string.Empty;
            SelectedSeverity = _selectedPlantProblem?.Severity ?? string.Empty;
            SelectedCategory = _selectedPlantProblem?.Category ?? string.Empty;
            //load related images to problem
            ShowImages();

        }

        /// <summary>
        /// Populate data
        /// </summary>
        /// <param name="dataService"></param>
        /// <returns></returns>
        private async Task PopulateDataAsync(IDataService dataService)
        {
            PlantProblems.Clear();
            var problems = await dataService.GetProblemsForPlantAsync(_selectedItemId);
            foreach (var item in problems)
            {
                PlantProblems.Add(item);
            }
            if (PlantProblems.Count > 0)
            {
                //set current problem
                SelectedPlantProblem = PlantProblems[0];
                //load images for the problem (if any)
                ShowImages();
            }
            else
            {
                SelectedPlantProblem = null;
                UpdateSelectedProblemFields();
            }
        }

        /// <summary>
        /// Navigation
        /// </summary>
        private void NavigateBack()
        {
            _navigationService.GoBack();
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="selectedItemId"></param>
        /// <returns></returns>
        public async Task InitializeItemPlantProblemsDataAsync(int selectedItemId)
        {
            _selectedItemId = selectedItemId;
            if (_selectedItemId >= 0)
            {
                try
                {
                    await PopulateDataAsync(_dataService);
                }
                catch
                {
                    // Handle error (e.g., log, show message)
                }
            }
            IsDirty = false;
        }



        /// <summary>
        /// command that retrieves and show the relevant images for the selected problems
        /// </summary>
        private async void ShowImages()
        {


            try
            {

                //clear SelectedPlantImages
                SelectedPlantImages.Clear();

                //---------------
                // add to observeable collection
                //---------------
                // 1. Retrieve the image bytes from the DB
                var ListImageBytes = await _dataService.GetImagesTablePlantProblemsForParentAsync(_selectedProblemId);

                //check if we have anything
                if (ListImageBytes == null || ListImageBytes.Count == 0)
                {
                    //MessageBox.Show("No image found for the specified ID.");
                    return;
                }

                //loop the list
                foreach (var ImageBytes in ListImageBytes)
                {
                    //add to observeable collection
                    await AddImageAsync(ImageBytes);
                }
                //---------------


 

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving or opening image: {ex.Message}");
            }
        }

        /// <summary>
        /// adds image
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        public async Task AddImageAsync(byte[] imageBytes)
        {
            var bitmapImage = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage();
            using (var stream = new Windows.Storage.Streams.InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(imageBytes.AsBuffer());
                stream.Seek(0);
                await bitmapImage.SetSourceAsync(stream);
            }
            SelectedPlantImages.Add(bitmapImage);
        }


    }
}
