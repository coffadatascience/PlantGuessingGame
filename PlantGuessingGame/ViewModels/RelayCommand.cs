using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.MVVM;

namespace PlantGuessingGame.ViewModels
{


    /// <summary>
    /// alternative version of RelayCommand, that implements ICommand
    /// --> Here we want an ICommand interface that is able to relay a method call that is placed behind a button.
    /// --> We also want this 
    /// </summary>
    public class RelayCommand : ICommand
    {

        /// <summary>
        /// constructor for RelayCommand
        /// </summary>
        private readonly Action action;

        /// <summary>
        /// constructor for RelayCommand
        /// </summary>
        private readonly Func<bool> canExecute;

        /// <summary>
        /// event handler
        /// </summary>

        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// method
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => canExecute == null || canExecute();


        /// <summary>
        /// event handler for CanExecuteChanged
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) => action();


        /// <summary>
        /// constructor for RelayCommand
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action) : this(action, null)
        {

        }

        /// <summary>
        /// constructor for RelayCommand with two parameters
        /// </summary>
        /// <param name="action"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action action, Func<bool> canExecute)
        {

            //check if action is null
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            //assign action and canExecute
            this.action = action;
            //check if canExecute is null
            this.canExecute = canExecute;


        }


        /// <summary>
        /// event handler for CanExecuteChanged
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    }

    /// <summary>
    /// alternative version of RelayCommand, that implements ICommand that can take parameters
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<T> execute, Func<T, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute?.Invoke((T)parameter) ?? true;
        public void Execute(object? parameter) => _execute((T)parameter);
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }



}
