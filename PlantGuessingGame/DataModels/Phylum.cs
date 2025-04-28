using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantGuessingGame.Enums;

namespace PlantGuessingGame.DataModels
{

    public class Phylum
    {

        /// <summary>
        /// Id of the plant gropu
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the plant group
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// type of the plant
        /// </summary>
        public required PlantType PlantType { get; set; }

        /// <summary>
        /// description of the phylum (general descriptoin of the phylum)
        /// </summary>
        public string? Description { get; internal set; }
    }


}
