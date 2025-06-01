using Microsoft.UI.Xaml;
using System;
using System.Reflection;
using System.Windows.Input;

//----------------------------------------------
// NOTE JCO --> this package uses a newer version of WINRT runtime resulting in a assembly clash with the SDK version 
//          -- Since this is known, we may not want to use the event command and stick to the relay command untill we need a more extensive package.
//----------------------------------------------
//using Microsoft.Xaml.Interactivity;

namespace PlantGuessingGame.ViewModels
{


    /// <summary>
    /// -----------------------------------------------------------------
    /// event commadn behavior class using the behavior framework funtionality
    /// -----------------------------------------------------------------
    ///     NOTE THAT WE NEED TO REFERENCE IN XAML
    ///     xmlns:interactivity="using:Microsoft.Xaml.Interactivity"
    ///     xmlns:behaviors="using:PlantGuessingGame.ViewModels"
    /// -----------------------------------------------------------------
    /*  EventToCommandBehavior for WinUI 3
    ----------------------------------

    Purpose:
    --------
    This behavior enables you to bind any event from a WinUI control (such as ComboBox.SelectionChanged)
    to an ICommand in your ViewModel. This is especially useful for controls that do not natively support
    command binding, allowing you to keep all UI logic in the ViewModel and follow the MVVM pattern.

    How to Use:
    -----------
    1. Add the Microsoft.Xaml.Behaviors.WinUI.Managed NuGet package to your project.
    2. Implement this class as a Behavior<FrameworkElement> (or Behavior<ComboBox>, etc.).
    3. In your XAML, declare the required namespaces:

        xmlns:interactivity="using:Microsoft.Xaml.Interactivity"
        xmlns:behaviors="using:YourNamespace"

    4. Attach the behavior to a control using the Interaction.Behaviors collection.
       For example, to filter a plant list when the ComboBox selection changes:

        <ComboBox
            ItemsSource="{x:Bind ViewModel.PlantTypes, Mode=OneWay}"
            SelectedItem="{x:Bind ViewModel.SelectedPlantType, Mode=TwoWay}">
            <interactivity:Interaction.Behaviors>
                <behaviors:EventToCommandBehavior
                    EventName="SelectionChanged"
                    Command="{x:Bind ViewModel.FilterPlantsCommand}" />
            </interactivity:Interaction.Behaviors>
        </ComboBox>

    5. In your ViewModel, implement the ICommand (e.g., RelayCommand or RelayCommand<object>) that will be executed
       when the event fires. You can access the event arguments as the command parameter if needed.

    Properties:
    -----------
    - EventName (string): The name of the event to listen for (e.g., "SelectionChanged").
    - Command (ICommand): The ViewModel command to execute.
    - CommandParameter (object, optional): A custom parameter to pass to the command. If not set, the event args are used.

    Notes:
    ------
    - This pattern helps keep your code-behind minimal and your UI logic in the ViewModel.
    - You can use this behavior with any event on any FrameworkElement-derived control.
    - For advanced scenarios, you can extend the behavior to support converters or multiple events.

    References:
    -----------
    - .NET MAUI Community Toolkit: EventToCommandBehavior [1]
    - Telerik UI for WinUI: EventToCommandBehavior [2]
    - XAML Behaviors and WinUI 3: xamlbrewer.wordpress.com [4]
*/

    /// </summary>
    //public class EventToCommandBehavior : Behavior<FrameworkElement>
    //{
    //    public string EventName { get; set; }
    //    public ICommand Command { get; set; }
    //    public object CommandParameter { get; set; }

    //    private Delegate _handler;
    //    private EventInfo _eventInfo;

    //    protected override void OnAttached()
    //    {
    //        base.OnAttached();
    //        if (AssociatedObject != null && !string.IsNullOrEmpty(EventName))
    //        {
    //            _eventInfo = AssociatedObject.GetType().GetEvent(EventName);
    //            if (_eventInfo != null)
    //            {
    //                _handler = new RoutedEventHandler(OnEvent);
    //                var eventHandler = Delegate.CreateDelegate(_eventInfo.EventHandlerType, this, nameof(OnEvent));
    //                _eventInfo.AddEventHandler(AssociatedObject, eventHandler);
    //            }
    //        }
    //    }

    //    protected override void OnDetaching()
    //    {
    //        if (_eventInfo != null && _handler != null && AssociatedObject != null)
    //        {
    //            _eventInfo.RemoveEventHandler(AssociatedObject, _handler);
    //        }
    //        base.OnDetaching();
    //    }

    //    private void OnEvent(object sender, object e)
    //    {
    //        var parameter = CommandParameter ?? e;
    //        if (Command?.CanExecute(parameter) == true)
    //            Command.Execute(parameter);
    //    }
    //}

}


