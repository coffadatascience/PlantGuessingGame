using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantGuessingGame.DataModels
{
    /// <summary>
    /// General plant problem data model.
    /// --> we will use this as a cross table to plants
    /// --> it may be possible that we can link problems to plant type or family, rather than having a list of problems for each specific plant
    /// --> though with the limited range of type we want to focus upon, we may want that low level info as it would lead to learning as well
    /// --> generalisation may however ease learning (get more information to understand the best level for this).
    /// </summary>
    public class PlantProblem
    {

        /// <summary>
        /// id of problem
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// name of problem
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// description of problem
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// symphoms as known
        /// </summary>
        public string Symptoms { get; set; }

        /// <summary>
        /// causes known to problems
        /// </summary>
        public string Causes { get; set; }

        /// <summary>
        /// solutions
        /// </summary>
        public string Solutions { get; set; }

        /// <summary>
        /// severity
        /// </summary>
        public string Severity { get; set; }


        /// <summary>
        /// category or type
        /// </summary>
        public string Category { get; set; }


        /// <summary>
        /// url of the main picture (we can use this for seeding, the images will exist in a separate table)
        /// </summary>
        public string ImagePath { get; set; } // Can store file path or URL

        /// <summary>
        /// Constructor
        /// </summary>
        public PlantProblem() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="problemId"></param>
        /// <param name="name"></param>
        public PlantProblem(int problemId, string name)
        {
            Id = problemId;
            Name = name;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="problemId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="symptoms"></param>
        /// <param name="causes"></param>
        /// <param name="solutions"></param>
        /// <param name="severity"></param>
        /// <param name="category"></param>
        /// <param name="imagePath"></param>
        public PlantProblem(
            int problemId,
            string name,
            string description,
            string symptoms,
            string causes,
            string solutions,
            string severity,
            string category,
            string imagePath)
        {
            Id = problemId;
            Name = name;
            Description = description;
            Symptoms = symptoms;
            Causes = causes;
            Solutions = solutions;
            Severity = severity;
            Category = category;
            ImagePath = imagePath;
        }
    }


}
