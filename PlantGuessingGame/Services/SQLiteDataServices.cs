using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using PlantGuessingGame.DataModels;
using PlantGuessingGame.Enums;
using PlantGuessingGame.Interfaces;
using Windows.Storage;

namespace PlantGuessingGame.Services
{
    public class SQLiteDataService : IDataService
    {
        /// <summary>
        /// Local variable to store the connection strding
        /// </summary>
        private const string DbName = "PlantCollectionData.db";

        /// <summary>
        /// list with plant types
        /// </summary>
        private IList<PlantType> _plantTypes;

        /// <summary>
        /// list with phyla (note this is a known list that can be filled at start)
        /// </summary>
        private IList<Phylum> _phyla;

        /// <summary>
        /// list with plant classifications
        /// </summary>
        private IList<PlantClassification> _plantClassifications;

        /// <summary>
        /// list with plants (used for examples)
        /// </summary>
        private IList<Plant> _plants;

        /// <summary>
        /// connection string
        /// </summary>
        private readonly string _connectionString;

        public SQLiteDataService(string connectionString = null)
        {
            _connectionString = connectionString ?? $"Data Source={DbName}";
        }



        #region Public Methods


        /// <summary>
        /// initialisation of database
        /// --> note how this initialisaiton is necessary and therefore also part of the interface
        ///     else all public method would not return any value
        /// </summary>
        /// <returns></returns>
        public async Task InitializeDataAsync()
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                //create database tables
                await CreatePhylumTableAsync(db);
                await CreatePlantTableAsync(db);

