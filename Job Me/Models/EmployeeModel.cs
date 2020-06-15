using System;
using System.Collections.Generic;
using System.Text;

namespace JobMe.Models
{
    class EmployeeModel : BaseCls
    {

        #region "Propiedades"

        private int _EmployeeID;

        public int EmployeeID
        {
            get { return _EmployeeID; }
            set
            {
                _EmployeeID = value;
                OnPropertyChanged();
            }
        }

        private string _State;

        public string State
        {
            get { return _State; }
            set
            {
                _State = value;
                OnPropertyChanged();
            }
        }

        private string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set
            {
                _FullName = value;
                OnPropertyChanged();
            }
        }

        private DateTime _Birthdate;

        public DateTime Birthdate
        {
            get { return _Birthdate; }
            set
            {
                _Birthdate = value;
                OnPropertyChanged();
            }
        }


        

        
        //private string _Email;
        //private string _UserName;
        //private string _Password;
        //private string _Country;
        //private bool _ChangeResidence;
        //private bool _TravelAvailability;
        //private string _Gender;

        #endregion



    }
}
