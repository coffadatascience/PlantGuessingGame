using PlantGuessingGame.DataModels;
using PlantGuessingGame.Enums;
using PlantGuessingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantGuessingGame.ViewModels
{

    /// <summary>
    /// ViewModel for the plant problems
    /// --> can open when a plant is selected in the details menu
    /// --> from the details we want to view the specific plant problems giving an overview of problems and solutions (possibly images)
    /// </summary>
    public class PlantProblemsViewModel : BindableBase
    {


        #region private variables

        /// <summary>
        /// id of current selected plant
        /// </summary>
        private int _itemId;

        /// <summary>
        /// selected item id
        /// </summary>
        private int _selectedItemId = -1;

        /// <summary>
        /// bool for dirty
        /// </summary>
        private bool _isDirty;

        /// <summary>
        /// local selected plant variable
        /// </summary>
        private Plant selectedPlant;

        /// <summary>
        /// observable collection to display list of PlantProblems (private)
        /// </summary>
        private ObservableCollection<PlantProblem> plantProblems = new ObservableCollection<PlantProblem>();


        #endregion



        #region public variables

        /// <summary>
        /// Collection of PlantProblems that the View will bind to
        /// </summary>
        public ObservableCollection<PlantProblem> PlantProblems
        {
            get { return plantProblems; }
            set
            {
                plantProblems = value;
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


        #region constructors


        /// <summary>
        /// Constructor
        /// --> gets navigation service from DI
        /// --> preps command
        /// --> add list of default plant information (we will make these collection later in a data service)
        /// </summary>
        /// <param name="navigationService"></param>
        public PlantProblemsViewModel(INavigationService navigationService, IDataService dataService)
        {
            //set nav
            _navigationServices = navigationService;
            _dataService = dataService;

            // Initialize the PlantProblems collection
            PlantProblems = [];

            // Add PlantProblems on initialization
            PopulateDataAsync();
        }

        #endregion



        #region procedures


        /// <summary>
        /// retrieves list of plants from data service
        /// </summary>
        /// <returns></returns>
        private async Task PopulateDataAsync()
        {

            //clear the items
            PlantProblems.Clear();

            //Get problems for specific
            foreach (var item in await _dataService.GetProblemsForPlantAsync(_itemId))
            {
                //add items
                PlantProblems.Add(item);

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



        #endregion

        #region public methods

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
                //await PopulateExistingItemAsync(_dataService);
            }

            //set the is dirty to false
            // --> Note that dirty is set to false, after population and that during initial population the IsDirty is set to true
            IsDirty = false;
        }

        #endregion


    }
}
