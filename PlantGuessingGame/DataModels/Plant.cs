using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantGuessingGame.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// class for plants
    /// </summary>
    public class Plant
    {
        // Properties
        /// <summary>
        /// Id of the medium
        /// </summary>
        [Key]
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; } // Can store file path or URL

        // Constructor
        public Plant(string familyName, string genus, string species, string commonName, string description, string picture = null)
        {
            FamilyName = familyName;
            Genus = genus;
            Species = species;
            CommonName = commonName;
            Description = description;
            Picture = picture;
        }

        // Method to get full scientific name
        public string GetScientificName()
        {
            return $"{Genus} {Species} ({FamilyName})";
        }

        // Override ToString for better display in a list or debug
        public override string ToString()
        {
            return $"{CommonName} ({Genus} {Species})";
        }
    }


}
