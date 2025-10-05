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
    public sealed partial class PlantProblemsPage : Page
    {
        #region Fields

        /// <summary>
        /// viewmodel for plant problems page
        /// </summary>
        public PlantProblemsViewModel ViewModel { get; } = (Application.Current as App).Container.GetService<PlantProblemsViewModel>();


        #endregion


        public PlantProblemsPage()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// constructor with selected model
        /// </summary>
        /// <param name="plantViewModel"></param>
        public PlantProblemsPage(PlantProblemsViewModel plantProblemsViewModel)
        {
            this.InitializeComponent();
            this.DataContext = plantProblemsViewModel;  // Set the DataContext to the injected plantProblemsViewModel
        }

        /// <summary>
        /// overwrite of on openings of page
        /// --> is an overwrite and is called on the navigation 
        /// --> So we can pass the selected item ID of the page that called to open this page by parameter
        /// NavigationEventArgs allows the passing of a standard parameter in this case the selected id
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
                await ViewModel.InitializeItemPlantProblemsDataAsync(selectedItemId);
            }
        }


        /// <summary>
        /// to loaded event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Set focus to the page to receive key events
            this.Focus(FocusState.Programmatic);
        }

        /// <summary>
        /// kery down event and link to command in the VM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            var vm = this.ViewModel;
            if (vm == null) return;

            if (e.Key == Windows.System.VirtualKey.Left)
            {
                if (vm.SelectPreviousItemCommand?.CanExecute(null) ?? false)
                    vm.SelectPreviousItemCommand.Execute(null);
                e.Handled = true;
            }
            else if (e.Key == Windows.System.VirtualKey.Right)
            {
                if (vm.SelectNextItemCommand?.CanExecute(null) ?? false)
                    vm.SelectNextItemCommand.Execute(null);
                e.Handled = true;
            }
        }
    }

}