/*
//public static class EventToCommandBehavior
//{
//    /// <summary>
//    ///  event
//    /// </summary>
//    public static readonly DependencyProperty EventProperty =
//        DependencyProperty.RegisterAttached(
//            "Event",
//            typeof(string),
//            typeof(EventToCommandBehavior),
//            new PropertyMetadata(null, OnEventChanged));

//    /// <summary>
//    /// command
//    /// </summary>
//    public static readonly DependencyProperty CommandProperty =
//        DependencyProperty.RegisterAttached(
//            "Command",
//            typeof(ICommand),
//            typeof(EventToCommandBehavior),
//            new PropertyMetadata(null));

//    /// <summary>
//    /// parameter for command
//    /// </summary>
//    public static readonly DependencyProperty CommandParameterProperty =
//        DependencyProperty.RegisterAttached(
//            "CommandParameter",
//            typeof(object),
//            typeof(EventToCommandBehavior),
//            new PropertyMetadata(null));

//    private static readonly DependencyProperty EventHandlerProperty =
//        DependencyProperty.RegisterAttached(
//            "EventHandler",
//            typeof(Delegate),
//            typeof(EventToCommandBehavior),
//            new PropertyMetadata(null));

//    /// <summary>
//    /// setter event
//    /// </summary>
//    /// <param name="obj"></param>
//    /// <param name="value"></param>
//    public static void SetEvent(DependencyObject obj, string value) => obj.SetValue(EventProperty, value);
//    public static string GetEvent(DependencyObject obj) => (string)obj.GetValue(EventProperty);

//    /// <summary>
//    /// setter command
//    /// </summary>
//    /// <param name="obj"></param>
//    /// <param name="value"></param>
//    public static void SetCommand(DependencyObject obj, ICommand value) => obj.SetValue(CommandProperty, value);
//    public static ICommand GetCommand(DependencyObject obj) => (ICommand)obj.GetValue(CommandProperty);

//    /// <summary>
//    /// setter parameter
//    /// </summary>
//    /// <param name="obj"></param>
//    /// <param name="value"></param>
//    public static void SetCommandParameter(DependencyObject obj, object value) => obj.SetValue(CommandParameterProperty, value);
//    public static object GetCommandParameter(DependencyObject obj) => obj.GetValue(CommandParameterProperty);

//    /// <summary>
//    /// event changed 
//    /// </summary>
//    /// <param name="d"></param>
//    /// <param name="e"></param>
//    private static void OnEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//    {
//        if (d is FrameworkElement element)
//        {
//            var oldEventName = e.OldValue as string;
//            var newEventName = e.NewValue as string;

//            if (!string.IsNullOrEmpty(oldEventName))
//            {
//                RemoveEventHandler(element, oldEventName);
//            }
//            if (!string.IsNullOrEmpty(newEventName))
//            {
//                AddEventHandler(element, newEventName);
//            }
//        }
//    }

//    /// <summary>
//    /// add handler
//    /// </summary>
//    /// <param name="element"></param>
//    /// <param name="eventName"></param>
//    /// <exception cref="ArgumentException"></exception>
//    private static void AddEventHandler(FrameworkElement element, string eventName)
//    {
//        var eventInfo = element.GetType().GetEvent(eventName);
//        if (eventInfo == null)
//            throw new ArgumentException($"Event '{eventName}' not found on type '{element.GetType().Name}'.");

//        // Create a delegate for the event handler
//        var handler = new EventHandler<object>((sender, args) =>
//        {
//            var command = GetCommand(element);
//            var parameter = GetCommandParameter(element) ?? args;
//            if (command?.CanExecute(parameter) == true)
//            {
//                command.Execute(parameter);
//            }
//        });

//        // Convert the handler to the event's delegate type
//        var eventHandler = Delegate.CreateDelegate(eventInfo.EventHandlerType, handler.Target, handler.Method);

//        // Store the handler so it can be removed later
//        element.SetValue(EventHandlerProperty, eventHandler);

//        eventInfo.AddEventHandler(element, eventHandler);
//    }


//    /// <summary>
//    /// removes handler
//    /// </summary>
//    /// <param name="element"></param>
//    /// <param name="eventName"></param>
//    private static void RemoveEventHandler(FrameworkElement element, string eventName)
//    {
//        var eventInfo = element.GetType().GetEvent(eventName);
//        var eventHandler = element.GetValue(EventHandlerProperty) as Delegate;
//        if (eventInfo != null && eventHandler != null)
//        {
//            eventInfo.RemoveEventHandler(element, eventHandler);
//            element.ClearValue(EventHandlerProperty);
//        }
//    }
//}


}*/

