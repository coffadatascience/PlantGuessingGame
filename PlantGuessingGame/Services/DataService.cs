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
                //PopulatePhyla();
                PopulateClassifications();
                PopulatePlants();
            }

            #endregion

            #region Data Population

            private void PopulatePlantTypes()
            {
                _plantTypes = Enum.GetValues(typeof(PlantType)).Cast<PlantType>().ToList();
            }

            //private void PopulatePhyla()
            //{
            //    _phyla = new List<Phylum>
            //    {
            //        new Phylum { Id = 1, Name = "Thallophyta", Description = "Simple plants like algae and fungi.", PlantType = PlantType.Herb },
            //        new Phylum { Id = 2, Name = "Bryophyta", Description = "Non-vascular plants like mosses.", PlantType = PlantType.Shrub },
            //        new Phylum { Id = 3, Name = "Pteridophyta", Description = "Ferns and their relatives.", PlantType = PlantType.Tree },
            //        new Phylum { Id = 4, Name = "Gymnosperms", Description = "Seed-producing plants like pines.", PlantType = PlantType.Climber },
            //        new Phylum { Id = 5, Name = "Angiosperms", Description = "Flowering plants.", PlantType = PlantType.Creeper }
            //    };
            //}

            private void PopulateClassifications()
            {
                _classifications = Enum.GetValues(typeof(PlantClassification)).Cast<PlantClassification>().ToList();
            }

            private void PopulatePlants()
            {
                var fern = new Plant(1, "Polypodiaceae", "Pteridium", "aquilinum", "Bracken Fern", "A large fern commonly found in temperate forests.", "fern.jpg")
                {
                    Id = 1,
                    PhylumInfo = _phyla.First(p => p.Name == "Pteridophyta"),
                    IsEatable = false,
                    Color = "Green",
                    IsFlowering = false,
                    IsEvergreen = true,
                    TrimmingInstructions = "Trim dead fronds regularly",
                    TrimmingPeriod = "Spring",
                    TemperatureRange = "10-25°C",
                    IsPoisonous = false,
                    FertilizationMethod = "Compost",
                    Shape = "Spreading",
                    FullGrownHeight = "1.5m",
                    FullGrownWidth = "2m",
                    Pictures = new List<string> { "fern1.jpg", "fern2.jpg" }
                };

                var sunflower = new Plant(2, "Asteraceae", "Helianthus", "annuus", "Sunflower", "Tall, bright flower turning toward the sun.", "sunflower.jpg")
                {
                    Id = 2,
                    PhylumInfo = _phyla.First(p => p.Name == "Angiosperms"),
                    IsEatable = true,
                    Color = "Yellow",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Remove dead heads",
                    TrimmingPeriod = "Summer",
                    TemperatureRange = "15-30°C",
                    IsPoisonous = false,
                    FertilizationMethod = "Organic fertilizer",
                    Shape = "Upright",
                    FullGrownHeight = "3m",
                    FullGrownWidth = "0.5m",
                    Pictures = new List<string> { "sunflower1.jpg", "sunflower2.jpg" }
                };

                _plants = new List<Plant> { fern, sunflower };
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

            #endregion
        }
    }

}
