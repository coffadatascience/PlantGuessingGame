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
    public class PlantProblems
    {


        public int ProblemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string Causes { get; set; }
        public string Solutions { get; set; }
        public string Severity { get; set; }
        public string Category { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PlantProblems() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="problemId"></param>
        /// <param name="name"></param>
        public PlantProblems(int problemId, string name)
        {
            ProblemId = problemId;
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
        public PlantProblems(
            int problemId,
            string name,
            string description,
            string symptoms,
            string causes,
            string solutions,
            string severity,
            string category)
        {
            ProblemId = problemId;
            Name = name;
            Description = description;
            Symptoms = symptoms;
            Causes = causes;
            Solutions = solutions;
            Severity = severity;
            Category = category;
        }
    }


}
