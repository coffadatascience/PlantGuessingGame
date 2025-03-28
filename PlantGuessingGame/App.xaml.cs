using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using ABI.System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.VisualBasic;
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
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window? m_window;
    }
}