                //add enums
                PopulateItemTypes();
                await PopulatePhylaAsync(db);
                PopulateLocationTypes();
                await PopulateExamplePLantsAsync(db);

            }
        }


        /// <summary>
        /// public method to add a new item to the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> AddItemAsync(Plant item)
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                return await InsertPlantAsync(db, item);
            }
        }


        /// <summary>
        /// public method to update an item in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task UpdateItemAsync(Plant item)
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                await UpdatePlantAsync(db, item);
            }
        }

        /// <summary>
        /// public method to get a plant from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Plant> GetItemAsync(int id)
        {
            IList<Plant> plantItems;

            using (var db = await GetSqliteConnectionAsync())
            {
                plantItems = await GetAllPlantsAsync(db);
            }

            // Filter the list to get the item for our Id.
            return plantItems.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// public method to get all of the plants from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Plant>> GetItemsAsync()
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                return await GetAllPlantsAsync(db);
            }
        }



        /// <summary>
        /// public method to get all of the available phyla
        /// </summary>
        /// <returns></returns>
        public IList<Phylum> GetPhyla()
        {
            return _phyla;
        }

        /// <summary>
        /// public method to get all of the available phyla for a specific plant type
        /// </summary>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public IList<Phylum> GetPhyla(PlantType plantType)
        {
            return _phyla
                .Where(m => m.PlantType == plantType)
                .ToList();
        }

        /// <summary>
        /// find phylum by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Phylum GetPhylumByName(string name)
        {
            //loop phyla
            foreach (var item in _phyla)
            {
                //match name
                if (item.Name.ToUpper() == name.ToUpper()) return item;

            }
            //return null
            return null;
        }

        #endregion



        #region Methods SQL

        /// <summary>
        /// method to insert a new media item into the database
        ///  SQL dapper code:
        ///         1. Insert into the MediaItems table 
        ///         2. the values are inserted by the VALUES statement and the parameters are added by the @nameof(item) and @nameof(item)
        ///         3. each value is taken from the item object media item and is referred by @ and variable name this refers to the parameter of the command
        ///         --> So note well, the first names are the names as given to the tables, the values are the names of the variables in the object
        /// </summary>
        /// <param name="db"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private async Task<int> InsertBasicPlantAsync(SqliteConnection db, Plant item)
        {
            var newIds = await db.QueryAsync<long>(
                    @"INSERT INTO Plants
                    (LocalName, CommonName, Genus, Species, Family, Description, ImagePath, PhylumId, PlantType, PlantClassification)
                    VALUES
                    (@LocalName, @CommonName, @Genus, @Species, @Family, @Description, @ImagePath, @PhylumId, @PlantType, @PlantClassification);
                    SELECT last_insert_rowid()", item);

            return (int)newIds.First();
        }

        //----------------------------------------------------------
        // InsertPlantAsync Extended
        // Includes also: IsEatable (bool), Color (string), IsFlowering (bool), IsEvergreen (bool),
        // TrimmingInstructions (string), TrimmingPeriod (string), TemperatureRangeMinimum (int),TemperatureRangeMaximum (int), IsPoisonous (bool)
        // FertilizationMethod (string), Shape (string), FullGrownHeight (int), FullGrownWidth (int)
        // Pictures (list<>string>) 
        //----------------------------------------------------------
        private async Task<int> InsertPlantAsync(SqliteConnection db, Plant item)
        {
            var newIds = await db.QueryAsync<long>(
                    @"INSERT INTO Plants
                    (LocalName, CommonName, Genus, Species, Family, Description, ImagePath, PhylumId, PlantType, PlantClassification,
                    IsEatable, Color, IsFlowering, IsEvergreen, TrimmingInstructions, TrimmingPeriod, TemperatureRangeMinimum, TemperatureRangeMaximum,
                    IsPoisonous, FertilizationMethod, Shape, FullGrownHeight, FullGrownWidth, PictureStringList)
                    VALUES
                    (@LocalName, @CommonName, @Genus, @Species, @Family, @Description, @ImagePath, @PhylumId, @PlantType, @PlantClassification,
                     @IsEatable, @Color, @IsFlowering, @IsEvergreen, @TrimmingInstructions, @TrimmingPeriod, @TemperatureRangeMinimum, @TemperatureRangeMaximum,
                    @IsPoisonous, @FertilizationMethod, @Shape, @FullGrownHeight, @FullGrownWidth, @Pictures);
                    SELECT last_insert_rowid()", item);

            return (int)newIds.First();
        }


        /// <summary>
        /// this method is used to insert a new phylum into the database
        ///  SQL dapper code:
        ///         1. Insert into the Phyla table the name and plant type
        ///         2. the values are inserted by the VALUES statement and the parameters are added by the @nameof(phylum.Name) and @nameof(phylum.PlantType)
        ///            @ here is used to indicate that it is a parameter of the command and the nameof() method is used to get the name of the properties
        ///         3. Select the last inserted row id
        ///         4. This is done by the SELECT last_insert_rowid() statement
        ///         
        /// </summary>
        /// <param name="db"></param>
        /// <param name="medium"></param>
        /// <returns></returns>
        private async Task InsertPhylumAsync(SqliteConnection db, Phylum phylum)
        {
            //insert the Phylum into the database
            var newIds = await db.QueryAsync<long>(
                $@"INSERT INTO Phyla ({nameof(phylum.Name)}, PlantType, {nameof(phylum.Description)}) 
                    VALUES 
                    (@{nameof(phylum.Name)}, @{nameof(phylum.PlantType)}, @{nameof(phylum.Description)});
                    SELECT last_insert_rowid()", phylum);

            //set the id of the phylum
            // This allows to get a values back from the database to know it completed successfully
            phylum.Id = (int)newIds.First();
        }




        #endregion

        #region Private Methods


        /// <summary>
        /// //method to create the PHylum table in the database
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private async Task PopulatePhylaAsync(SqliteConnection db)
        {
            _phyla = await GetAllPhylaAsync(db);

            //if the database has no info, then add the default list
            if (_phyla.Count == 0)
            {
                //add default phyla
                var Anthocerotophyta = new Phylum
                {
                    Id = 1,
                    Name = "Anthocerotophyta",
                    CommonName = "Hornworts",
                    PlantType = PlantType.Shrub,
                    Description = "Horn-shaped sporophytes, no vascular system"
                };
                var Bryophyta = new Phylum
                {
                    Id = 2,
                    Name = "Bryophyta",
                    CommonName = "Moss",
                    PlantType = PlantType.Shrub,
                    Description = "Persistent unbranched sporophytes, no vascular system"
                };
                var Charophyta = new Phylum
                {
                    Id = 3,
                    Name = "Charophyta",
                    CommonName = "Charophytes",
                    PlantType = PlantType.Other,
                    Description = "mainly autotrophs with exceptions and have the same chlorophyll a and b pigments as \"higher\" plant divisions"
                };
                var Chlorophyta = new Phylum
                {
                    Id = 4,
                    Name = "Chlorophyta",
                    CommonName = "Chlorophytes",
                    PlantType = PlantType.Other,
                    Description = ""
                };
                var Cycadophyta = new Phylum
                {
                    Id = 5,
                    Name = "Cycadophyta",
                    CommonName = "Cycads",
                    PlantType = PlantType.Tree,
                    Description = "Seeds, crown of compound leaves"
                };
                var Ginkgophyta = new Phylum
                {
                    Id = 6,
                    Name = "Ginkgophyta",
                    CommonName = "Ginkgo",
                    PlantType = PlantType.Tree,
                    Description = "Seeds not protected by fruit"
                };
                var Glaucophyta = new Phylum
                {
                    Id = 7,
                    Name = "Glaucophyta",
                    CommonName = "Glaucophytes",
                    PlantType = PlantType.Other,
                    Description = "XXX"
                };
                var Gnetophyta = new Phylum
                {
                    Id = 8,
                    Name = "Gnetophyta",
                    CommonName = "Gnetophytes",
                    PlantType = PlantType.Shrub,
                    Description = "Seeds and woody vascular system with vessels"
                };
                var Lycopodiophyta = new Phylum
                {
                    Id = 9,
                    Name = "Lycopodiophyta",
                    CommonName = "Clubmosses",
                    PlantType = PlantType.Creeper,
                    Description = "Microphyll leaves, vascular system"
                };
                var Magnoliophyta = new Phylum
                {
                    Id = 10,
                    Name = "Magnoliophyta",
                    CommonName = "Flowering plants, angiosperms",
                    PlantType = PlantType.Shrub,
                    Description = "Flowers and fruit, vascular system with vessels"
                };
                var Marchantiophyta = new Phylum
                {
                    Id = 11,
                    Name = "Marchantiophyta",
                    CommonName = "Liverworts",
                    PlantType = PlantType.Creeper,
                    Description = "Ephemeral unbranched sporophytes, no vascular system"
                };
                var Pinophyta = new Phylum
                {
                    Id = 12,
                    Name = "Pinophyta",
                    CommonName = "Conifers",
                    PlantType = PlantType.Shrub,
                    Description = "Cones containing seeds and wood composed of tracheids"
                };
                var Polypodiophyta = new Phylum
                {
                    Id = 13,
                    Name = "Polypodiophyta",
                    CommonName = "ferns, horsetails",
                    PlantType = PlantType.Tree,
                    Description = "Prothallus gametophytes and vascular system"
                };
                var Embryophyta = new Phylum
                {
                    Id = 14,
                    Name = "Embryophyta",
                    CommonName = "land plants",
                    PlantType = PlantType.Tree,
                    Description = "Embryophytes are complex multicellular eukaryotes with specialized reproductive organs."
                };
                var Tracheophyta = new Phylum
                {
                    Id = 15,
                    Name = "Tracheophyta",
                    CommonName = "Vascular plants",
                    PlantType = PlantType.Other,
                    Description = "Magnoliophyta – Cycadophyta – Ginkgophyta – Gnetophyta – Lycopodiophyta – Pinophyta – Pteridophyta – †Aneurophytophyta – †Asteroxylophyta – †Botryopteridiophyta – †Cladoxylophyta – †Cycadeoideophyta – †Lyginopteridophyta – †Moresnetiophyta – †Peltaspermophyta – †Psilophytophyta – †Rhyniophyta"
                };

                //create new list list
                var phyla = new List<Phylum>
                {
                    Anthocerotophyta,
                    Bryophyta,
                    Charophyta,
                    Chlorophyta,
                    Cycadophyta,
                    Ginkgophyta,
                    Glaucophyta,
                    Gnetophyta,
                    Lycopodiophyta,
                    Magnoliophyta,
                    Marchantiophyta,
                    Pinophyta,
                    Polypodiophyta,
                    Embryophyta,
                    Tracheophyta
                };

                //add the list 
                foreach (var phylum in phyla)
                {
                    await InsertPhylumAsync(db, phylum);
                }

                //add to local var
                _phyla = await GetAllPhylaAsync(db);
            }
        }

        /// <summary>
        /// //method to create the Plants table in the database
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private async Task PopulateExamplePLantsAsync(SqliteConnection db)
        {
            _plants = await GetAllPlantsAsync(db);

            //if the database has no info, then add the default list
            if (_plants.Count == 0)
            {
                var Nandina = new Plant
                {
                    Id = 0,
                    LocalName = "Nandina",
                    CommonName = "Heavenly Bamboo",
                    Family = "Berberidaceae",
                    Genus = "Nandina",
                    Species = "domestica",
                    Description = "A popular ornamental, upright evergreen shrub with beautiful red berries and colorful foliage. Native to eastern Asia, widely grown for its ornamental value. Leaves are purplish in spring and winter, green in summer, and red in autumn. Small white flowers in summer, followed by bright red berries that persist into winter.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    //set picturestringlist by converting the pictures to a single string
                    PlantType = PlantType.Shrub, // Broadleaf evergreen shrub[1][5][6]
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant[3]
                    PhylumInfo = GetPhylumByName("Embryophyta"), // Land plants
                                                                 // PhylumId will be set automatically if PhylumInfo is not null

                    // Eatable / non-eatable
                    IsEatable = false, // Not edible, berries are toxic[3][6]

                    // Color
                    Color = "Purple (spring/winter), Green (summer), Red (autumn), White (flowers), Red (berries)",

                    // Flowering
                    IsFlowering = true, // Yes, flowers in summer[6]

                    // Leaves all year / loses leaves
                    IsEvergreen = true, // Evergreen shrub[1][5][6]

                    // Trimming instructions and period
                    TrimmingInstructions = "Thin out old stems to maintain density and shape. Remove dead or damaged wood.",
                    TrimmingPeriod = "Late winter to early spring, after risk of frost[5]",

                    // Temperature range
                    TemperatureRangeMinimum = -18, // Hardy to USDA Zone 6, which is about -18°C[5]
                    TemperatureRangeMaximum = 35,  // Tolerates summer heat but prefers moderate climates (estimate based on general cultivation)

                    // Poisonous
                    IsPoisonous = true, // Berries are toxic to birds and mammals if ingested in quantity[3][5][6]

                    // Fertilization method
                    FertilizationMethod = "General-purpose fertilizer in spring. Not heavy feeders; avoid over-fertilization.",

                    // Shape
                    Shape = "Upright, bushy shrub with bamboo-like appearance[6]",

                    // Height(full grown)
                    FullGrownHeight = 200, // 2 meters (can reach up to 2.5 m)[6]

                    // Width(full grown)
                    FullGrownWidth = 150, // 1.5 meters[6]
                };


                //01
                var Haagbeuk = new Plant
                {
                    Id = 1,
                    LocalName = "Haagbeuk",
                    CommonName = "European Hornbeam",
                    Family = "Betulaceae",
                    Genus = "Carpinus",
                    Species = "betulus",
                    Description = "A deciduous tree often used for hedging, with a dense, narrow crown. Leaves are oval, double-serrated, and turn yellow to orange in autumn. Produces small, inconspicuous flowers in spring and winged nuts in autumn. Native to Europe and western Asia.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Tree, // Deciduous tree
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant[5]
                    PhylumInfo = GetPhylumByName("Magnoliophyta"), // Flowering plants

                    // Eatable / non-eatable
                    IsEatable = false, // Not edible

                    // Color
                    Color = "Green (spring/summer), Yellow-Orange (autumn)",

                    // Flowering
                    IsFlowering = true, // Small, inconspicuous flowers in spring

                    // Leaves all year / loses leaves
                    IsEvergreen = false, // Deciduous, loses leaves in autumn

                    // Trimming instructions and period
                    TrimmingInstructions = "Trim to shape in late summer if used as a hedge. Remove dead or diseased wood as needed.",
                    TrimmingPeriod = "Late summer for hedging; winter for structural pruning",

                    // Temperature range
                    TemperatureRangeMinimum = -30, // Hardy to at least USDA Zone 4 (~ -30°C)
                    TemperatureRangeMaximum = 35,  // Tolerates summer heat, prefers temperate climates

                    // Poisonous
                    IsPoisonous = false, // Not considered poisonous

                    // Fertilization method
                    FertilizationMethod = "Apply balanced fertilizer in early spring if soil is poor. Generally low maintenance.",

                    // Shape
                    Shape = "Upright tree with dense, oval to pyramidal crown. Can be pruned into hedges.",

                    // Height (full grown)
                    FullGrownHeight = 2000, // 20 meters (can reach up to 25 m)

                    // Width (full grown)
                    FullGrownWidth = 1500, // 15 meters (tree form); much less as a hedge
                };


                //Beech
                var BeukenHaag = new Plant
                {
                    Id = 2,
                    LocalName = "BeukenHaag",
                    CommonName = "European Beech",
                    Family = "Fagaceae",
                    Genus = "Fagus",
                    Species = "sylvatica",
                    Description = "A tree commonly used for hedges with small, serrated, wavy-edged leaves. Leaves are glossy green in spring and summer, turning coppery brown in autumn and often retained through winter. Forms a dense, elegant hedge that provides year-round interest.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Shrub, // Used as a hedge, typically maintained as a shrub[1][2][3]
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant
                    PhylumInfo = GetPhylumByName("Magnoliophyta"),

                    // Eatable / non-eatable
                    IsEatable = false, // Not edible in hedge form[4]

                    // Color
                    Color = "Green (spring/summer), Copper/Brown (autumn/winter)",

                    // Flowering
                    IsFlowering = true, // Produces small, inconspicuous flowers in spring

                    // Leaves all year / loses leaves
                    IsEvergreen = false, // Deciduous, but retains brown leaves through winter when used as a hedge[1][2][3]

                    // Trimming instructions and period
                    TrimmingInstructions = "Trim once in late summer (August) to maintain shape and density. For new hedges, light formative pruning in winter. Avoid pruning during bird nesting season (March–July). Remove old or diseased wood in early spring if needed.",
                    TrimmingPeriod = "Late summer (August) for main trim; light formative pruning in winter for young hedges[6][9][10]",

                    // Temperature range
                    TemperatureRangeMinimum = -25, // Hardy to at least USDA Zone 5 (~ -25°C)[1][2]
                    TemperatureRangeMaximum = 35,  // Tolerates summer heat, prefers moderate climates

                    // Poisonous
                    IsPoisonous = false, // Not considered poisonous[4]

                    // Fertilization method
                    FertilizationMethod = "Apply balanced fertilizer in early spring if soil is poor. Generally low maintenance.",

                    // Shape
                    Shape = "Dense, upright hedge with smooth, graceful branches and wavy-edged leaves[1][2]",

                    // Height (full grown)
                    FullGrownHeight = 750, // Up to 7.5 meters if unpruned, typically maintained at 1–3 meters as a hedge[2][3]

                    // Width (full grown)
                    FullGrownWidth = 200, // Typically maintained at 0.5–2 meters as a hedge[3]
                };


                //Hortensia flower
                var Hortensia = new Plant
                {
                    Id = 3,
                    LocalName = "Hortensia",
                    CommonName = "Bigleaf Hydrangea",
                    Family = "Hydrangeaceae", // Correct family for Hydrangea macrophylla[1][5][6]
                    Genus = "Hydrangea",
                    Species = "macrophylla",
                    Description = "A deciduous shrub widely cultivated for its large, globular or flattened clusters of showy flowers in shades of pink, blue, purple, and, rarely, white. Leaves are large, ovate, and serrated. Flower color varies with soil pH: blue in acidic soils, pink in alkaline. Blooms from summer into autumn. Native to Japan, popular in gardens worldwide.[1][3][5][6]",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Shrub, // Deciduous shrub[1][3][5][6]
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant[1]
                    PhylumInfo = GetPhylumByName("Magnoliophyta"), // Flowering plants[1]

                    // Eatable / non-eatable
                    IsEatable = false, // Not edible; potentially harmful if eaten, can cause stomach upset and is toxic to pets[6]

                    // Color
                    Color = "Pink, blue, purple, red, or white flowers (color depends on soil pH); dark green leaves[1][3][5][6]",

                    // Flowering
                    IsFlowering = true, // Yes, blooms in summer and autumn[1][3][5][6]

                    // Leaves all year / loses leaves
                    IsEvergreen = false, // Deciduous, loses leaves in autumn[1][3][5][6]

                    // Trimming instructions and period
                    TrimmingInstructions = "Prune after flowering by removing spent blooms and weak stems. Avoid heavy pruning, as flower buds form on old wood for most cultivars.",
                    TrimmingPeriod = "Late summer to early autumn, after flowering[5][6]",

                    // Temperature range
                    TemperatureRangeMinimum = -23, // Hardy to USDA Zone 5, about -23°C[4][5][7]
                    TemperatureRangeMaximum = 35,  // Tolerates summer heat if kept moist; prefers moderate climates

                    // Poisonous
                    IsPoisonous = true, // Harmful if eaten; can cause stomach upset and is toxic to pets[6]

                    // Fertilization method
                    FertilizationMethod = "Apply balanced, slow-release fertilizer in spring. Acidic fertilizer for blue flowers, lime for pink.",

                    // Shape
                    Shape = "Rounded, bushy shrub with large, globular or flattened flower clusters[1][5][6]",

                    // Height (full grown)
                    FullGrownHeight = 200, // Typically 1–2 meters, can reach up to 3 meters in ideal conditions[1][3][5][7][8]

                    // Width (full grown)
                    FullGrownWidth = 250, // Up to 2.5 meters wide[1][3][5][7][8]
                };



                //Plane Tree
                var Plane = new Plant
                {
                    Id = 4,
                    LocalName = "Plataan",
                    CommonName = "London Plane tree",
                    Family = "Platanaceae",
                    Genus = "Platanus",
                    Species = "acerifolia",
                    Description = "A large, fast-growing deciduous tree known for its distinctive mottled, exfoliating bark and broad, maple-like leaves. Widely planted in cities for its tolerance to pollution and pruning. Produces small, spherical fruit clusters that persist into winter.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Tree, // Large deciduous tree
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant
                    PhylumInfo = GetPhylumByName("Magnoliophyta"), // Flowering plants

                    // Eatable / non-eatable
                    IsEatable = false, // Not edible

                    // Color
                    Color = "Green leaves (spring/summer), yellow-brown (autumn), mottled cream/green/grey bark",

                    // Flowering
                    IsFlowering = true, // Inconspicuous flowers in spring

                    // Leaves all year / loses leaves
                    IsEvergreen = false, // Deciduous

                    // Trimming instructions and period
                    TrimmingInstructions = "Prune in late winter to early spring to remove dead or crossing branches. Can be pollarded to control size.",
                    TrimmingPeriod = "Late winter to early spring",

                    // Temperature range
                    TemperatureRangeMinimum = -20, // Hardy to at least -20°C (USDA zone 6)
                    TemperatureRangeMaximum = 40,  // Tolerates urban heat and drought

                    // Poisonous
                    IsPoisonous = false, // Not considered poisonous, but hairs on seeds can be irritating

                    // Fertilization method
                    FertilizationMethod = "Generally not required in urban soils. Mulch and water young trees.",

                    // Shape
                    Shape = "Broad, spreading crown with strong, upright branches",

                    // Height (full grown)
                    FullGrownHeight = 3000, // Up to 30 meters

                    // Width (full grown)
                    FullGrownWidth = 2000, // Up to 20 meters
                };


                //Apple tree
                var Apple = new Plant
                {
                    Id = 5,
                    LocalName = "Appel tree",
                    CommonName = "Apple Tree",
                    Family = "Rosaceae",
                    Genus = "Malus",
                    Species = "domestica",
                    Description = "A medium-sized, deciduous tree widely cultivated for its edible fruit. Apple trees produce showy white or pink-tinged flowers in spring, followed by crisp, sweet or tart apples in late summer to autumn. There are thousands of cultivars with varying fruit colors, flavors, and uses. Native to Central Asia, now grown worldwide.[4][6][7]",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Tree, // Deciduous fruit tree[4][6][7]
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant[4][6][7]
                    PhylumInfo = GetPhylumByName("Magnoliophyta"), // Flowering plants[4][6][7]

                    // Eatable / non-eatable
                    IsEatable = true, // Fruit is edible and widely consumed[4][6][7]

                    // Color
                    Color = "Green leaves (spring/summer), yellow/red/orange (autumn); white or pink flowers; fruit varies in color: red, green, yellow[4][6][7]",

                    // Flowering
                    IsFlowering = true, // Showy flowers in spring[4][6][7]

                    // Leaves all year / loses leaves
                    IsEvergreen = false, // Deciduous, loses leaves in autumn[4][6][7]

                    // Trimming instructions and period
                    TrimmingInstructions = "Prune in late winter to early spring to maintain shape, remove dead or diseased wood, and encourage productive branches. Young trees require formative pruning for strong structure.[4][5]",
                    TrimmingPeriod = "Late winter to early spring[4][5]",

                    // Temperature range
                    TemperatureRangeMinimum = -30, // Hardy to USDA zone 4, about -30°C[4][7]
                    TemperatureRangeMaximum = 35,  // Tolerates summer heat if well watered[5][7]

                    // Poisonous
                    IsPoisonous = false, // Fruit is edible; seeds contain amygdalin but are not hazardous in small quantities[7]

                    // Fertilization method
                    FertilizationMethod = "Apply balanced fertilizer in early spring if soil is poor. Mulch annually to retain moisture and provide nutrients.[5]",

                    // Shape
                    Shape = "Rounded, spreading crown with dense branching[4][6][7]",

                    // Height (full grown)
                    FullGrownHeight = 900, // Typically 2–9 meters depending on cultivar and rootstock[2][6][7]

                    // Width (full grown)
                    FullGrownWidth = 900, // 2–9 meters depending on cultivar and pruning[2][6][7]
                };


                //Alder
                var Alder = new Plant
                {
                    Id = 6,
                    LocalName = "Els",
                    CommonName = "Alder",
                    Family = "Betulaceae",
                    Genus = "Alnus",
                    Species = "glutinosa",
                    Description = "A medium-sized, fast-growing deciduous tree that thrives in wet soils, often along rivers and ponds. Recognizable by its dark, fissured bark, rounded leaves, and woody, cone-like fruits. Catkins appear in early spring, providing an important pollen source for insects. Native to Europe and western Asia.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Tree, // Deciduous tree
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant
                    PhylumInfo = GetPhylumByName("Magnoliophyta"), // Flowering plants

                    // Eatable / non-eatable
                    IsEatable = false, // Not edible

                    // Color
                    Color = "Green leaves (spring/summer), yellow (autumn); dark brown to black bark; brown catkins and cones",

                    // Flowering
                    IsFlowering = true, // Produces catkins in early spring

                    // Leaves all year / loses leaves
                    IsEvergreen = false, // Deciduous

                    // Trimming instructions and period
                    TrimmingInstructions = "Prune in late autumn or winter to remove dead or crossing branches. Minimal pruning required unless shaping or removing damaged wood.",
                    TrimmingPeriod = "Late autumn to winter",

                    // Temperature range
                    TemperatureRangeMinimum = -25, // Hardy to at least -25°C (USDA zone 5)
                    TemperatureRangeMaximum = 35,  // Tolerates summer heat if roots are moist

                    // Poisonous
                    IsPoisonous = false, // Not considered poisonous

                    // Fertilization method
                    FertilizationMethod = "Rarely needed; tolerates poor soils due to nitrogen-fixing roots. Mulch young trees to retain moisture.",

                    // Shape
                    Shape = "Pyramidal to rounded crown, often with multiple stems; can form dense thickets in wet areas",

                    // Height (full grown)
                    FullGrownHeight = 2500, // Up to 25 meters

                    // Width (full grown)
                    FullGrownWidth = 1000, // Up to 10 meters
                };


                //Tulip
                var Tulip = new Plant
                {
                    Id = 7,
                    LocalName = "Tulip",
                    CommonName = "Tulip",
                    Family = "Liliaceae",
                    Genus = "Tulipa",
                    Species = "gesneriana", // Most common cultivated species
                    Description = "A bulbous, spring-flowering perennial known for its vibrant, cup-shaped flowers in a wide range of colors. Tulips are iconic garden plants, especially in the Netherlands, and bloom from early to late spring depending on the variety. Leaves are lance-shaped and bluish-green. Bulbs are planted in autumn for spring display.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Bulb, // Bulbous perennial
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant
                    PhylumInfo = GetPhylumByName("Magnoliophyta"), // Flowering plants

                    // Eatable / non-eatable
                    IsEatable = false, // Not edible; bulbs and flowers can be toxic if ingested

                    // Color
                    Color = "Wide range: red, yellow, pink, purple, orange, white, and multicolored",

                    // Flowering
                    IsFlowering = true, // Yes, flowers in spring

                    // Leaves all year / loses leaves
                    IsEvergreen = false, // Dies back after flowering; dormant in summer

                    // Trimming instructions and period
                    TrimmingInstructions = "Remove spent flowers after blooming to prevent seed formation. Allow leaves to die back naturally to feed the bulb.",
                    TrimmingPeriod = "Deadhead after flowering; remove foliage only once it has yellowed and died back (late spring to early summer)",

                    // Temperature range
                    TemperatureRangeMinimum = -25, // Hardy to at least -25°C (USDA zone 5)
                    TemperatureRangeMaximum = 30,  // Prefers cool to moderate climates; bulbs go dormant in summer heat

                    // Poisonous
                    IsPoisonous = true, // Bulbs and flowers are toxic if eaten, especially to pets

                    // Fertilization method
                    FertilizationMethod = "Apply a balanced bulb fertilizer at planting and again as shoots emerge in spring.",

                    // Shape
                    Shape = "Upright, cup-shaped flowers on single, unbranched stems; lance-shaped leaves",

                    // Height (full grown)
                    FullGrownHeight = 60, // Most garden tulips reach 20–60 cm

                    // Width (full grown)
                    FullGrownWidth = 15, // Each plant typically 10–15 cm wide
                };


                //Narcis
                var Narcis = new Plant
                {
                    Id = 8,
                    LocalName = "Narcis",
                    CommonName = "Daffodil",
                    Family = "Amaryllidaceae",
                    Genus = "Narcissus",
                    Species = "pseudonarcissus", // Most common wild and cultivated daffodil
                    Description = "A spring-flowering perennial bulb known for its trumpet-shaped flowers, typically yellow or white, sometimes with orange or pink centers. Leaves are long, slender, and bluish-green. Narcissus species are widely grown in gardens and naturalized in meadows and woodlands. Bulbs are planted in autumn for a cheerful spring display.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Bulb, // Bulbous perennial
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant
                    PhylumInfo = GetPhylumByName("Magnoliophyta"), // Flowering plants

                    // Eatable / non-eatable
                    IsEatable = false, // Not edible; bulbs and all parts are toxic if ingested

                    // Color
                    Color = "Yellow, white, orange, or bicolored flowers; bluish-green leaves",

                    // Flowering
                    IsFlowering = true, // Yes, blooms in early to mid-spring

                    // Leaves all year / loses leaves
                    IsEvergreen = false, // Dies back after flowering; dormant in summer

                    // Trimming instructions and period
                    TrimmingInstructions = "Remove spent flowers after blooming to prevent seed formation. Allow leaves to die back naturally to feed the bulb.",
                    TrimmingPeriod = "Deadhead after flowering; remove foliage only once it has yellowed and died back (late spring)",

                    // Temperature range
                    TemperatureRangeMinimum = -20, // Hardy to at least -20°C (USDA zone 6)
                    TemperatureRangeMaximum = 30,  // Prefers cool to moderate climates; bulbs go dormant in summer heat

                    // Poisonous
                    IsPoisonous = true, // All parts, especially bulbs, are toxic if eaten

                    // Fertilization method
                    FertilizationMethod = "Apply a low-nitrogen, high-potassium fertilizer as shoots emerge in spring. Mulch in autumn to protect bulbs.",

                    // Shape
                    Shape = "Upright, trumpet-shaped flowers on leafless stems; slender, strap-like leaves",

                    // Height (full grown)
                    FullGrownHeight = 45, // Most daffodils reach 20–45 cm

                    // Width (full grown)
                    FullGrownWidth = 15, // Each plant typically 10–15 cm wide
                };


                //English Oak"
                var EnglishOak = new Plant
                {
                    Id = 0,
                    LocalName = "Zomereik",
                    CommonName = "English Oak",
                    Family = "Fagaceae",
                    Genus = "Quercus",
                    Species = "robur",
                    Description = "A large, long-lived deciduous tree with a broad, spreading crown, deeply lobed leaves, and distinctive acorns. Known for its strong, durable wood and ecological value in supporting wildlife. Bark is greyish-brown and deeply fissured with age. Leaves are dark green above, paler below, with 3–7 rounded lobes per side and short petioles. Produces yellow catkins in spring and oval acorns on long stalks in autumn.",

                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Tree, // Large deciduous tree[1][2][3][6][7][8]
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant[2][6]
                    PhylumInfo = GetPhylumByName("Magnoliophyta"), // Flowering plants[2][6]

                    // Eatable / non-eatable
                    IsEatable = false, // Not edible for humans; acorns are consumed by wildlife[6]

                    // Color
                    Color = "Green leaves (spring/summer), yellow/brown (autumn); greyish-brown bark; brown acorns[1][2][7][8]",

                    // Flowering
                    IsFlowering = true, // Inconspicuous yellow catkins in spring[1][6]

                    // Leaves all year / loses leaves
                    IsEvergreen = false, // Deciduous[1][2][3][6][8]

                    // Trimming instructions and period
                    TrimmingInstructions = "Prune in winter to remove dead, diseased, or crossing branches. Minimal pruning required for mature trees.",
                    TrimmingPeriod = "Winter (dormant season)[2][6]",

                    // Temperature range
                    TemperatureRangeMinimum = -25, // Hardy to at least -25°C (USDA zone 5)[7]
                    TemperatureRangeMaximum = 35,  // Tolerates summer heat if well established[7]

                    // Poisonous
                    IsPoisonous = false, // Not considered poisonous, though acorns contain tannins and are not suitable for raw human consumption[6]

                    // Fertilization method
                    FertilizationMethod = "Rarely needed; prefers deep, fertile, well-drained soils. Mulch young trees to retain moisture.",

                    // Shape
                    Shape = "Broad, spreading crown with sturdy branches and a short, thick trunk[1][2][3][7][8]",

                    // Height (full grown)
                    FullGrownHeight = 4000, // Up to 40 meters (typically 20–40 m)[1][2][6][7][8]

                    // Width (full grown)
                    FullGrownWidth = 2500, // Up to 25 meters (broad crown)[1][2][3][7][8]
                };


                //Strawberry
                var Strawberry = new Plant
                {
                    Id = 0,
                    LocalName = "Aardbei",
                    CommonName = "Strawberry",
                    Family = "Rosaceae",
                    Genus = "Fragaria",
                    Species = "ananassa",
                    Description = "A low-growing, herbaceous perennial plant known for its sweet, red, edible fruits. Leaves are trifoliate with toothed margins, and white flowers with yellow centers appear in spring. Fruits develop from the flower base and are technically aggregate accessory fruits. Plants spread via runners (stolons) and are widely cultivated in gardens and farms worldwide.",

                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Herb, // Low-growing herbaceous perennial
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant
                    PhylumInfo = GetPhylumByName("Magnoliophyta"), // Flowering plants

                    // Eatable / non-eatable
                    IsEatable = true, // Fruit is edible and widely consumed

                    // Color
                    Color = "Green leaves; white flowers with yellow centers; red fruit",

                    // Flowering
                    IsFlowering = true, // Yes, flowers in spring and early summer

                    // Leaves all year / loses leaves
                    IsEvergreen = true, // In mild climates can be semi-evergreen; in cold climates, leaves die back in winter

                    // Trimming instructions and period
                    TrimmingInstructions = "Remove old leaves and runners after fruiting to encourage new growth. Thin plants as needed to prevent overcrowding.",
                    TrimmingPeriod = "After fruiting (late summer to early autumn)",

                    // Temperature range
                    TemperatureRangeMinimum = -15, // Hardy to about -15°C (USDA zone 7), some varieties even lower
                    TemperatureRangeMaximum = 30,  // Prefers cool to warm climates; protect from extreme summer heat

                    // Poisonous
                    IsPoisonous = false, // Not poisonous

                    // Fertilization method
                    FertilizationMethod = "Apply balanced fertilizer in early spring and after the first harvest. Mulch to retain moisture and suppress weeds.",

                    // Shape
                    Shape = "Low, spreading mound with trifoliate leaves and runners forming new plants",

                    // Height (full grown)
                    FullGrownHeight = 20, // 10–20 cm

                    // Width (full grown)
                    FullGrownWidth = 50, // 30–50 cm or more as plants spread by runners
                };


                //create new list list
                var plants = new List<Plant>
                {
                    Nandina,
                    Haagbeuk,
                    BeukenHaag,
                    Hortensia,
                    Plane,
                    Apple,
                    Alder,
                    Tulip,
                    Narcis,
                    EnglishOak,
                    Strawberry
                };

                //add the list 
                foreach (var plant in plants)
                {
                    await InsertPlantAsync(db, plant);
                }

                //add to local var
                _plants = await GetAllPlantsAsync(db);
            }

        }

        /// <summary>
        /// method to create the Mediums table in the database
        /// </summary>
        private void PopulateItemTypes()
        {
            _plantTypes = new List<PlantType>
            {
                PlantType.Climber,
                PlantType.Tree,
                PlantType.Herb,
                PlantType.Creeper,
                PlantType.Shrub
            };
        }

        private void PopulateLocationTypes()
        {
            _plantClassifications = new List<PlantClassification>
            {
                PlantClassification.Gymnosperms,
                PlantClassification.Angiosperms,
                PlantClassification.Bryophyta,
                PlantClassification.Pteridophyta,
                PlantClassification.Thallophyta

            };
        }



        #endregion


        #region Methods SQL (test to create)


        /// <summary>
        /// method to add a new item to the database
        /// --> creates a new file if it does not exist else opens the existing file
        /// </summary>
        /// <returns></returns>
        private async Task<SqliteConnection> GetSqliteConnectionAsync()
        {
            try
            {

                //try to get ApplicationData.Current
                await ApplicationData.Current.LocalFolder.CreateFileAsync(DbName, CreationCollisionOption.OpenIfExists).AsTask().ConfigureAwait(false);

                //create the connection string
                string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName);

                //create a new connection
                var cn = new SqliteConnection($"Filename={dbPath}");

                //open the connection
                cn.Open();

                //return the connection
                return cn;

            }
            catch (InvalidOperationException ex)
            {
                // Handle the exception or log it
                throw new Exception("Failed to access ApplicationData.Current", ex);
            }
        }




        /// <summary>
        /// sql method to create the Phylum table in the database
        ///  SQL dapper code:
        ///     1. Create table if not exist (so we can run this always)
        ///     2. Table name is Mediums and has autoincrement Id, which is the primary key
        ///     3. the table has a name and a medium type that are not null
        ///     4. the medium type is an integer, name is a string
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private async Task CreatePhylumTableAsync(SqliteConnection db)
        {
            string tableCommand = @"CREATE TABLE IF NOT EXISTS 
                Phyla (Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                Name NVARCHAR(30) NOT NULL, 
                PlantType INTEGER NOT NULL,
                Description TEXT)";

            var createTable = new SqliteCommand(tableCommand, db);

            await createTable.ExecuteNonQueryAsync();
        }

        /// <summary>
        /// sql method to create the Plant table in the database
        ///  SQL dapper code:
        ///     1. Create table if not exist (so we can run this always)
        ///     2. Table name is Plant and has autoincrement Id, which is the primary key
        ///     3. the table has a name, item type, medium id and location type that are not null
        ///     4. the item type, medium id and location type are integers, name is a string
        ///     5. the medium id is a foreign key to the Mediums table, this is done by the CONSTRAINT fk_mediums and the FOREIGN KEY(MediumId) REFERENCES Mediums(Id)
        ///        constraint is needed to make sure that the medium id is a valid id in the Mediums table, if not it will throw an error, this is a referential integrity constraint
        ///        the foreign key field is the MediumId in the MediaItems table and the primary key field is the Id in the Mediums table
        ///     
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private async Task CreateBasicPlantTableAsync(SqliteConnection db)
        {
            string tableCommand = @"CREATE TABLE IF NOT EXISTS 
                Plants (Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                LocalName NVARCHAR(1000) NOT NULL, 
                CommonName NVARCHAR(1000) NOT NULL, 
                Genus NVARCHAR(1000), 
                Species NVARCHAR(1000), 
                Family NVARCHAR(1000), 
                Description NVARCHAR(3000), 
                ImagePath NVARCHAR(1000), 
                PhylumId INTEGER NOT NULL, 
                PlantType INTEGER NOT NULL, 
                PlantClassification INTEGER, 
                CONSTRAINT fk_phyla 
                FOREIGN KEY(PhylumId) REFERENCES Phyla(Id))";

            var createTable = new SqliteCommand(tableCommand, db);

            await createTable.ExecuteNonQueryAsync();
        }

        //-------------------------------------
        // Create extended table
        // Includes also: IsEatable (bool), Color (string), IsFlowering (bool), IsEvergreen (bool),
        // TrimmingInstructions (string), TrimmingPeriod (string), TemperatureRangeMinimum (int),TemperatureRangeMaximum (int), IsPoisonous (bool)
        // FertilizationMethod (string), Shape (string), FullGrownHeight (int), FullGrownWidth (int)
        // Pictures (list<>string>) 
        //-------------------------------------
        // --> NOte:In SQLite, boolean values are typically stored as integers (0 for false, 1 for true), which is reflected in the IsActive property of the Product class.
        // SQLite does not support array or list types directly as a column type. However, you can store a list of strings in a single column by using a string representation, such as a comma-separated list. When you retrieve the data, you can then split the string back into a list.
        //-------------------------------------
        private async Task CreatePlantTableAsync(SqliteConnection db)
        {

            db.Open();

            string tableCommand = @"CREATE TABLE IF NOT EXISTS 
                Plants (Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                LocalName NVARCHAR(1000) NOT NULL, 
                CommonName NVARCHAR(1000) NOT NULL, 
                Genus NVARCHAR(1000), 
                Species NVARCHAR(1000), 
                Family NVARCHAR(1000), 
                Description NVARCHAR(3000), 
                ImagePath NVARCHAR(1000), 
                PhylumId INTEGER, 
                PlantType INTEGER, 
                PlantClassification INTEGER, 
				IsEatable INTEGER,
                Color NVARCHAR(100), 
				IsFlowering INTEGER,
				IsEvergreen INTEGER,
                TrimmingInstructions NVARCHAR(1000), 
                TrimmingPeriod NVARCHAR(100), 
				TemperatureRangeMinimum INTEGER,
				TemperatureRangeMaximum INTEGER,
				IsPoisonous INTEGER,
                FertilizationMethod NVARCHAR(1000), 
                Shape NVARCHAR(100), 
				FullGrownHeight INTEGER,
				FullGrownWidth INTEGER,
				PictureStringList TEXT,
                CONSTRAINT fk_phyla 
                FOREIGN KEY(PhylumId) REFERENCES Phyla(Id))";

            var createTable = new SqliteCommand(tableCommand, db);

            await createTable.ExecuteNonQueryAsync();
        }

        /// <summary>
        /// method to get all of the phyla from the database using Dapper
        ///  SQL dapper code:
        ///         1. Select the Id, Name, PlantType and description from the Phyla table
        ///         2. This is done by the SELECT statement
        ///         3. the selected table is the Phyla table as noted by the FROM Phyla statement
        ///         4. the results are returned as a list
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private async Task<IList<Phylum>> GetAllPhylaAsync(SqliteConnection db)
        {
            var mediums =
                await db.QueryAsync<Phylum>(@"SELECT Id, 
                                                     Name, 
                                                     PlantType AS PlantType,
                                                     Description
                                                     FROM Phyla");

            return mediums.ToList();
        }

        /// <summary>
        /// get list with all plants
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private async Task<IList<Plant>> GetAllPlantsBasicAsync(SqliteConnection db)
        {

            //---> SQL to only get the plant table
            //var plants =
            //    await db.QueryAsync<Plant>(@"SELECT Id, 
            //                                         CommonName,
            //                                         Genus,
            //                                         Species,
            //                                         Family,
            //                                         Description,
            //                                         ImagePath,
            //                                         PhylumId,
            //                                         PlantType AS PlantType,
            //                                         PlantClassification as PlantClassification                                                     FROM Plants");

            //-->  Get plant table but join Phylum table as well based on ID
            var plants = await db.QueryAsync<Plant, Phylum, Plant>
            (
                @"SELECT
                                        [Plants].[Id],
                                        [Plants].[LocalName],
                                        [Plants].[CommonName],
                                        [Plants].[Genus],
                                        [Plants].[Species],
                                        [Plants].[Family],
                                        [Plants].[Description],
                                        [Plants].[ImagePath],
                                        [Plants].[PlantType] AS PlantType,
                                        [Plants].[PlantClassification] AS PlantClassification,
                                        [Phyla].[Id],
                                        [Phyla].[Name],
                                        [Phyla].[PlantType] AS PlantType
                                    FROM
                                        [Plants]
                                    JOIN
                                        [Phyla]
                                    ON
                                        [Phyla].[Id] = [Plants].[PhylumId]",
                (item, phylum) =>
                {
                    //set inside table
                    item.PhylumInfo = phylum;

                    //return item
                    return item;
                }
            );

            //return list
            return plants.ToList();
        }

        /// <summary>
        /// get list with all plants (extended info)
        // Includes also: IsEatable (bool), Color (string), IsFlowering (bool), IsEvergreen (bool),
        // TrimmingInstructions (string), TrimmingPeriod (string), TemperatureRangeMinimum (int),TemperatureRangeMaximum (int), IsPoisonous (bool)
        // FertilizationMethod (string), Shape (string), FullGrownHeight (int), FullGrownWidth (int)
        // Pictures (list<>string>) 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private async Task<IList<Plant>> GetAllPlantsAsync(SqliteConnection db)
        {

            //---> SQL to only get the plant table
            //var plants =
            //    await db.QueryAsync<Plant>(@"SELECT Id, 
            //                                         CommonName,
            //                                         Genus,
            //                                         Species,
            //                                         Family,
            //                                         Description,
            //                                         ImagePath,
            //                                         PhylumId,
            //                                         PlantType AS PlantType,
            //                                         PlantClassification as PlantClassification                                                     FROM Plants");

            //-->  Get plant table but join Phylum table as well based on ID
            var plants = await db.QueryAsync<Plant, Phylum, Plant>
            (
                @"SELECT
                                        [Plants].[Id],
                                        [Plants].[LocalName],
                                        [Plants].[CommonName],
                                        [Plants].[Genus],
                                        [Plants].[Species],
                                        [Plants].[Family],
                                        [Plants].[Description],
                                        [Plants].[ImagePath],
                                        [Plants].[PlantType] AS PlantType,
                                        [Plants].[PlantClassification] AS PlantClassification,
                                        [Plants].[IsEatable],
                                        [Plants].[Color],
                                        [Plants].[IsFlowering],
                                        [Plants].[IsEvergreen],
                                        [Plants].[TrimmingInstructions],
                                        [Plants].[TrimmingPeriod],
                                        [Plants].[TemperatureRangeMinimum],
                                        [Plants].[TemperatureRangeMaximum],
                                        [Plants].[IsPoisonous],
                                        [Plants].[FertilizationMethod],
                                        [Plants].[Shape],
                                        [Plants].[FullGrownHeight],
                                        [Plants].[FullGrownWidth],
                                        [Plants].[PictureStringList],
                                        [Phyla].[Id],
                                        [Phyla].[Name],
                                        [Phyla].[PlantType] AS PlantType
                                    FROM
                                        [Plants]
                                    JOIN
                                        [Phyla]
                                    ON
                                        [Phyla].[Id] = [Plants].[PhylumId]",
                (item, phylum) =>
                {
                    //set inside table
                    item.PhylumInfo = phylum;

                    //return item
                    return item;
                }
            );

            //return list
            return plants.ToList();
        }



        /// <summary>
        /// method to update a plant in the database
        ///  SQL dapper code:
        ///         1. Update the plant table with the CommonName, Genus, Species, Family, Description, ImagePath, PhylumId, PlantType and PlantClassification.
        ///         2. the values are updated by the SET statement and the parameters are added by the @nameof(item) and @nameof(item)
        ///         3. each value is taken from the item object media item and is referred by @ and variable name this refers to the parameter of the command
        ///         4. the item is updated where the Id is the same as the item id
        ///         5. this is done by the WHERE Id = @Id statement, @id refers to the item id this auto references 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private async Task UpdateBasicPlantAsync(SqliteConnection db, Plant plant)
        {
            await db.QueryAsync(
                    @"UPDATE Plants
                    SET 
                      LocalName = @LocalName,
                      CommonName = @CommonName,
                      Genus = @Genus,
                      Species = @Species,
                      Family = @Family,
                      Description = @Description,
                      ImagePath = @ImagePath,
                      PhylumId = @PhylumId,
                      PlantType = @PlantType
                  WHERE Id = @Id;", plant);
        }

        //--------------------------------------------
        // UpdatePlantAsync Extended
        //--------------------------------------------
        // Includes also: IsEatable (bool), Color (string), IsFlowering (bool), IsEvergreen (bool),
        // TrimmingInstructions (string), TrimmingPeriod (string), TemperatureRangeMinimum (int),TemperatureRangeMaximum (int), IsPoisonous (bool)
        // FertilizationMethod (string), Shape (string), FullGrownHeight (int), FullGrownWidth (int)
        // Pictures (list<>string>) 
        //--------------------------------------------
        private async Task UpdatePlantAsync(SqliteConnection db, Plant plant)
        {
            await db.QueryAsync(
                    @"UPDATE Plants
                    SET 
                      LocalName = @LocalName,
                      CommonName = @CommonName,
                      Genus = @Genus,
                      Species = @Species,
                      Family = @Family,
                      Description = @Description,
                      ImagePath = @ImagePath,
                      PhylumId = @PhylumId,
                      PlantType = @PlantType,
                      IsEatable = @IsEatable,
                      Color = @Color,
                      IsFlowering = @IsFlowering,
                      IsEvergreen = @IsEvergreen,
                      TrimmingInstructions = @TrimmingInstructions,
                      TrimmingPeriod = @TrimmingPeriod,
                      TemperatureRangeMinimum = @TemperatureRangeMinimum,
                      TemperatureRangeMaximum = @TemperatureRangeMaximum,
                      IsPoisonous = @IsPoisonous,
                      FertilizationMethod = @FertilizationMethod,
                      Shape = @Shape,
                      FullGrownHeight = @FullGrownHeight,
                      FullGrownWidth = @FullGrownWidth,
                      PictureStringList = @PictureStringList
                  WHERE Id = @Id;", plant);
        }

        #endregion




        #region Tasks


        public async Task DeleteItemAsync(Plant item)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();

                var deleteQuery = @"DELETE FROM Plants WHERE Id = @Id";
                await connection.ExecuteAsync(deleteQuery, new { Id = item.Id });

                var deleteLinksQuery = @"DELETE FROM PlantLinks WHERE PlantId = @Id";
                await connection.ExecuteAsync(deleteLinksQuery, new { Id = item.Id });
            }
        }

        #endregion


        #region Synchronous Methods

        public IList<PlantType> GetItemTypes()
        {
            return Enum.GetValues(typeof(PlantType)).Cast<PlantType>().ToList();
        }

        public Phylum GetPhylum(string name)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Phylum>("SELECT * FROM Phyla WHERE Name = @Name", new { Name = name });
            }
        }

        public IList<PlantClassification> GetPlantClassifications()
        {
            return Enum.GetValues(typeof(PlantClassification)).Cast<PlantClassification>().ToList();
        }

        public int SelectedItemId { get; set; }

        #endregion
    }
}
