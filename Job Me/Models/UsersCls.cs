using Plugin.Media.Abstractions;
using Syncfusion.XForms.BadgeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace JobMe.Models
{
    public class UserModel : BaseCls
    {
        public string Age { get; set; }
        public string FotoURL { get; set; }
        private bool _WorkHere1;

        public bool WorkHere1
        {
            get { return _WorkHere1; }
            set
            {
                _WorkHere1 = value;
                OnPropertyChanged();

                if (_WorkHere1)
                {
                    MifechaFin = string.Empty;

                    WorkHereEnable1 = !_WorkHere1;
                    WorkHereEnable2 = _WorkHere1;
                    WorkHereEnable3 = _WorkHere1;
                    WorkHereEnable4 = _WorkHere1;
                    WorkHereEnable5 = _WorkHere1;

                    WorkHere2 = !_WorkHere1;
                    WorkHere3 = !_WorkHere1;
                    WorkHere4 = !_WorkHere1;
                }
                else
                {
                    WorkHereEnable1 = !_WorkHere1;
                }
            }
        }

        private bool _WorkHere2;

        public bool WorkHere2
        {
            get { return _WorkHere2; }
            set
            {
                _WorkHere2 = value;
                OnPropertyChanged();

                if (_WorkHere2)
                {
                    MifechaFin1 = string.Empty;

                    WorkHereEnable1 = _WorkHere2;
                    WorkHereEnable2 = !_WorkHere2;
                    WorkHereEnable3 = _WorkHere2;
                    WorkHereEnable4 = _WorkHere2;
                    WorkHereEnable5 = _WorkHere2;

                    WorkHere1 = !_WorkHere2;
                    WorkHere3 = !_WorkHere2;
                    WorkHere4 = !_WorkHere2;
                }
                else
                {
                    WorkHereEnable2 = !_WorkHere2;
                }
            }
        }

        private bool _WorkHere3;

        public bool WorkHere3
        {
            get { return _WorkHere3; }
            set
            {
                _WorkHere3 = value;
                OnPropertyChanged();

                if (_WorkHere3)
                {
                    MifechaFin2 = string.Empty;

                    WorkHereEnable1 = _WorkHere3;
                    WorkHereEnable2 = _WorkHere3;
                    WorkHereEnable3 = !_WorkHere3;
                    WorkHereEnable4 = _WorkHere3;
                    WorkHereEnable5 = _WorkHere3;

                    WorkHere1 = !_WorkHere3;
                    WorkHere2 = !_WorkHere3;
                    WorkHere4 = !_WorkHere3;
                }
                else
                {
                    WorkHereEnable3 = !_WorkHere3;
                }
            }
        }

        private bool _WorkHere4;

        public bool WorkHere4
        {
            get { return _WorkHere4; }
            set
            {
                _WorkHere4 = value;
                OnPropertyChanged();

                if (_WorkHere4)
                {
                    MifechaFin3 = string.Empty;

                    WorkHereEnable1 = _WorkHere4;
                    WorkHereEnable2 = _WorkHere4;
                    WorkHereEnable3 = _WorkHere4;
                    WorkHereEnable4 = !_WorkHere4;
                    WorkHereEnable5 = _WorkHere4;

                    WorkHere1 = !_WorkHere4;
                    WorkHere2 = !_WorkHere4;
                    WorkHere3 = !_WorkHere4;
                }
                else
                {
                    WorkHereEnable4 = !_WorkHere4;
                }
            }
        }

        private bool _WorkHere5;

        public bool WorkHere5
        {
            get { return _WorkHere5; }
            set
            {
                _WorkHere5 = value;
                OnPropertyChanged();

                if (_WorkHere5)
                {
                    MifechaFin4 = string.Empty;

                    WorkHereEnable1 = _WorkHere5;
                    WorkHereEnable2 = _WorkHere5;
                    WorkHereEnable3 = _WorkHere5;
                    WorkHereEnable4 = _WorkHere5;
                    WorkHereEnable5 = !_WorkHere5;

                    WorkHere1 = !_WorkHere4;
                    WorkHere2 = !_WorkHere4;
                    WorkHere3 = !_WorkHere4;
                }
                else
                {
                    WorkHereEnable5 = !_WorkHere5;
                }
            }
        }

        private bool _WorkHereEnable1 = true;

        public bool WorkHereEnable1
        {
            get { return _WorkHereEnable1; }
            set
            {
                _WorkHereEnable1 = value;
                OnPropertyChanged();
            }
        }

        private bool _WorkHereEnable2 = true;

        public bool WorkHereEnable2
        {
            get { return _WorkHereEnable2; }
            set
            {
                _WorkHereEnable2 = value;
                OnPropertyChanged();
            }
        }

        private bool _WorkHereEnable3 = true;

        public bool WorkHereEnable3
        {
            get { return _WorkHereEnable3; }
            set
            {
                _WorkHereEnable3 = value;
                OnPropertyChanged();
            }
        }

        private bool _WorkHereEnable4 = true;

        public bool WorkHereEnable4
        {
            get { return _WorkHereEnable4; }
            set
            {
                _WorkHereEnable4 = value;
                OnPropertyChanged();
            }
        }

        private bool _WorkHereEnable5 = true;

        public bool WorkHereEnable5
        {
            get { return _WorkHereEnable5; }
            set
            {
                _WorkHereEnable5 = value;
                OnPropertyChanged();
            }
        }

        #region "Listas para combos"

        private ObservableCollection<Experiencias> _listExperience;

        public ObservableCollection<Experiencias> listExperience
        {
            get
            {
                return _listExperience; ;
            }
            set
            {
                _listExperience = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Generos> _listGenders;

        public ObservableCollection<Generos> listGenders
        {
            get
            {
                return _listGenders; ;
            }
            set
            {
                _listGenders = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Ciudades> _listCities;

        public ObservableCollection<Ciudades> listCities
        {
            get
            {
                return _listCities;
            }
            set
            {
                _listCities = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Paises> _listCountries;

        public ObservableCollection<Paises> listCountries
        {
            get
            {
                return _listCountries;
            }
            set
            {
                _listCountries = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Salarios> _listSalaries;

        public ObservableCollection<Salarios> listSalaries
        {
            get
            {
                return _listSalaries;
            }
            set
            {
                _listSalaries = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AñosGraduacion> _listAñosGraduacion;

        public ObservableCollection<AñosGraduacion> ListAñosGraduacion
        {
            get
            {
                return _listAñosGraduacion;
            }
            set
            {
                _listAñosGraduacion = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Escuelas> _listSchools;

        public ObservableCollection<Escuelas> listSchools
        {
            get
            {
                return _listSchools;
            }
            set
            {
                _listSchools = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Certificaciones> _listCertifications;

        public ObservableCollection<Certificaciones> listCertifications
        {
            get
            {
                return _listCertifications;
            }
            set
            {
                _listCertifications = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Idiomas> _listLanguajes;

        public ObservableCollection<Idiomas> listLanguajes
        {
            get
            {
                return _listLanguajes;
            }
            set
            {
                _listLanguajes = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Titulos> _listDegrees;

        public ObservableCollection<Titulos> listDegrees
        {
            get
            {
                return _listDegrees;
            }
            set
            {
                _listDegrees = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Escuelas> _EscuelasSelected;

        public ObservableCollection<Escuelas> EscuelasSelected
        {
            get
            {
                return _EscuelasSelected;
            }
            set
            {
                _EscuelasSelected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Titulos> _TitulosSelected;

        public ObservableCollection<Titulos> TitulosSelected
        {
            get
            {
                return _TitulosSelected;
            }
            set
            {
                _TitulosSelected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _CertificacionesSelected;

        public ObservableCollection<object> CertificacionesSelected
        {
            get
            {
                return _CertificacionesSelected;
            }
            set
            {
                _CertificacionesSelected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Areas> _AreasSelected;

        public ObservableCollection<Areas> AreasSelected
        {
            get
            {
                return _AreasSelected;
            }
            set
            {
                _AreasSelected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AñosGraduacion> _añosSelected;

        public ObservableCollection<AñosGraduacion> AñosSelected
        {
            get
            {
                return _añosSelected;
            }
            set
            {
                _añosSelected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BSFields> _listbssfields;

        public ObservableCollection<BSFields> listbssfields
        {
            get
            {
                return _listbssfields;
            }
            set
            {
                _listbssfields = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Areas> _listAreas;

        public ObservableCollection<Areas> listAreas
        {
            get
            {
                return _listAreas;
            }
            set
            {
                _listAreas = value;
                OnPropertyChanged();
            }
        }

        #endregion "Listas para combos"

        #region "date 1"

        private ObservableCollection<object> _startdate1;

        public ObservableCollection<object> StartDate1
        {
            get { return _startdate1; }
            set
            {
                _startdate1 = value;
                //Mifecha = "Start date";
                Mifecha1 = StartDate1[0].ToString() + ' ' + StartDate1[1].ToString();
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _enddate1;

        public ObservableCollection<object> EndDate1
        {
            get { return _enddate1; }
            set
            {
                _enddate1 = value;
                // MifechaFin = "End date";
                MifechaFin1 = EndDate1[0].ToString() + ' ' + EndDate1[1].ToString();
                OnPropertyChanged();
            }
        }

        private string mifecha1 = "Start date";

        public string Mifecha1
        {
            get { return mifecha1; }
            set
            {
                mifecha1 = value;
                OnPropertyChanged();
            }
        }

        private string mifechafin1 = "End date";

        public string MifechaFin1
        {
            get { return mifechafin1; }
            set
            {
                mifechafin1 = value;
                OnPropertyChanged();
            }
        }

        #endregion "date 1"

        #region "date 2"

        private ObservableCollection<object> _startdate2;

        public ObservableCollection<object> StartDate2
        {
            get { return _startdate2; }
            set
            {
                _startdate2 = value;
                //Mifecha = "Start date";
                Mifecha2 = StartDate2[0].ToString() + ' ' + StartDate2[1].ToString();
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _enddate2;

        public ObservableCollection<object> EndDate2
        {
            get { return _enddate2; }
            set
            {
                _enddate2 = value;
                // MifechaFin = "End date";
                MifechaFin2 = EndDate2[0].ToString() + ' ' + EndDate2[1].ToString();
                OnPropertyChanged();
            }
        }

        private string mifecha2 = "Start date";

        public string Mifecha2
        {
            get { return mifecha2; }
            set
            {
                mifecha2 = value;
                OnPropertyChanged();
            }
        }

        private string mifechafin2 = "End date";

        public string MifechaFin2
        {
            get { return mifechafin2; }
            set
            {
                mifechafin2 = value;
                OnPropertyChanged();
            }
        }

        #endregion "date 2"

        #region "date 3"

        private ObservableCollection<object> _startdate3;

        public ObservableCollection<object> StartDate3
        {
            get { return _startdate3; }
            set
            {
                _startdate3 = value;
                //Mifecha = "Start date";
                Mifecha3 = StartDate3[0].ToString() + ' ' + StartDate3[1].ToString();
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _enddate3;

        public ObservableCollection<object> EndDate3
        {
            get { return _enddate3; }
            set
            {
                _enddate3 = value;
                // MifechaFin = "End date";
                MifechaFin3 = EndDate3[0].ToString() + ' ' + EndDate3[1].ToString();
                OnPropertyChanged();
            }
        }

        private string mifecha3 = "Start date";

        public string Mifecha3
        {
            get { return mifecha3; }
            set
            {
                mifecha3 = value;
                OnPropertyChanged();
            }
        }

        private string mifechafin3 = "End date";

        public string MifechaFin3
        {
            get { return mifechafin3; }
            set
            {
                mifechafin3 = value;
                OnPropertyChanged();
            }
        }

        #endregion "date 3"

        #region "date 4"

        private ObservableCollection<object> _startdate4;

        public ObservableCollection<object> StartDate4
        {
            get { return _startdate4; }
            set
            {
                _startdate4 = value;
                //Mifecha = "Start date";
                Mifecha4 = StartDate4[0].ToString() + ' ' + StartDate4[1].ToString();
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _enddate4;

        public ObservableCollection<object> EndDate4
        {
            get { return _enddate4; }
            set
            {
                _enddate4 = value;
                // MifechaFin = "End date";
                MifechaFin4 = EndDate4[0].ToString() + ' ' + EndDate4[1].ToString();
                OnPropertyChanged();
            }
        }

        private string mifecha4 = "Start date";

        public string Mifecha4
        {
            get { return mifecha4; }
            set
            {
                mifecha4 = value;
                OnPropertyChanged();
            }
        }

        private string mifechafin4 = "End date";

        public string MifechaFin4
        {
            get { return mifechafin4; }
            set
            {
                mifechafin4 = value;
                OnPropertyChanged();
            }
        }

        #endregion "date 4"

        private ObservableCollection<object> _startdate;

        public ObservableCollection<object> StartDate
        {
            get { return _startdate; }
            set
            {
                _startdate = value;
                //Mifecha = "Start date";
                Mifecha = StartDate[0].ToString() + ' ' + StartDate[1].ToString();
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _enddate;

        public ObservableCollection<object> EndDate
        {
            get { return _enddate; }
            set
            {
                _enddate = value;
                // MifechaFin = "End date";
                MifechaFin = EndDate[0].ToString() + ' ' + EndDate[1].ToString();
                OnPropertyChanged();
            }
        }

        private string mifecha = "Start date";

        public string Mifecha
        {
            get { return mifecha; }
            set
            {
                mifecha = value;
                OnPropertyChanged();
            }
        }

        private string mifechafin = "End date";

        public string MifechaFin
        {
            get { return mifechafin; }
            set
            {
                mifechafin = value;
                OnPropertyChanged();
            }
        }

        private bool _IsMainContact;

        public bool IsMainContact
        {
            get { return _IsMainContact; }
            set { _IsMainContact = value; OnPropertyChanged(); }
        }

        private int _IDCompany;

        public int IDCompany
        {
            get { return _IDCompany; }
            set { _IDCompany = value; }
        }

        private byte[] _CV;

        public byte[] CV
        {
            get { return _CV; }
            set { _CV = value; OnPropertyChanged(); }
        }

        private string _CVName;

        public string CVName
        {
            get { return _CVName; }
            set { _CVName = value; OnPropertyChanged(); }
        }

        private string _VideoAcPath;

        public string VideoAcPath
        {
            get { return _VideoAcPath; }
            set { _VideoAcPath = value; OnPropertyChanged(); }
        }

        private string _VideoJobsPath;

        public string VideoJobsPath
        {
            get { return _VideoJobsPath; }
            set { _VideoJobsPath = value; OnPropertyChanged(); }
        }

        private string _VideoOthersPath;

        public string VideoOthersPath
        {
            get { return _VideoOthersPath; }
            set { _VideoOthersPath = value; OnPropertyChanged(); }
        }

        public enum TipoVideo
        {
            Academics = 1,
            Jobs = 2,
            Others = 3
        }

        private int _UserID;

        public int UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
                OnPropertyChanged();
            }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                OnPropertyChanged();
            }
        }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; OnPropertyChanged(); }
        }

        private string _Mail;

        public string Mail
        {
            get { return _Mail; }
            set
            {
                _Mail = value;
                OnPropertyChanged();
            }
        }

        private DateTime _BirthDate = DateTime.Now;

        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; OnPropertyChanged(); }
        }

        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; OnPropertyChanged(); }
        }

        private Generos _Gender;

        public Generos Gender
        {
            get { return _Gender; }
            set { _Gender = value; OnPropertyChanged(); }
        }

        private bool hasError;

        public bool HasError
        {
            get { return hasError; }
            set
            {
                hasError = value;
                OnPropertyChanged();
            }
        }

        private Ciudades _CitySelected;

        public Ciudades City
        {
            get { return _CitySelected; }
            set
            {
                _CitySelected = value;
                OnPropertyChanged();
            }
        }

        private Paises _CountrySelected;

        public Paises Country
        {
            get { return _CountrySelected; }
            set
            {
                _CountrySelected = value;

                if (_CountrySelected != null)
                {
                    if (Country.IDCountry != 117)
                    {
                        //Mexico
                        City = null;
                        cityVisible = false;
                    }
                    else
                    {
                        //Mexico
                        cityVisible = true;
                    }
                }

                OnPropertyChanged();
            }
        }

        private bool _cityVisible = true;

        public bool cityVisible
        {
            get { return _cityVisible; }
            set { _cityVisible = value; OnPropertyChanged(); }
        }

        private int _IDCountry;

        public int IDCountry
        {
            get { return _IDCountry; }
            set
            {
                _IDCountry = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _MiArea;

        public ObservableCollection<object> MiArea
        {
            get
            {
                if (_MiArea != null)
                {
                    if (((ObservableCollection<object>)_MiArea).Count > 4)
                    {
                        ((ObservableCollection<object>)_MiArea).RemoveAt(4);
                        App.Current.MainPage.DisplayAlert("JobMe", "Max 4", "Ok");
                    }

                    return _MiArea;
                }
                else
                {
                    return _MiArea;
                };
            }

            set
            {
                _MiArea = value;
                OnPropertyChanged();
            }
        }

        private Salarios _salarios;

        public Salarios Salary
        {
            get { return _salarios; }
            set { _salarios = value; OnPropertyChanged(); }
        }

        private object _travel;

        public object TravelAvailable
        {
            get { return _travel; }
            set { _travel = value; OnPropertyChanged(); }
        }

        private ObservableCollection<object> _BSFieldsSelected;

        public ObservableCollection<object> BSFieldsSelected
        {
            get
            {
                return _BSFieldsSelected;
            }
            set
            {
                _BSFieldsSelected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _ExpSelected;

        public ObservableCollection<object> ExpSelected
        {
            get
            {
                return _ExpSelected;
            }
            set
            {
                _ExpSelected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _LanguajeSelected;

        public ObservableCollection<object> LanguajeSelected
        {
            get
            {
                return _LanguajeSelected;
            }
            set
            {
                _LanguajeSelected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _BusinessFields;

        public ObservableCollection<object> BusinessFields
        {
            get
            {
                if (_BusinessFields != null)
                {
                    if (((ObservableCollection<object>)_BusinessFields).Count > 4)
                    {
                        ((ObservableCollection<object>)_BusinessFields).RemoveAt(4);
                        App.Current.MainPage.DisplayAlert("JobMe", "Max 4", "Ok");
                    }

                    return _BusinessFields;
                }
                else
                {
                    return _BusinessFields;
                };
            }

            //get
            //{
            //    return _BusinessFields;
            //}
            set
            {
                _BusinessFields = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _EmpExperience;

        public ObservableCollection<object> Experiences
        {
            get
            {
                if (_EmpExperience != null)
                {
                    if (((ObservableCollection<object>)_EmpExperience).Count > 4)
                    {
                        ((ObservableCollection<object>)_EmpExperience).RemoveAt(4);
                        App.Current.MainPage.DisplayAlert("JobMe", "Max 4", "Ok");
                    }

                    return _EmpExperience;
                }
                else
                {
                    return _EmpExperience;
                }; ;
            }
            set { _EmpExperience = value; OnPropertyChanged(); }
        }

        private ObservableCollection<object> _EmpExperience1;

        public ObservableCollection<object> Experiences1
        {
            get
            {
                if (_EmpExperience1 != null)
                {
                    if (((ObservableCollection<object>)_EmpExperience1).Count > 4)
                    {
                        ((ObservableCollection<object>)_EmpExperience1).RemoveAt(4);
                        App.Current.MainPage.DisplayAlert("JobMe", "Max 4", "Ok");
                    }

                    return _EmpExperience1;
                }
                else
                {
                    return _EmpExperience1;
                }; ;
            }
            set { _EmpExperience1 = value; OnPropertyChanged(); }
        }

        private ObservableCollection<object> _EmpExperience2;

        public ObservableCollection<object> Experiences2
        {
            get
            {
                if (_EmpExperience2 != null)
                {
                    if (((ObservableCollection<object>)_EmpExperience2).Count > 4)
                    {
                        ((ObservableCollection<object>)_EmpExperience2).RemoveAt(4);
                        App.Current.MainPage.DisplayAlert("JobMe", "Max 4", "Ok");
                    }

                    return _EmpExperience2;
                }
                else
                {
                    return _EmpExperience2;
                }; ;
            }
            set { _EmpExperience2 = value; OnPropertyChanged(); }
        }

        private ObservableCollection<object> _EmpExperience3;

        public ObservableCollection<object> Experiences3
        {
            get
            {
                if (_EmpExperience3 != null)
                {
                    if (((ObservableCollection<object>)_EmpExperience3).Count > 4)
                    {
                        ((ObservableCollection<object>)_EmpExperience3).RemoveAt(4);
                        App.Current.MainPage.DisplayAlert("JobMe", "Max 4", "Ok");
                    }

                    return _EmpExperience3;
                }
                else
                {
                    return _EmpExperience3;
                }; ;
            }
            set { _EmpExperience3 = value; OnPropertyChanged(); }
        }

        private ObservableCollection<object> _EmpExperience4;

        public ObservableCollection<object> Experiences4
        {
            get
            {
                if (_EmpExperience4 != null)
                {
                    if (((ObservableCollection<object>)_EmpExperience4).Count > 4)
                    {
                        ((ObservableCollection<object>)_EmpExperience4).RemoveAt(4);
                        App.Current.MainPage.DisplayAlert("JobMe", "Max 4", "Ok");
                    }

                    return _EmpExperience4;
                }
                else
                {
                    return _EmpExperience4;
                }; ;
            }
            set { _EmpExperience4 = value; OnPropertyChanged(); }
        }

        private object _ChangeResidence;

        public object ChangeResidence
        {
            get { return _ChangeResidence; }
            set { _ChangeResidence = value; OnPropertyChanged(); }
        }

        private object _TypeofJob;

        public object TypeofJob
        {
            get { return _TypeofJob; }
            set { _TypeofJob = value; OnPropertyChanged(); }
        }

        private MediaFile _AcademicsVideo;

        public MediaFile AcadVideo
        {
            get { return _AcademicsVideo; }
            set { _AcademicsVideo = value; OnPropertyChanged(); }
        }

        private string _Firm;

        public string Firm
        {
            get { return _Firm; }
            set { _Firm = value; OnPropertyChanged(); }
        }

        private string _Firm1;

        public string Firm1
        {
            get { return _Firm1; }
            set { _Firm1 = value; OnPropertyChanged(); }
        }

        private string _Firm2;

        public string Firm2
        {
            get { return _Firm2; }
            set { _Firm2 = value; OnPropertyChanged(); }
        }

        private string _Firm3;

        public string Firm3
        {
            get { return _Firm3; }
            set { _Firm3 = value; OnPropertyChanged(); }
        }

        private string _Firm4;

        public string Firm4
        {
            get { return _Firm4; }
            set { _Firm4 = value; OnPropertyChanged(); }
        }

        private string _PhotoSrc;

        public string PhotoSrc
        {
            get { return _PhotoSrc; }
            set { _PhotoSrc = value; }
        }

        private string _JobTitle;

        public string JobTitle
        {
            get { return _JobTitle; }
            set { _JobTitle = value; OnPropertyChanged(); }
        }

        private string _JobTitle1;

        public string JobTitle1
        {
            get { return _JobTitle1; }
            set { _JobTitle1 = value; OnPropertyChanged(); }
        }

        private string _JobTitle2;

        public string JobTitle2
        {
            get { return _JobTitle2; }
            set { _JobTitle2 = value; OnPropertyChanged(); }
        }

        private string _JobTitle3;

        public string JobTitle3
        {
            get { return _JobTitle3; }
            set { _JobTitle3 = value; OnPropertyChanged(); }
        }

        private string _JobTitle4;

        public string JobTitle4
        {
            get { return _JobTitle4; }
            set { _JobTitle4 = value; OnPropertyChanged(); }
        }

        private MediaFile _JobsVideo;

        public MediaFile JbVideo
        {
            get { return _JobsVideo; }
            set { _JobsVideo = value; OnPropertyChanged(); }
        }

        private MediaFile _OthersVideo;

        public MediaFile OthersVideo
        {
            get { return _OthersVideo; }
            set { _OthersVideo = value; OnPropertyChanged(); }
        }

        private byte[] _Photo;

        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; OnPropertyChanged(); }
        }

        public int UserType { get; set; }

        private Escuelas _School;

        public Escuelas School
        {
            get { return _School; }
            set { _School = value; OnPropertyChanged(); }
        }

        private Escuelas _School1;

        public Escuelas School1
        {
            get { return _School1; }
            set { _School1 = value; OnPropertyChanged(); }
        }

        private Escuelas _School2;

        public Escuelas School2
        {
            get { return _School2; }
            set { _School2 = value; OnPropertyChanged(); }
        }

        private Escuelas _School3;

        public Escuelas School3
        {
            get { return _School3; }
            set { _School3 = value; OnPropertyChanged(); }
        }

        private Escuelas _School4;

        public Escuelas School4
        {
            get { return _School4; }
            set { _School4 = value; OnPropertyChanged(); }
        }

        private string myDegree;

        public string MyDegree
        {
            get { return myDegree; }
            set { myDegree = value; OnPropertyChanged(); }
        }

        private Titulos _Degree;

        public Titulos Degree
        {
            get { return _Degree; }
            set { _Degree = value; OnPropertyChanged(); }
        }

        private Titulos _Degree1;

        public Titulos Degree1
        {
            get { return _Degree1; }
            set { _Degree1 = value; OnPropertyChanged(); }
        }

        private Titulos _Degree2;

        public Titulos Degree2
        {
            get { return _Degree2; }
            set { _Degree2 = value; OnPropertyChanged(); }
        }

        private Titulos _Degree3;

        public Titulos Degree3
        {
            get { return _Degree3; }
            set { _Degree3 = value; OnPropertyChanged(); }
        }

        private Titulos _Degree4;

        public Titulos Degree4
        {
            get { return _Degree4; }
            set { _Degree4 = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Titulos> _Degrees;

        public ObservableCollection<Titulos> Degrees
        {
            get { return _Degrees; }
            set { _Degrees = value; OnPropertyChanged(); }
        }

        private object _Certifications;

        public object Certifications
        {
            get
            {
                return _Certifications;
            }
            set { _Certifications = value; OnPropertyChanged(); }
        }

        private object _Languajes;

        public object Languajes
        {
            get
            {
                return _Languajes;
            }
            set { _Languajes = value; OnPropertyChanged(); }
        }

        private AñosGraduacion _GraduationYears;

        public AñosGraduacion GraduationYears
        {
            get { return _GraduationYears; }
            set { _GraduationYears = value; OnPropertyChanged(); }
        }

        private AñosGraduacion _GraduationYears1;

        public AñosGraduacion GraduationYears1
        {
            get { return _GraduationYears1; }
            set { _GraduationYears1 = value; OnPropertyChanged(); }
        }

        private AñosGraduacion _GraduationYears2;

        public AñosGraduacion GraduationYears2
        {
            get { return _GraduationYears2; }
            set { _GraduationYears2 = value; OnPropertyChanged(); }
        }

        private AñosGraduacion _GraduationYears3;

        public AñosGraduacion GraduationYears3
        {
            get { return _GraduationYears3; }
            set { _GraduationYears3 = value; OnPropertyChanged(); }
        }

        private AñosGraduacion _GraduationYears4;

        public AñosGraduacion GraduationYears4
        {
            get { return _GraduationYears4; }
            set { _GraduationYears4 = value; OnPropertyChanged(); }
        }
    }

    public class Experiencias
    {
        private int _IDExperience;

        public int IDExperience
        {
            get { return _IDExperience; }
            set { _IDExperience = value; }
        }

        private string _Experience;

        public string Experience
        {
            get { return _Experience; }
            set
            {
                _Experience = value;
            }
        }
    }

    public class Generos : BaseCls
    {
        private int _IDGender;

        public int IDGender
        {
            get { return _IDGender; }
            set { _IDGender = value; }
        }

        private string _Gender;

        public string Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
                OnPropertyChanged();
            }
        }
    }

    public class Paises : BaseCls
    {
        private int _IDCountry;

        public int IDCountry
        {
            get { return _IDCountry; }
            set
            {
                _IDCountry = value;
                OnPropertyChanged();
            }
        }

        private string _Country;

        public string Country
        {
            get { return _Country; }
            set
            {
                _Country = value;
                OnPropertyChanged();
            }
        }
    }

    public class Ciudades
    {
        private int _IDCity;

        public int IDCity
        {
            get { return _IDCity; }
            set { _IDCity = value; }
        }

        private string _City;

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
    }

    public class BSFields
    {
        private string _BusinessField;

        public string BusinessField
        {
            get { return _BusinessField; }
            set { _BusinessField = value; }
        }

        private int _IDBusinessField;

        public int IDBusinessField
        {
            get { return _IDBusinessField; }
            set { _IDBusinessField = value; }
        }
    }

    public class Escuelas
    {
        private int _IDSchool;

        public int IDSchool
        {
            get { return _IDSchool; }
            set { _IDSchool = value; }
        }

        private string _School;

        public string School
        {
            get { return _School; }
            set { _School = value; }
        }
    }

    public class Certificaciones
    {
        private int _IDCertification;

        public int IDCertification
        {
            get { return _IDCertification; }
            set { _IDCertification = value; }
        }

        private string _Certification;

        public string Certification
        {
            get { return _Certification; }
            set { _Certification = value; }
        }
    }

    public class Idiomas : BaseCls
    {
        private int _IDLanguaje;

        public int IDLanguaje
        {
            get { return _IDLanguaje; }
            set { _IDLanguaje = value; }
        }

        private string _Languaje;

        public string Languaje
        {
            get { return _Languaje; }
            set
            {
                _Languaje = value; OnPropertyChanged();
            }
        }
    }

    public class Salarios : BaseCls
    {
        private int _IDSalary;

        public int IDSalary
        {
            get { return _IDSalary; }
            set { _IDSalary = value; OnPropertyChanged(); }
        }

        private string _Salary;

        public string Salary
        {
            get { return _Salary; }
            set { _Salary = value; OnPropertyChanged(); }
        }
    }

    public class Titulos : BaseCls
    {
        private int _IDDegree;

        public int IDDegree
        {
            get { return _IDDegree; }
            set { _IDDegree = value; }
        }

        private string _Degree;

        public string Degree
        {
            get { return _Degree; }
            set { _Degree = value; }
        }
    }

    public class AñosGraduacion
    {
        private int _IDGraduationYear;

        public int IDGraduationYear
        {
            get { return _IDGraduationYear; }
            set { _IDGraduationYear = value; }
        }

        private string _Year;

        public string Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
    }

    public class Areas
    {
        private int _IDArea;

        public int IDArea
        {
            get { return _IDArea; }
            set { _IDArea = value; }
        }

        private string _Area;

        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }
    }

    public class EmpJobs
    {
        private ObservableCollection<string> _Firms;

        public ObservableCollection<string> Firm
        {
            get { return _Firms; }
            set { _Firms = value; }
        }

        private ObservableCollection<string> _JobTitles;

        public ObservableCollection<string> JobTitles
        {
            get { return _JobTitles; }
            set { _JobTitles = value; }
        }

        private ObservableCollection<string> _StartDates;

        public ObservableCollection<string> StartDates
        {
            get { return _StartDates; }
            set { _StartDates = value; }
        }

        private ObservableCollection<string> _EndDates;

        public ObservableCollection<string> EndDates
        {
            get { return _EndDates; }
            set { _EndDates = value; }
        }

        private ObservableCollection<Experiencias> _EmpExperiencias;

        public ObservableCollection<Experiencias> EmpExperiencias
        {
            get { return _EmpExperiencias; }
            set { _EmpExperiencias = value; }
        }
    }

    public class Companies : BaseCls
    {
        private int _IDCompany;

        public int IDCompany
        {
            get { return _IDCompany; }
            set { _IDCompany = value; OnPropertyChanged(); }
        }

        private string _Company;

        public string Company
        {
            get { return _Company; }
            set { _Company = value; OnPropertyChanged(); }
        }

        private byte[] _Logo;

        public byte[] Logo
        {
            get { return _Logo; }
            set { _Logo = value; OnPropertyChanged(); }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; OnPropertyChanged(); }
        }

        private string _LogoUrl;

        public string LogoUrl
        {
            get { return _LogoUrl; }
            set { _LogoUrl = value; OnPropertyChanged(); }
        }

        private string _LogoName;

        public string LogoName
        {
            get { return _LogoName; }
            set { _LogoName = value; OnPropertyChanged(); }
        }

        public UserModel MainUser { get; set; }
    }

    public class Curriculum : BaseCls
    {
        private byte[] _CV;

        public byte[] CV
        {
            get { return _CV; }
            set { _CV = value; OnPropertyChanged(); }
        }

        private string _CVName;

        public string CVName
        {
            get { return _CVName; }
            set { _CVName = value; OnPropertyChanged(); }
        }
    }
}