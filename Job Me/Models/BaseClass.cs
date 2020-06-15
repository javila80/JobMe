using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace JobMe.Models
{
    public class BaseCls : INotifyPropertyChanged
    {
        private bool _IsVisible;

        public bool IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; OnPropertyChanged(); }
        }

        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set { _IsBusy = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Represents the method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Represents the method that will handle when a Errors are changed.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //IEnumerable INotifyDataErrorInfo.GetErrors(string propertyName)
        //{

        //    if (propertyName == null)
        //    {
        //        return null;
        //    }

        //    List<string> errors = new List<string>();

        //    if (propertyName == "Name")
        //    {
        //        if (!string.IsNullOrEmpty("Name"))
        //        {
                    
                    
        //                    errors = new List<string>();
        //                    errors.Add("Length should be between 5 and 10.");
                      
        //        }
             
        //    }

        //    return errors;
        //}

        private void RaiseErrorChanged(string propertyName)
        {

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        }
    }
}
