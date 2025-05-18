using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using PlantGuessingGame.DataModels;
using PlantGuessingGame.Enums;
using PlantGuessingGame.Interfaces;
using Windows.Storage;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PlantGuessingGame.Services
{

    /// <summary>
    /// Splitting your data access methods into public methods that manage the connection and private methods that perform the query/operation using an open connection is a widely recommended pattern in professional C# and database application development. Here’s why this pattern is preferred:

    //------------------------------------------------------------
    // NOTES ON 1. Connection Management and Reuse
    //------------------------------------------------------------
    // The public method is responsible for opening and closing the database connection(often via a using statement). This ensures that connections are always properly disposed of and returned to the connection pool, which is a best practice for performance and resource management.
    // The private method assumes the connection is already open, allowing you to reuse the same connection for multiple operations within a transaction or batch, avoiding unnecessary open/close cycles.
    //------------------------------------------------------------
    /// </summary>
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

                //testing for images
                await CreatePlantImageTable(db);

               
                //add enums
                PopulateItemTypes();
                await PopulatePhylaAsync(db);
                PopulateClassificationTypes();
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
        /// public method to delete an item from the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task DeleteItemAsync(Plant item)
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                await DeletePlantItemAsync(db, item.Id);
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

        /// <summary>
        /// Public method to add a new image for a parent item.
        /// </summary>
        /// <param name="parentId">The ID of the parent item.</param>
        /// <param name="imagePath">The file path of the image to add.</param>
        /// <returns>The ID of the inserted image.</returns>
        public async Task<int> AddItemImageAsync(int parentId, string imagePath)
        {
            byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);

            using (var db = await GetSqliteConnectionAsync())
            {
                return await InsertImageAsync(db, parentId, imageBytes);
            }
        }
        /// <summary>
        /// Public method to retrieve an image by its ID.
        /// </summary>
        /// <param name="id">The image ID.</param>
        /// <returns>The image data as a byte array, or null if not found.</returns>
        public async Task<byte[]> GetItemImageAsync(int id)
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                return await GetItemImageAsync(db, id);
            }
        }

        /// <summary>
        /// Retrieves all images for a given parent ID.
        /// </summary>
        /// <param name="parentId">The ID of the parent entity.</param>
        /// <returns>A list of image byte arrays.</returns>
        public async Task<List<byte[]>> GetImagesForParentAsync(int parentId)
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                return await GetImagesForParentAsync(db, parentId);
            }
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

                //get list from seeder
                var plants = PlantSeedData.GetAllPlants(_phyla);

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

        /// <summary>
        /// add list of classificaitonss
        /// </summary>
        private void PopulateClassificationTypes()
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

        /// <summary>
        /// method to delete a plant item from the database
        /// </summary>
        /// <param name="db"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task DeletePlantItemAsync(SqliteConnection db, int id)
        {
            await db.DeleteAsync<Plant>(new Plant { Id = id });
        }

        #endregion


        #region Methods SQL


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
        /// --> Updated example code for gettings a connection
        ///     -->20250518  evaluate to replace code above
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<SqliteConnection> GetSqliteConnectionAsyncRefined()
        {
            try
            {
                await ApplicationData.Current.LocalFolder
                    .CreateFileAsync(DbName, CreationCollisionOption.OpenIfExists)
                    .AsTask().ConfigureAwait(false);

                string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName);
                var cn = new SqliteConnection($"Filename={dbPath}");
                cn.Open();
                cn.Execute("PRAGMA journal_mode=WAL;"); // Optional: enables WAL mode
                return cn;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Failed to access ApplicationData.Current", ex);
            }
            // Optionally catch SqliteException for DB errors
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


        #region Methods for Blobbing


        /// -------------------------------------------------
        /// ------   STORING A LIST OF INTTEGERS WITH IDS ---------
        /// The best way to store a list of integers in a SQL (including SQLite) database is not to store them as a single value (e.g., comma-separated string, JSON, or BLOB), but rather to use a separate table where each integer in the list is stored as a row, linked to its parent entity via a foreign key. This is the standard relational approach and is both efficient and flexible.
        /// -------------------------------------------------
        //        CREATE TABLE Parent(
        //    ParentId INTEGER PRIMARY KEY,
        //    Name TEXT
        //);

        //        CREATE TABLE ParentIntList(
        //        ParentId INTEGER NOT NULL,
        //            Value INTEGER NOT NULL,
        //            FOREIGN KEY (ParentId) REFERENCES Parent(ParentId)
        //        );
        //      
        //  TO get all ids integers for a parten
        //  SELECT Value FROM ParentIntList WHERE ParentId = 1;
        //  To add an integers to a parents
        // INSERT INTO ParentIntList(ParentId, Value) VALUES(1, 10);
        /// -------------------------------------------------



        /// <summary>
        /// -------------------------------------------------
        /// create table for a blob (binary large objects)
        /// --> creates table with an auto incremented integer id for the BLOBS
        /// -------------------------------------------------
        /// Considerations and Best Practices
        // -->> Although storing images using the BLOB data type in SQL is possible, it may not always be the most efficient solution.Especially for numerous or large images, direct database storage could potentially impact performance and increase the database’s size significantly.In many cases, a more optimized approach involves storing images in a filesystem or cloud storage and maintaining database references(e.g., file paths or URLs).
        /// </summary>
        // / <param name="db"></param>
        /// <returns></returns>

        private async Task CreatePlantImageTable(SqliteConnection db)
        {
            // SQL command to create a table with an ImageID and a foreign key to the parent table (e.g., Plant)
            string tableCommand = @"
                CREATE TABLE IF NOT EXISTS ImageTable (
                    ImageID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ParentID INTEGER NOT NULL,
                    ImageData BLOB,
                    FOREIGN KEY (ParentID) REFERENCES ParentTable(ParentID)
                )";

            // create command
            var createTable = new SqliteCommand(tableCommand, db);

            // execute
            await createTable.ExecuteNonQueryAsync();
        }


        //----------------------------
        // REFACTOR
        // NOTE JCO --> adjust this with a private and public accessort
        //----------------------------


        /// <summary>
        /// Private helper to insert an image using an open database connection.
        /// </summary>
        /// <param name="db">An open SqliteConnection.</param>
        /// <param name="parentId">The ID of the parent item.</param>
        /// <param name="imageBytes">The image data as a byte array.</param>
        /// <returns>The ID of the inserted image.</returns>
        private async Task<int> InsertImageAsync(SqliteConnection db, int parentId, byte[] imageBytes)
        {
            var ids = await db.QueryAsync<long>(
                    @"INSERT INTO ImageTable (ParentID, ImageData) VALUES (@ParentID, @ImageData);
              SELECT last_insert_rowid();",
                new { ParentID = parentId, ImageData = imageBytes });

            return (int)ids.First();
        }

   
        /// <summary>
        /// Private helper to retrieve image data using an open database connection.
        /// </summary>
        /// <param name="db">An open SqliteConnection.</param>
        /// <param name="id">The image ID.</param>
        /// <returns>The image data as a byte array, or null if not found.</returns>
        private async Task<byte[]> GetItemImageAsync(SqliteConnection db, int id)
        {
            string sql = "SELECT ImageData FROM ImageTable WHERE ImageID = @Id";
            return await db.ExecuteScalarAsync<byte[]>(sql, new { Id = id });
        }

        /// <summary>
        /// Helper to retrieve all images for a parent using an open connection.
        /// </summary>
        /// <param name="db">An open SqliteConnection.</param>
        /// <param name="parentId">The parent ID.</param>
        /// <returns>A list of image byte arrays.</returns>
        private async Task<List<byte[]>> GetImagesForParentAsync(SqliteConnection db, int parentId)
        {
            string sql = "SELECT ImageData FROM ImageTable WHERE ParentID = @ParentID";
            var images = await db.QueryAsync<byte[]>(sql, new { ParentID = parentId });
            return images.ToList();
        }


        #endregion


    }
}
