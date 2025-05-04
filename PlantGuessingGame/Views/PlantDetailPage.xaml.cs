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

namespace PlantGuessingGame.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlantDetailPage : Page
    {

        #region Fields

        /// <summary>
        /// viewmodel for detaili page
        /// </summary>
        public PlantDetailsViewModel ViewModel { get; } = (Application.Current as App).Container.GetService<PlantDetailsViewModel>();


        #endregion

        #region constructors

        public PlantDetailPage()
        {
            this.InitializeComponent();

            //execute add plant command



        }

        public PlantDetailPage(PlantViewModel plantViewModel)
        {
            this.InitializeComponent();
            this.DataContext = plantViewModel;  // Set the DataContext to the injected PlantViewModel

        }

        #endregion

        #region procedures

        /// <summary>
        /// method to handle the navigation to the item details page
        /// --> it is necessary to overwrite the OnNavigatedTo method to handle the navigation to the item details page
        ///     in order to access the parameter that is passed to the page
        ///     the NavigationEventArgs e parameter is used to access the parameter that is passed to the page
        ///     which is then cast to the appropriate type (in this case an int)
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // call the base class
            base.OnNavigatedTo(e);

            // get the selected item id
            var selectedItemId = (int)e.Parameter;

            // check if the selected item id is greater than 0
            if (selectedItemId >= 0)
            {
                await ViewModel.InitializeItemDetailDataAsync(selectedItemId);
            }
        }

        #endregion

    }
}
