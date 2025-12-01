using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using System.Runtime.CompilerServices;
using PlantGuessingGame.Interfaces;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlantGuessingGame.ViewModels
{

    /// <summary>
    /// Base class for view models
    /// --> here we implement the INotifyPropertyChanged interface
    /// --> we also implement the OnPropertyChanged method
    /// --> we also implement the SetProperty method
    /// --> the SetProperty method is used to set the property and call the OnPropertyChanged method
    /// this is a generic method that takes the original value, the new value, and the property name
    /// the property name is optional, if not provided, the method will use the caller member name
    /// </summary>
    public class BindableBase : INotifyPropertyChanged, INotifyDataErrorInfo, IValidatable
    {

        //Note JCO --> here we add those services that are needed for the view models
        //--> by adding them to the base class, we can use them in all view models
        //--> this is a good way to keep the view models clean and to avoid code duplication
        //--> we can also add services to the view models directly, but this is not recommended
        #region protected properties

        /// <summary>
        /// protected properties for the navigation service and the data service
        /// --> these are protected properties, so they can be accessed by the view models
        /// </summary>
        protected INavigationService _navigationServices;

        /// <summary>
        /// protected properties for the navigation service and the data service
        /// --> these are protected properties, so they can be accessed by the view models
        /// </summary>
        protected IDataService _dataService;

        /// <summary>
        /// event handler for the DataErrorsChangedEventArgs event
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        #endregion


        /// <summary>
        /// implementation of the INotifyPropertyChanged interface
        /// --> Note that this is the essence for updatable controls and thus the incoking to a new event handler passing 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// dictionary to hold the errors (of type ValidationResult)
        /// </summary>
        readonly Dictionary<string, List<ValidationResult>> _errors = new Dictionary<string, List<ValidationResult>>();

        /// <summary>
        /// returns true if the view model has errors
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return _errors.Any();
            }
        }


        /// <summary>
        /// get the errors for a specific property
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEnumerable GetErrors(string propertyName)
        {
            //add a check 
            if (!_errors.TryGetValue(propertyName, out List<ValidationResult> errors))
            {
                //not found
                return null;
            }

            //return error
            return _errors[propertyName];

        }

        /// <summary>
        /// add errors to the dictionary
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="results"></param>
        private void AddErrors(string propertyName, IEnumerable<ValidationResult> results)
        {
            if (!_errors.TryGetValue(propertyName, out List<ValidationResult> errors))
            {
                errors = new List<ValidationResult>();
                _errors.Add(propertyName, errors);
            }

            errors.AddRange(results);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        /// <summary>
        /// clear the errors from the dictionary
        /// </summary>
        /// <param name="propertyName"></param>
        private void ClearErrors(string propertyName)
        {
            if (_errors.TryGetValue(propertyName, out List<ValidationResult> errors))
            {
                errors.Clear();
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// implementation of the IValidatable interface
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="value"></param>
        public void Validate(string memberName, object value)
        {
            //first clear the errors
            ClearErrors(memberName);

            //create a list of validation results
            List<ValidationResult> results = new List<ValidationResult>();

            //execute the validation
            bool result = Validator.TryValidateProperty(value, 
                new ValidationContext(this, null, null)
                {
                    MemberName = memberName
                },

                results);

            //if the result is false, add the errors
            if (!result)
            {
                AddErrors(memberName, results);
            }
        }

        /// <summary>
        /// overloaded method to call the PropertyChanged event, that also calls the Validate method
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName, object value)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Validate(propertyName, value);
        }

        /// <summary>
        /// Method to call the PropertyChanged event
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Method to set the property and call the OnPropertyChanged method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        //protected bool SetProperty<T>(ref T originalValue, T value, [CallerMemberName] string propertyName = null)
        //{
        //    //check if the value is the same as the original value
        //    if (Equals(originalValue, value))
        //    {
        //        return false;
        //    }

        //    //set the value
        //    originalValue = value;

        //    //call the OnPropertyChanged method
        //    OnPropertyChanged(propertyName);

        //    //return true
        //    return true;
        //}


        // Updates set property method to include the value parameter implementation allowing for the validation to be called
        protected bool SetProperty<T>(ref T originalValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(originalValue, newValue))
            {
                originalValue = newValue;
                OnPropertyChanged(propertyName, newValue);

                return true;
            }

            return false;
        }

        /// <summary>
        /// overload for set property that includes a Call back
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalValue"></param>
        /// <param name="newValue"></param>
        /// <param name="onChanged"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T originalValue, T newValue, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(originalValue, newValue))
            {
                originalValue = newValue;
                OnPropertyChanged(propertyName, newValue);
                onChanged?.Invoke();  // Invoke the callback after property changed
                return true;
            }
            return false;
        }

    }
}
