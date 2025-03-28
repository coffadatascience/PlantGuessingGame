using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PlantGuessingGame.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace PlantGuessingGame.Services
{
    public class NavigationService : INavigationService
    {

        /// <summary>
        /// concurrent dictionary to store the pages
        /// </summary>
        private readonly IDictionary<string, Type> _pages = new ConcurrentDictionary<string, Type>();

        /// <summary>
        /// the root page
        /// </summary>
        public const string RootPage = "(Root)";

        /// <summary>
        /// the unknown page
        /// </summary>
        public const string UnknownPage = "(Unknown)";

        /// <summary>
        /// the app frame
        /// --> note that this has been setup in the app.xaml.cs
        /// where the root frame is set to the content of the window
        /// this allows us to navigate to the pages
        /// --> it is the Frame object that has a navigate method and accepts the type of the page to navigate to
        /// </summary>
        private static Frame AppFrame
        {
            get
            {
                // get the window
                var window = (Application.Current as App)?.Window as Window;
                // return the frame
                return (Frame)window?.Content;
            }
        }


        /// <summary>
        /// configure the page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="type"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Configure(string page, Type type)
        {
            if (_pages.Values.Any(v => v == type))
            {
                throw new ArgumentException($"The {type.Name} view has already been registered under another name.");
            }

            _pages[page] = type;
        }

        /// <summary>
        /// Gets the name of the currently displayed page.
        /// </summary>
        public string CurrentPage
        {
            get
            {
                var frame = AppFrame;

                if (frame.BackStackDepth == 0)
                    return RootPage;

                if (frame.Content == null)
                    return UnknownPage;

                var type = frame.Content.GetType();

                if (_pages.Values.All(v => v != type))
                    return UnknownPage;

                var item = _pages.Single(i => i.Value == type);

                return item.Key;
            }
        }

        /// <summary>
        /// method to navigate to the page
        /// </summary>
        /// <param name="page"></param>
        public void NavigateTo(string page)
        {
            NavigateTo(page, null);
        }

        /// <summary>
        /// method to navigate to the page with parameters
        /// </summary>
        /// <param name="page"></param>
        /// <param name="parameter"></param>
        /// <exception cref="ArgumentException"></exception>
        public void NavigateTo(string page, object parameter)
        {
            if (!_pages.ContainsKey(page))
            {
                throw new ArgumentException($"Unable to find a page registered with the name {page}.");
            }

            AppFrame.Navigate(_pages[page], parameter);
        }

        /// <summary>
        /// go back
        /// </summary>
        public void GoBack()
        {
            if (AppFrame?.CanGoBack == true)
            {
                AppFrame.GoBack();
            }
        }
    }
}