using PlantGuessingGame.DataModels;
using PlantGuessingGame.Enums;
using PlantGuessingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

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


        private int _itemId;

        //list of local variables that we place here that are observed and serve for user / dataservice (database) interaction via their public related vars
        private string _itemCommonName;

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
        public PlantDetailsViewModel(INavigationService navigationService) //, IDataService dataService)
        {
            _navigationServices = navigationService;
            //_dataService = dataService;

            PopulateLists();

            //SaveCommand = new RelayCommand2(SaveItem, CanSaveItem);
            CancelCommand = new RelayCommand(Cancel);
            NavigateBackCommand = new RelayCommand(NavigateBack);

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

                PlantTypes.Clear();

                if (!string.IsNullOrWhiteSpace(value))
                {
                    //foreach (string med in _dataService.GetMediums((ItemType)Enum.Parse(typeof(ItemType), SelectedItemType)).Select(m => m.Name))
                    //    Mediums.Add(med);
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
            if (_selectedItemId > 0)
            {
                //await PopulateExistingItemAsync(_dataService);
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
            if (_selectedItemId > 0)
            {
                var item = await _dataService.GetItemAsync(_selectedItemId);

                //clear Phyla
                Phyla.Clear();

                //add phyla based on plant type
                foreach (string phylum in dataService.GetPhyla(item.PlantType).Select(m => m.Name))
                    Phyla.Add(phylum);


                //!!! Note on the IProperty Changed the first time will be Change is true because the original values are not set yet.
                //    --> therefore like IsDirty, any color codings indicating changes need to be set afterwards and not by reactiveness to the change from nothing to default
                _itemId = item.Id;
                ItemCommonName = item.CommonName;
                SelectedPlantType = item.PlantType.ToString();
                SelectedPlantClassification = item.PlantClassification.ToString();

                //NOTE --> its essential that setting the selected medium is done after the mediums are populated
                //         else the selected medium will not be set due the fact that setting itemtype will clear the mediums
                SelectedPhylum = item.PhylumInfo.Name;

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
            foreach (string lType in Enum.GetNames(typeof(PlantClassification)))
                PlantClassifications.Add(lType);

            //Phyla has to be filled via data service
            _phyla = new ObservableCollection<string>();
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
                //get item by id from DB
                item = await _dataService.GetItemAsync(_itemId);

                //set values
                item.CommonName = ItemCommonName;
                item.PlantType = (PlantType)Enum.Parse(typeof(PlantType), SelectedPlantType);
                item.PlantClassification = (PlantClassification)Enum.Parse(typeof(PlantClassification), SelectedPlantClassification);
                item.PhylumInfo = _dataService.GetPhylum(SelectedPhylum);

                //update item
                await _dataService.UpdateItemAsync(item);
            }
            else
            {
                item = new Plant
                {
                    CommonName = ItemCommonName,
                    PlantType = (PlantType)Enum.Parse(typeof(PlantType), SelectedPlantType),
                    PlantClassification = (PlantClassification)Enum.Parse(typeof(PlantClassification), SelectedPlantClassification),
                    PhylumInfo = _dataService.GetPhylum(SelectedPhylum)
                };
                
                //add item
                await _dataService.AddItemAsync(item);
            }

            _navigationServices.GoBack();
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


        // Method to handle the logic of navigating back
        private void NavigateBack()
        {
            // Call the navigation service to navigate back
            _navigationServices.GoBack();
        }

        #endregion

    }
}
