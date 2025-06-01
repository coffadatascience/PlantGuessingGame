using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PlantGuessingGame.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PlantGuessingGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public PlantOverviewViewModel ViewModel { get; } = (Application.Current as App).Container.GetService<PlantOverviewViewModel>();


        public MainPage()
        {
            this.InitializeComponent();
        }


        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            //myButton.Content = "Clicked";

            //navigate to the edit page by passing the selected item
           //ViewModel._navigationServices.NavigateTo("PlantDetailPage");
        }

        private void AddWindow_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// NOTE ---> we now have the event here, and linked with the command
        ///           The event command manager would be more applicable using behavior but it does not seem to work with a matched WINRT version that is curently reference
        ///           --> as such we may need to first update our SDK, then we may use a newer version.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel.FilterPlantsCommand.CanExecute(null))
            {
                ViewModel.FilterPlantsCommand.Execute(null);
            }
        }

    }
}
