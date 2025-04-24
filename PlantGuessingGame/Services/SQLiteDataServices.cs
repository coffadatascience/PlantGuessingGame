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
        /// Local variable to store the connection string
        /// </summary>
        private const string DbName = "PlantCollectionData.db";

        /// <summary>
        /// list with plant types
        /// </summary>
        private IList<PlantType> _plantTypes;

        /// <summary>
        /// list with plant classifications
        /// </summary>
        private IList<PlantClassification> _plantClassifications;


        private readonly string _connectionString;

        public SQLiteDataService(string connectionString = null)
        {
            _connectionString = connectionString ?? $"Data Source={DbName}";
        }


        #region Methods SQL (test to create)

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
                PopulateLocationTypes();

                //await PopulateMediumsAsync(db);
            }
        }


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
                Name NVARCHAR(1000) NOT NULL, 
                PlantType INTEGER NOT NULL, 
                PhylumId INTEGER NOT NULL, 
                PlantType INTEGER, 
                CONSTRAINT fk_phyla 
                FOREIGN KEY(PhylumId) REFERENCES Phyla(Id))";

            var createTable = new SqliteCommand(tableCommand, db);

            await createTable.ExecuteNonQueryAsync();
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



        #region Tasks

        /// <summary>
        /// 20250424 replaced by split commands
        /// </summary>
        /// <returns></returns>
        public async Task InitializeDataAsyncBYGPT()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Initialize database tables
                var createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Plants (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Type TEXT,
                        Phylum TEXT,
                        Classification TEXT,
                        Location TEXT);

                    CREATE TABLE IF NOT EXISTS PlantLinks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PlantId INTEGER,
                        Link TEXT,
                        FOREIGN KEY (PlantId) REFERENCES Plants(Id));";

                await connection.ExecuteAsync(createTableQuery);
            }
        }

        public async Task<IList<Plant>> GetItemsAsync()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Fetch plants with linked data (if any)
                var plants = await connection.QueryAsync<Plant>(
                    @"SELECT * FROM Plants p
                      LEFT JOIN PlantLinks l ON p.Id = l.PlantId");

                return plants.ToList();
            }
        }

        public async Task<Plant> GetItemAsync(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Fetch specific plant and its associated links
                var plant = await connection.QueryFirstOrDefaultAsync<Plant>(
                    @"SELECT * FROM Plants p
                      LEFT JOIN PlantLinks l ON p.Id = l.PlantId
                      WHERE p.Id = @Id", new { Id = id });

                return plant;
            }
        }

        public async Task<int> AddItemAsync(Plant item)
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

        public async Task UpdateItemAsync(Plant item)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();

                var updateQuery = @"UPDATE Plants 
                                    SET Name = @Name, Type = @Type, Phylum = @Phylum, 
                                        Classification = @Classification, Location = @Location
                                    WHERE Id = @Id";

                await connection.ExecuteAsync(updateQuery, item);

                // Optionally update associated links
                if (item.Pictures != null && item.Pictures.Any())
                {
                    var deleteLinksQuery = @"DELETE FROM PlantLinks WHERE PlantId = @PlantId";
                    await connection.ExecuteAsync(deleteLinksQuery, new { PlantId = item.Id });

                    foreach (var link in item.Pictures)
                    {
                        var insertLinkQuery = @"INSERT INTO PlantLinks (PlantId, Link) VALUES (@PlantId, @Link)";
                        await connection.ExecuteAsync(insertLinkQuery, new { PlantId = item.Id, Link = link });
                    }
                }
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

        public IList<Phylum> GetPhyla()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Phylum>("SELECT * FROM Phyla").ToList();
            }
        }

        public IList<Phylum> GetPhyla(PlantType itemType)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Phylum>("SELECT * FROM Phyla WHERE ItemType = @ItemType", new { ItemType = itemType }).ToList();
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
