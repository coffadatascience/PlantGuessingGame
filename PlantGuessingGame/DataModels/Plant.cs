using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using Dapper.Contrib.Extensions;
using PlantGuessingGame.Enums;

namespace PlantGuessingGame.DataModels
{

    /// <summary>
    /// class for plants
    /// </summary>
    public class Plant
    {
        // Properties
        /// <summary>
        /// Id of the plant for idenfication (used as key)
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        /// <summary>
        /// common name as in general usage
        /// </summary>
        public string CommonName { get; set; }

        /// <summary>
        /// genus, as we use for denotation and recognition
        /// </summary>
        public string Genus { get; set; }

        /// <summary>
        /// specific name
        /// </summary>
        public string Species { get; set; }

        /// <summary>
        /// family name as being used in denotation of species
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// desription of type of plant
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// url of the main picture (we also want a list of pictures0
        /// </summary>
        public string ImagePath { get; set; } // Can store file path or URL

        /// <summary>
        /// medium info
        /// </summary>
        [Computed]
        public Phylum PhylumInfo { get; set; }

        /// <summary>
        /// id of phylum
        /// </summary>
        public int PhylumId => PhylumInfo.Id;

        /// <summary>
        /// type of the Plant
        /// </summary>
        public PlantType PlantType { get; set; }

        /// <summary>
        /// Classification of the Plant
        /// </summary>
        public PlantClassification PlantClassification { get; set; }

        //--------------------------------------
        // other relevant information
        //--------------------------------------
        //  1.	Eatable / non-eatable
        //  2.	Color
        //  3.	Flowering
        //  4.	Leaves all year / loses leaves 
        //  5.	Trimming instructions and period
        //  6.	Temperature range
        //  7.	Poisonous
        //  8.	Eatable
        //  9.	Fertilization method
        //  10.	Shape
        //  11.	Height(full grown)
        //  12.	Width(full grown)
        //--------------------------------------

        /// <summary>
        /// Indicates if the plant is eatable or not
        /// </summary>
        public bool IsEatable { get; set; }

        /// <summary>
        /// Color of the plant or its flowers
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Indicates if the plant flowers
        /// </summary>
        public bool IsFlowering { get; set; }

        /// <summary>
        /// Indicates if the plant has leaves all year or loses them
        /// </summary>
        public bool IsEvergreen { get; set; }

        /// <summary>
        /// Trimming instructions
        /// </summary>
        public string TrimmingInstructions { get; set; }

        /// <summary>
        /// Best period for trimming
        /// </summary>
        public string TrimmingPeriod { get; set; }

        /// <summary>
        /// Ideal temperature range for the plant (e.g., "10-30°C")
        /// </summary>
        public string TemperatureRange { get; set; }

        /// <summary>
        /// Indicates if the plant is poisonous
        /// </summary>
        public bool IsPoisonous { get; set; }

        /// <summary>
        /// Fertilization method for the plant
        /// </summary>
        public string FertilizationMethod { get; set; }

        /// <summary>
        /// Shape of the plant
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// Full-grown height of the plant (e.g., in cm or m)
        /// </summary>
        public string FullGrownHeight { get; set; }

        /// <summary>
        /// Full-grown width of the plant (e.g., in cm or m)
        /// </summary>
        public string FullGrownWidth { get; set; }

        /// <summary>
        /// List of additional pictures (URLs or file paths)
        /// </summary>
        public List<string> Pictures { get; set; } = new List<string>();

        //--------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commonName"></param>
        public Plant() {}
        public Plant(int id, string commonName)
        {
            Id = id;
            CommonName = commonName;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="familyName"></param>
        /// <param name="genus"></param>
        /// <param name="species"></param>
        /// <param name="commonName"></param>
        /// <param name="description"></param>
        /// <param name="picture"></param>
        public Plant(string family, string genus, string species, string commonName, string description, string imagePath = null)
        {
            Family = family;
            Genus = genus;
            Species = species;
            CommonName = commonName;
            Description = description;
            ImagePath = imagePath;
        }

        // Method to get full scientific name
        public string GetScientificName()
        {
            return $"{Genus} {Species} ({Family})";
        }

        // Override ToString for better display in a list or debug
        public override string ToString()
        {
            return $"{CommonName} ({Genus} {Species})";
        }
    }


}
