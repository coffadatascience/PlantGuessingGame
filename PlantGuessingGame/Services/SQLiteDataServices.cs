using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private async Task<int> InsertPlantAsync(SqliteConnection db, Plant item)
        {
            var newIds = await db.QueryAsync<long>(
                    @"INSERT INTO Plants
                    (CommonName, Genus, Species, Family, Description, ImagePath, PhylumId, PlantType, PlantClassification)
                    VALUES
                    (@CommonName, @Genus, @Species, @Family, @Description, @ImagePath, @PhylumId, @PlantType, @PlantClassification);
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
                var Anthocerotophyta = new Phylum { Id = 1, Name = "Anthocerotophyta", PlantType = PlantType.Shrub, Description = "Horn-shaped sporophytes, no vascular system" };
                var Bryophyta = new Phylum { Id = 2, Name = "Bryophyta", PlantType = PlantType.Shrub, Description = "Persistent unbranched sporophytes, no vascular system" };
                var Embryophyta = new Phylum { Id = 3, Name = "Embryophyta", PlantType = PlantType.Tree, Description = "" };

                //create new list list
                var phyla = new List<Phylum>
                {
                    Anthocerotophyta,
                    Bryophyta,
                    Embryophyta
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
                //add default plants
                //01
                var Haagbeuk = new Plant
                {
                    Id = 1,
                    CommonName = "Haagbeuk",
                    //set phylum
                    PhylumInfo = _phyla[2]
                };
                //02
                var BeukenHaag = new Plant
                {
                    Id = 1,
                    CommonName = "BeukenHaag",
                    PhylumInfo = _phyla[2]
                };


                //create new list list
                var plants = new List<Plant>
                {
                    Haagbeuk,
                    BeukenHaag
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
        private async Task CreatePlantTableAsync(SqliteConnection db)
        {
            string tableCommand = @"CREATE TABLE IF NOT EXISTS 
                Plants (Id INTEGER PRIMARY KEY AUTOINCREMENT, 
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
        private async Task<IList<Plant>> GetAllPlantsAsync(SqliteConnection db)
        {
            var plants =
                await db.QueryAsync<Plant>(@"SELECT Id, 
                                                     CommonName,
                                                     Genus,
                                                     Species,
                                                     Family,
                                                     Description,
                                                     ImagePath,
                                                     PhylumId,
                                                     PlantType AS PlantType,
                                                     PlantClassification as PlantClassification                                                     FROM Plants");

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
        private async Task UpdatePlantAsync(SqliteConnection db, Plant plant)
        {
            await db.QueryAsync(
                    @"UPDATE Plants
                    SET 
                      CommonName = @CommonName,
                      Genus = @Genus,
                      Species = @Species,
                      Family = @Family
                      Description = @Description
                      ImagePath = @ImagePath
                      PhylumId = @PhylumId
                      PlantType = @PlantType
                  WHERE Id = @Id;", plant);
        }



        #endregion




        #region Tasks



        public async Task<int> AddItemAsyncByChatGPT(Plant item)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();

                var insertQuery = @"INSERT INTO Plants (Name, Type, Phylum, Classification, Location) 
                                    VALUES (@Name, @Type, @Phylum, @Classification, @Location)";

                var plantId = await connection.ExecuteAsync(insertQuery, item);

                // Optionally add associated links
                if (item.Pictures != null && item.Pictures.Any())
                {
                    foreach (var link in item.Pictures)
                    {
                        var linkQuery = @"INSERT INTO PlantLinks (PlantId, Link) VALUES (@PlantId, @Link)";
                        await connection.ExecuteAsync(linkQuery, new { PlantId = plantId, Link = link });
                    }
                }

                return plantId;
            }
        }

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
