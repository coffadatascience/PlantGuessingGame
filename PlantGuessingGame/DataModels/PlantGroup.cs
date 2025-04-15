using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantGuessingGame.Enums;

namespace PlantGuessingGame.DataModels
{

    public class PlantGroup
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


    }


}
