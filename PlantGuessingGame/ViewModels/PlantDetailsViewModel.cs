using PlantGuessingGame.DataModels;
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

        private ObservableCollection<string> _locationTypes = new ObservableCollection<string>();
        private ObservableCollection<string> _mediums = new ObservableCollection<string>();
        private ObservableCollection<string> _itemTypes = new ObservableCollection<string>();
        private int _itemId;
        private string _itemName;
        private string _selectedMedium;
        private string _selectedItemType;
        private string _selectedLocation;
        private bool _isDirty;
        private int _selectedItemId = -1;

        // Replace the following line
        // private Brush _selectedItemNameColor = new(0xFFFFFFFF);
        // with the correct initialization
        private System.Windows.Media.Brush _selectedItemNameColor;

        /// <summary>
        /// selected item in the list
        /// </summary>
        private Plant _selectedPlant;


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
        /// </summary>
        [MinLength(2, ErrorMessage = "Item name must be at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Item name must be 100 characters or less.")]
        public string ItemName
        {
            get => _itemName;
            set
            {
                if (!SetProperty(ref _itemName, value, nameof(ItemName)))
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
                var errors = GetErrors(nameof(ItemName));

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
        /// The SelectedPlant property, which will hold the plant details.
        /// </summary>
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
        /// property for the selected medium
        /// </summary>
        public string SelectedMedium
        {
            get => _selectedMedium;
            set
            {
                if (!SetProperty(ref _selectedMedium, value, nameof(SelectedMedium)))
                    return;

                IsDirty = true;
            }
        }

        /// <summary>
        /// property for the selected item type
        /// </summary>
        public string SelectedItemType
        {
            get => _selectedItemType;
            set
            {
                if (!SetProperty(ref _selectedItemType, value, nameof(SelectedItemType)))
                    return;

                IsDirty = true;

                Mediums.Clear();

                if (!string.IsNullOrWhiteSpace(value))
                {
                    //foreach (string med in _dataService.GetMediums((ItemType)Enum.Parse(typeof(ItemType), SelectedItemType)).Select(m => m.Name))
                    //    Mediums.Add(med);
                }
            }
        }

        /// <summary>
        /// property for the selected location
        /// </summary>
        public string SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                if (!SetProperty(ref _selectedLocation, value, nameof(SelectedLocation)))
                    return;

                IsDirty = true;
            }
        }

        /// <summary>
        /// observable collection of location types
        /// </summary>
        public ObservableCollection<string> LocationTypes { get => _locationTypes; set => SetProperty(ref _locationTypes, value, nameof(LocationTypes)); }

        /// <summary>
        /// observable collection of mediums
        /// </summary>
        public ObservableCollection<string> Mediums { get => _mediums; set => SetProperty(ref _mediums, value, nameof(Mediums)); }

        /// <summary>
        /// observable collection of item types
        /// </summary>
        public ObservableCollection<string> ItemTypes { get => _itemTypes; set => SetProperty(ref _itemTypes, value, nameof(ItemTypes)); }

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
            ItemName = string.Empty;
            SelectedMedium = string.Empty;
            SelectedItemType = string.Empty;
            SelectedLocation = string.Empty;
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
        /// --> Note that here the selected fileds are set (such as selected medium, location and item type)
        /// --> Also note here that we only use the Name of MediumInfo and that these two object are repsented here as a flat table
        /// </summary>
        /// <param name="dataService"></param>
        //private async Task PopulateExistingItemAsync(IDataService dataService)
        //{


        //    if (_selectedItemId > 0)
        //    {
        //        var item = await _dataService.GetItemAsync(_selectedItemId);
        //        Mediums.Clear();

        //        foreach (string medium in dataService.GetMediums(item.MediaType).Select(m => m.Name))
        //            Mediums.Add(medium);


        //        //!!! Note on the IProperty Changed the first time will be Change is true because the original values are not set yet.
        //        //    --> therefore like IsDirty, any color codings indicating changes need to be set afterwards and not by reactiveness to the change from nothing to default
        //        _itemId = item.Id;
        //        ItemName = item.Name;
        //        SelectedLocation = item.Location.ToString();
        //        SelectedItemType = item.MediaType.ToString();

        //        //NOTE --> its essential that setting the selected medium is done after the mediums are populated
        //        //         else the selected medium will not be set due the fact that setting itemtype will clear the mediums
        //        SelectedMedium = item.MediumInfo.Name;

        //        //-----------------------------------
        //        //!!!! --> note that the color setting must be after settting the trigger value of name
        //        //     --> Note that we merely implemented this here to evaluate reactivity and that this is not a logical place to implement this
        //        //     --> we are better of having a dedicated method that checks the validity of the data and sets the color accordingly
        //        //         However functionally it is a good example of how to set the color of a label based on the value of a field, as well as disabling the saving option
        //        //-----------------------------------
        //        //Set color before itemname (or block the change edit of name to color)
        //        //create new brush that is white
        //        SolidColorBrush Brush = new SolidColorBrush(Colors.White);
        //        //set color to white
        //        SelectedItemNameColor = Brush;
        //    }
        //}

        /// <summary>
        /// method to populate the lists
        /// </summary>
        private void PopulateLists()
        {
            //ItemTypes.Clear();
            //foreach (string iType in Enum.GetNames(typeof(ItemType)))
            //    ItemTypes.Add(iType);

            //LocationTypes.Clear();
            //foreach (string lType in Enum.GetNames(typeof(LocationType)))
            //    LocationTypes.Add(lType);

            //Mediums = new ObservableCollection<string>();
        }

        /// <summary>
        /// method to save the item
        /// </summary>
        private async Task SaveItemAsync()
        {
            //MediaItem item;

            //if (_itemId > 0)
            //{
            //    item = await _dataService.GetItemAsync(_itemId);

            //    item.Name = ItemName;
            //    item.Location = (LocationType)Enum.Parse(typeof(LocationType), SelectedLocation);
            //    item.MediaType = (ItemType)Enum.Parse(typeof(ItemType), SelectedItemType);
            //    item.MediumInfo = _dataService.GetMedium(SelectedMedium);

            //    await _dataService.UpdateItemAsync(item);
            //}
            //else
            //{
            //    item = new MediaItem
            //    {
            //        Name = ItemName,
            //        Location = (LocationType)Enum.Parse(typeof(LocationType), SelectedLocation),
            //        MediaType = (ItemType)Enum.Parse(typeof(ItemType), SelectedItemType),
            //        MediumInfo = _dataService.GetMedium(SelectedMedium)
            //    };

            //    await _dataService.AddItemAsync(item);
            //}

            //_navigationServices.GoBack();
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
