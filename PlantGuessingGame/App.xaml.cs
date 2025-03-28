using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using ABI.System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.VisualBasic;
using PlantGuessingGame.Interfaces;
using PlantGuessingGame.Services;
using PlantGuessingGame.ViewModels;
using PlantGuessingGame.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PlantGuessingGame
{

    //------------------------------------------------------
    // what is the plant guessing game?
    // The plant guessing game is an App, that we make to learn different information about plants while we are doing horticulture. We want to use it to add plants one by one as we come across them in nature and then add picture and other types of information that may be useful, such as preferred earth type, likes and dislikes, matching, colors etc. Anything that may be useful as a gardener. Next to that we also want to use this app to evaluate different programming techniques that come available such as AI and different community components, as so to keep up the coding skills and implement new techniques.
    // Concepts we want to include
    //    As point of learning and including some techniques we want to make use of:
    //      -	MediatR: separation of concern of sender and receiver of information and commands
    //      -	UIdispatcher:  being able to initialize a change via a delegate back to a sender View while in a command end of execution so control is given back to the UI
    //      -	Dependency injection: data service, frame control, etc
    //      -	Control finder: instead of needing to denote controls we can just find them in a tree and use behind code from there
    //      -	Dapper or EF based local database
    //------------------------------------------------------
    // While we may consider separation of models, view models and views in separate projects, we will initially place them in the same project to keep it simple.
    // --> however we want enough separation so splitting later may be easy and we want to minimize connections.
    //------------------------------------------------------

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {

        #region fields app-wide

        /// <summary>
        /// service provider containsr
        /// </summary>
        public IServiceProvider Container { get; private set; }


        /// <summary>
        /// the window
        /// </summary>
        private Window? m_window;

        /// <summary>
        /// the window public property
        /// </summary>
        public Window Window => m_window;

        #endregion



        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }



        /// <summary>
        /// Invoked when the application is launched
        /// </summary>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            // Register services for the app
            Container = RegisterServices();

            // Get the data service
            //var dataService = Container.GetService<IDataService>();
            // Initialize the data service for the database
            //await dataService.InitializeDataAsync();

            // Create a MainWindow and set the content to a new Frame
            //m_window = new Window();
            // Create a MainWindow and set the content to a new Frame
            m_window = new Window();

            // Create a Frame to act as the navigation context and navigate to the first page
            Frame rootFrame = new Frame();
            rootFrame.NavigationFailed += OnNavigationFailed;
            // Navigate to the first page, configuring the new page
            // by passing required information as a navigation parameter
            rootFrame.Navigate(typeof(MainPage), args.Arguments);

            // Place the frame in the current Window
            m_window.Content = rootFrame;

            // Ensure the MainWindow is active
            m_window.Activate();
        }

        /// <summary>
        /// register services for the app
        /// --> this together with registering the services in the on launch event is enough to create a service provider for the app and expose the viewmodel app-wide
        /// </summary>
        /// <returns></returns>
        private IServiceProvider RegisterServices()
        {

            //create new service collection
            var services = new ServiceCollection();


            //-------------------------------------------------------------------------------------------------------------------------------------------------
            // -------> navigation services allows all ViewModels to use the navigation service to open pages -----------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------
            //new navigation service
            var navigationService = new NavigationService();
            //add pages to the navigation service
            navigationService.Configure(nameof(MainWindow), typeof(MainWindow));
            navigationService.Configure(nameof(MainPage), typeof(MainPage));
            navigationService.Configure(nameof(PlantDetailPage), typeof(PlantDetailPage));
            //add navigation service to the services
            //note that this is a singleton, and is available throughout the application
            //placing the navigation service here makes it available throughout the application and only one instance is created
            //the service is made in the launch event and a client can access the service provider to get the navigation service
            //note that it is an instance of the interface that is set here, differerent from the viewmodels that are set as instances of the viewmodels
            // NOTE JCO --> it would seem that app navigation serivce is called on compilation, while Idataservice and inavigationservice are called on request
            // --> that means that adding them as a service is only when they are requested (which increases initialisation time)
            // --> also allows for more flexibility in the application (rather than loading all services at once)
            // --> E.g. we can usually have a large user / organisation filter, which speeds up the application a lot if we only load the services that are needed
            // NOTE JCO --> these serice are client services, and are used by the viewmodels
            services.AddSingleton<INavigationService>(navigationService);
            //-------------------------------------------------------------------------------------------------------------------------------------------------


            //-------------------------------------------------------------------------------------------------------------------------------------------------
            //---------> Note if we do not add a transient service here, it can note be accesssed by the Views -----------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------
            //add object to service (transient here 
            //note that this is a transient, and is created each time it is requested
            // Note JCO: because iNavigationServices, as well as Idataservices are singletons, they are created once and are available throughout the application
            // This means that we can include them in the constructor of the viewmodel, and they will be available throughout the application
            // --> the constructor of the viewmodel is the place where the services are injected (this is a property of the DI pattern)
            services.AddTransient<MainViewModel>();
            //-------------------------------------------------------------------------------------------------------------------------------------------------


            //return services for the app
            return services.BuildServiceProvider();

        }


        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new System.Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

    }
}
