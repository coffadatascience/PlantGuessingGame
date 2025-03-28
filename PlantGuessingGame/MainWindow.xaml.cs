using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PlantGuessingGame.Interfaces;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PlantGuessingGame
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        /// <summary>
        /// protected properties for the navigation service and the data service
        /// --> these are protected properties, so they can be accessed by the view models
        /// // NOTE -- this should be take from the base, as this is loaded via its view model that sits on its page (placing this here is just for testing)
        /// </summary>
        protected INavigationService _navigationServices;

        public MainWindow()
        {
            this.InitializeComponent();

        }
        public MainWindow(INavigationService navigationService)
        {
            this.InitializeComponent();

            //set navigation service
            _navigationServices = navigationService;
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";

            //navigate to the edit page by passing the selected item
            _navigationServices.NavigateTo("PlantDetailPage");
        }
    }
}
