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

        public PlantViewModel ViewModel { get; } = (Application.Current as App).Container.GetService<PlantViewModel>();

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
    }
}
