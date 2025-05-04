using Microsoft.UI.Xaml.Input;
using PlantGuessingGame.DataModels;

//using PlantGuessingGame.Enums;
using PlantGuessingGame.Interfaces;
//using PlantGuessingGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlantGuessingGame.ViewModels
{

    /// <summary>
    /// Main view model, inherits from BindableBase
    /// </summary>
    public class MainViewModel : BindableBase
    {

        #region fields


        /// <summary>
        /// constant for all mediums
        /// </summary>
        private const string AllMediums = "All";

        /// <summary>
        /// Temp var for number of items added to the list
        /// </summary>
        private int additionalItemCount;


        ///// <summary>
        ///// List of media items
        ///// </summary>
        //private ObservableCollection<MediaItem> items = new ObservableCollection<MediaItem>();

        ///// <summary>
        ///// Ilist for medium types for the combo box
        ///// </summary>
        //private ObservableCollection<MediaItem> allItems;

        /// <summary>
        /// Ilist for medium types for the combo box
        /// </summary>
        private IList<string> mediums;

        #endregion


        #region properties

        /// <summary>
        /// Property for selected media item
        /// </summary>
        //public MediaItem SelectedMediaItem
        //{
        //    get => selectedMediaItem;
        //    set
        //    {
        //        //sets property
        //        SetProperty(ref selectedMediaItem, value);

        //        // Adjust a relay Icommand (in this case we make a relay command delete for the selected item)
        //        // --> note that as such the button is prepped with what is selected
        //        // --> the presence of a selection determines if the deleted button is visible
        //        // --> Different than in the constructor where Delecommand is initialized, here the DeleteCommand is parsed to a RelayCommand Class and then the function
        //        //     Raise Can Execute Changes is ran, leading to the button being able to execute or not

        //        // --> 20250102 Note that this doesnt work because the Interface ICommand does not have the method RaiseCanExecuteChanged
        //        //     This interface has been recently changed and now works different (with the eventhandler CanExecuteChanged)
        //        ((RelayCommand2)DeleteCommand).RaiseCanexecuteChanged();

        //        ////get CanDeleteItem
        //        //bool CanDeleteBool = CanDeleteItem();
        //        ////create new Delete command
        //        ////check if we can delete the item
        //        //DeleteCommand = new RelayCommand(DeleteItem, CanDeleteItem);

        //    }
        //}

        /// <summary>
        /// command for add edit
        /// </summary>
        public RelayCommand AddEditCommand { get; set; }

        /// <summary>
        /// command for delete
        /// </summary>
        public RelayCommand DeleteCommand { get; set; }




        #endregion


        #region Constructor

        /// <summary>
        /// Constructor
        //  constructor for the main view model that include InavigationService and IDataService
        // --> note that the constructor is now empty, the data is loaded in the PopulateData method
        // --> because they are initially registered as a service (DI container)
        // --> Now by passing them into transient models, they become available to each viewmodel and thus whatever View where we implement such a view model
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="dataService"></param>
        public MainViewModel(INavigationService navigationService)//, IDataService dataService)
        {
            //set the navigation service
            _navigationServices = navigationService;
            //set the data service
            //_dataService = dataService;

            //selected first item in grid
            //selectedMediaItem = items.FirstOrDefault();
            //check if we can delete the item
            //DeleteCommand = new RelayCommand2(DeleteItem, CanDeleteItem);
            // --> replace by async call
            //DeleteCommand = new RelayCommand2(async() => await DeleteItemAsync(), CanDeleteItem);

            //add edit (note that we can always add, but cant alway delete)
            //AddEditCommand = new RelayCommand(AddOrEditItem);

            //populate with some data (this normally would come from a DB)
            PopulateDataAsync();
        }


        /// <summary>
        /// Constructor
        /// --> NOTE JCO --> because the navigationService, and dataService are registered the above contructor will be called instead of this one
        /// --> without registering these services this constructor would be called
        /// note that using this principle 
        /// --> Old constructor
        /// </summary>
        //public MainViewModel()
        //{
        //    //populate with some data (this normally would come from a DB)
        //    PopulateData();

        //    //selected first item in grid
        //    //selectedMediaItem = items.FirstOrDefault();

        //    //check if we can delete the item
        //    DeleteCommand = new RelayCommand2(DeleteItem, CanDeleteItem);
        //    //add edit (note that we can always add, but cant alway delete)
        //    AddEditCommand = new RelayCommand2(AddOrEditItem);

        //}

        #endregion


        #region events




        #endregion


        #region Methods

        /// <summary>
        /// function to delete the selected item
        /// </summary>
        //public void DeleteItem()
        //{
        //    //all items remove
        //    allItems.Remove(SelectedMediaItem);
        //    items.Remove(SelectedMediaItem);
        //}

        //async method to delete item (replace above sync method)
        private async Task DeleteItemAsync()
        {
            //call the data service to delete the item
            //await _dataService.DeleteItemAsync(SelectedMediaItem);
            //remove the item from the list
            //allItems.Remove(SelectedMediaItem);
            //items.Remove(SelectedMediaItem);
        }

        /// <summary>
        /// check if we can remove the item
        /// </summary>
        /// <returns></returns>
        //private bool CanDeleteItem() => selectedMediaItem != null;


        public void NavigateToDetailsPage(object sender, DoubleTappedRoutedEventArgs e)
        {
            _navigationServices.NavigateTo("PlantDetailPage");

        }


        /// <summary>
        /// method to load the data from the data service
        /// --> Note JCO now we have a method that calls the data service to get the data
        /// and it only sets the data to the items, mediums, and allItems that are used in the view to display the data
        //  !!!!!!!!!!!!!!!!!!!!!!!!!
        ///  NOTE JCO --> here we can clearly see how the View model play the intermediar between the data models and the view
        ///               without any knowledge about the creation of the data it implements it in a way that the view can understand
        ///               Often the more layering that is applied, the less each model needs to change to work with its data
        ///               also the more layering is applied often meaning is filtered out
        //  !!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        private async Task PopulateDataAsync()
        {

            ////clear the items
            //items.Clear();
            //foreach (var item in await _dataService.GetItemsAsync())
            //{
            //    items.Add(item);
            //}

            ////new observable collection with all items
            //allItems = new ObservableCollection<MediaItem>(items);

            ////create a list with mediums and add "All" to it
            //mediums = new ObservableCollection<string>
            //{
            //    AllMediums
            //};

            ////add the rest of the items
            //foreach (var itemType in _dataService.GetItemTypes())
            //{
            //    mediums.Add(itemType.ToString());
            //}

            //set selected medium
            //selectedMedium = Mediums[0];

        }

        /// <summary>
        /// method to load the data
        /// --> We will replace this method and move it to the IDataService
        /// ---> as such this method will be replaced by a call to the data service that sets the data (see above)
        /// </summary>
        //private void PopulateData()
        //{

        //    //create item 1. classic favorites
        //    var cd = new MediaItem
        //    {
        //        Id = 1,
        //        Name = "Classical Favorites",
        //        MediaType = ItemType.Music,
        //        MediumInfo = new Medium
        //        {
        //            Id = 1,
        //            Name = "Music",
        //            MediaType = ItemType.Music,
        //        },
        //    };

        //    //create item 2. classic fairy tales
        //    var book = new MediaItem
        //    {
        //        Id = 2,
        //        Name = "Classic Fairy Tales",
        //        MediaType = ItemType.Book,
        //        MediumInfo = new Medium
        //        {
        //            Id = 2,
        //            Name = "Book",
        //            MediaType = ItemType.Book,
        //        },
        //    };

        //    //create item 3. the mummy
        //    var video = new MediaItem
        //    {
        //        Id = 3,
        //        Name = "The Mummy",
        //        MediaType = ItemType.Video,
        //        MediumInfo = new Medium
        //        {
        //            Id = 3,
        //            Name = "Video",
        //            MediaType = ItemType.Video,
        //        },
        //    };

        //    //create a list of items
        //    items = new ObservableCollection<MediaItem>
        //        {
        //            cd,
        //            book,
        //            video
        //        };

        //    //create a list of all items
        //    allItems = new ObservableCollection<MediaItem>(items);

        //    //create a list of mediums
        //    mediums = new List<string>
        //    {
        //        "All",
        //        nameof(ItemType.Book),
        //        nameof(ItemType.Music),
        //        nameof(ItemType.Video)
        //    };

        //    //set the selected medium
        //    selectedMedium = mediums[0];


        //}


        #endregion

    }
}
