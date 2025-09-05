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
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using Catel.Collections;
using System.Data;
using System.Reflection;

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
        /// list with problems (used for examples)
        /// </summary>
        private IList<PlantProblem> _problems;

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
                await CreatePlantSpecificProblemsTableAsync(db);
                //we want a separate table for the plant problems images
                //--> note that we have a separate images table for plant problems because we need a parent reference (that in this case in the plant problems)
                await CreatePlantProblemsImageTable(db);


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
        /// Public method to add a new image for a parent plant item.
        /// </summary>
        /// <param name="parentId">The ID of the parent item.</param>
        /// <param name="imagePath">The file path of the image to add.</param>
        /// <returns>The ID of the inserted image.</returns>
        public async Task<int> AddItemImageTablePlantsAsync(int parentId, string imagePath)
        {
            byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);

            using (var db = await GetSqliteConnectionAsync())
            {
                return await InsertImageTablePlantsAsync(db, parentId, imageBytes);
            }
        }

        /// <summary>
        /// Public method to retrieve an image by its ID.
        /// </summary>
        /// <param name="id">The image ID.</param>
        /// <returns>The image data as a byte array, or null if not found.</returns>
        public async Task<byte[]> GetItemImageTablePlantsAsync(int id)
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                return await GetItemImageTablePlantsAsync(db, id);
            }
        }

        /// <summary>
        /// Retrieves all images for a given parent ID.
        /// </summary>
        /// <param name="parentId">The ID of the parent entity.</param>
        /// <returns>A list of image byte arrays.</returns>
        public async Task<List<byte[]>> GetImagesTablePlantsForParentAsync(int parentId)
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                return await GetImagesTablePlantsForParentAsync(db, parentId);
            }
        }

        /// <summary>
        /// get all problems
        /// </summary>
        /// <param name="plantId"></param>
        /// <returns></returns>
        public async Task<List<PlantProblem>> GetProblemsForPlantAsync(int parentId)
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                return await GetProblemsForPlantAsync(db, parentId);
            }
        }

        //Public procedure for images.
        /// <summary>
        /// Public method to add a new image for a parent plant Problem item.
        /// </summary>
        /// <param name="parentId">The ID of the parent item.</param>
        /// <param name="imagePath">The file path of the image to add.</param>
        /// <returns>The ID of the inserted image.</returns>
        public async Task<int> AddItemImageTablePlantProblemAsync(int parentId, string imagePath)
        {
            byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);

            using (var db = await GetSqliteConnectionAsync())
            {
                return await InsertImageTablePlantProblemsAsync(db, parentId, imageBytes);
            }
        }

        /// <summary>
        /// Public method to retrieve an image for a plant problem by its ID.
        /// </summary>
        /// <param name="id">The image ID.</param>
        /// <returns>The image data as a byte array, or null if not found.</returns>
        public async Task<byte[]> GetItemImageTablePlantProblemsAsync(int id)
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                return await GetItemImageTablePlantProblemsAsync(db, id);
            }
        }

        /// <summary>
        /// Retrieves all images for a plant problems for a given parent ID.
        /// </summary>
        /// <param name="parentId">The ID of the parent entity.</param>
        /// <returns>A list of image byte arrays.</returns>
        public async Task<List<byte[]>> GetImagesTablePlantProblemsForParentAsync(int parentId)
        {
            using (var db = await GetSqliteConnectionAsync())
            {
                return await GetImagesTablePlantProblemsForParentAsync(db, parentId);
            }
        }

        #endregion



        #region Methods SQL

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
                (LocalName, CommonName, AlternativeNames, Genus, Species, Family, Description, Etymology, ImagePath, PhylumId, PlantType, PlantClassification,
                 IsEatable, Color, IsFlowering, IsEvergreen, TrimmingInstructions, TrimmingPeriod, TemperatureRangeMinimum, TemperatureRangeMaximum,
                 IsPoisonous, FertilizationMethod, Shape, FullGrownHeight, FullGrownWidth, Light, Water, Soil)
                VALUES
                (@LocalName, @CommonName, @AlternativeNames, @Genus, @Species, @Family, @Description, @Etymology, @ImagePath, @PhylumId, @PlantType, @PlantClassification,
                 @IsEatable, @Color, @IsFlowering, @IsEvergreen, @TrimmingInstructions, @TrimmingPeriod, @TemperatureRangeMinimum, @TemperatureRangeMaximum,
                 @IsPoisonous, @FertilizationMethod, @Shape, @FullGrownHeight, @FullGrownWidth, @Light, @Water, @Soil);
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


        /// <summary>
        /// code to insert a plant problem in the db
        /// </summary>
        /// <param name="db"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private async Task<int> InsertPlantProblemAsync(SqliteConnection db, int parentId, PlantProblem item)
        {
            var newIds = await db.QueryAsync<long>(
                @"INSERT INTO PlantSpecificProblems
                    (PlantId, Name, Description, Symptoms, Causes, Solutions, Severity, Category)
                    VALUES
                    (@parentId, @Name, @Description, @Symptoms, @Causes, @Solutions, @Severity, @Category);
                    SELECT last_insert_rowid()",
                new { parentId, item.Name, item.Description, item.Symptoms, item.Causes, item.Solutions, item.Severity, item.Category });

            return (int)newIds.First();
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
            _problems = await GetAllPlantProblemsAsync(db);

            //if the database has no info, then add the default list
            if (_plants.Count == 0)
            {


                //get list from seeder
                var plants = PlantSeedData.GetAllPlants(_phyla);


                //loop plants and add known base images to the data base
                foreach (var plant in plants)
                {

                    //NOTE --> the Plant ID list is autoincrement
                    //         We thus need the return value of the inserted plant to make a match for the image if we want to match the inserted id of the plant
                    var PlantID = -1;

                    // Insert plant data first
                    PlantID = await InsertPlantAsync(db, plant);


                    //------------------------------------------
                    // Get base images collection
                    //------------------------------------------
                    // Skip if no image path provided
                    if (string.IsNullOrEmpty(plant.ImagePath))
                    {
                        Console.WriteLine($"No image path for plant {plant.CommonName}");
                        continue;
                    }

                    // 1. Check if image exists
                    if (!File.Exists(plant.ImagePath))
                    {
                        Console.WriteLine($"Image not found: {plant.ImagePath}");
                        continue;
                    }

                    try
                    {
                        // 2. Load and compress image
                        using var image = await Image.LoadAsync(plant.ImagePath);

                        // Resize to max 800px width while maintaining aspect ratio
                        image.Mutate(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(800, 0), // 0 maintains aspect ratio
                            Mode = ResizeMode.Max
                        }));

                        // 3. Convert to JPEG with 75% quality
                        var encoder = new JpegEncoder
                        {
                            Quality = 75 // Medium quality (0-100)
                        };

                        using var memoryStream = new MemoryStream();
                        await image.SaveAsync(memoryStream, encoder);
                        byte[] compressedBytes = memoryStream.ToArray();

                        // 4. Insert compressed image
                        await InsertImageTablePlantsAsync(db, PlantID, compressedBytes);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to process image {plant.ImagePath}: {ex.Message}");
                    }
                    //------------------------------------------

                    //------------------------------------------
                    // Get base problems collection
                    //------------------------------------------

                    //get problems for curent plant
                    var CurrentPlantProblems = PlantSeedData.GetAllProblems(plant.Family, plant.Genus, plant.Species);

                    //loop problems
                    foreach (var Problem in CurrentPlantProblems)
                    {

                        // Insert problem data first
                        var ProblemId = await InsertPlantProblemAsync(db, PlantID, Problem);

                        //------------------------------------------
                        // Get plant problems images collection
                        //------------------------------------------
                        // Skip if no image path provided
                        if (string.IsNullOrEmpty(Problem.ImagePath))
                        {
                            Console.WriteLine($"No image path for plant {Problem.Name}");
                            continue;
                        }

                        // 1. Check if image exists
                        if (!File.Exists(Problem.ImagePath))
                        {
                            Console.WriteLine($"Image not found: {Problem.ImagePath}");
                            continue;
                        }

                        try
                        {
                            // 2. Load and compress image
                            using var image = await Image.LoadAsync(Problem.ImagePath);

                            // Resize to max 800px width while maintaining aspect ratio
                            image.Mutate(x => x.Resize(new ResizeOptions
                            {
                                Size = new Size(800, 0), // 0 maintains aspect ratio
                                Mode = ResizeMode.Max
                            }));

                            // 3. Convert to JPEG with 75% quality
                            var encoder = new JpegEncoder
                            {
                                Quality = 75 // Medium quality (0-100)
                            };

                            using var memoryStream = new MemoryStream();
                            await image.SaveAsync(memoryStream, encoder);
                            byte[] compressedBytes = memoryStream.ToArray();

                            // 4. Insert compressed image
                            // --> note Image ids are autoincrement, we need to pass the parent id of the problem itself
                            await InsertImageTablePlantProblemsAsync(db, ProblemId, compressedBytes);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to process image {Problem.ImagePath}: {ex.Message}");
                        }
                        //------------------------------------------
                    }
                    //------------------------------------------

                }



                //add to local var
                _plants = await GetAllPlantsAsync(db);
                _problems = await GetAllPlantProblemsAsync(db);

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
        /// --> Note that we need to delete the children first.Else we error:Deleting a Parent Row with Existing Children: Attempting to delete a row from a parent table while there are still related rows in the child table, and the foreign key is not configured with ON DELETE CASCADE. For instance, deleting a department that still has employees referencing it, without proper cascading, will fail.
        /// NOTEL: Dapper's DeleteAsync<T> does not cascade deletes to children by itself. Use ON DELETE CASCADE in your schema for automatic cascading, or implement manual deletion logic in your code if your schema does not support it.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task DeletePlantItemAsync(SqliteConnection db, int id)
        {
            await db.DeleteAsync<Plant>(new Plant { Id = id });
        }



        //------------------------------------------------------------------
        // We can create this code to delete a table and the children explicit
        // --> for extensions it may be easier to enable the cascading option when creating the childrens tables so that the standard dapper functionality knows how to delete all children
        //------------------------------------------------------------------
        //--> Example on deleting usage
        //        await connection.DeleteEntityWithChildrenAsync(
        //    department,           // The parent entity to delete
        //    "Employee",           // Child table name
        //    "DepartmentId",       // Child table's foreign key column
        //    "Id"                  // Parent table's key column
        //);
        //public static async Task<bool> DeleteEntityWithChildrenAsync<T>(
        //    this IDbConnection connection,
        //    T parentEntity,
        //    string childTableName,
        //    string childForeignKeyColumn,
        //    string parentKeyColumn,
        //    IDbTransaction transaction = null,
        //    int? commandTimeout = null)
        //    where T : class
        //{
        //    if (parentEntity == null)
        //        throw new ArgumentException("Cannot delete null object", nameof(parentEntity));

        //    // Get parent key value using reflection
        //    var parentKeyValue = parentEntity.GetType().GetProperty(parentKeyColumn)?.GetValue(parentEntity);
        //    if (parentKeyValue == null)
        //        throw new ArgumentException($"Parent entity does not have key property '{parentKeyColumn}'.");

        //    // Delete child rows first
        //    var deleteChildrenSql = $"DELETE FROM {childTableName} WHERE {childForeignKeyColumn} = @ParentKey";
        //    await connection.ExecuteAsync(deleteChildrenSql, new { ParentKey = parentKeyValue }, transaction, commandTimeout);

        //    // Now delete the parent row
        //    var parentTableName = GetTableName(typeof(T)); // Implement this according to your naming conventions
        //    var deleteParentSql = $"DELETE FROM {parentTableName} WHERE {parentKeyColumn} = @ParentKey";
        //    var deleted = await connection.ExecuteAsync(deleteParentSql, new { ParentKey = parentKeyValue }, transaction, commandTimeout);

        //    return deleted > 0;
        //}
        //------------------------------------------------------------------

        public static string GetTableName(Type type)
        {
            // Check for [Table] attribute
            var tableAttribute = type.GetCustomAttribute<TableAttribute>();
            if (tableAttribute != null)
                return tableAttribute.Name;

            // Fallback: use class name
            return type.Name;
        }


        #endregion


        #region Methods SQL


        /// <summary>
        /// method to add a new item to the database
        /// --> creates a new file if it does not exist else opens the existing file
        /// </summary>
        /// <returns></returns>
        //private async Task<SqliteConnection> GetSqliteConnectionAsync()
        //{
        //    try
        //    {

        //        //try to get ApplicationData.Current
        //        await ApplicationData.Current.LocalFolder.CreateFileAsync(DbName, CreationCollisionOption.OpenIfExists).AsTask().ConfigureAwait(false);

        //        //create the connection string
        //        string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName);

        //        //create a new connection
        //        var cn = new SqliteConnection($"Filename={dbPath}");

        //        //open the connection
        //        cn.Open();

        //        //return the connection
        //        return cn;




        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        // Handle the exception or log it
        //        throw new Exception("Failed to access ApplicationData.Current", ex);
        //    }
        //}

        /// --> Replace for code above that sets Pragma foreign keys on, so that all childrens rows are deleted when removing aplant
        private async Task<SqliteConnection> GetSqliteConnectionAsync()
        {
            try
            {
                // Ensure the database file exists
                await ApplicationData.Current.LocalFolder
                    .CreateFileAsync(DbName, CreationCollisionOption.OpenIfExists)
                    .AsTask()
                    .ConfigureAwait(false);

                string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName);

                var cn = new SqliteConnection($"Filename={dbPath}");
                cn.Open();

                // Enable foreign key constraints for this connection
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "PRAGMA foreign_keys = ON;";
                    cmd.ExecuteNonQuery();
                }

                return cn;
            }
            catch (InvalidOperationException ex)
            {
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
                Plants (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    LocalName NVARCHAR(1000) NOT NULL, 
                    CommonName NVARCHAR(1000) NOT NULL, 
                    AlternativeNames NVARCHAR(1000), 
                    Genus NVARCHAR(1000), 
                    Species NVARCHAR(1000), 
                    Family NVARCHAR(1000), 
                    Description NVARCHAR(3000), 
                    Etymology NVARCHAR(3000), 
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
                    Light NVARCHAR(500),
                    Water NVARCHAR(500),
                    Soil NVARCHAR(500),
                    CONSTRAINT fk_phyla 
                        FOREIGN KEY(PhylumId) REFERENCES Phyla(Id)
                )";

           

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

            var plants = await db.QueryAsync<Plant, Phylum, Plant>
            (
                @"SELECT
                    [Plants].[Id],
                    [Plants].[LocalName],
                    [Plants].[CommonName],
                    [Plants].[AlternativeNames],
                    [Plants].[Genus],
                    [Plants].[Species],
                    [Plants].[Family],
                    [Plants].[Description],
                    [Plants].[Etymology],
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
                    [Plants].[Light],
                    [Plants].[Water],
                    [Plants].[Soil],
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
                    item.PhylumInfo = phylum;
                    return item;
                }
            );


            //return list
            return plants.ToList();
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
                    AlternativeNames = @AlternativeNames,
                    Genus = @Genus,
                    Species = @Species,
                    Family = @Family,
                    Description = @Description,
                    Etymology = @Etymology,
                    ImagePath = @ImagePath,
                    PhylumId = @PhylumId,
                    PlantType = @PlantType,
                    PlantClassification = @PlantClassification,
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
                    Light = @Light,
                    Water = @Water,
                    Soil = @Soil
                WHERE Id = @Id;", plant);

        }

        /// --> Alternative create table function that also removes the rows of problems when deleting a plant
        private async Task CreatePlantSpecificProblemsTableAsync(SqliteConnection db)
        {
            db.Open();

                    string tableCommand = @"CREATE TABLE IF NOT EXISTS 
                PlantSpecificProblems (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PlantId INTEGER NOT NULL,
                    Name NVARCHAR(1000) NOT NULL,
                    Description NVARCHAR(3000),
                    Symptoms NVARCHAR(3000),
                    Causes NVARCHAR(3000),
                    Solutions NVARCHAR(3000),
                    Severity NVARCHAR(100),
                    Category NVARCHAR(100),
                    FOREIGN KEY (PlantId) REFERENCES Plants(Id) ON DELETE CASCADE
                )";

            var createTable = new SqliteCommand(tableCommand, db);

            await createTable.ExecuteNonQueryAsync();
        }


        /// <summary>
        /// get all plant problems
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private async Task<IList<PlantProblem>> GetAllPlantProblemsAsync(SqliteConnection db)
        {
            var problems = await db.QueryAsync<PlantProblem>(
                @"SELECT
                [Id],
                [PlantId],
                [Name],
                [Description],
                [Symptoms],
                [Causes],
                [Solutions],
                [Severity],
                [Category]
        FROM
                [PlantSpecificProblems]"
            );

            return problems.ToList();
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

   
        /// --> updated version that enables the delete cascade for the image rows
        private async Task CreatePlantImageTable(SqliteConnection db)
        {
                string tableCommand = @"
            CREATE TABLE IF NOT EXISTS ImageTablePlants (
                ImageID INTEGER PRIMARY KEY AUTOINCREMENT,
                ParentID INTEGER NOT NULL,
                ImageData BLOB,
                FOREIGN KEY (ParentID) REFERENCES Plants(Id) ON DELETE CASCADE
            )";

            var createTable = new SqliteCommand(tableCommand, db);
            await createTable.ExecuteNonQueryAsync();
        }

        /// <summary>
        /// code to create an images table for plant problems
        /// --> we can have the same name for image id
        /// --> the matching parent id is that of the PlantSpecificProblems
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private async Task CreatePlantProblemsImageTable(SqliteConnection db)
        {
            string tableCommand = @"
            CREATE TABLE IF NOT EXISTS ImageTablePlantProblems (
                ImageID INTEGER PRIMARY KEY AUTOINCREMENT,
                ParentID INTEGER NOT NULL,
                ImageData BLOB,
                FOREIGN KEY (ParentID) REFERENCES PlantSpecificProblems(Id) ON DELETE CASCADE
            )";

            var createTable = new SqliteCommand(tableCommand, db);
            await createTable.ExecuteNonQueryAsync();
        }
        

        //----------------------------
        // REFACTOR
        // NOTE JCO --> adjust this with a private and public accessort
        //----------------------------


        /// <summary>
        /// Private helper to insert an image using an open database connection.
        /// --> note that the ImageID is autoincrement, and does not need to be passed
        /// --> Parent ID is that of the plant, and needs to be passed and matched in the create Table code
        /// </summary>
        /// <param name="db">An open SqliteConnection.</param>
        /// <param name="parentId">The ID of the parent item.</param>
        /// <param name="imageBytes">The image data as a byte array.</param>
        /// <returns>The ID of the inserted image.</returns>
        private async Task<int> InsertImageTablePlantsAsync(SqliteConnection db, int parentId, byte[] imageBytes)
        {
            var ids = await db.QueryAsync<long>(
                    @"INSERT INTO ImageTablePlants (ParentID, ImageData) VALUES (@ParentID, @ImageData);
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
        private async Task<byte[]> GetItemImageTablePlantsAsync(SqliteConnection db, int id)
        {
            string sql = "SELECT ImageData FROM ImageTablePlants WHERE ImageID = @Id";
            return await db.ExecuteScalarAsync<byte[]>(sql, new { Id = id });
        }

        /// <summary>
        /// Helper to retrieve all images for a parent using an open connection.
        /// </summary>
        /// <param name="db">An open SqliteConnection.</param>
        /// <param name="parentId">The parent ID.</param>
        /// <returns>A list of image byte arrays.</returns>
        private async Task<List<byte[]>> GetImagesTablePlantsForParentAsync(SqliteConnection db, int parentId)
        {
            string sql = "SELECT ImageData FROM ImageTablePlants WHERE ParentID = @ParentID";
            var images = await db.QueryAsync<byte[]>(sql, new { ParentID = parentId });
            return images.ToList();
        }


        /// <summary>
        /// Helper to retrieve all problems for a plant using an open connection.
        /// </summary>
        /// <param name="db">An open SqliteConnection.</param>
        /// <param name="plantId">The plant ID (parent ID).</param>
        /// <returns>A list of PlantProblem objects.</returns>
        private async Task<List<PlantProblem>> GetProblemsForPlantAsync(SqliteConnection db, int plantId)
        {
            string sql = "SELECT * FROM PlantSpecificProblems WHERE PlantId = @PlantId";
            var problems = await db.QueryAsync<PlantProblem>(sql, new { PlantId = plantId });
            return problems.ToList();
        }

        /// <summary>
        /// coide to insert image for plants problems
        /// --> parent id is here the id of the plant problems table
        /// </summary>
        /// <param name="db"></param>
        /// <param name="parentId"></param>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        private async Task<int> InsertImageTablePlantProblemsAsync(SqliteConnection db, int parentId, byte[] imageBytes)
        {
            var ids = await db.QueryAsync<long>(
                    @"INSERT INTO ImageTablePlantProblems (ParentID, ImageData) VALUES (@ParentID, @ImageData);
              SELECT last_insert_rowid();",
                new { ParentID = parentId, ImageData = imageBytes });

            return (int)ids.First();
        }

        /// <summary>
        /// get image from the plant problmes
        /// </summary>
        /// <param name="db"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<byte[]> GetItemImageTablePlantProblemsAsync(SqliteConnection db, int id)
        {
            string sql = "SELECT ImageData FROM ImageTablePlantProblems WHERE ImageID = @Id";
            return await db.ExecuteScalarAsync<byte[]>(sql, new { Id = id });
        }

        /// <summary>
        /// get all images for the parent problems
        /// </summary>
        /// <param name="db"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private async Task<List<byte[]>> GetImagesTablePlantProblemsForParentAsync(SqliteConnection db, int parentId)
        {
            string sql = "SELECT ImageData FROM ImageTablePlantProblems WHERE ParentID = @ParentID";
            var images = await db.QueryAsync<byte[]>(sql, new { ParentID = parentId });
            return images.ToList();
        }


        #endregion


    }
}
