using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantGuessingGame.Interfaces
{

    /// <summary>
    /// interface for the navigation service
    /// </summary>
    public interface  INavigationService
    {

        /// <summary>
        /// get the current page
        /// </summary>
        string CurrentPage { get; }

        /// <summary>
        /// method to navigate to the page
        /// </summary>
        /// <param name="pageName"></param>
        void NavigateTo(string pageName);

        /// <summary>
        /// method to navigate to the page with parameters
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="parameter"></param>
        void NavigateTo(string pageName, object parameter);

        /// <summary>
        /// method to go back
        /// </summary>
        void GoBack();

    }


}
