using PlantGuessingGame.DataModels;
using PlantGuessingGame.Enums;
using PlantGuessingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace PlantGuessingGame.ViewModels
{


    public class PlantDetailsViewModel : BindableBase
    {


        #region private fields

        /// <summary>
        /// Observable collections
        /// </summary>
        private ObservableCollection<string> _plantTypes = new ObservableCollection<string>();
        private ObservableCollection<string> _plantClassifications = new ObservableCollection<string>();
        private ObservableCollection<string> _phyla = new ObservableCollection<string>();

        //image source collection of images
        public ObservableCollection<BitmapImage> SelectedPlantImages = new ObservableCollection<BitmapImage>();

        private int _itemId;

        //----------------------------
        // NOTE: We apply here loose variables for the different plant properties as it will allow updating using the base class
        // --> this in turn allows a regulated saving / comparing system to the database when a user saves or cancels as well as individual validation checks in the filled data types
        //     These checks may be implemented using attributes (that decorate the variables)
        // --> these in turn should match our database limitations
        //----------------------------

        // List of local variables that we place here that are observed and serve for user / dataservice (database) interaction via their public related vars
        private string _itemLocalName;
        private string _itemCommonName;

        // Other relevant variables
        private string _itemGenus;
        private string _itemSpecies;
        private string _itemFamily;
        private string _itemDescription;

        //--------------------------------------
        // Other relevant information
        //--------------------------------------
        //  1.	Eatable / non-eatable
        //  2.	Color
        //  3.	Flowering
        //  4.	Leaves all year / loses leaves 
        //  5.	Trimming instructions and period
        //  6.	Temperature range
        //  7.	Poisonous
        //  8.	Eatable
        //  9.	Fertilization method
        //  10.	Shape
        //  11.	Height(full grown)
        //  12.	Width(full grown)
        //  13.   Light requirements
        //  14.   Water requirements
        //  15.   Soil requirements
        //--------------------------------------
        private bool _itemIsEatable;
        private string _itemColor;
        private bool _itemIsFlowering;
        private bool _itemIsEvergreen;
        private string _itemTrimmingInstructions;
        private string _itemTrimmingPeriod;
        private int _itemTemperatureRangeMinimum;
        private int _itemTemperatureRangeMaximum;
        private bool _itemIsPoisonous;
        private string _itemFertilizationMethod;

        private string _itemShape;
        private int _itemFullGrownHeight;
        private int _itemFullGrownWidth;
        // Removed: private string _itemPictureStringList;
        private string _itemLight;
        private string _itemWater;
        private string _itemSoil;

        //setup enums
        private string _selectedPlantClassification;
        private string _selectedPlantType;

        //vars used to keeop up tabs
        private bool _isDirty;
        private int _selectedItemId = -1;

        // Replace the following line
        // private Brush _selectedItemNameColor = new(0xFFFFFFFF);
        // with the correct initialization
        private System.Windows.Media.Brush _selectedItemNameColor;

        /// <summary>
        /// selected phylum in the list
        /// </summary>
        private string _selectedPhylum;

        #endregion


        #region constructor

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="dataService"></param>
        public PlantDetailsViewModel(INavigationService navigationService, IDataService dataService)
        {
            //set services
            _navigationServices = navigationService;
            _dataService = dataService;

            //fille lists
            PopulateLists();

            //SaveCommand = new RelayCommand2(SaveItem, CanSaveItem);
            CancelCommand = new RelayCommand(Cancel);
            NavigateBackCommand = new RelayCommand(NavigateBack);

            //new command to import an image
            ImportImageCommand = new RelayCommand(ImportImage);
            ShowImageCommand = new RelayCommand(ShowImages);
            //add relay command to open the plant problems page
            OpenPlantProblemsPageCommand = new RelayCommand(OpenPlantProblemsPage);

        }



        #endregion


        #region public properties

        /// <summary>
        /// command to save the item
        /// </summary>
        //public ICommand SaveCommand { get; set; }

        /// <summary>
        /// command to cancel the item
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// The NavigateBackCommand to navigate back
        /// </summary>
        public ICommand NavigateBackCommand { get; set; }

        /// <summary>
        /// command to import and image
        /// </summary>
        public ICommand ImportImageCommand { get; set; }

        /// <summary>
        /// command to Show the image (only for testing imported images)
        /// </summary>
        public ICommand ShowImageCommand { get; set; }

        /// <summary>
        /// command to open the plant problems page
        /// </summary>
        public ICommand OpenPlantProblemsPageCommand { get; set; }
        
        /// <summary>
        /// property for the item name
        /// --> Note JCO; the extensive set here is to demonstrate the use of validation and color to provide user feedback
        /// </summary>
        [MinLength(2, ErrorMessage = "Item name must be at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Item name must be 100 characters or less.")]
        public string ItemCommonName
        {
            get => _itemCommonName;
            set
            {
                if (!SetProperty(ref _itemCommonName, value, nameof(ItemCommonName)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;


                //Set color before itemname (or block the change edit of name to color)
                //create new brush that is white
                SolidColorBrush Brush = new SolidColorBrush(Colors.Orange);
                // set color to orange
                if (IsDirty == true) SelectedItemNameColor = Brush;

                // if there is an error in the IValidation error list, then print it here to debug console
                // -- > Note this is perhaps not the most logical place to catch such things but it allows evaluation of options catching this data in the viewmodel and processing it to usefull data for a user
                // --> we only want to do this if there are errors

                //-----------------------------------
                // --> we may even consider that adding such values or controls with color coding and makeup is better to be done in a specific control that allows all these settings
                //     So rather than having value settings, they may be better off in a control that is specifically designed for this purpose on a lower level allowing it to occur on every level
                //     --> E.g.
                //      1. it would be more logical to make an readly only properly in the bindable base that checks if a value is changed based on its property name and return a color
                //      2. it would be more flexible to have a read only property on the base that asks the validation implementation if there are error and return a color
                //          Both implementation remove the need for a separate variable in the ViewModel and can as such be implemented at any variable or any ViewModel
                //-----------------------------------

                // -- 20250124 Note we currently do nothing with this actively, we can add a list somewhere, or return the necessity to play to the rule and deactivate dirty so saving is disabled.
                var errors = GetErrors(nameof(ItemCommonName));

                //print to debug if there are errors.
                if (errors != null)
                {
                    //cast Inumerable to List
                    List<ValidationResult> errorsList = errors.Cast<ValidationResult>().ToList();

                    //check if there are errors
                    if (errorsList.Count > 0)
                    {
                        //print errors to debug
                        foreach (var error in errorsList)
                        {
                            System.Diagnostics.Debug.WriteLine(error);
                        }
                        //red
                        Brush = new SolidColorBrush(Colors.Red);
                        //change color label to red
                        SelectedItemNameColor = Brush;

                        //Now if we set IsDirty to false, the save button will be disabled
                        IsDirty = false;
                    }

                }

            }
        }

        /// <summary>
        /// name in local language
        /// </summary>
        [MinLength(2, ErrorMessage = "Item name must be at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Item name must be 100 characters or less.")]
        public string ItemLocalName
        {
            get => _itemLocalName;
            set
            {
                if (!SetProperty(ref _itemLocalName, value, nameof(ItemLocalName)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        /// <summary>
        /// public field for genus
        /// </summary>
        public string ItemGenus
        {
            get => _itemGenus;
            set
            {
                if (!SetProperty(ref _itemGenus, value, nameof(ItemGenus)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        /// <summary>
        /// field for species
        /// </summary>
        public string ItemSpecies
        {
            get => _itemSpecies;
            set
            {
                if (!SetProperty(ref _itemSpecies, value, nameof(ItemSpecies)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        /// <summary>
        /// public field for family
        /// </summary>
        public string ItemFamily
        {
            get => _itemFamily;
            set
            {
                if (!SetProperty(ref _itemFamily, value, nameof(ItemFamily)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        /// <summary>
        /// field for description
        /// </summary>
        public string ItemDescription
        {
            get => _itemDescription;
            set
            {
                if (!SetProperty(ref _itemDescription, value, nameof(ItemDescription)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        /// <summary>
        /// color label for ItemName combox
        /// --> !!! Note that this changes the color, but not results in reactiveness of the label on user interaction.
        /// </summary>
        public Brush SelectedItemNameColor
        {
            get => _selectedItemNameColor;
            set
            {
                if (SetProperty(ref _selectedItemNameColor, value, nameof(SelectedItemNameColor)))
                {
                    OnPropertyChanged(nameof(SelectedItemNameColor));
                }
            }
        }

        /// <summary>
        /// property for the Selected Plant Classification
        /// </summary>
        public string SelectedPlantClassification
        {
            get => _selectedPlantClassification;
            set
            {
                if (!SetProperty(ref _selectedPlantClassification, value, nameof(SelectedPlantClassification)))
                    return;

                IsDirty = true;
            }
        }

        /// <summary>
        /// property for the selected plant type
        /// </summary>
        public string SelectedPlantType
        {
            get => _selectedPlantType;
            set
            {
                if (!SetProperty(ref _selectedPlantType, value, nameof(SelectedPlantType)))
                    return;

                IsDirty = true;

                ////we probably need to limit Phyla, however, this relation may not be one to one and difficult to define
                //Phyla.Clear();

                //if (!string.IsNullOrWhiteSpace(value))
                //{
                //    //add phyla based on plant type
                //    foreach (string med in _dataService.GetPhyla((PlantType)Enum.Parse(typeof(PlantType), SelectedPlantType)).Select(m => m.Name))
                //        Phyla.Add(med);

                //}
            }
        }

        /// <summary>
        /// The SelectedPhylum property, which will hold the plant details.
        /// </summary>
        public string SelectedPhylum
        {
            get { return _selectedPhylum; }
            set
            {
                if (_selectedPhylum != value)
                {
                    _selectedPhylum = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// observable collection of plant types
        /// </summary>
        public ObservableCollection<string> PlantTypes { get => _plantTypes; set => SetProperty(ref _plantTypes, value, nameof(PlantTypes)); }

        /// <summary>
        /// observable collection of plant classifications
        /// </summary>
        public ObservableCollection<string> PlantClassifications { get => _plantClassifications; set => SetProperty(ref _plantTypes, value, nameof(PlantClassifications)); }

        /// <summary>
        /// phyla
        /// </summary>
        public ObservableCollection<string> Phyla { get => _phyla; set => SetProperty(ref _phyla, value, nameof(Phyla)); }


        public bool ItemIsEatable
        {
            get => _itemIsEatable;
            set
            {
                if (!SetProperty(ref _itemIsEatable, value, nameof(ItemIsEatable)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public string ItemColor
        {
            get => _itemColor;
            set
            {
                if (!SetProperty(ref _itemColor, value, nameof(ItemColor)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public bool ItemIsFlowering
        {
            get => _itemIsFlowering;
            set
            {
                if (!SetProperty(ref _itemIsFlowering, value, nameof(ItemIsFlowering)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public bool ItemIsEvergreen
        {
            get => _itemIsFlowering;
            set
            {
                if (!SetProperty(ref _itemIsEvergreen, value, nameof(ItemIsEvergreen)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public string ItemShape
        {
            get => _itemShape;
            set
            {
                if (!SetProperty(ref _itemShape, value, nameof(ItemShape)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public int ItemFullGrownHeight
        {
            get => _itemFullGrownHeight;
            set
            {
                if (!SetProperty(ref _itemFullGrownHeight, value, nameof(ItemFullGrownHeight)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public int ItemFullGrownWidth
        {
            get => _itemFullGrownWidth;
            set
            {
                if (!SetProperty(ref _itemFullGrownWidth, value, nameof(ItemFullGrownWidth)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }


        public string ItemTrimmingInstructions
        {
            get => _itemTrimmingInstructions;
            set
            {
                if (!SetProperty(ref _itemTrimmingInstructions, value, nameof(ItemTrimmingInstructions)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public string ItemTrimmingPeriod
        {
            get => _itemTrimmingPeriod;
            set
            {
                if (!SetProperty(ref _itemTrimmingPeriod, value, nameof(ItemTrimmingPeriod)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public int ItemTemperatureRangeMinimum
        {
            get => _itemTemperatureRangeMinimum;
            set
            {
                if (!SetProperty(ref _itemTemperatureRangeMinimum, value, nameof(ItemTemperatureRangeMinimum)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public int ItemTemperatureRangeMaximum
        {
            get => _itemTemperatureRangeMaximum;
            set
            {
                if (!SetProperty(ref _itemTemperatureRangeMaximum, value, nameof(ItemTemperatureRangeMaximum)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public bool ItemIsPoisonous
        {
            get => _itemIsPoisonous;
            set
            {
                if (!SetProperty(ref _itemIsPoisonous, value, nameof(ItemIsPoisonous)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }

        public string ItemFertilizationMethod
        {
            get => _itemFertilizationMethod;
            set
            {
                if (!SetProperty(ref _itemFertilizationMethod, value, nameof(ItemFertilizationMethod)))
                    return;


                //set to dirty cause we changed a value
                IsDirty = true;

            }
        }
        public string ItemLight
        {
            get => _itemLight;
            set
            {
                if (!SetProperty(ref _itemLight, value, nameof(ItemLight)))
                    return;

                IsDirty = true;
            }
        }

        public string ItemWater
        {
            get => _itemWater;
            set
            {
                if (!SetProperty(ref _itemWater, value, nameof(ItemWater)))
                    return;

                IsDirty = true;
            }
        }

        public string ItemSoil
        {
            get => _itemSoil;
            set
            {
                if (!SetProperty(ref _itemSoil, value, nameof(ItemSoil)))
                    return;

                IsDirty = true;
            }
        }

        /// <summary>
        /// property to determine if the item is dirty
        /// </summary>
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                SetProperty(ref _isDirty, value, nameof(IsDirty));
            }
        }

        #endregion


        #region public methods


        /// <summary>
        /// method for save item and continue (this is for implementation of a split button that can replace the Icommand SaveCommand)
        /// </summary>
        public async Task SaveItemAndContinueAsync()
        {           

            await SaveItemAsync();
            _itemId = 0;
            ItemCommonName = string.Empty;
            SelectedPlantType = string.Empty;
            SelectedPlantClassification = string.Empty;
            IsDirty = false;

        }

        /// <summary>
        /// Method for save and return to the main page *is also part of the split button implementation
        /// </summary>
        public async Task SaveItemAndReturnAsync()
        {
            //save the item
            await SaveItemAsync();

            //return to the main page
            _navigationServices.GoBack();
        }


        /// <summary>
        /// method to initialize the item detail data
        /// </summary>
        /// <param name="selectedItemId"></param>
        public async Task InitializeItemDetailDataAsync(int selectedItemId)
        {
            //set the selected item id
            _selectedItemId = selectedItemId;

            //populate the existing item
            if (_selectedItemId >= 0)
            {
                await PopulateExistingItemAsync(_dataService);
            }

            //set the is dirty to false
            // --> Note that dirty is set to false, after population and that during initial population the IsDirty is set to true
            IsDirty = false;
        }

        /// <summary>
        /// method to populate the existing item
        /// --> main method that based on the selected item (passed as parameter filled the fields with the item data)
        /// --> Note that here the selected fileds are set 
        /// --> Also note here that we only use the Name of Plant and that these two object are repsented here as a flat table
        /// </summary>
        /// <param name="dataService"></param>
        private async Task PopulateExistingItemAsync(IDataService dataService)
        {

            //when we open the page we should pass an id, this may then be used to obtain the relevant data item from the service
            if (_selectedItemId >= 0)
            {
                //get item
                var item = await dataService.GetItemAsync(_selectedItemId);

                //check if we have the item
                if (item is null == false)
                {

                    //clear Phyla
                    //Phyla.Clear();
                    //--> can we limit on type?
                    ////add phyla based on plant type
                    //foreach (string phylum in dataService.GetPhyla(item.PlantType).Select(m => m.Name))
                    //    Phyla.Add(phylum);

                    //!!! Note on the IProperty Changed the first time will be Change is true because the original values are not set yet.
                    //    --> therefore like IsDirty, any color codings indicating changes need to be set afterwards and not by reactiveness to the change from nothing to default
                    _itemId = item.Id;
                    ItemLocalName = item.LocalName;
                    ItemCommonName = item.CommonName;

                    //set other variables
                    ItemGenus = item.Genus;
                    ItemSpecies = item.Species;
                    ItemFamily = item.Family;
                    ItemDescription = item.Description;

                    //set enums
                    SelectedPlantType = item.PlantType.ToString();
                    SelectedPlantClassification = item.PlantClassification.ToString();

                    //NOTE --> its essential that setting the selected medium is done after the mediums are populated
                    //         else the selected medium will not be set due the fact that setting itemtype will clear the mediums
                    if (item.PhylumInfo is null == false) SelectedPhylum = item.PhylumInfo.Name;

                    //set plant details
                    ItemIsEatable = item.IsEatable;
                    ItemColor = item.Color;
                    ItemIsFlowering = item.IsFlowering;
                    ItemIsEvergreen = item.IsEvergreen;
                    ItemTrimmingInstructions = item.TrimmingInstructions;
                    ItemTrimmingPeriod = item.TrimmingPeriod;
                    ItemTemperatureRangeMinimum = item.TemperatureRangeMinimum;
                    ItemTemperatureRangeMaximum = item.TemperatureRangeMaximum;
                    ItemIsPoisonous = item.IsPoisonous;
                    ItemFertilizationMethod = item.FertilizationMethod;
                    ItemShape = item.Shape;
                    ItemFullGrownHeight = item.FullGrownHeight;
                    ItemFullGrownWidth = item.FullGrownWidth;
                    // New plant care properties
                    ItemLight = item.Light;
                    ItemWater = item.Water;
                    ItemSoil = item.Soil;


                    //-----------------------------------
                    //!!!! --> note that the color setting must be after settting the trigger value of name
                    //     --> Note that we merely implemented this here to evaluate reactivity and that this is not a logical place to implement this
                    //     --> we are better of having a dedicated method that checks the validity of the data and sets the color accordingly
                    //         However functionally it is a good example of how to set the color of a label based on the value of a field, as well as disabling the saving option
                    //-----------------------------------
                    //Set color before itemname (or block the change edit of name to color)
                    //create new brush that is white
                    SolidColorBrush Brush = new SolidColorBrush(Colors.White);
                    //set color to white
                    SelectedItemNameColor = Brush;


                    //get images
                    ShowImages();

                    //--> we have a specifci page for this now.
                    //test to collect problems
                    //ShowAllProblems();
                }
            }
        }

        /// <summary>
        /// method to populate the lists
        /// </summary>
        private void PopulateLists()
        {
            PlantTypes.Clear();
            foreach (string iType in Enum.GetNames(typeof(PlantType)))
                PlantTypes.Add(iType);

            PlantClassifications.Clear();
            foreach (string CType in Enum.GetNames(typeof(PlantClassification)))
                PlantClassifications.Add(CType);

            //Phyla has to be filled via data service
            _phyla = new ObservableCollection<string>();
            //add all
            foreach (string phylum in _dataService.GetPhyla().Select(m => m.Name))
                Phyla.Add(phylum);

        }

        /// <summary>
        /// method to save the item
        /// </summary>
        private async Task SaveItemAsync()
        {
            //new
            Plant item;

            if (_itemId > 0)
            {
                item = await _dataService.GetItemAsync(_itemId);
                MapViewModelToPlant(item);
                await _dataService.UpdateItemAsync(item);
            }
            else
            {
                item = new Plant();
                MapViewModelToPlant(item);
                await _dataService.AddItemAsync(item);
            }


            _navigationServices.GoBack();
        }

        /// <summary>
        /// map view to model 
        /// </summary>
        /// <param name="item"></param>
        private void MapViewModelToPlant(Plant item)
        {
            item.LocalName = ItemLocalName;
            item.CommonName = ItemCommonName;
            item.Genus = ItemGenus;
            item.Species = ItemSpecies;
            item.Family = ItemFamily;
            item.Description = ItemDescription;
            item.PlantType = (PlantType)Enum.Parse(typeof(PlantType), SelectedPlantType);
            item.PlantClassification = (PlantClassification)Enum.Parse(typeof(PlantClassification), SelectedPlantClassification);
            item.PhylumInfo = _dataService.GetPhylum(SelectedPhylum);
            item.IsEatable = ItemIsEatable;
            item.Color = ItemColor;
            item.IsFlowering = ItemIsFlowering;
            item.IsEvergreen = ItemIsEvergreen;
            item.TrimmingInstructions = ItemTrimmingInstructions;
            item.TrimmingPeriod = ItemTrimmingPeriod;
            item.TemperatureRangeMinimum = ItemTemperatureRangeMinimum;
            item.TemperatureRangeMaximum = ItemTemperatureRangeMaximum;
            item.IsPoisonous = ItemIsPoisonous;
            item.FertilizationMethod = ItemFertilizationMethod;
            item.Shape = ItemShape;
            item.FullGrownHeight = ItemFullGrownHeight;
            item.FullGrownWidth = ItemFullGrownWidth;
            // New plant care properties
            item.Light = ItemLight;
            item.Water = ItemWater;
            item.Soil = ItemSoil;
        }


        /// <summary>
        /// method to determine if the item can be saved
        /// </summary>
        /// <returns></returns>
        private bool CanSaveItem()
        {
            return IsDirty;
        }

        /// <summary>
        /// method to cancel the item
        /// </summary>
        private void Cancel()
        {
            _navigationServices.GoBack();
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
        /// task to import and image
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private async void ImportImage()
        {
            // 1. Show file picker dialog with multiselect enabled
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select Images",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string[] selectedFilePaths = openFileDialog.FileNames;
                int successCount = 0;

                foreach (var filePath in selectedFilePaths)
                {
                    try
                    {
                        await _dataService.AddItemImageAsync(_itemId, filePath);
                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importing image: {filePath}\n{ex.Message}");
                    }
                }

                MessageBox.Show($"{successCount} image(s) imported successfully!");
            }
        }


        /// <summary>
        /// command that retrieves and show the relevant image
        /// </summary>
        private async void ShowImages()
        {


            try
            {

                //---------------
                // add to observeable collection
                //---------------
                // 1. Retrieve the image bytes from the DB
                var ListImageBytes = await _dataService.GetImagesForParentAsync(_itemId);

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


                //---------------
                //ALT --> set to temp file and open
                //---------------
                // 2. Save to a temporary file
                //string tempFile = Path.Combine(Path.GetTempPath(), $"dbimage_{imageId}.jpg");
                //await File.WriteAllBytesAsync(tempFile, imageBytes);

                //// 3. Open the image with the default viewer
                //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                //{
                //    FileName = tempFile,
                //    UseShellExecute = true
                //});
                //---------------

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving or opening image: {ex.Message}");
            }
        }

        public async Task RetrieveAndOpenImageAsync(int imageId)
        {

            try
            {

                //---------------
                // add to observeable collection
                //---------------
                // 1. Retrieve the image bytes from the DB
                byte[] imageBytes = await _dataService.GetItemImageAsync(imageId);

                if (imageBytes == null || imageBytes.Length == 0)
                {
                    MessageBox.Show("No image found for the specified ID.");
                    return;
                }

                //add to observeable collection
                await AddImageAsync(imageBytes);
                //---------------


                //---------------
                //ALT --> set to temp file and open
                //---------------
                // 2. Save to a temporary file
                //string tempFile = Path.Combine(Path.GetTempPath(), $"dbimage_{imageId}.jpg");
                //await File.WriteAllBytesAsync(tempFile, imageBytes);

                //// 3. Open the image with the default viewer
                //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                //{
                //    FileName = tempFile,
                //    UseShellExecute = true
                //});
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

        /// <summary>
        /// open the plant problems page
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void OpenPlantProblemsPage()
        {
            //navigat to the plant problems page
            _navigationServices.NavigateTo("PlantProblemsPage", _itemId);

        }

        /// <summary>
        /// Command that retrieves and shows all plant problems in the database.
        /// </summary>
        private async void ShowAllProblems()
        {
            try
            {
                // Retrieve all plant problems from the DB
                var allProblems = await _dataService.GetProblemsForPlantAsync(_itemId);

                // Check if we have any problems
                if (allProblems == null || allProblems.Count() == 0)
                {
                    MessageBox.Show("No plant problems found in the database.");
                    return;
                }

                // Build a string to display all problems
                var message = new System.Text.StringBuilder();
                foreach (var problem in allProblems)
                {
                    message.AppendLine($"Problem: {problem.Name}");
                    message.AppendLine($"Description: {problem.Description}");
                    message.AppendLine($"Symptoms: {problem.Symptoms}");
                    message.AppendLine($"Causes: {problem.Causes}");
                    message.AppendLine($"Solutions: {problem.Solutions}");
                    message.AppendLine($"Severity: {problem.Severity}");
                    message.AppendLine($"Category: {problem.Category}");
                    message.AppendLine("---");
                }

                // Show all problems in a message box
                MessageBox.Show(message.ToString(), "All Plant Problems");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving plant problems: {ex.Message}");
            }
        }


        #endregion

    }
}
