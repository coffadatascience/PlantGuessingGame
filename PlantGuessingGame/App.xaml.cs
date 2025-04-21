using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using PlantGuessingGame.Interfaces;
using PlantGuessingGame.Services;
using PlantGuessingGame.Services.PlantGuessingGame.Services;
using PlantGuessingGame.ViewModels;
using PlantGuessingGame.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Storage;

namespace PlantGuessingGame
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        #region App-wide fields and properties

        private Window? m_window;
        public Window Window => m_window;

        private StorageFolder? m_applicationLocalFolder;
        public StorageFolder ApplicationLocalFolder => m_applicationLocalFolder!;

        public IServiceProvider Container { get; private set; }

        #endregion

        public App()
        {
            this.InitializeComponent();

            CoreApplication.Suspending += OnSuspending;

            try
            {
                m_applicationLocalFolder = ApplicationData.Current.LocalFolder;
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Failed to access ApplicationData.Current: {ex.Message}");
            }
        }

        protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            // Register services
            Container = RegisterServices();

            // Initialize the SQLite data service
            var dataService = Container.GetService<IDataService>();
            if (dataService is not null)
            {
                await dataService.InitializeDataAsync();
            }

            // Create and activate the main window
            m_window = new Window();

            var rootFrame = new Frame();
            rootFrame.NavigationFailed += OnNavigationFailed;
            rootFrame.Navigate(typeof(MainPage), args.Arguments);

            m_window.Content = rootFrame;
            m_window.Activate();
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            // TODO: Save app state and stop background tasks if needed
            deferral.Complete();
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();

            // Navigation service
            var navigationService = new NavigationService();
            navigationService.Configure(nameof(MainWindow), typeof(MainWindow));
            navigationService.Configure(nameof(MainPage), typeof(MainPage));
            navigationService.Configure(nameof(PlantDetailPage), typeof(PlantDetailPage));
            services.AddSingleton<INavigationService>(navigationService);

            // Data service
            services.AddSingleton<IDataService, SQLiteDataService>();

            // ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<PlantViewModel>();
            services.AddTransient<PlantDetailsViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
