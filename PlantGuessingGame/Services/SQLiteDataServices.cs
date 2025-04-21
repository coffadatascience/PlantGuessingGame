using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using PlantGuessingGame.DataModels;
using PlantGuessingGame.Enums;
using PlantGuessingGame.Interfaces;

namespace PlantGuessingGame.Services
{
    public class SQLiteDataService : IDataService
    {
        /// <summary>
        /// Local variable to store the connection string
        /// </summary>
        private const string DbName = "PlantCollectionData.db";

        private readonly string _connectionString;

        public SQLiteDataService(string connectionString = null)
        {
            _connectionString = connectionString ?? $"Data Source={DbName}";
        }

        #region Tasks

        public async Task InitializeDataAsync()
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
