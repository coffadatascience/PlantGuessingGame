using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantGuessingGame.DataModels;
using PlantGuessingGame.Enums;

namespace PlantGuessingGame.Interfaces
{

    /// <summary>
    /// interface that represents a data service
    /// --> this is the interface that the view model will use to interact with the data store
    /// </summary>
    public interface IDataService
    {

        #region Tasks

        /// <summary>
        /// task that must be implemented to initialize the database
        /// </summary>
        /// <returns></returns>
        Task InitializeDataAsync();

        /// <summary>
        /// async method to get all of the available Plants
        /// </summary>
        /// <returns></returns>
        Task<IList<Plant>> GetItemsAsync();

        /// <summary>
        /// async method to get a specific Plant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Plant> GetItemAsync(int id);

        /// <summary>
        /// async method to add a new item to the data store
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> AddItemAsync(Plant item);

        /// <summary>
        /// async method to update an existing item in the data store
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateItemAsync(Plant item);

        /// <summary>
        /// async method to get all of the available media types
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task DeleteItemAsync(Plant item);

        /// <summary>
        /// task to insert image
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> AddItemImageAsync(string imagePath);

        /// <summary>
        /// task to get the image by id (int)
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        Task<byte[]> GetItemImageAsync(int v);

        #endregion


        #region Synchronous Methods

        //-----------------------------------
        // group
        //-----------------------------------
        // The plant kingdom has been classified into five subgroups according to the above-mentioned criteria:
        //-----------------------------------
        //  Thallophyta
        //  Bryophyta
        //  Pteridophyta
        //  Gymnosperms
        //  Angiosperms
        //-----------------------------------



        //-----------------------------------
        // Types
        // Types of Plants-Herbs, Shrubs, Trees, Climbers, and Creepers.
        //-----------------------------------

        /// <summary>
        /// gets all of the available plant types
        /// </summary>
        /// <returns></returns>
        IList<PlantType> GetItemTypes();

        /// <summary>
        /// gets all of the available plant Phylum
        /// </summary>
        /// <returns></returns>
        Phylum GetPhylum(string name);

        /// <summary>
        /// gets all of the available PlantGroups
        /// </summary>
        /// <returns></returns>
        IList<Phylum> GetPhyla();

        /// <summary>
        /// gets all of the available Phyla for a specific plant type
        /// </summary>
        /// <param name="itemType"></param>
        /// <returns></returns>
        IList<Phylum> GetPhyla(PlantType itemType);

        /// <summary>
        /// gets all of the available PlantClassification
        /// </summary>
        /// <returns></returns>
        IList<PlantClassification> GetPlantClassifications();

        /// <summary>
        /// gets all of the available location types for a specific item type
        /// </summary>
        int SelectedItemId { get; set; }

        #endregion

    }
}
