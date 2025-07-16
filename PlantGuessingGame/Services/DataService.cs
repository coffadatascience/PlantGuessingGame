namespace PlantGuessingGame.Services
{
    using global::PlantGuessingGame.DataModels;
    using global::PlantGuessingGame.Enums;
    using global::PlantGuessingGame.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace PlantGuessingGame.Services
    {

        /// <summary>
        /// Data service class
        /// --->? Note we may not need this class anymore as it is replaced by an SQL service
        /// --> we will keep for now and see how it may have a future function or serve as an extra layer.
        /// </summary>
        public class DataService : IDataService
        {
            #region Fields

            private IList<Plant> _plants;
            private IList<PlantType> _plantTypes;
            private IList<Phylum> _phyla;
            private IList<PlantClassification> _classifications;

            public int SelectedItemId { get; set; }

            #endregion

            #region Constructor

            public DataService()
            {
                _plants = new List<Plant>();
                _plantTypes = new List<PlantType>();
                _phyla = new List<Phylum>();
                _classifications = new List<PlantClassification>();

                PopulatePlantTypes();
                PopulateClassifications();
            }

            #endregion

            #region Data Population

            private void PopulatePlantTypes()
            {
                _plantTypes = Enum.GetValues(typeof(PlantType)).Cast<PlantType>().ToList();
            }

            private void PopulateClassifications()
            {
                _classifications = Enum.GetValues(typeof(PlantClassification)).Cast<PlantClassification>().ToList();
            }

            #endregion

            #region Async Methods

            public Task InitializeDataAsync()
            {
                // In-memory, so initialization is done in constructor
                return Task.CompletedTask;
            }

            public Task<IList<Plant>> GetItemsAsync()
            {
                return Task.FromResult(_plants);
            }

            public Task<Plant> GetItemAsync(int id)
            {
                var plant = _plants.FirstOrDefault(p => p.Id == id);
                return Task.FromResult(plant);
            }

            public Task<int> AddItemAsync(Plant item)
            {
                var newId = _plants.Any() ? _plants.Max(p => p.Id) + 1 : 1;
                item.Id = newId;
                _plants.Add(item);
                return Task.FromResult(newId);
            }

            public Task UpdateItemAsync(Plant item)
            {
                var index = _plants.ToList().FindIndex(p => p.Id == item.Id);
                if (index != -1)
                    _plants[index] = item;

                return Task.CompletedTask;
            }

            public Task DeleteItemAsync(Plant item)
            {
                _plants.Remove(item);
                return Task.CompletedTask;
            }

            #endregion


            #region NotImplemented

            /// <summary>
            /// note implemented
            /// </summary>
            /// <param name="imagePath"></param>
            /// <returns></returns>
            public Task<int> AddItemImageAsync(int parentId, string imagePath)
            {
                throw new NotImplementedException("This method is not implemented in this class.");
            }


            #endregion


            #region Synchronous Methods


            public IList<PlantType> GetItemTypes()
            {
                return _plantTypes;
            }

            public Phylum GetPhylum(string name)
            {
                return _phyla.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }

            public IList<Phylum> GetPhyla()
            {
                return _phyla;
            }

            public IList<Phylum> GetPhyla(PlantType itemType)
            {
                return _phyla.Where(p => p.PlantType == itemType).ToList();
            }

            public IList<PlantClassification> GetPlantClassifications()
            {
                return _classifications;
            }



            public Task<List<byte[]>> GetImagesForParentAsync(int parentId)
            {
                throw new NotImplementedException();
            }

            public Task<List<PlantProblem>> GetProblemsForPlantAsync(int parentId)
            {
                throw new NotImplementedException();
            }

            public Task<int> AddItemImageTablePlantsAsync(int parentId, string imagePath)
            {
                throw new NotImplementedException();
            }

            public Task<byte[]> GetItemImageTablePlantsAsync(int v)
            {
                throw new NotImplementedException();
            }

            public Task<List<byte[]>> GetImagesTablePlantsForParentAsync(int parentId)
            {
                throw new NotImplementedException();
            }





            #endregion
        }
    }

}
