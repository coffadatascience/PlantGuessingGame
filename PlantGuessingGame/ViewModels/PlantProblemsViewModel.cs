using Microsoft.UI.Xaml.Media.Imaging;
using PlantGuessingGame.DataModels;
using PlantGuessingGame.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Windows.Storage.Pickers;
using Windows.Storage;

namespace PlantGuessingGame.ViewModels
{
    public class PlantProblemsViewModel : BindableBase
    {
        #region private variables
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;

        private int _selectedItemId = -1;
        private bool _isDirty;

        private ObservableCollection<PlantProblem> _plantProblems = new ObservableCollection<PlantProblem>();
        private PlantProblem _selectedPlantProblem;

        private int _selectedProblemId;
        private string _selectedName;
        private string _selectedDescription;
        private string _selectedSymptoms;
        private string _selectedCauses;
        private string _selectedSolutions;
        private string _selectedSeverity;
        private string _selectedCategory;

        private ICommand _navigateBackCommand;
        private ICommand _selectPreviousItemCommand;
        private ICommand _selectNextItemCommand;
        private ICommand _importImageCommand;

        #endregion

        #region public properties
        public ObservableCollection<BitmapImage> SelectedPlantImages { get; } = new ObservableCollection<BitmapImage>();

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
                    UpdateSelectedProblemFields();

                    // Inform command to reevaluate CanExecute so button enabled state updates
                    ((RelayCommand)_importImageCommand).RaiseCanExecuteChanged();


                    // Similarly you might want to raise CanExecuteChanged for other commands if they depend on selection
                    //((RelayCommand)_selectPreviousItemCommand).RaiseCanExecuteChanged();
                    //((RelayCommand)_selectNextItemCommand).RaiseCanExecuteChanged();

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

        public ICommand NavigateBackCommand => _navigateBackCommand ??= new RelayCommand(NavigateBack);

        public ICommand SelectPreviousItemCommand => _selectPreviousItemCommand ??= new RelayCommand(SelectPreviousItem, CanSelectPreviousItem);

        public ICommand SelectNextItemCommand => _selectNextItemCommand ??= new RelayCommand(SelectNextItem, CanSelectNextItem);

        public ICommand ImportImageCommand => _importImageCommand ??= new RelayCommand(async () => await ImportImageAsync(), CanImportImage);
        #endregion

        public PlantProblemsViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            PlantProblems = new ObservableCollection<PlantProblem>();
        }

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

            ShowImages();
        }

        private async Task PopulateDataAsync(IDataService dataService)
        {
            PlantProblems.Clear();
            var problems = await dataService.GetProblemsForPlantAsync(_selectedItemId);
            foreach (var item in problems)
                PlantProblems.Add(item);

            if (PlantProblems.Count > 0)
            {
                SelectedPlantProblem = PlantProblems[0];
                ShowImages();
            }
            else
            {
                SelectedPlantProblem = null;
                UpdateSelectedProblemFields();
            }
        }

        private void NavigateBack()
        {
            _navigationService.GoBack();
        }

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
                    // Handle errors accordingly
                }
            }
            IsDirty = false;
        }

        private async void ShowImages()
        {
            try
            {
                SelectedPlantImages.Clear();

                var imageBytesList = await _dataService.GetImagesTablePlantProblemsForParentAsync(_selectedProblemId);
                if (imageBytesList == null || imageBytesList.Count == 0) return;

                foreach (var imageBytes in imageBytesList)
                    await AddImageAsync(imageBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving or opening image: {ex.Message}");
            }
        }

        public async Task AddImageAsync(byte[] imageBytes)
        {
            var bitmapImage = new BitmapImage();
            using (var stream = new Windows.Storage.Streams.InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(imageBytes.AsBuffer());
                stream.Seek(0);
                await bitmapImage.SetSourceAsync(stream);
            }
            SelectedPlantImages.Add(bitmapImage);
        }

        private bool CanSelectPreviousItem()
        {
            if (PlantProblems == null || SelectedPlantProblem == null)
                return false;

            int currentIndex = PlantProblems.IndexOf(SelectedPlantProblem);
            return currentIndex > 0;
        }

        private bool CanSelectNextItem()
        {
            if (PlantProblems == null || SelectedPlantProblem == null)
                return false;

            int currentIndex = PlantProblems.IndexOf(SelectedPlantProblem);
            return currentIndex < PlantProblems.Count - 1;
        }

        private void SelectPreviousItem()
        {
            if (!CanSelectPreviousItem())
                return;

            int currentIndex = PlantProblems.IndexOf(SelectedPlantProblem);
            SelectedPlantProblem = PlantProblems[currentIndex - 1];
        }

        private void SelectNextItem()
        {
            if (!CanSelectNextItem())
                return;

            int currentIndex = PlantProblems.IndexOf(SelectedPlantProblem);
            SelectedPlantProblem = PlantProblems[currentIndex + 1];
        }

        private bool CanImportImage()
        {
            return SelectedPlantProblem != null;
        }

        private async Task ImportImageAsync()
        {
            if (SelectedPlantProblem == null)
                return;

            try
            {
                var picker = new FileOpenPicker
                {
                    ViewMode = PickerViewMode.Thumbnail,
                    SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                    // Note: Multiselect is not directly supported by FileOpenPicker in WinUI3;
                    // consider picking files one by one or using FolderPicker for folder selection instead.
                };
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".jpeg");
                picker.FileTypeFilter.Add(".png");
                picker.FileTypeFilter.Add(".bmp");
                picker.FileTypeFilter.Add(".gif");



                // Must initialize picker with Win32 window handle in WinUI3 Desktop apps:
                var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(App.CurrentWindow); // Assuming your App.Window is your MainWindow
                WinRT.Interop.InitializeWithWindow.Initialize(picker, windowHandle);


                var file = await picker.PickSingleFileAsync();
                if (file == null)
                    return; // user cancelled

                // Use path (if accessible), or fallback to stream or copy as needed
                var filePath = file.Path;

                await _dataService.AddItemImageTablePlantProblemAsync(SelectedProblemId, filePath);

                ShowImages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing image: {ex.Message}");
            }
        }

    }
}
