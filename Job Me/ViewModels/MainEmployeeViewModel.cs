using FormsVideoLibrary;
using JobMe.Models;
using JobMe.Services;
using JobMe.Views;
using Plugin.FilePicker;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Syncfusion.XForms.BadgeView;
using Syncfusion.XForms.Border;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.ComboBox;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Syncfusion.SfPicker.XForms;
using Xamarin.Essentials;
using Syncfusion.XForms.AvatarView;
using System.Globalization;
using JobMe.Behaviors;
using Newtonsoft.Json.Linq;
using System.Collections;
using Plugin.FilePicker.Abstractions;
using Acr.UserDialogs;
using System.Linq;
using JobMe.FormsVideoLibrary;
using JobMe.Views.Employee.Register.Templates;
using Syncfusion.XForms.MaskedEdit;
using System.Text.RegularExpressions;

namespace JobMe.ViewModels
{
    public class MyIdioma
    {
        public static string Español = "es";
        public static string Ingles = "en";
    }

    public class MainEmployeeViewModel : UserModel
    {
        #region "Propiedades"

        private const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
         @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public string MiFuente
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "Font Awesome 5 Free";

                    case Device.Android:
                        return "FontSolid-900.otf#Font Awesome 5 Free Solid";

                    default:
                        return null;
                };
            }
        }

        public FontAttributes MiFontAttributes
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return FontAttributes.Bold;

                    case Device.Android:
                        return FontAttributes.None;

                    default:
                        return FontAttributes.None;
                };
            }
        }

        public MediaFile MyProperty { get; set; }

        private bool myVar;

        // public MediaFile MyProperty { get; set; }
        public MediaFile MyFoto { get; set; }

        private BadgeIcon _IconoOKCV = BadgeIcon.None;

        public BadgeIcon IconoOKCV
        {
            get { return _IconoOKCV; }
            set
            {
                _IconoOKCV = value; OnPropertyChanged();
            }
        }

        private Stream acadstream;

        public Stream AcadStream
        {
            get { return acadstream; }
            set { acadstream = value; OnPropertyChanged(); }
        }

        private Stream jobsstream;

        public Stream JobsStream
        {
            get { return jobsstream; }
            set { jobsstream = value; OnPropertyChanged(); }
        }

        private Stream othersstream;

        public Stream OthersStream
        {
            get { return othersstream; }
            set { othersstream = value; OnPropertyChanged(); }
        }

        private bool _IsImageVisible = true;

        public bool IsImageVisible
        {
            get { return _IsImageVisible; }
            set { _IsImageVisible = value; OnPropertyChanged(); }
        }

        private BadgeIcon _IconoOK = BadgeIcon.None;

        public BadgeIcon IconoOK
        {
            get { return _IconoOK; }
            set { _IconoOK = value; OnPropertyChanged(); }
        }

        private BadgeIcon _IconoOKjobs = BadgeIcon.None;

        public BadgeIcon IconoOKjobs
        {
            get { return _IconoOKjobs; }
            set { _IconoOKjobs = value; OnPropertyChanged(); }
        }

        private BadgeIcon _IconoOKothers = BadgeIcon.None;

        public BadgeIcon IconoOKothers
        {
            get { return _IconoOKothers; }
            set { _IconoOKothers = value; OnPropertyChanged(); }
        }

        private ObservableCollection<object> todaycollection = new ObservableCollection<object>();

        private Stream photostream;

        public Stream PhotoStream
        {
            get { return photostream; }
            set { photostream = value; OnPropertyChanged(); }
        }

        private bool _Swipe;

        public bool Swipe
        {
            get { return _Swipe; }
            set { _Swipe = value; OnPropertyChanged(); }
        }

        private bool _AvatarVisible;

        public bool AvatarVisible
        {
            get { return _AvatarVisible; }
            set
            {
                _AvatarVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _addMoreVisible = false;

        public bool addMoreVisible
        {
            get { return _addMoreVisible; }
            set
            {
                _addMoreVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _addMoreVisible1 = false;

        public bool addMoreVisible1
        {
            get { return _addMoreVisible1; }
            set
            {
                _addMoreVisible1 = value;
                OnPropertyChanged();
            }
        }

        private bool _addMoreVisible2 = false;

        public bool addMoreVisible2
        {
            get { return _addMoreVisible2; }
            set
            {
                _addMoreVisible2 = value;
                OnPropertyChanged();
            }
        }

        private bool _addMoreVisible3 = false;

        public bool addMoreVisible3
        {
            get { return _addMoreVisible3; }
            set
            {
                _addMoreVisible3 = value;
                OnPropertyChanged();
            }
        }

        private bool _addMoreVisible4 = false;

        public bool addMoreVisible4
        {
            get { return _addMoreVisible4; }
            set
            {
                _addMoreVisible4 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ////////////////////////////////
        /// </summary>

        private bool _addJobsVisible = false;

        public bool addJobsVisible
        {
            get { return _addJobsVisible; }
            set
            {
                _addJobsVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _addJobsVisible1 = false;

        public bool addJobsVisible1
        {
            get { return _addJobsVisible1; }
            set
            {
                _addJobsVisible1 = value;
                OnPropertyChanged();
            }
        }

        private bool _addJobsVisible2 = false;

        public bool addJobsVisible2
        {
            get { return _addJobsVisible2; }
            set
            {
                _addJobsVisible2 = value;
                OnPropertyChanged();
            }
        }

        private bool _addJobsVisible3 = false;

        public bool addJobsVisible3
        {
            get { return _addJobsVisible3; }
            set
            {
                _addJobsVisible3 = value;
                OnPropertyChanged();
            }
        }

        private bool _IsJobVideoVisible;

        public bool IsJobVideoVisible
        {
            get { return _IsJobVideoVisible; }
            set { _IsJobVideoVisible = value; OnPropertyChanged(); }
        }

        private bool _IsVideoVisible = false;

        public bool IsVideoVisible
        {
            get { return _IsVideoVisible; }
            set
            {
                _IsVideoVisible = value;
                OnPropertyChanged();
            }
        }

        public INavigation Navigation { get; set; }
        public SfBadgeView Content { get; private set; }

        //public ScrollView Content { get; private set; }

        private bool _CanSwipe;

        public bool CanSwipe
        {
            get { return _CanSwipe; }
            set { _CanSwipe = value; OnPropertyChanged(); }
        }

        private List<CustomCell> _CarouselColllection;

        public List<CustomCell> CarouselColllection
        {
            get { return _CarouselColllection; }
            set
            {
                _CarouselColllection = value;
                OnPropertyChanged();
            }
        }

        private NewEmployeeTemplateSelector _templateselector;

        public NewEmployeeTemplateSelector TemplateSelector
        {
            get { return _templateselector; }
            set { _templateselector = value; }
        }

        public ICommand TapCommandTakePhoto { get; set; }

        private ImageSource _PhotoPath;

        public ImageSource PhotoPath
        {
            get { return _PhotoPath; }
            set { _PhotoPath = value; OnPropertyChanged(); }
        }

        private bool _IsPhotoVisible;

        public bool IsPhotoVisible
        {
            get { return _IsPhotoVisible; }
            set { _IsPhotoVisible = value; OnPropertyChanged(); }
        }

        private bool _IsOthersVideoVisible;

        public bool IsOthersVideoVisible
        {
            get { return _IsOthersVideoVisible; }
            set { _IsOthersVideoVisible = value; OnPropertyChanged(); }
        }

        private bool _IsRun;

        public bool IsRun
        {
            get { return _IsRun; }
            set { _IsRun = value; OnPropertyChanged(); }
        }

        public Command FocusedCommand { get; set; }

        private bool _UpdateOthersVisible;

        public bool UpdateOthersVisible
        {
            get { return _UpdateOthersVisible; }
            set { _UpdateOthersVisible = value; OnPropertyChanged(); }
        }

        private bool _UpdateEssentialVisible;

        public bool UpdateEssentialVisible
        {
            get { return _UpdateEssentialVisible; }
            set { _UpdateEssentialVisible = value; OnPropertyChanged(); }
        }

        private bool _UpdateAcademicsVisible;

        public bool UpdateAcademicsVisible
        {
            get { return _UpdateAcademicsVisible; }
            set { _UpdateAcademicsVisible = value; OnPropertyChanged(); }
        }

        private bool _UpdateInterestVisible;

        public bool UpdateInterestVisible
        {
            get { return _UpdateInterestVisible; }
            set { _UpdateInterestVisible = value; OnPropertyChanged(); }
        }

        private bool _UpdateJobsVisible;

        public bool UpdateJobsVisible
        {
            get { return _UpdateJobsVisible; }
            set { _UpdateJobsVisible = value; OnPropertyChanged(); }
        }

        private async Task<bool> UserExist()
        {
            try
            {
                var x = await Services.JobMe.UserExistAsync(Mail != null ? Mail : "null", UserName != null ? UserName : "null");

                if (x == 1) //Existe el usuario
                {
                    UserHasError = true;
                    UserErrorText = "The username already exist, please choose another one";
                    return true;
                }
                else if (x == 2)//Existe el correo
                {
                    MailHasError = true;
                    MailErrorText = "The email already exist";

                    return true;
                }
                else
                {
                    UserHasError = false;
                    MailHasError = false;
                    // MyUserExist = false;
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }

        public void OpenPicker()
        {
            IsVisible = true;
        }

        private bool _UserHasError;

        public bool UserHasError
        {
            get { return _UserHasError; }
            set { _UserHasError = value; OnPropertyChanged(); }
        }

        private bool _MailHasError;

        public bool MailHasError
        {
            get { return _MailHasError; }
            set { _MailHasError = value; OnPropertyChanged(); }
        }

        public ICommand SwipeCommand { get; set; }

        private bool _IndicatorVisible = true;

        public bool IndicatorVisible
        {
            get { return _IndicatorVisible; }
            set { _IndicatorVisible = value; OnPropertyChanged(); }
        }

        private string _UserErrorText;

        public string UserErrorText
        {
            get { return _UserErrorText; }
            set { _UserErrorText = value; OnPropertyChanged(); }
        }

        private string _MailErrorText;

        public string MailErrorText
        {
            get { return _MailErrorText; }
            set { _MailErrorText = value; OnPropertyChanged(); }
        }

        private string _TextAddMore;

        public string TextAddMore
        {
            get { return _TextAddMore; }
            set { _TextAddMore = value; OnPropertyChanged(); }
        }

        #endregion "Propiedades"

        private object _CurrentItem;

        public object CurrentItem
        {
            get { return _CurrentItem; }
            set
            {
                _CurrentItem = value;

                if (((CustomCell)CurrentItem).TipoHoja == 1)
                {
                    NavPage = true;
                }
                else
                {
                    NavPage = false;
                };
                OnPropertyChanged();
            }
        }

        private object rotadorpos;

        public object Rotadorpos
        {
            get { return rotadorpos; }
            set { rotadorpos = value; OnPropertyChanged(); }
        }

        private bool _NavPage;

        public bool NavPage
        {
            get { return _NavPage; }
            set { _NavPage = value; OnPropertyChanged(); }
        }

        private string _Privacylbl;

        public string Privacylbl
        {
            get { return _Privacylbl; }
            set { _Privacylbl = value; OnPropertyChanged(); }
        }

        public MainEmployeeViewModel()
        {
            try
            {
                Preferences.Set("VideoOtros", string.Empty);
                Privacylbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Política de privacidad" : "Privacy policy";
                NewMember = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "NUEVO USUARIO" : "NEW MEMBER";
                NavPage = true;
                IsSwipeEnable = true;
                UpdateEssentialVisible = false;
                UpdateJobsVisible = false;
                UpdateAcademicsVisible = false;
                UpdateInterestVisible = false;
                UpdateOthersVisible = false;

                //Select today dates
                todaycollection.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3));
                if (DateTime.Now.Date.Day < 10)
                    todaycollection.Add("0" + DateTime.Now.Date.Day);
                else
                    todaycollection.Add(DateTime.Now.Date.Day.ToString());
                todaycollection.Add(DateTime.Now.Date.Year.ToString());

                this.StartDate = todaycollection;

                //BindCombos();
                BindCountries();
                BindCities();
                BindBSFields();
                BindSchool();
                BindDegree();
                BindYear();
                BindCertification();
                BindLanguaje();
                BindSalaries();
                BindAreas();
                BindExperience();

                listGenders = new ObservableCollection<Generos>
            {
                 new Generos() { IDGender = 0, Gender = "Prefer not to say" },
                new Generos() { IDGender = 1, Gender = "Female" },
                new Generos() { IDGender = 2, Gender = "Male" }
            };

                LoadCarousel();

                ////Se cargan las pestañas

                BSFieldsSelected = new ObservableCollection<object>();
                ExpSelected = new ObservableCollection<object>();
                LanguajeSelected = new ObservableCollection<object>();
                CertificacionesSelected = new ObservableCollection<object>();

                //Abre el selector de fechas
                FocusedCommand = new Command(() => OpenPicker());
                //Verifica que el usuario no exista en la base de datos
                UnFocusedCommand = new Command(async () => await UserExist());
                TermsCommand = new Command(ViewTerms);
                PrivacyCommand = new Command(PrivacyTerms);
                TextAddMore = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "+      Agregar        " : "+      Add more       ";
                TapCommandTakePhoto = new Command(async () => await TakePhotoAsync());
                CurrentItemCommand = new Command<CustomCell>((item) => Validame(item));
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Jobme", ex.Message, "ok");
                //throw;
            }
        }

        public void LoadCarousel()
        {
            //Se cargan las pestañas
            CarouselColllection = new List<CustomCell>();
            CarouselColllection.Add(new CustomCell { TipoHoja = 1 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 2 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 3 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 4 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 5 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 6 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 7 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 8 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 9 });

            TemplateSelector = new NewEmployeeTemplateSelector
            {
                EssentialTemplate = new DataTemplate(Essential),
                InterestTemplate = new DataTemplate(Interest),
                AcademicsTemplate = new DataTemplate(Academics),
                AcademicsVideoTemplate = new DataTemplate(AcademicsVideo),
                JobsVTemplate = new DataTemplate(JobsV),
                JobsVideoTemplate = new DataTemplate(JobsVideo),
                OthersTemplate = new DataTemplate(Others),
                uploadPhotoTemplate = new DataTemplate(uploadPhoto),
                uploadCVTemplate = new DataTemplate(uploadCV)
            };
        }

        private bool _IsSwipeEnable;

        public bool IsSwipeEnable
        {
            get { return _IsSwipeEnable; }
            set { _IsSwipeEnable = value; OnPropertyChanged(); }
        }

        private int _Position;

        public int Position
        {
            get { return _Position; }
            set { _Position = value; OnPropertyChanged(); }
        }

        public async Task Validame(object obj)
        {
            UserDialogs.Instance.ShowLoading("Loading");

            //if(((CustomCell)obj).TipoHoja ==5)
            //{
            //    //Position = 2;
            //}
            await Task.Delay(800);
            UserDialogs.Instance.HideLoading();
        }

        private string _newmember;

        public string NewMember
        {
            get { return _newmember; }
            set { _newmember = value; OnPropertyChanged(); }
        }

        public MainEmployeeViewModel(int tipo)
        {
            Preferences.Set("VideoOtros", string.Empty);
            Privacylbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Política de privacidad" : "Privacy policy";
            NewMember = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "NUEVO USUARIO" : "NEW MEMBER";
            TextAddMore = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "+      Ver mas        " : "    View more    ";

            FocusedCommand = new Command(() => OpenPicker());
            TermsCommand = new Command(ViewTerms);

            PrivacyCommand = new Command(PrivacyTerms);
            //Select today dates
            todaycollection.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3));
            if (DateTime.Now.Date.Day < 10)
                todaycollection.Add("0" + DateTime.Now.Date.Day);
            else
                todaycollection.Add(DateTime.Now.Date.Day.ToString());
            todaycollection.Add(DateTime.Now.Date.Year.ToString());

            this.StartDate = todaycollection;

            TapCommandTakePhoto = new Command(async () => await TakePhotoAsync());

            CanSwipe = false;

            listGenders = new ObservableCollection<Generos>
            {
                new Generos() { IDGender = 0, Gender = "Prefer not to say" },
                new Generos() { IDGender = 1, Gender = "Female" },
                new Generos() { IDGender = 2, Gender = "Male" }
            };

            CarouselColllection = new List<CustomCell>();

            switch (tipo)
            {
                case 1:

                    GetUserEssential();
                    CarouselColllection.Add(new CustomCell { TipoHoja = 1 });

                    break;

                case 2:
                    GetUserInterest();
                    CarouselColllection.Add(new CustomCell { TipoHoja = 2 });

                    break;

                case 3:
                    GetUserAcademics();
                    CarouselColllection.Add(new CustomCell { TipoHoja = 3 });
                    CarouselColllection.Add(new CustomCell { TipoHoja = 4 });
                    break;

                case 4:
                    GetUserJobs();
                    CarouselColllection.Add(new CustomCell { TipoHoja = 5 });
                    CarouselColllection.Add(new CustomCell { TipoHoja = 6 });
                    break;

                case 5:
                    CarouselColllection.Add(new CustomCell { TipoHoja = 7 });
                    break;

                default:

                    break;
            }

            ////Se cargan las pestañas

            TemplateSelector = new NewEmployeeTemplateSelector
            {
                EssentialTemplate = new DataTemplate(Essential),
                InterestTemplate = new DataTemplate(Interest),
                AcademicsTemplate = new DataTemplate(Academics),
                AcademicsVideoTemplate = new DataTemplate(AcademicsVideo),
                JobsVTemplate = new DataTemplate(JobsV),
                JobsVideoTemplate = new DataTemplate(JobsVideo),
                OthersTemplate = new DataTemplate(Others),
                uploadPhotoTemplate = new DataTemplate(uploadPhoto),
                uploadCVTemplate = new DataTemplate(uploadCV)
            };

            BtnUpdateEssentialCommand = new Command(UpdateUserEssential);

            BtnUpdateInterestCommand = new Command(UpdateUserInterets);

            BtnUpdateAcademicsCommand = new Command(UpdateUserAcademics);

            BtnUpdateJobsCommand = new Command(UpdateUserJobs);

            UpdateEssentialVisible = true;
            UpdateJobsVisible = true;
            UpdateAcademicsVisible = true;
            UpdateInterestVisible = true;
            UpdateOthersVisible = true;
        }

        #region "Comands"

        public Command CurrentItemCommand { get; set; }
        public Command BtnUpdateEssentialCommand { get; set; }
        public Command BtnUpdateInterestCommand { get; set; }
        public Command BtnUpdateAcademicsCommand { get; set; }
        public Command BtnUpdateJobsCommand { get; set; }
        public Command TermsCommand { get; set; }
        public Command PrivacyCommand { get; set; }
        public Command UnFocusedCommand { get; set; }

        #endregion "Comands"

        private async void GetUserEssential()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Loading...");

                var aTask = Task.Run(async () => await Services.JobMe.GetCountries());
                var bTask = Task.Run(async () => await Services.JobMe.GetCities());

                listCountries = await aTask;
                listCities = await bTask;

                IndicatorVisible = false;
                UpdateEssentialVisible = true;

                UserModel miusuario = new UserModel();
                miusuario = await UserService.GetUserEssentialAsync((int)Preferences.Get("UserID", 0));

                Name = miusuario.Name;
                Mail = miusuario.Mail;
                BirthDate = miusuario.BirthDate;
                string tel = miusuario.Phone.Replace("-", "");
                Phone = tel;

                if (miusuario.City != null)
                {
                    var cityselected = new Ciudades() { IDCity = miusuario.City.IDCity, City = miusuario.City.City };
                    // City = new Ciudades() { IDCity = miusuario.City.IDCity, City = miusuario.City.City };
                    City = listCities.Where(p => p.IDCity == cityselected.IDCity).First();
                }

                //Country = new Paises() { IDCountry = miusuario.Country.IDCountry, Country = miusuario.Country.Country };
                var countryselected = new Paises() { IDCountry = miusuario.Country.IDCountry, Country = miusuario.Country.Country };
                Country = listCountries.Where(p => p.IDCountry == countryselected.IDCountry).First();

                var genderselected = new Generos() { IDGender = miusuario.Gender.IDGender, Gender = miusuario.Gender.Gender };
                Gender = listGenders.Where(p => p.IDGender == genderselected.IDGender).First();

                UserName = miusuario.UserName;
                Password = miusuario.Password;

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("Job Me", "Ocurrio un error al cargar los datos", "Ok");
                // throw;
            }
        }

        private async void GetUserInterest()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Loading...");

                var aTask = Task.Run(async () => await Services.JobMe.GetBSFields());
                var bTask = Task.Run(async () => await Services.JobMe.GetAreas());
                var cTask = Task.Run(async () => await Services.JobMe.GetSalaries());

                listbssfields = await aTask;
                listAreas = await bTask;
                listSalaries = await cTask;

                IndicatorVisible = false;
                UserModel miusuario = new UserModel();
                miusuario = await UserService.GetUserInterestAsync((int)Preferences.Get("UserID", 0));

                //await Task.Delay(1000);

                int idarea = 0;
                string area = string.Empty;
                // MiArea = miusuario.MiArea;

                ObservableCollection<object> ar = new ObservableCollection<object>();
                //Areas
                for (int i = 0; i < ((IList)miusuario.MiArea).Count; i++)
                {
                    JObject result = JObject.Parse(((IList)miusuario.MiArea)[i].ToString());

                    foreach (KeyValuePair<string, JToken> keyValuePair in result)
                    {
                        if ("IDArea" == keyValuePair.Key)
                        {
                            idarea = (int)(keyValuePair.Value);
                        }

                        if ("Area" == keyValuePair.Key)
                        {
                            area = keyValuePair.Value.ToString();
                        }
                    }

                    ar.Add(new Areas { IDArea = idarea, Area = area });
                }
                MiArea = ar;

                string bsfield = string.Empty;
                int idbsfield = 0;

                ObservableCollection<object> bsf = new ObservableCollection<object>();
                //Areas
                for (int i = 0; i < ((IList)miusuario.BusinessFields).Count; i++)
                {
                    JObject result = JObject.Parse(((IList)miusuario.BusinessFields)[i].ToString());

                    foreach (KeyValuePair<string, JToken> keyValuePair in result)
                    {
                        if ("IDBusinessField" == keyValuePair.Key)
                        {
                            idbsfield = (int)(keyValuePair.Value);
                        }

                        if ("BusinessField" == keyValuePair.Key)
                        {
                            bsfield = keyValuePair.Value.ToString();
                        }
                    }

                    bsf.Add(new BSFields { IDBusinessField = idbsfield, BusinessField = bsfield });
                }
                BusinessFields = bsf;

                TravelAvailable = miusuario.TravelAvailable;
                ChangeResidence = miusuario.ChangeResidence;
                TypeofJob = miusuario.TypeofJob;

                var salaryselected = new Salarios() { IDSalary = miusuario.Salary.IDSalary, Salary = miusuario.Salary.Salary };
                // listGenders.Where(p => p.IDGender == genderselected.IDGender).First();
                Salary = listSalaries.Where(p => p.IDSalary == salaryselected.IDSalary).First();

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("Job Me", "Ocurrio un error al cargar los datos", "Ok");
                //throw;
            }
        }

        private async void GetUserAcademics()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Loading...");

                var aTask = Task.Run(async () => await Services.JobMe.GetSchools());
                var bTask = Task.Run(async () => await Services.JobMe.GetDegrees());
                var cTask = Task.Run(async () => await Services.JobMe.GetYears());
                var dTask = Task.Run(async () => await Services.JobMe.GetCertifications());
                var eTask = Task.Run(async () => await Services.JobMe.GetLanguajes());

                listSchools = await aTask;
                listDegrees = await bTask;
                ListAñosGraduacion = await cTask;
                listCertifications = await dTask;
                listLanguajes = await eTask;

                //Quitamos el "Todos" de la lista
                ListAñosGraduacion.Remove(ListAñosGraduacion.Where(p => p.IDGraduationYear == 0).FirstOrDefault());

                UserModel miusuario = new UserModel();
                miusuario = await UserService.GetUserAcademicsAsync((int)Preferences.Get("UserID", 0));

                int idlanguaje = 0;
                string languaje = string.Empty;
                ObservableCollection<object> lng = new ObservableCollection<object>();

                if (miusuario.Languajes != null)
                {
                    for (int i = 0; i < ((IList)miusuario.Languajes).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)miusuario.Languajes)[i].ToString());

                        foreach (KeyValuePair<string, JToken> keyValuePair in result)
                        {
                            if ("IDLanguaje" == keyValuePair.Key)
                            {
                                idlanguaje = (int)keyValuePair.Value;
                            }

                            if ("Languaje" == keyValuePair.Key)
                            {
                                languaje = keyValuePair.Value.ToString();
                            }
                        }
                        lng.Add(new Idiomas() { IDLanguaje = idlanguaje, Languaje = languaje });
                    }

                    Languajes = lng;
                }

                int idcertification = 0;
                string certification = string.Empty;

                ObservableCollection<object> crt = new ObservableCollection<object>();

                if (miusuario.Certifications != null)
                {
                    for (int i = 0; i < ((IList)miusuario.Certifications).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)miusuario.Certifications)[i].ToString());

                        foreach (KeyValuePair<string, JToken> keyValuePair in result)
                        {
                            if ("IDCertification" == keyValuePair.Key)
                            {
                                idcertification = (int)(keyValuePair.Value);
                            }

                            if ("Certification" == keyValuePair.Key)
                            {
                                certification = keyValuePair.Value.ToString();
                            }
                        }
                        crt.Add(new Certificaciones() { IDCertification = idcertification, Certification = certification });
                    }

                    Certifications = crt;
                }
                //var salaryselected = new Salarios() { IDSalary = miusuario.Salary.IDSalary, Salary = miusuario.Salary.Salary };
                // listGenders.Where(p => p.IDGender == genderselected.IDGender).First();

                var schoolselected = new Escuelas() { IDSchool = miusuario.School.IDSchool, School = miusuario.School.School };
                School = listSchools.Where(p => p.IDSchool == schoolselected.IDSchool).FirstOrDefault();

                var schoolselected1 = new Escuelas() { IDSchool = miusuario.School1.IDSchool, School = miusuario.School1.School };
                School1 = listSchools.Where(p => p.IDSchool == schoolselected1.IDSchool).FirstOrDefault();

                var schoolselected2 = new Escuelas() { IDSchool = miusuario.School2.IDSchool, School = miusuario.School2.School };
                School2 = listSchools.Where(p => p.IDSchool == schoolselected2.IDSchool).FirstOrDefault();

                var schoolselected3 = new Escuelas() { IDSchool = miusuario.School3.IDSchool, School = miusuario.School3.School };
                School3 = listSchools.Where(p => p.IDSchool == schoolselected3.IDSchool).FirstOrDefault();

                var schoolselected4 = new Escuelas() { IDSchool = miusuario.School4.IDSchool, School = miusuario.School4.School };
                School4 = listSchools.Where(p => p.IDSchool == schoolselected4.IDSchool).FirstOrDefault();

                //School1 = new Escuelas() { IDSchool = miusuario.School1.IDSchool, School = miusuario.School1.School };
                //School2 = new Escuelas() { IDSchool = miusuario.School2.IDSchool, School = miusuario.School2.School };
                //School3 = new Escuelas() { IDSchool = miusuario.School3.IDSchool, School = miusuario.School3.School };
                //School4 = new Escuelas() { IDSchool = miusuario.School4.IDSchool, School = miusuario.School4.School };

                var degreeselected = new Titulos() { IDDegree = miusuario.Degree.IDDegree, Degree = miusuario.Degree.Degree };
                Degree = listDegrees.Where(p => p.IDDegree == degreeselected.IDDegree).FirstOrDefault();

                var degreeselected1 = new Titulos() { IDDegree = miusuario.Degree1.IDDegree, Degree = miusuario.Degree1.Degree };
                Degree1 = listDegrees.Where(p => p.IDDegree == degreeselected1.IDDegree).FirstOrDefault();

                var degreeselected2 = new Titulos() { IDDegree = miusuario.Degree2.IDDegree, Degree = miusuario.Degree2.Degree };
                Degree2 = listDegrees.Where(p => p.IDDegree == degreeselected2.IDDegree).FirstOrDefault();

                var degreeselected3 = new Titulos() { IDDegree = miusuario.Degree3.IDDegree, Degree = miusuario.Degree3.Degree };
                Degree3 = listDegrees.Where(p => p.IDDegree == degreeselected3.IDDegree).FirstOrDefault();

                var degreeselected4 = new Titulos() { IDDegree = miusuario.Degree4.IDDegree, Degree = miusuario.Degree4.Degree };
                Degree4 = listDegrees.Where(p => p.IDDegree == degreeselected4.IDDegree).FirstOrDefault();

                //Degree1 = new Titulos() { IDDegree = miusuario.Degree1.IDDegree, Degree = miusuario.Degree1.Degree };
                //Degree2 = new Titulos() { IDDegree = miusuario.Degree2.IDDegree, Degree = miusuario.Degree2.Degree };
                //Degree3 = new Titulos() { IDDegree = miusuario.Degree3.IDDegree, Degree = miusuario.Degree3.Degree };
                //Degree4 = new Titulos() { IDDegree = miusuario.Degree4.IDDegree, Degree = miusuario.Degree4.Degree };

                var gyselected = new AñosGraduacion() { IDGraduationYear = miusuario.GraduationYears.IDGraduationYear, Year = miusuario.GraduationYears.Year };
                GraduationYears = ListAñosGraduacion.Where(p => p.IDGraduationYear == gyselected.IDGraduationYear).FirstOrDefault();

                var gyselected1 = new AñosGraduacion() { IDGraduationYear = miusuario.GraduationYears1.IDGraduationYear, Year = miusuario.GraduationYears1.Year };
                GraduationYears1 = ListAñosGraduacion.Where(p => p.IDGraduationYear == gyselected1.IDGraduationYear).FirstOrDefault();

                var gyselected2 = new AñosGraduacion() { IDGraduationYear = miusuario.GraduationYears2.IDGraduationYear, Year = miusuario.GraduationYears2.Year };
                GraduationYears2 = ListAñosGraduacion.Where(p => p.IDGraduationYear == gyselected2.IDGraduationYear).FirstOrDefault();

                var gyselected3 = new AñosGraduacion() { IDGraduationYear = miusuario.GraduationYears3.IDGraduationYear, Year = miusuario.GraduationYears3.Year };
                GraduationYears3 = ListAñosGraduacion.Where(p => p.IDGraduationYear == gyselected3.IDGraduationYear).FirstOrDefault();

                var gyselected4 = new AñosGraduacion() { IDGraduationYear = miusuario.GraduationYears4.IDGraduationYear, Year = miusuario.GraduationYears4.Year };
                GraduationYears4 = ListAñosGraduacion.Where(p => p.IDGraduationYear == gyselected4.IDGraduationYear).FirstOrDefault();

                //GraduationYears1 = new AñosGraduacion() { IDGraduationYear = miusuario.GraduationYears1.IDGraduationYear, Year = miusuario.GraduationYears1.Year };
                //GraduationYears2 = new AñosGraduacion() { IDGraduationYear = miusuario.GraduationYears2.IDGraduationYear, Year = miusuario.GraduationYears2.Year };
                //GraduationYears3 = new AñosGraduacion() { IDGraduationYear = miusuario.GraduationYears3.IDGraduationYear, Year = miusuario.GraduationYears3.Year };
                //GraduationYears4 = new AñosGraduacion() { IDGraduationYear = miusuario.GraduationYears4.IDGraduationYear, Year = miusuario.GraduationYears4.Year };

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("Job Me", "Ocurrio un error al cargar los datos", "Ok");
                //throw;
            }
        }

        private async void GetUserJobs()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Loading...");
                var aTask = Task.Run(async () => await Services.JobMe.GetExperience());

                listExperience = await aTask;

                UserModel u = new UserModel();
                u = await UserService.GetUserJobsAsync((int)Preferences.Get("UserID", 0));

                Firm = u.Firm;
                Firm1 = u.Firm1;
                Firm2 = u.Firm2;
                Firm3 = u.Firm3;
                Firm4 = u.Firm4;

                JobTitle = u.JobTitle;
                JobTitle1 = u.JobTitle1;
                JobTitle2 = u.JobTitle2;
                JobTitle3 = u.JobTitle3;
                JobTitle4 = u.JobTitle4;

                Mifecha = u.Mifecha;
                Mifecha1 = u.Mifecha1;
                Mifecha2 = u.Mifecha2;
                Mifecha3 = u.Mifecha3;
                Mifecha4 = u.Mifecha4;

                MifechaFin = u.MifechaFin;
                MifechaFin1 = u.MifechaFin1;
                MifechaFin2 = u.MifechaFin2;
                MifechaFin3 = u.MifechaFin3;
                MifechaFin4 = u.MifechaFin4;

                WorkHere1 = u.WorkHere1;
                WorkHere2 = u.WorkHere2;
                WorkHere3 = u.WorkHere3;
                WorkHere4 = u.WorkHere4;
                WorkHere5 = u.WorkHere5;

                if (u.Experiences != null)
                {
                    int idexperience = 0;
                    string experience = string.Empty;
                    ObservableCollection<object> exp = new ObservableCollection<object>();
                    //MiArea = miusuario.MiArea;
                    for (int i = 0; i < ((IList)u.Experiences).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)u.Experiences)[i].ToString());

                        foreach (KeyValuePair<string, JToken> keyValuePair in result)
                        {
                            if ("IDExperience" == keyValuePair.Key)
                            {
                                idexperience = (int)(keyValuePair.Value);
                            }

                            if ("Experience" == keyValuePair.Key)
                            {
                                experience = keyValuePair.Value.ToString();
                            }
                        }
                        exp.Add(new Experiencias() { IDExperience = idexperience, Experience = experience });
                    }
                    Experiences = exp;
                }

                ///Experience 1
                if (u.Experiences1 != null)
                {
                    int idexperience1 = 0;
                    string experience1 = string.Empty;
                    ObservableCollection<object> exp1 = new ObservableCollection<object>();
                    //MiArea = miusuario.MiArea;
                    for (int i = 0; i < ((IList)u.Experiences1).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)u.Experiences1)[i].ToString());

                        foreach (KeyValuePair<string, JToken> keyValuePair in result)
                        {
                            if ("IDExperience" == keyValuePair.Key)
                            {
                                idexperience1 = (int)(keyValuePair.Value);
                            }

                            if ("Experience" == keyValuePair.Key)
                            {
                                experience1 = keyValuePair.Value.ToString();
                            }
                        }
                        exp1.Add(new Experiencias() { IDExperience = idexperience1, Experience = experience1 });
                    }
                    Experiences1 = exp1;
                }

                ///Experience 2
                ///
                if (u.Experiences2 != null)
                {
                    int idexperience2 = 0;
                    string experience2 = string.Empty;
                    ObservableCollection<object> exp2 = new ObservableCollection<object>();
                    //MiArea = miusuario.MiArea;
                    for (int i = 0; i < ((IList)u.Experiences2).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)u.Experiences2)[i].ToString());

                        foreach (KeyValuePair<string, JToken> keyValuePair in result)
                        {
                            if ("IDExperience" == keyValuePair.Key)
                            {
                                idexperience2 = (int)(keyValuePair.Value);
                            }

                            if ("Experience" == keyValuePair.Key)
                            {
                                experience2 = keyValuePair.Value.ToString();
                            }
                        }
                        exp2.Add(new Experiencias() { IDExperience = idexperience2, Experience = experience2 });
                    }
                    Experiences2 = exp2;
                }

                ///Experience 3
                ///
                if (u.Experiences3 != null)
                {
                    int idexperience3 = 0;
                    string experience3 = string.Empty;
                    ObservableCollection<object> exp3 = new ObservableCollection<object>();
                    //MiArea = miusuario.MiArea;
                    for (int i = 0; i < ((IList)u.Experiences3).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)u.Experiences3)[i].ToString());

                        foreach (KeyValuePair<string, JToken> keyValuePair in result)
                        {
                            if ("IDExperience" == keyValuePair.Key)
                            {
                                idexperience3 = (int)(keyValuePair.Value);
                            }

                            if ("Experience" == keyValuePair.Key)
                            {
                                experience3 = keyValuePair.Value.ToString();
                            }
                        }
                        exp3.Add(new Experiencias() { IDExperience = idexperience3, Experience = experience3 });
                    }
                    Experiences3 = exp3;
                }

                ///Experience 4
                ///
                if (u.Experiences4 != null)
                {
                    int idexperience4 = 0;
                    string experience4 = string.Empty;
                    ObservableCollection<object> exp4 = new ObservableCollection<object>();
                    //MiArea = miusuario.MiArea;
                    for (int i = 0; i < ((IList)u.Experiences4).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)u.Experiences4)[i].ToString());

                        foreach (KeyValuePair<string, JToken> keyValuePair in result)
                        {
                            if ("IDExperience" == keyValuePair.Key)
                            {
                                idexperience4 = (int)(keyValuePair.Value);
                            }

                            if ("Experience" == keyValuePair.Key)
                            {
                                experience4 = keyValuePair.Value.ToString();
                            }
                        }
                        exp4.Add(new Experiencias() { IDExperience = idexperience4, Experience = experience4 });
                    }
                    Experiences4 = exp4;
                }

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("Job Me",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ocurrio un error al cargar los datos" : "Error saving data",
                    "Ok");
                //throw;
            }
        }

        public bool ValidaEssential(UserModel u)
        {
            if (MailHasError)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "E-Mail already exists", "Ok");
                return false;
            }

            if (string.IsNullOrEmpty(u.Name))
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Name can't be empty", "Ok");
                return false;
            }
            else
            {
                if (u.Name.Length < 5)
                {
                    Application.Current.MainPage.DisplayAlert("JobMe", "Name can't be empty", "Ok");
                    return false;
                }
            }

            if (u.UserName == null || u.UserName == string.Empty || u.UserName.Length < 4)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Username can't be empty", "Ok");
                return false;
            }

            if (UserHasError)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "UserName already exists", "Ok");
                return false;
            }

            if (u.Password == null || u.Password == string.Empty)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Password can't be empty", "Ok");
                return false;
            }

            if (u.Gender == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Gender can't be empty", "Ok");
                return false;
            }

            if (u.Phone == null || u.Phone == string.Empty)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Phone can't be empty", "Ok");
                return false;
            }

            if (Country == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Country can´t be empty", "Ok");
                return false;
            }

            return true;
        }

        public async Task<bool> ValidaEssential()
        {
            UserDialogs.Instance.ShowLoading();

            await Task.Delay(300);

            if (MailHasError)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El correo ya existe" : "E-Mail already exists",
                    "Ok");
                return false;
            }

            if (Name == null || Name.Length < 2)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El nombre no puede estar vacío" : "Name can't be empty",
                    "Ok");
                return false;
            }

            if (string.IsNullOrEmpty(Mail))
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El Mail no puede estar vacío" : "Mail can't be empty",
                    "Ok");
                return false;
            }
            else
            {
                bool vmail = Regex.IsMatch(Mail, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

                if (!vmail)
                {
                    UserDialogs.Instance.HideLoading();
                    await Application.Current.MainPage.DisplayAlert("JobMe",
                        App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa un email válido" : "Please enter a valid email",
                        "Ok");
                    return false;
                }
            }
            if (string.IsNullOrEmpty(UserName) || UserName.Length < 4)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El usuario no puede estar vacío" : "Username can't be empty",
                    "Ok");
                return false;
            }

            if (UserHasError)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El usuario ya existe, por favor elige otro" : "UserName already exists",
                    "Ok");
                return false;
            }

            if (string.IsNullOrEmpty(Password))
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                     App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El password no puede estar vacío" : "Password can't be empty",
                    "Ok");
                return false;
            }

            if (Gender == null)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                     App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El genero no puede estar vacío" : "Gender can't be empty",
                    "Ok");
                return false;
            }

            if (string.IsNullOrEmpty(Phone))
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El teléfono no puede estar vacío" : "Phone can't be empty",
                    "Ok");
                return false;
            }
            else
            {
                if (Phone.Length < 14)
                {
                    UserDialogs.Instance.HideLoading();
                    await Application.Current.MainPage.DisplayAlert("JobMe",
                        App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa un teléfono válido" : "Please enter a valid phone",
                        "Ok");
                    return false;
                }
            }

            if (Country == null)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El país no puede estar vacío" : "Country can´t be empty",
                    "Ok");
                return false;
            }

            UserDialogs.Instance.HideLoading();
            return true;
        }

        public async Task<bool> ValidaAcademics()
        {
            UserDialogs.Instance.ShowLoading();

            await Task.Delay(300);
            //Academics
            if (School == null)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "La escuela no puede estar vacío" : "School can't be empty",
                    "Ok");
                return false;
            }

            if (Degree == null)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El título no puede estar vacío" : "Degree can't be empty",
                    "Ok");
                return false;
            }

            if (GraduationYears == null)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El año de graduación no puede estar vacío" : "Graduation year can't be empty",
                    "Ok");
                return false;
            }
            if (Languajes == null)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El idioma no puede estar vacío" : "Languajes can't be empty",
                    "Ok");
                return false;
            }

            UserDialogs.Instance.HideLoading();
            return true;
        }

        public async Task<bool> ValidaVideoAcademics()
        {
            UserDialogs.Instance.ShowLoading();

            await Task.Delay(300);

            if (AcadStream == null)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El video académico no puede estar vacío" : "Academics video can't be empty",
                    "Ok");
                return false;
            }

            UserDialogs.Instance.HideLoading();
            return true;
        }

        public async Task<bool> ValidaInterest()
        {
            UserDialogs.Instance.ShowLoading();

            await Task.Delay(300);

            if (BusinessFields == null)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Industria puede estar vacío" : "Business Fields can't be empty",
                    "Ok");
                return false;
            }

            if (MiArea == null)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Áreas de interes no puede estar vacío" : "Areas of interests can't be empty",
                    "Ok");
                return false;
            }

            if (Salary == null)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Salario no puede estar vacío" : "Salary can't be empty",
                    "Ok");
                return false;
            }

            UserDialogs.Instance.HideLoading();
            return true;
        }

        private async void UpdateUserEssential()
        {
            try
            {
                int userid = Preferences.Get("UserID", 0);

                UserModel u = new UserModel()
                {
                    UserID = userid,
                    UserType = 1,
                    Name = Name,
                    BirthDate = BirthDate,
                    Country = Country,
                    City = City ?? new Ciudades() { IDCity = 0, City = "None" },
                    Mail = Mail,
                    Phone = Phone,
                    Gender = Gender,
                    UserName = UserName,
                    Password = Password,
                };

                if (ValidaEssential(u))
                {
                    UserDialogs.Instance.ShowLoading("Updating...");

                    var response = await Services.UserService.UpdatetUserEssentialAsync(u);
                    if (response)
                    {
                        DateTime now = DateTime.Today;
                        int age = now.Year - u.BirthDate.Year;
                        if (u.BirthDate > now.AddYears(-age)) age--;

                        Preferences.Set("Name", Name);
                        Preferences.Set("Age", age.ToString());
                        UserDialogs.Instance.HideLoading();

                        //Envia mensaje para actualizar la lista de trabajos disponibles
                        MessagingCenter.Send<MainEmployeeViewModel, int>(this, "Status", 1);
                        await Application.Current.MainPage.DisplayAlert("JobMe",
                            App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Actualizado correctamente" : "Info Updated",
                            "OK");
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        await Application.Current.MainPage.DisplayAlert("JobMe", "Error updating info", "OK");
                    }
                }
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                throw;
            }
        }

        private async void UpdateUserInterets()
        {
            int userid = Preferences.Get("UserID", 0);
            try
            {
                UserDialogs.Instance.ShowLoading("Updating...");
                UserModel u = new UserModel()
                {
                    UserID = userid,
                    BusinessFields = BusinessFields,
                    MiArea = MiArea,
                    TypeofJob = TypeofJob,
                    ChangeResidence = ChangeResidence,
                    TravelAvailable = TravelAvailable,
                    Salary = Salary,
                };

                var response = await Services.UserService.UpdateUserInterestAsync(u);

                if (response)
                {
                    UserDialogs.Instance.HideLoading();
                    //Envia mensaje para actualizar la lista de trabajos disponibles
                    MessagingCenter.Send<MainEmployeeViewModel, int>(this, "Status", 1);
                    await Application.Current.MainPage.DisplayAlert("JobMe",
                         App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Actualizado correctamente" : "Info Updated",
                        "OK");
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await Application.Current.MainPage.DisplayAlert("JobMe", "Error updating info", "OK");
                }
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                throw;
            }
        }

        private async void UpdateUserAcademics()
        {
            int userid = Preferences.Get("UserID", 0);
            try
            {
                UserDialogs.Instance.ShowLoading("Updating...");
                UserModel u = new UserModel()
                {
                    UserID = userid,
                    UserType = 1,

                    School = School,
                    School1 = School1,
                    School2 = School2,
                    School3 = School3,
                    School4 = School4,

                    Degree = Degree,
                    Degree1 = Degree1,
                    Degree2 = Degree2,
                    Degree3 = Degree3,
                    Degree4 = Degree4,

                    GraduationYears = GraduationYears,
                    GraduationYears1 = GraduationYears1,
                    GraduationYears2 = GraduationYears2,
                    GraduationYears3 = GraduationYears3,
                    GraduationYears4 = GraduationYears4,

                    Certifications = Certifications,
                    Languajes = Languajes,
                };

                var response = await Services.UserService.UpdateUserAcademicsAsync(u);

                if (response)
                {
                    Preferences.Set("Degree", u.Degree.Degree);
                    UserDialogs.Instance.HideLoading();

                    //Envia mensaje para actualizar la lista de trabajos disponibles
                    MessagingCenter.Send<MainEmployeeViewModel, int>(this, "Status", 1);
                    await Application.Current.MainPage.DisplayAlert("JobMe",
                         App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Actualizado correctamente" : "Info Updated",
                        "OK");
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await Application.Current.MainPage.DisplayAlert("JobMe", "Error updating info", "OK");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void UpdateUserJobs()
        {
            int userid = Preferences.Get("UserID", 0);
            try
            {
                UserDialogs.Instance.ShowLoading("Updating...");
                UserModel u = new UserModel()
                {
                    UserID = userid,

                    Firm = Firm,
                    Firm1 = Firm1,
                    Firm2 = Firm2,
                    Firm3 = Firm3,
                    Firm4 = Firm4,

                    JobTitle = JobTitle,
                    JobTitle1 = JobTitle1,
                    JobTitle2 = JobTitle2,
                    JobTitle3 = JobTitle3,
                    JobTitle4 = JobTitle4,

                    Experiences = Experiences,
                    Experiences1 = Experiences1,
                    Experiences2 = Experiences2,
                    Experiences3 = Experiences3,
                    Experiences4 = Experiences4,

                    Mifecha = Mifecha,
                    Mifecha1 = Mifecha1,
                    Mifecha2 = Mifecha2,
                    Mifecha3 = Mifecha3,
                    Mifecha4 = Mifecha4,

                    MifechaFin = MifechaFin,
                    MifechaFin1 = MifechaFin1,
                    MifechaFin2 = MifechaFin2,
                    MifechaFin3 = MifechaFin3,
                    MifechaFin4 = MifechaFin4,

                    WorkHere1 = WorkHere1,
                    WorkHere2 = WorkHere2,
                    WorkHere3 = WorkHere3,
                    WorkHere4 = WorkHere4,
                    WorkHere5 = WorkHere5,
                };

                var response = await Services.UserService.UpdateUserJobsAsync(u);

                if (response)
                {
                    UserDialogs.Instance.HideLoading();
                    //Envia mensaje para actualizar la lista de trabajos disponibles
                    MessagingCenter.Send<MainEmployeeViewModel, int>(this, "Status", 1);
                    await Application.Current.MainPage.DisplayAlert("JobMe",
                         App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Actualizado correctamente" : "Info Updated",
                        "OK");
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await Application.Current.MainPage.DisplayAlert("JobMe", "Error updating info", "OK");
                }
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                throw;
            }
        }

        private async void ViewTerms()
        {
            await Navigation.PushAsync(new TermsView() { Title = "Terms & conditions" });
        }

        private async void PrivacyTerms()
        {
            await Navigation.PushAsync(new PrivacyView() { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Política de privacidad" : "Privacy policy" });
        }

        #region "Bind combos"

        private async void BindAreas()
        {
            IsRun = true;
            ///await Task.Delay(3000);
            listAreas = await Services.JobMe.GetAreas();
            //await Task.Delay(2000);
            IsRun = false;
        }

        public async void BindCountries()
        {
            listCountries = await Services.JobMe.GetCountries();
        }

        private async void BindCities()
        {
            listCities = await Services.JobMe.GetCities();
        }

        private async void BindSchool()
        {
            listSchools = await Services.JobMe.GetSchools();
        }

        private async void BindDegree()
        {
            listDegrees = await Services.JobMe.GetDegrees();
        }

        private async void BindYear()
        {
            ListAñosGraduacion = await Services.JobMe.GetYears();
        }

        private async void BindCertification()
        {
            listCertifications = await Services.JobMe.GetCertifications();
        }

        private async void BindLanguaje()
        {
            listLanguajes = await Services.JobMe.GetLanguajes();
        }

        private async void BindSalaries()
        {
            listSalaries = await Services.JobMe.GetSalaries();
        }

        private async void BindBSFields()
        {
            listbssfields = await Services.JobMe.GetBSFields();
        }

        private async void BindExperience()
        {
            listExperience = await Services.JobMe.GetExperience();
        }

        #endregion "Bind combos"

        public View Essential()
        {
            StackLayout sl1 = new StackLayout() { Margin = new Thickness(10, 0, 10, 0) };

            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "       Esencial       " : "       Essential       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                // VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };

            //Name
            var entryName = new Entry();
            entryName.FontFamily = "Roboto";
            entryName.TextColor = Color.Black;
            entryName.SetBinding(Entry.TextProperty, "Name");
            entryName.Behaviors.Add(new EntryLengthValidator() { MinLength = 3, MaxLength = 50 });

            entryName.BindingContext = this;

            var inputName = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Nombre" : "Name",

                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf0c0",
                    FontFamily = MiFuente,
                    FontSize = 24,
                    FontAttributes = MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                },

                ContainerType = ContainerType.Filled,
                ErrorText = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa tu nombre" : "Enter your name",
                CharMaxLength = 50,
                //inputName.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = entryName
            };

            //Birthday
            var bdaypicker = new DatePicker
            {
                // VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.WhiteSmoke,
                //TextColor = Color.FromHex(Colores.JobMeGray),
                //MaximumDate = DateTime.Now.AddYears(-15),
                MinimumDate = new DateTime(1960, 1, 1),
                //Opacity = 100
            };

            bdaypicker.SetBinding(DatePicker.DateProperty, "BirthDate");
            bdaypicker.BindingContext = this;

            var BirthdayLayout = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Fecha de nacimiento" : "BirthDate",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf1fd",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = bdaypicker
            };

            ////cOUNTRY
            var pickerCountry = new Picker()
            {
                BackgroundColor = Color.WhiteSmoke,
                Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Pais" : "Country",
                TitleColor = Color.FromHex(Colores.JobMeGray)
            };

            pickerCountry.SetBinding(Picker.ItemsSourceProperty, "listCountries");
            pickerCountry.SetBinding(Picker.SelectedItemProperty, "Country", BindingMode.TwoWay);
            pickerCountry.ItemDisplayBinding = new Binding("Country");
            pickerCountry.BindingContext = this;

            var CountryLayout = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "País" : "Country",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf57d",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = pickerCountry
            };
            ///

            ////City
            var pickerCity = new Picker()
            {
                BackgroundColor = Color.WhiteSmoke,
                Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ciudad" : "City",
                TitleColor = Color.FromHex(Colores.JobMeGray)
            };

            pickerCity.SetBinding(Picker.ItemsSourceProperty, "listCities");
            pickerCity.SetBinding(Picker.SelectedItemProperty, "City", BindingMode.TwoWay);
            pickerCity.SetBinding(Picker.IsEnabledProperty, "cityVisible");
            pickerCity.ItemDisplayBinding = new Binding("City");
            pickerCity.BindingContext = this;

            var CityLayout = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ciudad" : "City",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf64f",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = pickerCity
            };

            ////Mail
            var entryMail = new Entry();
            entryMail.TextColor = Color.Black;
            entryMail.Keyboard = Keyboard.Email;
            entryMail.SetBinding(Entry.TextProperty, "Mail");
            entryMail.Behaviors.Add(new EventToCommandBehavior
            {
                EventName = "Unfocused",
                Command = (this).UnFocusedCommand
            });
            entryMail.Behaviors.Add(new EmailValidatorBehavior());

            entryMail.BindingContext = this;
            var inputMail = new SfTextInputLayout
            {
                Hint = "Mail",
                ErrorText = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa un email válido" : "Please enter a valid email",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf0e0",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                //inputMail.HelperText = "Enter your Mail";
                //inputMail.CharMaxLength = 3;
                //inputMail.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = entryMail
            };
            inputMail.SetBinding(SfTextInputLayout.HasErrorProperty, "MailHasError");
            //inputMail.SetBinding(SfTextInputLayout.ErrorTextProperty, "MailErrorText");
            inputMail.BindingContext = this;

            ////Telephone
            var entryTelephone = new Entry();
            entryTelephone.TextColor = Color.Black;
            entryTelephone.Keyboard = Keyboard.Telephone;
            entryTelephone.SetBinding(Entry.TextProperty, "Phone");
            //Se comentaron por que fallan con el rotador de syncfusion
            // entryTelephone.Behaviors.Add(new PhoneNumberMaskBehavior());
            //entryTelephone.Behaviors.Add(new EntryLengthValidator() { MaxLength = 12, MinLength = 12 });
            entryTelephone.BindingContext = this;

            SfMaskedEdit maskedEdit = new SfMaskedEdit();
            maskedEdit.Mask = "00-00-00-00-00";
            maskedEdit.TextColor = Color.Black;
            maskedEdit.Keyboard = Keyboard.Telephone;
            maskedEdit.SetBinding(SfMaskedEdit.ValueProperty, "Phone");
            maskedEdit.ValidationMode = InputValidationMode.LostFocus;
            maskedEdit.BindingContext = this;

            var inputPhone = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Teléfono" : "Phone",
                ErrorText = "Enter a valid 10 digit telephone",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf095",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                //inputPhone.HelperText = "Enter your Phone";
                //inputPhone.CharMaxLength = 3;
                // inputPhone.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = maskedEdit,
            };

            ///Gender nuevo

            var pickerGender = new Picker()
            {
                BackgroundColor = Color.WhiteSmoke,
                Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Género" : "Gender",
                TitleColor = Color.FromHex(Colores.JobMeGray)
            };
            pickerGender.SetBinding(Picker.ItemsSourceProperty, "listGenders");
            pickerGender.SetBinding(Picker.SelectedItemProperty, "Gender", BindingMode.TwoWay);
            pickerGender.ItemDisplayBinding = new Binding("Gender");
            pickerGender.BindingContext = this;

            var genderly = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Género" : "Gender",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf228",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = pickerGender
            };

            ////Username
            var entryUsername = new Entry();
            entryUsername.SetBinding(Entry.TextProperty, "UserName");
            entryUsername.Behaviors.Add(new EventToCommandBehavior
            {
                EventName = "Unfocused",
                Command = (this).UnFocusedCommand
            });
            //entryUsername.Behaviors.Add(new EntryLengthValidator() { MinLength = 6, MaxLength = 10 });
            entryUsername.BindingContext = this;
            var inputUser = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Usuario" : "Username",
                ErrorText = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Mínimo 6 caracteres" : "Minimun 6 characters",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf406",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                // inputUser.HelperText = "Enter your Username";
                //inputUser.CharMaxLength = 3;
                //inputUser.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = entryUsername
            };
            inputUser.SetBinding(SfTextInputLayout.HasErrorProperty, "UserHasError");
            inputUser.SetBinding(SfTextInputLayout.ErrorTextProperty, "UserErrorText");
            inputUser.BindingContext = this;
            ////Password
            var entryPassword = new Entry() { IsPassword = true };
            entryPassword.SetBinding(Entry.TextProperty, "Password");
            // entryPassword.Behaviors.Add(new EntryLengthValidator() { MinLength = 6, MaxLength = 10 });
            entryPassword.BindingContext = this;
            var inputPass = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Contraseña" : "Password",
                ErrorText = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Mínimo 6 caracteres" : "Minimun 6 characters",
                EnablePasswordVisibilityToggle = true,
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf023",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                // inputPass.HelperText = "Enter your Password";
                //inputPass.c = 3;
                //inputPass.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = entryPassword,
                Margin = new Thickness(0, 0, 0, 5)
            };

            var lbPalomita = new SfButton()
            {
                Text = "Update",
                CornerRadius = 5,
                HeightRequest = 40,
                FontSize = 14,
                // VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange)
            };
            lbPalomita.SetBinding(SfButton.CommandProperty, "BtnUpdateEssentialCommand");
            lbPalomita.SetBinding(SfButton.IsVisibleProperty, "UpdateEssentialVisible");
            lbPalomita.BindingContext = this;

            sl1.Orientation = StackOrientation.Vertical;

            sl1.Children.Add(inputes);
            sl1.Children.Add(inputName);
            sl1.Children.Add(BirthdayLayout);
            sl1.Children.Add(CountryLayout);
            sl1.Children.Add(CityLayout);
            sl1.Children.Add(inputMail);
            sl1.Children.Add(inputPhone);
            //sl1.Children.Add(gridGender);
            sl1.Children.Add(genderly);

            sl1.Children.Add(inputUser);
            sl1.Children.Add(inputPass);
            sl1.Children.Add(lbPalomita);
            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                //VerticalOptions = LayoutOptions.FillAndExpand
            };

            scv.Content = sl1;
            return scv;
        }

        public View Academics()
        {
            UserType = 1;

            StackLayout sl1 = new StackLayout() { Margin = new Thickness(10, 0, 10, 0) };

            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "    Historial Académico     " : "       Academics       ",

                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                // VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };

            ////Schools
            ///
            var gridSchool = new Grid();
            gridSchool.Margin = new Thickness(4, 0, 0, 20);

            gridSchool.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            gridSchool.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridSchool.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            //var comboSchool = new SfComboBox()
            //{
            //    BackgroundColor = Color.WhiteSmoke,
            //    HeightRequest = 40,
            //    Watermark = "School",
            //    WatermarkColor = Color.FromHex(Colores.JobMeGray)

            //};

            var pickerSSchool = new Picker()
            {
                BackgroundColor = Color.WhiteSmoke,
                HeightRequest = 40,
                Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Escuela" : "School",
                TitleColor = Color.FromHex(Colores.JobMeGray)
            };

            pickerSSchool.SetBinding(Picker.ItemsSourceProperty, "listSchools");
            pickerSSchool.SetBinding(Picker.SelectedItemProperty, "School", BindingMode.TwoWay);
            pickerSSchool.ItemDisplayBinding = new Binding("School");
            pickerSSchool.BindingContext = this;

            var LeadingViewSchool = new Label()
            {
                Text = "\uf549",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                // VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            //comboSchool.ItemPadding = 5;
            //comboSchool.ShowBorder = false;

            //comboSchool.DataSource = listSchools;
            //comboSchool.DisplayMemberPath = "School";

            //comboSchool.SetBinding(SfComboBox.DataSourceProperty, "listSchools");
            //comboSchool.SetBinding(SfComboBox.SelectedItemProperty, "School");
            //comboSchool.BindingContext = this;

            //comboSchool.SelectionChanged += comboSchool_SelectionChanged;

            gridSchool.Children.Add(LeadingViewSchool, 0, 0);
            gridSchool.Children.Add(pickerSSchool, 1, 0);

            //Degree
            var gridDegree = new Grid();
            gridDegree.Margin = new Thickness(4, 0, 0, 20);

            gridDegree.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            gridDegree.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridDegree.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            //var comboDegree = new SfComboBox()
            //{
            //    BackgroundColor = Color.WhiteSmoke,
            //    HeightRequest = 40,
            //    Watermark = "Degree",
            //    WatermarkColor = Color.FromHex(Colores.JobMeGray)

            //};

            var pickerDegree = new Picker()
            {
                BackgroundColor = Color.WhiteSmoke,
                HeightRequest = 40,
                Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Título" : "Degree",

                TitleColor = Color.FromHex(Colores.JobMeGray)
            };

            pickerDegree.SetBinding(Picker.ItemsSourceProperty, "listDegrees");
            pickerDegree.SetBinding(Picker.SelectedItemProperty, "Degree", BindingMode.TwoWay);
            pickerDegree.ItemDisplayBinding = new Binding("Degree");
            pickerDegree.BindingContext = this;

            var LeadingViewDegree = new Label()
            {
                Text = "\uf091",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                // VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };
            //comboDegree.ItemPadding = 5;
            //comboDegree.ShowBorder = false;
            //comboDegree.DataSource = listDegrees;
            //comboDegree.DisplayMemberPath = "Degree";

            //comboDegree.SetBinding(SfComboBox.DataSourceProperty, "listDegrees");
            //comboDegree.SetBinding(SfComboBox.SelectedItemProperty, "Degree");
            //comboDegree.BindingContext = this;

            // comboDegree.SelectionChanged += comboDegree_SelectionChanged;

            gridDegree.Children.Add(LeadingViewDegree, 0, 0);
            gridDegree.Children.Add(pickerDegree, 1, 0);

            //Graduation

            var gridGraduation = new Grid();
            gridGraduation.Margin = new Thickness(4, 0, 0, 20);

            gridGraduation.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            gridGraduation.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridGraduation.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            //var comboGraduation = new SfComboBox()
            //{
            //    BackgroundColor = Color.WhiteSmoke,
            //    HeightRequest = 40,
            //    Watermark = "Graduation year",
            //    WatermarkColor = Color.FromHex(Colores.JobMeGray)
            //};

            var pickerGraduation = new Picker()
            {
                BackgroundColor = Color.WhiteSmoke,
                HeightRequest = 40,
                Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Año de graduación" : "Graduation year",

                TitleColor = Color.FromHex(Colores.JobMeGray)
            };

            pickerGraduation.SetBinding(Picker.ItemsSourceProperty, "ListAñosGraduacion");
            pickerGraduation.SetBinding(Picker.SelectedItemProperty, "GraduationYears", BindingMode.TwoWay);
            pickerGraduation.ItemDisplayBinding = new Binding("Year");
            pickerGraduation.BindingContext = this;

            var LeadingViewGraduation = new Label()
            {
                Text = "\uf501",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };
            //comboGraduation.ItemPadding = 5;
            //comboGraduation.ShowBorder = false;

            //comboGraduation.DataSource = ListAñosGraduacion;
            //comboGraduation.DisplayMemberPath = "Year";

            ////  comboGraduation.SelectionChanged += comboGraduation_SelectionChanged;

            //comboGraduation.SetBinding(SfComboBox.DataSourceProperty, "ListAñosGraduacion");
            //comboGraduation.SetBinding(SfComboBox.SelectedItemProperty, "GraduationYears");
            //comboGraduation.BindingContext = this;

            gridGraduation.Children.Add(LeadingViewGraduation, 0, 0);
            gridGraduation.Children.Add(pickerGraduation, 1, 0);

            // Token Customization
            TokenSettings token = new TokenSettings();
            token.FontSize = 10;
            token.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
            token.IsCloseButtonVisible = true;
            token.CornerRadius = 15;
            token.DeleteButtonPlacement = DeleteButtonPlacement.Left;

            //Certifications
            var gridCertifications = new Grid();
            gridCertifications.Margin = new Thickness(4, 0, 0, 20);

            gridCertifications.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            gridCertifications.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.40, GridUnitType.Star) });
            gridCertifications.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.60, GridUnitType.Star) });

            var comboCertifications = new SfComboBox()
            {
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Certificaciones" : "Certifications",

                //BackgroundColor=Color.FromHex("#FFFFFF"),
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                // HeightRequest = 70,
                //WidthRequest = 100,
                IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                ShowBorder = false,
                ShowClearButton = false,
            };

            // Create Border control
            SfBorder border = new SfBorder();
            border.CornerRadius = 10;
            // border.VerticalOptions = LayoutOptions.FillAndExpand;
            //  border.HorizontalOptions = LayoutOptions.FillAndExpand;
            border.BorderColor = Color.FromHex(Colores.JobMeOrange);

            border.Content = comboCertifications;

            //comboCertifications.DataSource = listCertifications;
            comboCertifications.DisplayMemberPath = "Certification";
            comboCertifications.SetBinding(SfComboBox.SelectedItemProperty, "Certifications", BindingMode.TwoWay);
            comboCertifications.SetBinding(SfComboBox.DataSourceProperty, "listCertifications");
            comboCertifications.BindingContext = this;
            // comboCertifications.SelectionChanged += comboCertifications_SelectionChanged;
            //comboCertifications.HeightRequest = 60;
            // inputCertifications.InputView = comboCertifications;

            var lbcertifications = new Label
            {
                // VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Certificaciones" : "Certifications",
                TextColor = Color.FromHex(Colores.JobMeGray),
                HeightRequest = 70,
            };

            gridCertifications.Children.Add(lbcertifications, 0, 0);
            gridCertifications.Children.Add(border, 1, 0);

            //Languaje

            var gridLanguaje = new Grid();
            gridLanguaje.Margin = new Thickness(4, 0, 0, 20);

            gridLanguaje.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            gridLanguaje.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.40, GridUnitType.Star) });
            gridLanguaje.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.60, GridUnitType.Star) });

            var comboLanguaje = new SfComboBox()
            {
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Idiomas" : "Languaje",

                //BackgroundColor=Color.FromHex("#FFFFFF"),
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                //HeightRequest = 70,
                //WidthRequest = 100,
                IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                ShowClearButton = false,
                EnableAutoSize = true,
            };

            // Create Border control
            SfBorder borderLanguaje = new SfBorder();
            borderLanguaje.CornerRadius = 10;
            //  borderLanguaje.VerticalOptions = LayoutOptions.FillAndExpand;
            //  borderLanguaje.HorizontalOptions = LayoutOptions.FillAndExpand;
            borderLanguaje.BorderColor = Color.FromHex(Colores.JobMeOrange);

            borderLanguaje.Content = comboLanguaje;

            comboLanguaje.ItemPadding = 5;
            comboLanguaje.ShowBorder = false;

            comboLanguaje.DataSource = listLanguajes;
            comboLanguaje.DisplayMemberPath = "Languaje";

            // comboLanguaje.SelectionChanged += comboLanguaje_SelectionChanged;
            comboLanguaje.SetBinding(SfComboBox.SelectedItemProperty, "Languajes", BindingMode.TwoWay);
            comboLanguaje.SetBinding(SfComboBox.DataSourceProperty, "listLanguajes");
            comboLanguaje.BindingContext = this;

            //inputLanguaje.InputView = comboLanguaje;

            var lblanguaje = new Label
            {
                // VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Idiomas" : "Languajes",
                TextColor = Color.FromHex(Colores.JobMeGray),
                HeightRequest = 70,
            };

            gridLanguaje.Children.Add(lblanguaje, 0, 0);
            gridLanguaje.Children.Add(borderLanguaje, 1, 0);

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    comboCertifications.EnableAutoSize = false;
                    comboLanguaje.EnableAutoSize = false;
                    break; ;
                case Device.Android:
                    comboCertifications.EnableAutoSize = true;
                    comboLanguaje.EnableAutoSize = true;
                    break;
            };

            var lbaddmore = new Label
            {
                //Text = " +      Add more       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                // VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };

            lbaddmore.SetBinding(Label.TextProperty, "TextAddMore");
            lbaddmore.BindingContext = this;

            var lbaddmoretap = new TapGestureRecognizer();
            lbaddmoretap.Tapped += (sender, args) =>
           {
               addMoreVisible = true;
               lbaddmore.IsVisible = false;
           };

            lbaddmore.GestureRecognizers.Add(lbaddmoretap);

            View AddMoreSchool1()
            {
                var gridSchool1 = new Grid();

                gridSchool1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible");
                gridSchool1.BindingContext = this;

                gridSchool1.Margin = new Thickness(4, 0, 0, 20);

                gridSchool1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridSchool1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridSchool1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                //var comboSchool1 = new SfComboBox()
                //{
                //    BackgroundColor = Color.WhiteSmoke,
                //    HeightRequest = 40,
                //    Watermark = "School",
                //    WatermarkColor = Color.FromHex(Colores.JobMeGray)

                //};
                var pickerSSchool1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Escuela" : "School",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerSSchool1.SetBinding(Picker.ItemsSourceProperty, "listSchools");
                pickerSSchool1.SetBinding(Picker.SelectedItemProperty, "School1", BindingMode.TwoWay);
                pickerSSchool1.ItemDisplayBinding = new Binding("School");
                pickerSSchool1.BindingContext = this;

                var LeadingViewSchool1 = new Label()
                {
                    Text = "\uf549",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                gridSchool1.Children.Add(LeadingViewSchool1, 0, 0);
                gridSchool1.Children.Add(pickerSSchool1, 1, 0);

                return gridSchool1;
            }

            View AddMoreDegree1()
            {
                //Degree
                var gridDegree1 = new Grid();
                gridDegree1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible");
                gridDegree1.BindingContext = this;
                gridDegree1.Margin = new Thickness(4, 0, 0, 20);

                gridDegree1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridDegree1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridDegree1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                //var comboDegree1 = new SfComboBox()
                //{
                //    BackgroundColor = Color.WhiteSmoke,
                //    HeightRequest = 40,
                //    Watermark = "Degree",
                //};
                var pickerDegree1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Título" : "Degree",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerDegree1.SetBinding(Picker.ItemsSourceProperty, "listDegrees");
                pickerDegree1.SetBinding(Picker.SelectedItemProperty, "Degree1", BindingMode.TwoWay);
                pickerDegree1.ItemDisplayBinding = new Binding("Degree");
                pickerDegree1.BindingContext = this;

                var LeadingViewDegree1 = new Label()
                {
                    Text = "\uf091",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                //comboDegree1.ItemPadding = 5;
                //comboDegree1.ShowBorder = false;

                //comboDegree1.DataSource = listDegrees;
                //comboDegree1.DisplayMemberPath = "Degree";

                //comboDegree1.SetBinding(SfComboBox.DataSourceProperty, "listDegrees");
                //comboDegree1.SetBinding(SfComboBox.SelectedItemProperty, "Degree1");
                //comboDegree1.BindingContext = this;
                //   comboDegree1.SelectionChanged += comboDegree_SelectionChanged;

                gridDegree1.Children.Add(LeadingViewDegree1, 0, 0);
                gridDegree1.Children.Add(pickerDegree1, 1, 0);

                return gridDegree1;
            }

            View AddMoreGraduation1()
            {
                var gridGraduation1 = new Grid();
                gridGraduation1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible");
                gridGraduation1.BindingContext = this;

                gridGraduation1.Margin = new Thickness(4, 0, 0, 20);

                gridGraduation1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridGraduation1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridGraduation1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                //var comboGraduation1 = new SfComboBox()
                //{
                //    BackgroundColor = Color.WhiteSmoke,
                //    HeightRequest = 40,
                //    Watermark = "Graduation year",
                //};

                var pickerGraduation1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Año de graduación" : "Graduation year",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerGraduation1.SetBinding(Picker.ItemsSourceProperty, "ListAñosGraduacion");
                pickerGraduation1.SetBinding(Picker.SelectedItemProperty, "GraduationYears1", BindingMode.TwoWay);
                pickerGraduation1.ItemDisplayBinding = new Binding("Year");
                pickerGraduation1.BindingContext = this;

                var LeadingViewGraduation1 = new Label()
                {
                    Text = "\uf501",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                //comboGraduation1.ItemPadding = 5;
                //comboGraduation1.ShowBorder = false;

                //comboGraduation1.DataSource = ListAñosGraduacion;
                //comboGraduation1.DisplayMemberPath = "Year";

                ////   comboGraduation1.SelectionChanged += comboGraduation_SelectionChanged;

                //comboGraduation1.SetBinding(SfComboBox.DataSourceProperty, "ListAñosGraduacion");
                //comboGraduation1.SetBinding(SfComboBox.SelectedItemProperty, "GraduationYears1");
                //comboGraduation1.BindingContext = this;

                gridGraduation1.Children.Add(LeadingViewGraduation1, 0, 0);
                gridGraduation1.Children.Add(pickerGraduation1, 1, 0);

                return gridGraduation1;
            }

            var lbaddmore1 = new Label
            {
                // Text = " +      Add more       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                // VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };

            lbaddmore1.SetBinding(Label.TextProperty, "TextAddMore");
            lbaddmore1.SetBinding(Label.IsVisibleProperty, "addMoreVisible");
            lbaddmore1.BindingContext = this;

            var lbaddmoretap1 = new TapGestureRecognizer();
            lbaddmoretap1.Tapped += (sender, args) =>
            {
                addMoreVisible1 = true;
                lbaddmore1.IsVisible = false;
            };

            lbaddmore1.GestureRecognizers.Add(lbaddmoretap1);
            //////////////////////////////////////
            View AddMoreSchool2()
            {
                var gridSchool1 = new Grid();

                gridSchool1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible1");
                gridSchool1.BindingContext = this;

                gridSchool1.Margin = new Thickness(4, 0, 0, 20);

                gridSchool1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridSchool1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridSchool1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                //var comboSchool1 = new SfComboBox()
                //{
                //    BackgroundColor = Color.WhiteSmoke,
                //    HeightRequest = 40,
                //    Watermark = "School",
                //    WatermarkColor = Color.FromHex(Colores.JobMeGray)

                //};

                var pickerSSchool1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Escuela" : "School",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerSSchool1.SetBinding(Picker.ItemsSourceProperty, "listSchools");
                pickerSSchool1.SetBinding(Picker.SelectedItemProperty, "School2", BindingMode.TwoWay);
                pickerSSchool1.ItemDisplayBinding = new Binding("School");
                pickerSSchool1.BindingContext = this;

                var LeadingViewSchool1 = new Label()
                {
                    Text = "\uf549",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                //comboSchool1.ItemPadding = 5;
                //comboSchool1.ShowBorder = false;

                //comboSchool1.DataSource = listSchools;
                //comboSchool1.DisplayMemberPath = "School";

                //comboSchool1.SetBinding(SfComboBox.DataSourceProperty, "listSchools");
                //comboSchool1.SetBinding(SfComboBox.SelectedItemProperty, "School2");
                //comboSchool1.BindingContext = this;

                // comboSchool1.SelectionChanged += comboSchool_SelectionChanged;

                gridSchool1.Children.Add(LeadingViewSchool1, 0, 0);
                gridSchool1.Children.Add(pickerSSchool1, 1, 0);

                return gridSchool1;
            }

            View AddMoreDegree2()
            {
                //Degree
                var gridDegree1 = new Grid();
                gridDegree1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible1");
                gridDegree1.BindingContext = this;
                gridDegree1.Margin = new Thickness(4, 0, 0, 20);

                gridDegree1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridDegree1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridDegree1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                //var comboDegree1 = new SfComboBox()
                //{
                //    BackgroundColor = Color.WhiteSmoke,
                //    HeightRequest = 40,
                //    Watermark = "Degree",
                //};
                var pickerDegree1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Título" : "Degree",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerDegree1.SetBinding(Picker.ItemsSourceProperty, "listDegrees");
                pickerDegree1.SetBinding(Picker.SelectedItemProperty, "Degree2", BindingMode.TwoWay);
                pickerDegree1.ItemDisplayBinding = new Binding("Degree");
                pickerDegree1.BindingContext = this;

                var LeadingViewDegree1 = new Label()
                {
                    Text = "\uf091",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                //comboDegree1.ItemPadding = 5;
                //comboDegree1.ShowBorder = false;

                //comboDegree1.DataSource = listDegrees;
                //comboDegree1.DisplayMemberPath = "Degree";

                //comboDegree1.SetBinding(SfComboBox.DataSourceProperty, "listDegrees");
                //comboDegree1.SetBinding(SfComboBox.SelectedItemProperty, "Degree2");
                //comboDegree1.BindingContext = this;
                //   comboDegree1.SelectionChanged += comboDegree_SelectionChanged;

                gridDegree1.Children.Add(LeadingViewDegree1, 0, 0);
                gridDegree1.Children.Add(pickerDegree1, 1, 0);

                return gridDegree1;
            }

            View AddMoreGraduation2()
            {
                var gridGraduation1 = new Grid();
                gridGraduation1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible1");
                gridGraduation1.BindingContext = this;

                gridGraduation1.Margin = new Thickness(4, 0, 0, 20);

                gridGraduation1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridGraduation1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridGraduation1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                //var comboGraduation1 = new SfComboBox()
                //{
                //    BackgroundColor = Color.WhiteSmoke,
                //    HeightRequest = 40,
                //    Watermark = "Graduation year",
                //};

                var pickerGraduation1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Año de graduación" : "Graduation year",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerGraduation1.SetBinding(Picker.ItemsSourceProperty, "ListAñosGraduacion");
                pickerGraduation1.SetBinding(Picker.SelectedItemProperty, "GraduationYears2", BindingMode.TwoWay);
                pickerGraduation1.ItemDisplayBinding = new Binding("Year");
                pickerGraduation1.BindingContext = this;

                var LeadingViewGraduation1 = new Label()
                {
                    Text = "\uf501",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                gridGraduation1.Children.Add(LeadingViewGraduation1, 0, 0);
                gridGraduation1.Children.Add(pickerGraduation1, 1, 0);

                return gridGraduation1;
            }

            var lbaddmore2 = new Label
            {
                //Text = " +      Add more       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                //VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };
            lbaddmore2.SetBinding(Label.TextProperty, "TextAddMore");
            lbaddmore2.SetBinding(Label.IsVisibleProperty, "addMoreVisible1");
            lbaddmore2.BindingContext = this;

            var lbaddmoretap2 = new TapGestureRecognizer();
            lbaddmoretap2.Tapped += (sender, args) =>
            {
                addMoreVisible2 = true;
                lbaddmore2.IsVisible = false;
            };

            lbaddmore2.GestureRecognizers.Add(lbaddmoretap2);

            //////////////////////////////////////
            View AddMoreSchool3()
            {
                var gridSchool1 = new Grid();

                gridSchool1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible2");
                gridSchool1.BindingContext = this;

                gridSchool1.Margin = new Thickness(4, 0, 0, 20);

                gridSchool1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridSchool1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridSchool1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                //var comboSchool1 = new SfComboBox()
                //{
                //    BackgroundColor = Color.WhiteSmoke,
                //    HeightRequest = 40,
                //    Watermark = "School",
                //    WatermarkColor = Color.FromHex(Colores.JobMeGray)

                //};
                var pickerSSchool1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Escuela" : "School",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerSSchool1.SetBinding(Picker.ItemsSourceProperty, "listSchools");
                pickerSSchool1.SetBinding(Picker.SelectedItemProperty, "School3", BindingMode.TwoWay);
                pickerSSchool1.ItemDisplayBinding = new Binding("School");
                pickerSSchool1.BindingContext = this;

                var LeadingViewSchool1 = new Label()
                {
                    Text = "\uf549",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                //comboSchool1.ItemPadding = 5;
                //comboSchool1.ShowBorder = false;

                //comboSchool1.DataSource = listSchools;
                //comboSchool1.DisplayMemberPath = "School";

                //comboSchool1.SetBinding(SfComboBox.DataSourceProperty, "listSchools");
                //comboSchool1.SetBinding(SfComboBox.SelectedItemProperty, "School3");
                //comboSchool1.BindingContext = this;

                // comboSchool1.SelectionChanged += comboSchool_SelectionChanged;

                gridSchool1.Children.Add(LeadingViewSchool1, 0, 0);
                gridSchool1.Children.Add(pickerSSchool1, 1, 0);

                return gridSchool1;
            }

            View AddMoreDegree3()
            {
                //Degree
                var gridDegree1 = new Grid();
                gridDegree1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible2");
                gridDegree1.BindingContext = this;
                gridDegree1.Margin = new Thickness(4, 0, 0, 20);

                gridDegree1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridDegree1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridDegree1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                //var comboDegree1 = new SfComboBox()
                //{
                //    BackgroundColor = Color.WhiteSmoke,
                //    HeightRequest = 40,
                //    Watermark = "Degree",
                //};
                var pickerDegree1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Título" : "Degree",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerDegree1.SetBinding(Picker.ItemsSourceProperty, "listDegrees");
                pickerDegree1.SetBinding(Picker.SelectedItemProperty, "Degree3", BindingMode.TwoWay);
                pickerDegree1.ItemDisplayBinding = new Binding("Degree");
                pickerDegree1.BindingContext = this;

                var LeadingViewDegree1 = new Label()
                {
                    Text = "\uf091",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                gridDegree1.Children.Add(LeadingViewDegree1, 0, 0);
                gridDegree1.Children.Add(pickerDegree1, 1, 0);

                return gridDegree1;
            }

            View AddMoreGraduation3()
            {
                var gridGraduation1 = new Grid();
                gridGraduation1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible2");
                gridGraduation1.BindingContext = this;

                gridGraduation1.Margin = new Thickness(4, 0, 0, 20);

                gridGraduation1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridGraduation1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridGraduation1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                var pickerGraduation1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Año de graduación" : "Graduation year",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerGraduation1.SetBinding(Picker.ItemsSourceProperty, "ListAñosGraduacion");
                pickerGraduation1.SetBinding(Picker.SelectedItemProperty, "GraduationYears3", BindingMode.TwoWay);
                pickerGraduation1.ItemDisplayBinding = new Binding("Year");
                pickerGraduation1.BindingContext = this;

                var LeadingViewGraduation1 = new Label()
                {
                    Text = "\uf501",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                gridGraduation1.Children.Add(LeadingViewGraduation1, 0, 0);
                gridGraduation1.Children.Add(pickerGraduation1, 1, 0);

                return gridGraduation1;
            }

            var lbaddmore3 = new Label
            {
                Text = " +      Add more       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                //VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };

            lbaddmore3.SetBinding(Label.TextProperty, "TextAddMore");
            lbaddmore3.SetBinding(Label.IsVisibleProperty, "addMoreVisible2");
            lbaddmore3.BindingContext = this;

            var lbaddmoretap3 = new TapGestureRecognizer();
            lbaddmoretap3.Tapped += (sender, args) =>
            {
                addMoreVisible3 = true;
                lbaddmore3.IsVisible = false;
            };

            lbaddmore3.GestureRecognizers.Add(lbaddmoretap3);

            //////////////////////////////////////
            ///
            View AddMoreSchool4()
            {
                var gridSchool1 = new Grid();

                gridSchool1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible3");
                gridSchool1.BindingContext = this;

                gridSchool1.Margin = new Thickness(4, 0, 0, 20);

                gridSchool1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridSchool1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridSchool1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                //var comboSchool1 = new SfComboBox()
                //{
                //    BackgroundColor = Color.WhiteSmoke,
                //    HeightRequest = 40,
                //    Watermark = "School",
                //    WatermarkColor = Color.FromHex(Colores.JobMeGray)

                //};
                var pickerSSchool1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Escuela" : "School",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerSSchool1.SetBinding(Picker.ItemsSourceProperty, "listSchools");
                pickerSSchool1.SetBinding(Picker.SelectedItemProperty, "School4", BindingMode.TwoWay);
                pickerSSchool1.ItemDisplayBinding = new Binding("School");
                pickerSSchool1.BindingContext = this;
                var LeadingViewSchool1 = new Label()
                {
                    Text = "\uf549",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                gridSchool1.Children.Add(LeadingViewSchool1, 0, 0);
                gridSchool1.Children.Add(pickerSSchool1, 1, 0);

                return gridSchool1;
            }

            View AddMoreDegree4()
            {
                //Degree
                var gridDegree1 = new Grid();
                gridDegree1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible3");
                gridDegree1.BindingContext = this;
                gridDegree1.Margin = new Thickness(4, 0, 0, 20);

                gridDegree1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridDegree1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridDegree1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                //var comboDegree1 = new SfComboBox()
                //{
                //    BackgroundColor = Color.WhiteSmoke,
                //    HeightRequest = 40,
                //    Watermark = "Degree",
                //};
                var pickerDegree1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Título" : "Degree",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerDegree1.SetBinding(Picker.ItemsSourceProperty, "listDegrees");
                pickerDegree1.SetBinding(Picker.SelectedItemProperty, "Degree4", BindingMode.TwoWay);
                pickerDegree1.ItemDisplayBinding = new Binding("Degree");
                pickerDegree1.BindingContext = this;

                var LeadingViewDegree1 = new Label()
                {
                    Text = "\uf091",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                gridDegree1.Children.Add(LeadingViewDegree1, 0, 0);
                gridDegree1.Children.Add(pickerDegree1, 1, 0);

                return gridDegree1;
            }

            View AddMoreGraduation4()
            {
                var gridGraduation1 = new Grid();
                gridGraduation1.SetBinding(Grid.IsVisibleProperty, "addMoreVisible3");
                gridGraduation1.BindingContext = this;

                gridGraduation1.Margin = new Thickness(4, 0, 0, 20);

                gridGraduation1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

                gridGraduation1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
                gridGraduation1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

                var pickerGraduation1 = new Picker()
                {
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 40,
                    Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Año de graduación" : "Graduation year",
                    TitleColor = Color.FromHex(Colores.JobMeGray)
                };

                pickerGraduation1.SetBinding(Picker.ItemsSourceProperty, "ListAñosGraduacion");
                pickerGraduation1.SetBinding(Picker.SelectedItemProperty, "GraduationYears4", BindingMode.TwoWay);
                pickerGraduation1.ItemDisplayBinding = new Binding("Year");
                pickerGraduation1.BindingContext = this;

                var LeadingViewGraduation1 = new Label()
                {
                    Text = "\uf501",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                //comboGraduation1.ItemPadding = 5;
                //comboGraduation1.ShowBorder = false;

                //comboGraduation1.DataSource = ListAñosGraduacion;
                //comboGraduation1.DisplayMemberPath = "Year";

                ////   comboGraduation1.SelectionChanged += comboGraduation_SelectionChanged;

                //comboGraduation1.SetBinding(SfComboBox.DataSourceProperty, "ListAñosGraduacion");
                //comboGraduation1.SetBinding(SfComboBox.SelectedItemProperty, "GraduationYears4");
                //comboGraduation1.BindingContext = this;

                gridGraduation1.Children.Add(LeadingViewGraduation1, 0, 0);
                gridGraduation1.Children.Add(pickerGraduation1, 1, 0);

                return gridGraduation1;
            }

            var lbPalomita = new SfButton()
            {
                Text = "Update",
                CornerRadius = 5,
                HeightRequest = 40,
                FontSize = 14,
                // VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange)
            };
            lbPalomita.SetBinding(SfButton.CommandProperty, "BtnUpdateAcademicsCommand");
            lbPalomita.SetBinding(SfButton.IsVisibleProperty, "UpdateAcademicsVisible");
            lbPalomita.BindingContext = this;

            sl1.Orientation = StackOrientation.Vertical;

            sl1.Children.Add(inputes);
            sl1.Children.Add(gridSchool);
            sl1.Children.Add(gridDegree);
            sl1.Children.Add(gridGraduation);
            sl1.Children.Add(gridCertifications);
            sl1.Children.Add(gridLanguaje);

            sl1.Children.Add(lbaddmore);

            //sl1.Children.Add(lbPalomita);
            ////////////////////////////////////////
            sl1.Children.Add(AddMoreSchool1());
            sl1.Children.Add(AddMoreDegree1());
            sl1.Children.Add(AddMoreGraduation1());
            sl1.Children.Add(lbaddmore1);
            ////////////////////////////////////////
            sl1.Children.Add(AddMoreSchool2());
            sl1.Children.Add(AddMoreDegree2());
            sl1.Children.Add(AddMoreGraduation2());
            sl1.Children.Add(lbaddmore2);
            ////////////////////////////////////////
            sl1.Children.Add(AddMoreSchool3());
            sl1.Children.Add(AddMoreDegree3());
            sl1.Children.Add(AddMoreGraduation3());
            sl1.Children.Add(lbaddmore3);
            ///////////////////////////////////////
            sl1.Children.Add(AddMoreSchool4());
            sl1.Children.Add(AddMoreDegree4());
            sl1.Children.Add(AddMoreGraduation4());
            sl1.Children.Add(lbPalomita);

            ////////////////////////////////////////

            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                //  VerticalOptions = LayoutOptions.FillAndExpand
            };
            scv.Content = sl1;

            return scv;
        }

        public View Interest()
        {
            StackLayout sl1 = new StackLayout() { Margin = new Thickness(10, 0, 10, 0) };

            // Token Customization
            TokenSettings token = new TokenSettings();
            token.FontSize = 12;
            token.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
            token.IsCloseButtonVisible = true;
            token.CornerRadius = 15;
            token.DeleteButtonPlacement = DeleteButtonPlacement.Left;

            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "       Intereses       " : "       Interest       ",

                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                // VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };

            var gridArea1 = new Grid();
            //ámbito profesional
            gridArea1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.25, GridUnitType.Star) });
            gridArea1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.75, GridUnitType.Star) });

            var comboArea1 = new SfComboBox
            {
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Industria" : "Bussines Fields",

                // BackgroundColor = Color.FromHex("#FFFFFF"),
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                //HeightRequest = 80,
                // WidthRequest = 100,
                IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                ShowBorder = false,
                TokenSettings = token,
                ShowClearButton = false,
                Margin = new Thickness(0, 0, 0, 10),

                DropDownButtonSettings = new DropDownButtonSettings { Width = 30, },
            };

            //comboArea1.DropDownClosed += ComboArea1_DropDownClosed1;
            //comboArea.DataSource = listAreas;
            comboArea1.DisplayMemberPath = "BusinessField";
            comboArea1.SetBinding(SfComboBox.DataSourceProperty, "listbssfields");
            comboArea1.SetBinding(SfComboBox.SelectedItemProperty, "BusinessFields", BindingMode.TwoWay);
            comboArea1.BindingContext = this;

            //inputArea.InputView = comboArea;

            var lbarea1 = new Label
            {
                // VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Industria" : "Bussines Fields",
                TextColor = Color.FromHex(Colores.JobMeGray),
                HeightRequest = 80,
            };

            // Create Border control
            SfBorder borderArea1 = new SfBorder();
            borderArea1.CornerRadius = 10;
            //borderArea.VerticalOptions = LayoutOptions.FillAndExpand;
            // borderArea1.HorizontalOptions = LayoutOptions.FillAndExpand;
            borderArea1.BorderColor = Color.FromHex(Colores.JobMeOrange);

            borderArea1.Content = comboArea1;

            gridArea1.Children.Add(lbarea1, 0, 0);
            gridArea1.Children.Add(borderArea1, 1, 0);

            //Area

            var gridArea = new Grid();

            gridArea.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.25, GridUnitType.Star) });
            gridArea.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.75, GridUnitType.Star) });

            var comboArea = new SfComboBox
            {
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Áreas" : "Areas",
                // BackgroundColor = Color.FromHex("#FFFFFF"),
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                //HeightRequest = 80,
                // WidthRequest = 100,
                IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                ShowBorder = false,
                TokenSettings = token,
                ShowClearButton = false,

                Margin = new Thickness(0, 0, 0, 10),

                DropDownButtonSettings = new DropDownButtonSettings { Width = 30, },
            };

            //comboArea.DataSource = listAreas;
            comboArea.DisplayMemberPath = "Area";
            comboArea.SetBinding(SfComboBox.DataSourceProperty, "listAreas");
            comboArea.SetBinding(SfComboBox.SelectedItemProperty, "MiArea", BindingMode.TwoWay);

            comboArea.BindingContext = this;

            //inputArea.InputView = comboArea;

            var lbarea = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Área" : "Area",
                TextColor = Color.FromHex(Colores.JobMeGray),
                HeightRequest = 80,
            };

            // Create Border control
            SfBorder borderArea = new SfBorder();
            borderArea.CornerRadius = 10;
            //borderArea.VerticalOptions = LayoutOptions.FillAndExpand;
            // borderArea.HorizontalOptions = LayoutOptions.FillAndExpand;
            borderArea.BorderColor = Color.FromHex(Colores.JobMeOrange);

            borderArea.Content = comboArea;

            gridArea.Children.Add(lbarea, 0, 0);
            gridArea.Children.Add(borderArea, 1, 0);

            //comboArea.SelectionChanged += comboArea_SelectionChanged;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    comboArea1.EnableAutoSize = false;
                    comboArea.EnableAutoSize = false;
                    break; ;
                case Device.Android:
                    comboArea1.EnableAutoSize = true;
                    comboArea.EnableAutoSize = true;
                    break;
            };

            //Type of job
            var gridJob = new Grid();

            gridJob.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.35, GridUnitType.Star) });
            gridJob.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.65, GridUnitType.Star) });

            SfSegmentedControl segmentedControlType = new SfSegmentedControl();

            List<String> typesjob;

            if (App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español)
            {
                typesjob = new List<String>
                {
                    "Medio tiempo","Tiempo completo"
                };
            }
            else
            {
                typesjob = new List<String>
                {
                    "Part Time","Full Time"
                };
            }

            if (App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español)
            {
                segmentedControlType.WidthRequest = 220;
            }
            segmentedControlType.ItemsSource = typesjob;
            segmentedControlType.DisplayMode = SegmentDisplayMode.Text;
            segmentedControlType.Color = Color.FromHex("#FFFFFF");
            segmentedControlType.SegmentHeight = 40;
            segmentedControlType.VisibleSegmentsCount = 3;
            segmentedControlType.CornerRadius = 5;
            segmentedControlType.HeightRequest = 20;
            segmentedControlType.SelectedIndex = 1;
            segmentedControlType.BorderColor = Color.FromHex(Colores.JobMeOrange);
            segmentedControlType.FontColor = Color.FromHex(Colores.JobMeGray);

            segmentedControlType.FontSize = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? 14 : 18;
            segmentedControlType.VerticalOptions = LayoutOptions.Center;
            segmentedControlType.HorizontalOptions = LayoutOptions.End;
            segmentedControlType.SelectionTextColor = Color.FromHex("#FFFFFF");
            segmentedControlType.Margin = new Thickness(0, 10, 0, 10);
            SelectionIndicatorSettings selectionIndicator1 = new SelectionIndicatorSettings();
            selectionIndicator1.Color = Color.FromHex(Colores.JobMeGray);
            segmentedControlType.SelectionIndicatorSettings = selectionIndicator1;

            var lbJob = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Tipo de empleo" : "Type of job",
                TextColor = Color.FromHex(Colores.JobMeGray),
            };

            segmentedControlType.SetBinding(SfSegmentedControl.SelectedIndexProperty, "TypeofJob");
            segmentedControlType.BindingContext = this;

            gridJob.Children.Add(lbJob, 0, 0);
            gridJob.Children.Add(segmentedControlType, 1, 0);

            //Residence
            var gridResidence = new Grid();

            gridResidence.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.35, GridUnitType.Star) });
            gridResidence.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.65, GridUnitType.Star) });
            SfSegmentedControl segmentedControlResidence = new SfSegmentedControl();

            List<String> periodsList = new List<String>();

            if (App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español)
            {
                periodsList = new List<String>
                {
                    "No","Si"
                };
            }
            else
            {
                periodsList = new List<String>
                {
                    "No","Yes"
                };
            }

            segmentedControlResidence.ItemsSource = periodsList;
            segmentedControlResidence.DisplayMode = SegmentDisplayMode.Text;
            segmentedControlResidence.Color = Color.FromHex("#FFFFFF");
            segmentedControlResidence.SegmentHeight = 40;
            segmentedControlResidence.VisibleSegmentsCount = 3;
            segmentedControlResidence.CornerRadius = 5;
            segmentedControlResidence.HeightRequest = 20;
            segmentedControlResidence.SelectedIndex = 1;
            segmentedControlResidence.BorderColor = Color.FromHex(Colores.JobMeOrange); ;
            segmentedControlResidence.FontColor = Color.FromHex(Colores.JobMeGray); ;
            segmentedControlResidence.FontSize = 18;
            segmentedControlResidence.VerticalOptions = LayoutOptions.Center;
            segmentedControlResidence.HorizontalOptions = LayoutOptions.End;
            segmentedControlResidence.Margin = new Thickness(0, 10, 0, 10);
            segmentedControlResidence.SelectionTextColor = Color.FromHex("#FFFFFF");
            SelectionIndicatorSettings selectionIndicator = new SelectionIndicatorSettings();
            selectionIndicator.Color = Color.FromHex(Colores.JobMeGray);
            segmentedControlResidence.SelectionIndicatorSettings = selectionIndicator;

            //Residence
            var lbResidence = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Cambio de lugar de residencia" : "Change of residence",

                TextColor = Color.FromHex(Colores.JobMeGray),
            };

            segmentedControlResidence.SetBinding(SfSegmentedControl.SelectedIndexProperty, "ChangeResidence");
            segmentedControlResidence.BindingContext = this;

            gridResidence.Children.Add(lbResidence, 0, 0);
            gridResidence.Children.Add(segmentedControlResidence, 1, 0);

            //Travel
            var gridTravel = new Grid();

            gridTravel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.35, GridUnitType.Star) });
            gridTravel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.65, GridUnitType.Star) });
            SfSegmentedControl segmentedControlTravel = new SfSegmentedControl();

            List<String> travelList = new List<String>();

            if (App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español)
            {
                travelList = new List<String>
                {
                    "No","Si"
                };
            }
            else
            {
                travelList = new List<String>
                {
                    "No","Yes"
                };
            }
            segmentedControlTravel.HorizontalOptions = LayoutOptions.FillAndExpand;
            segmentedControlTravel.DisabledTextColor = Color.FromHex("Red");
            segmentedControlTravel.ItemsSource = travelList;
            segmentedControlTravel.DisplayMode = SegmentDisplayMode.Text;
            segmentedControlTravel.Color = Color.FromHex("#FFFFFF");
            segmentedControlTravel.SegmentHeight = 40;
            segmentedControlTravel.VisibleSegmentsCount = 3;
            segmentedControlTravel.CornerRadius = 5;
            segmentedControlTravel.HeightRequest = 20;
            segmentedControlTravel.SelectedIndex = 1;
            segmentedControlTravel.BorderColor = Color.FromHex(Colores.JobMeOrange);
            segmentedControlTravel.FontColor = Color.FromHex(Colores.JobMeGray); ;
            segmentedControlTravel.FontSize = 18;
            segmentedControlTravel.VerticalOptions = LayoutOptions.Center;
            segmentedControlTravel.HorizontalOptions = LayoutOptions.End;
            segmentedControlTravel.SelectionTextColor = Color.FromHex("#FFFFFF");
            segmentedControlTravel.Margin = new Thickness(0, 10, 0, 10);
            SelectionIndicatorSettings selectionIndicator2 = new SelectionIndicatorSettings();
            selectionIndicator2.Color = Color.FromHex(Colores.JobMeGray);
            segmentedControlTravel.SelectionIndicatorSettings = selectionIndicator2;

            var lbTravel = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Disponibilidad para viajar" : "Availability to travel",
                TextColor = Color.FromHex(Colores.JobMeGray),
            };
            segmentedControlTravel.SetBinding(SfSegmentedControl.SelectedIndexProperty, "TravelAvailable");
            segmentedControlTravel.BindingContext = this;

            gridTravel.Children.Add(lbTravel, 0, 0);
            gridTravel.Children.Add(segmentedControlTravel, 1, 0);

            //Salary
            ////

            var gridSalary = new Grid() { Margin = new Thickness(0, 30, 0, 0), BackgroundColor = Color.White };

            gridSalary.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.25, GridUnitType.Star) });
            gridSalary.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.75, GridUnitType.Star) });

            var pickerSalary = new Picker()
            {
                BackgroundColor = Color.White,
                HeightRequest = 40,

                Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Salario" : "Salary",
                TitleColor = Color.FromHex(Colores.JobMeGray)
            };

            pickerSalary.SetBinding(Picker.ItemsSourceProperty, "listSalaries");
            pickerSalary.SetBinding(Picker.SelectedItemProperty, "Salary", BindingMode.TwoWay);
            pickerSalary.ItemDisplayBinding = new Binding("Salary");
            pickerSalary.BindingContext = this;

            //Create Border control
            SfBorder borderSalary = new SfBorder();
            borderSalary.CornerRadius = 5;
            borderSalary.BackgroundColor = Color.White;
            //borderArea.VerticalOptions = LayoutOptions.FillAndExpand;
            borderSalary.HorizontalOptions = LayoutOptions.FillAndExpand;
            borderSalary.BorderColor = Color.FromHex(Colores.JobMeOrange);

            borderSalary.Content = pickerSalary;

            var lbSalary = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Salario" : "Salary",
                TextColor = Color.FromHex(Colores.JobMeGray),
                HeightRequest = 35,
            };

            gridSalary.Children.Add(lbSalary, 0, 0);
            gridSalary.Children.Add(borderSalary, 1, 0);

            //inputSalary.InputView = combobox1;

            //var lbPalomita = new Button() { Text = "next" };
            //lbPalomita.SetBinding(Button.CommandProperty, "BtnNextCommand");
            //lbPalomita.BindingContext = this;

            var lbPalomita = new SfButton()
            {
                Text = "Update",
                CornerRadius = 5,
                HeightRequest = 40,
                FontSize = 14,
                // VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange)
            };
            lbPalomita.SetBinding(SfButton.CommandProperty, "BtnUpdateInterestCommand");
            lbPalomita.SetBinding(SfButton.IsVisibleProperty, "UpdateInterestVisible");
            lbPalomita.BindingContext = this;

            sl1.Orientation = StackOrientation.Vertical;

            sl1.Children.Add(inputes);

            sl1.Children.Add(gridArea1);
            sl1.Children.Add(gridArea);

            sl1.Children.Add(gridJob);
            sl1.Children.Add(gridResidence);
            sl1.Children.Add(gridTravel);
            sl1.Children.Add(gridSalary);

            sl1.Children.Add(lbPalomita);

            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                //VerticalOptions = LayoutOptions.FillAndExpand
            };
            scv.Content = sl1;

            return scv;
        }

        public View AcademicsVideo()
        {
            IsVideoVisible = false;

            StackLayout sl1 = new StackLayout();
            //imagen grande de video
            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "       Video Académico       " : "       Academics Video       ",

                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                //  VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 50)
            };

            SfBadgeView sfBadgeView = new SfBadgeView();

            //Imagen de academics
            var lbImagen = new Label()
            {
                Text = "\uf501",
                FontFamily = this.MiFuente,
                FontSize = 80,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 0, 0, 40)
            };

            sfBadgeView.Content = lbImagen;
            BadgeSetting badgeSetting = new BadgeSetting
            {
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                BadgeIcon = BadgeIcon.None,
                BadgePosition = BadgePosition.BottomRight,
                BadgeType = BadgeType.Success,
                Offset = new Point(0, -10)
            };

            badgeSetting.SetBinding(BadgeSetting.BadgeIconProperty, "IconoOK");
            badgeSetting.BindingContext = this;

            sfBadgeView.BadgeSettings = badgeSetting;

            Content = sfBadgeView;

            var lbl1 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Tienes 30 segundos" : "You have 30 seconds",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray)
            };

            var lbl2 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "para compartir lo que" : "to share everything",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray)
            };

            var lbl3 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "consideres relevante" : "you consider relevant",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray)
            };

            var lbl4 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "acerca de tu formación " : "about your academic",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray)
            };

            var lbl5 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "académica" : "formation",
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray),
                Margin = new Thickness(0, 0, 0, 40)
            };

            var btnupload = new SfButton()
            {
                Text = "\uf093",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                // VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent,
            };

            var lbUpload = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "COMPARTIR" : "UPLOAD",

                FontSize = 20,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            SfButton buttoncamera = new SfButton()
            {
                Text = "\uf030",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent,
                Margin = new Thickness(0, 10, 0, 0)
            };

            SfButton buttongallery = new SfButton()
            {
                Text = "\uf07c",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 10, 0, 0)
            };

            grid.Children.Add(buttoncamera, 0, 0);
            grid.Children.Add(buttongallery, 1, 0);

            var lbVideo = new Label()
            {
                Text = "video",
                FontSize = 16,
                TextColor = Color.FromHex(Colores.JobMeGray),
                // VerticalOptions = LayoutOptions.Center,

                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            buttoncamera.Clicked += async (sender, args) =>
            {
                try
                {
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    if (await JobMePermissions.CameraPermission())
                    {
                        AcadVideo = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions
                        {
                            DesiredLength = TimeSpan.FromSeconds(30),
                            SaveToAlbum = false,
                            Quality = Device.RuntimePlatform == Device.Android ? VideoQuality.Medium : VideoQuality.Medium,
                            DefaultCamera = CameraDevice.Front,
                            Directory = "Media",
                            Name = "videoacad.mp4",//UserName + "_acads.mp4",
                            CompressionQuality = 80,
                        });
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe", "Permissions Denied Unable to take photos.", "OK");
                        return;
                    }

                    if (AcadVideo != null)
                    {
                        try
                        {
                            Preferences.Set("UserName", UserName);

                            switch (Device.RuntimePlatform)
                            {
                                case Device.iOS:
                                    AcadStream = AcadVideo.GetStream();
                                    Preferences.Set("AcadVideo", AcadVideo.Path);
                                    break;

                                case Device.Android:
                                    UserDialogs.Instance.ShowLoading("Comprimiendo video");
                                    string compressedfile = await DependencyService.Get<IVideoCompress>().CompressVideo(AcadVideo.Path);
                                    AcadStream = File.Open(compressedfile, FileMode.Open, System.IO.FileAccess.ReadWrite);
                                    Preferences.Set("AcadVideo", AcadVideo.Path);
                                    UserDialogs.Instance.HideLoading();
                                    break;
                            };
                        }
                        catch (Exception)
                        {
                            //throw;
                        }

                        IconoOK = BadgeIcon.Available;

                        if (UpdateAcademicsVisible)
                        {
                            int idusuario = Preferences.Get("UserID", 0);
                            UserDialogs.Instance.ShowLoading("Updating video");
                            // DependencyService.Get<IFileService>().SavePicture(idusuario + "_acads.mp4", AcadVideo.GetStream());
                            //await UserService.UploadVideo(AcadVideo, idusuario + "_acads.mp4");
                            await UserService.UploadPhoto(AcadStream, idusuario + "_acads.mp4");
                            UserDialogs.Instance.HideLoading();
                            await Application.Current.MainPage.DisplayAlert("JobMe",
                                App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video actualizado" : "Video Updated",
                                "OK");
                        }

                        //Preferences.Set("AcadVideo", AcadVideo.AlbumPath);
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "Error getting video", "OK");
                    // throw;
                }

                //}

                // CanExecute = true;
            };

            buttongallery.Clicked += async (sender, args) =>
            {
                try
                {
                    if (!await JobMePermissions.GalleryPermission())
                    {
                        return;
                    }

                    AcadVideo = await CrossMedia.Current.PickVideoAsync();
                    if (AcadVideo != null)
                    {
                        try
                        {
                            int duracion = DependencyService.Get<IVideoLength>().GetVideoLength(AcadVideo);

                            FileInfo fi = new FileInfo(AcadVideo.Path);
                            long megas = fi.Length / 1480576; //megas

                            if (duracion <= 30 && megas <= 10)
                            {
                                Preferences.Set("UserName", UserName);
                                AcadStream = AcadVideo.GetStream();

                                if (AcadVideo != null)
                                {
                                    IconoOK = BadgeIcon.Available;

                                    if (UpdateAcademicsVisible)
                                    {
                                        UserDialogs.Instance.ShowLoading("Updating video");
                                        int idusuario = Preferences.Get("UserID", 0);

                                        await UserService.UploadVideo(AcadVideo, idusuario + "_acads.mp4");
                                        await Application.Current.MainPage.DisplayAlert("JobMe",
                                            App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video actualizado" : "Video Updated",
                                            "OK");

                                        UserDialogs.Instance.HideLoading();
                                    }

                                    switch (Device.RuntimePlatform)
                                    {
                                        case Device.iOS:
                                            Preferences.Set("AcadVideo", AcadVideo.Path);
                                            break;

                                        case Device.Android:
                                            Preferences.Set("AcadVideo", AcadVideo.Path);
                                            break;
                                    };
                                }
                            }
                            else
                            {
                                if (duracion > 30)
                                {
                                    await Application.Current.MainPage.DisplayAlert("JobMe", "Maximum video duration is 30 seconds", "OK");
                                }
                                if (megas > 10)
                                {
                                    await Application.Current.MainPage.DisplayAlert("JobMe", "Maximum video size is 10 megas", "OK");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Can´t retrieve media info, please select different media", "OK");

                            // throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", ex.Message, "OK");
                    //throw;
                }

                //}

                // CanExecute = true;
            };

            sl1.Children.Add(inputes);

            sl1.Children.Add(sfBadgeView);
            // sl1.Children.Add(_video);
            sl1.Children.Add(lbl1);
            sl1.Children.Add(lbl2);
            sl1.Children.Add(lbl3);
            sl1.Children.Add(lbl4);
            sl1.Children.Add(lbl5);
            // sl1.Children.Add(lbl6);
            // sl1.Children.Add(lbl7);
            //sl1.Children.Add(imgu);
            //sl1.Children.Add(btnupload);
            sl1.Children.Add(grid);
            //sl1.Children.Add(espera);
            sl1.Children.Add(lbUpload);
            sl1.Children.Add(lbVideo);

            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                // VerticalOptions = LayoutOptions.FillAndExpand
            };

            scv.Content = sl1;

            return scv;
        }

        public View JobsV()
        {
            StackLayout sl1 = new StackLayout() { Margin = new Thickness(10, 0, 10, 0) };

            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "       Empleos       " : "       Jobs       ",

                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                //VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };

            //Firm

            var entryFirm = new Entry();
            entryFirm.SetBinding(Entry.TextProperty, "Firm");
            entryFirm.BindingContext = this;
            var inputFirm = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empresa" : "Firm",

                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf1ad",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                //inputName.HelperText = "Enter your name";
                CharMaxLength = 50,
                //inputName.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = entryFirm
            };

            //Job title
            var entryJobTitle = new Entry();
            entryJobTitle.SetBinding(Entry.TextProperty, "JobTitle");
            entryJobTitle.BindingContext = this;
            var inputJobTitle = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Puesto" : "Job title",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf0b1",
                    FontFamily = this.MiFuente,
                    FontSize = 24,
                    FontAttributes = this.MiFontAttributes,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    // VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                //inputCountry.HelperText = "Enter your country";
                CharMaxLength = 50,
                //inputCountry.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = entryJobTitle
            };

            //Start date
            var gridStartDate = new Grid();

            gridStartDate.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridStartDate.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var LeadingView = new Label()
            {
                Text = "\uf073",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                // VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var entrydateinicial = new Entry()
            {
                Placeholder = "Start Date",
                TextColor = Color.FromHex(Colores.JobMeGray),
                BackgroundColor = Color.WhiteSmoke,
            };

            entrydateinicial.SetBinding(Entry.TextProperty, "Mifecha");
            entrydateinicial.BindingContext = this;

            var customdate = new CustomDatePicker()
            {
                HeaderText = "Start date",
                CancelButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                OKButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                SelectedItemTextColor = Color.FromHex(Colores.JobMeOrange),
                HeaderBackgroundColor = Color.FromHex(Colores.JobMeOrange),
                ColumnHeaderHeight = 40,
                HorizontalOptions = LayoutOptions.Center,
                PickerHeight = 400,
                PickerMode = PickerMode.Dialog,
                PickerWidth = 300,
                //  VerticalOptions = LayoutOptions.Center,
            };

            customdate.SetBinding(CustomDatePicker.SelectedItemProperty, "StartDate");
            customdate.BindingContext = this;

            entrydateinicial.Focused += (sender, arg) =>
            {
                entrydateinicial.Unfocus();

                customdate.IsOpen = !customdate.IsOpen;
            };

            gridStartDate.Children.Add(LeadingView, 0, 0);
            gridStartDate.Children.Add(entrydateinicial, 1, 0);

            //End date
            var gridEndDate = new Grid();

            gridEndDate.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridEndDate.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var LeadingViewenddate = new Label()
            {
                Text = "\uf073",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                // VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var entrydatefinal = new Entry()
            {
                Placeholder = "End Date",
                TextColor = Color.FromHex(Colores.JobMeGray),
                BackgroundColor = Color.WhiteSmoke,
            };

            entrydatefinal.SetBinding(Entry.TextProperty, "MifechaFin");
            entrydatefinal.SetBinding(Entry.IsEnabledProperty, "WorkHereEnable1");
            entrydatefinal.BindingContext = this;

            var customenddate = new CustomDatePicker()
            {
                HeaderText = "End date",
                CancelButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                OKButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                SelectedItemTextColor = Color.FromHex(Colores.JobMeOrange),
                HeaderBackgroundColor = Color.FromHex(Colores.JobMeOrange),
                ColumnHeaderHeight = 40,
                HorizontalOptions = LayoutOptions.Center,
                PickerHeight = 400,
                PickerMode = PickerMode.Dialog,
                PickerWidth = 300,
                // VerticalOptions = LayoutOptions.Center,
            };

            customenddate.SetBinding(CustomDatePicker.SelectedItemProperty, "EndDate");
            customenddate.BindingContext = this;

            entrydatefinal.Focused += (sender, arg) =>
            {
                entrydatefinal.Unfocus();
                customenddate.IsOpen = !customenddate.IsOpen;
            };

            gridEndDate.Children.Add(LeadingViewenddate, 0, 0);
            gridEndDate.Children.Add(entrydatefinal, 1, 0);

            var gridchk = new Grid();

            CheckBox checkBox = new CheckBox { IsChecked = false, Color = Color.FromHex(Colores.JobMeOrange) };
            checkBox.SetBinding(CheckBox.IsCheckedProperty, "WorkHere1");
            checkBox.BindingContext = this;

            var lblchk = new Label()
            {
                FontSize = 12,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Trabajo aquí" : "I work here",
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center
            };
            gridchk.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridchk.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });
            gridchk.Children.Add(checkBox, 0, 0);
            gridchk.Children.Add(lblchk, 1, 0);

            ///Experience
            ///
            var gridExperience = new Grid();

            gridExperience.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.30, GridUnitType.Star) });
            gridExperience.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.70, GridUnitType.Star) });

            // Token Customization
            TokenSettings token = new TokenSettings();
            token.FontSize = 10;
            token.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
            token.IsCloseButtonVisible = true;
            token.CornerRadius = 15;
            token.DeleteButtonPlacement = DeleteButtonPlacement.Left;

            var comboExperience = new SfComboBox
            {
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                //HeightRequest = 60,
                //WidthRequest = 100,
                IsSelectedItemsVisibleInDropDown = false,
                ShowBorder = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                ShowClearButton = false,
            };

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    comboExperience.EnableAutoSize = false;

                    break; ;
                case Device.Android:

                    comboExperience.EnableAutoSize = true;
                    break;
            };

            // Create Border control
            SfBorder border = new SfBorder();
            border.CornerRadius = 10;
            border.VerticalOptions = LayoutOptions.FillAndExpand;
            border.HorizontalOptions = LayoutOptions.FillAndExpand;
            border.BorderColor = Color.FromHex(Colores.JobMeOrange);

            border.Content = comboExperience;

            // comboExperience.DataSource = listExperience;
            comboExperience.DisplayMemberPath = "Experience";
            comboExperience.SetBinding(SfComboBox.DataSourceProperty, "listExperience");
            comboExperience.SetBinding(SfComboBox.SelectedItemProperty, "Experiences", BindingMode.TwoWay);
            comboExperience.BindingContext = this;

            //comboExperience.HeightRequest = 90;
            // inputBusinessField.InputView = comboExperience;

            var lbbusiness = new Label
            {
                //   VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
                TextColor = Color.FromHex(Colores.JobMeGray),
                HeightRequest = 60,
            };

            gridExperience.Children.Add(lbbusiness, 0, 0);
            gridExperience.Children.Add(border, 1, 0);

            // comboExperience.SelectionChanged += comboExperience_SelectionChanged;

            var lbaddmore = new Label
            {
                //Text = " +      Add more       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                //  VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };
            lbaddmore.SetBinding(Label.TextProperty, "TextAddMore");
            lbaddmore.BindingContext = this;

            var lbaddmoretap = new TapGestureRecognizer();
            lbaddmoretap.Tapped += (sender, args) =>
           {
               addJobsVisible = true;
               lbaddmore.IsVisible = false;
           };

            View AddMoreFirm()
            {
                //Firm

                var entryFirm1 = new Entry();
                entryFirm1.SetBinding(Entry.TextProperty, "Firm1");
                entryFirm1.SetBinding(Entry.IsVisibleProperty, "addJobsVisible");
                entryFirm1.BindingContext = this;
                var inputFirm1 = new SfTextInputLayout
                {
                    Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empresa" : "Firm",
                    InputViewPadding = 5,
                    LeadingViewPosition = ViewPosition.Outside,
                    LeadingView = new Label()
                    {
                        Text = "\uf1ad",
                        FontFamily = this.MiFuente,
                        FontSize = 24,
                        FontAttributes = this.MiFontAttributes,
                        TextColor = Color.FromHex(Colores.JobMeGray),
                        //   VerticalOptions = LayoutOptions.Center
                    },
                    ContainerType = ContainerType.Filled,
                    //inputName.HelperText = "Enter your name";
                    CharMaxLength = 50,
                    Margin = new Thickness(0, 10, 0, 0),
                    //inputName.ShowCharCount = true;
                    HintLabelStyle = new LabelStyle() { FontSize = 16 },
                    InputView = entryFirm1
                };

                inputFirm1.SetBinding(Entry.IsVisibleProperty, "addJobsVisible");
                inputFirm1.BindingContext = this;
                return inputFirm1;
            }

            View AddMoreJobTitle()
            {
                //Job title
                var entryJobTitle1 = new Entry();
                entryJobTitle1.SetBinding(Entry.TextProperty, "JobTitle1");
                entryJobTitle1.SetBinding(Entry.IsVisibleProperty, "addJobsVisible");
                entryJobTitle1.BindingContext = this;
                var inputJobTitle1 = new SfTextInputLayout
                {
                    Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Puesto" : "Job Title",
                    InputViewPadding = 5,
                    LeadingViewPosition = ViewPosition.Outside,
                    LeadingView = new Label()
                    {
                        Text = "\uf0b1",
                        FontFamily = this.MiFuente,
                        FontSize = 24,
                        FontAttributes = this.MiFontAttributes,
                        TextColor = Color.FromHex(Colores.JobMeGray),
                        //   VerticalOptions = LayoutOptions.Center
                    },
                    ContainerType = ContainerType.Filled,
                    //inputCountry.HelperText = "Enter your country";
                    CharMaxLength = 50,
                    //inputCountry.ShowCharCount = true;
                    HintLabelStyle = new LabelStyle() { FontSize = 16 },
                    InputView = entryJobTitle1
                };

                inputJobTitle1.SetBinding(SfTextInputLayout.IsVisibleProperty, "addJobsVisible");
                inputJobTitle1.BindingContext = this;
                return inputJobTitle1;
            }

            //Start date 1
            var gridStartDate1 = new Grid();
            gridStartDate1.SetBinding(Grid.IsVisibleProperty, "addJobsVisible");
            gridStartDate1.BindingContext = this;
            gridStartDate1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridStartDate1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var LeadingView1 = new Label()
            {
                Text = "\uf073",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var entrydateinicial1 = new Entry()
            {
                Placeholder = "Start Date",
                TextColor = Color.FromHex(Colores.JobMeGray),
                BackgroundColor = Color.WhiteSmoke,
            };

            entrydateinicial1.SetBinding(Entry.TextProperty, "Mifecha1");
            entrydateinicial1.BindingContext = this;

            var customdate1 = new CustomDatePicker()
            {
                HeaderText = "Start date",
                CancelButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                OKButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                SelectedItemTextColor = Color.FromHex(Colores.JobMeOrange),
                HeaderBackgroundColor = Color.FromHex(Colores.JobMeOrange),
                ColumnHeaderHeight = 40,
                HorizontalOptions = LayoutOptions.Center,
                PickerHeight = 400,
                PickerMode = PickerMode.Dialog,
                PickerWidth = 300,
                //   VerticalOptions = LayoutOptions.Center,
            };

            customdate1.SetBinding(CustomDatePicker.SelectedItemProperty, "StartDate1");
            customdate1.BindingContext = this;

            entrydateinicial1.Focused += (sender, arg) =>
            {
                entrydateinicial1.Unfocus();
                customdate1.IsOpen = !customdate1.IsOpen;
            };

            gridStartDate1.Children.Add(LeadingView1, 0, 0);
            gridStartDate1.Children.Add(entrydateinicial1, 1, 0);

            //End date
            var gridEndDate1 = new Grid();
            gridEndDate1.SetBinding(Grid.IsVisibleProperty, "addJobsVisible");
            gridEndDate1.BindingContext = this;
            gridEndDate1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridEndDate1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var LeadingEndView1 = new Label()
            {
                Text = "\uf073",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var entrydateend1 = new Entry()
            {
                Placeholder = "End Date",
                TextColor = Color.FromHex(Colores.JobMeGray),
                BackgroundColor = Color.WhiteSmoke,
            };

            entrydateend1.SetBinding(Entry.TextProperty, "MifechaFin1");
            entrydateend1.SetBinding(Entry.IsEnabledProperty, "WorkHereEnable2");
            entrydateend1.BindingContext = this;

            var customenddate1 = new CustomDatePicker()
            {
                HeaderText = "End date",
                CancelButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                OKButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                SelectedItemTextColor = Color.FromHex(Colores.JobMeOrange),
                HeaderBackgroundColor = Color.FromHex(Colores.JobMeOrange),
                ColumnHeaderHeight = 40,
                HorizontalOptions = LayoutOptions.Center,
                PickerHeight = 400,
                PickerMode = PickerMode.Dialog,
                PickerWidth = 300,
                //   VerticalOptions = LayoutOptions.Center,
            };

            customenddate1.SetBinding(CustomDatePicker.SelectedItemProperty, "EndDate1");
            customenddate1.BindingContext = this;

            entrydateend1.Focused += (sender, arg) =>
            {
                entrydateend1.Unfocus();
                customenddate1.IsOpen = !customdate1.IsOpen;
            };

            gridEndDate1.Children.Add(LeadingEndView1, 0, 0);
            gridEndDate1.Children.Add(entrydateend1, 1, 0);

            var gridchk1 = new Grid();

            CheckBox checkBox1 = new CheckBox { IsChecked = false, Color = Color.FromHex(Colores.JobMeOrange) };
            checkBox1.SetBinding(CheckBox.IsCheckedProperty, "WorkHere2");
            checkBox1.BindingContext = this;

            var lblchk1 = new Label()
            {
                FontSize = 12,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Trabajo aquí" : "I work here",
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center
            };
            gridchk1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridchk1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });
            gridchk1.SetBinding(Grid.IsVisibleProperty, "addJobsVisible");
            gridchk1.BindingContext = this;

            gridchk1.Children.Add(checkBox1, 0, 0);
            gridchk1.Children.Add(lblchk1, 1, 0);

            View AddMoreExperience()
            {
                var gridExperience1 = new Grid();
                gridExperience1.SetBinding(Grid.IsVisibleProperty, "addJobsVisible");
                gridExperience1.BindingContext = this;
                gridExperience1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.30, GridUnitType.Star) });
                gridExperience1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.70, GridUnitType.Star) });

                // Token Customization
                TokenSettings token1 = new TokenSettings();
                token1.FontSize = 10;
                token1.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
                token1.IsCloseButtonVisible = true;
                token1.CornerRadius = 15;
                token1.DeleteButtonPlacement = DeleteButtonPlacement.Left;

                var comboExperience1 = new SfComboBox
                {
                    Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",

                    MultiSelectMode = MultiSelectMode.Token,
                    TokensWrapMode = TokensWrapMode.Wrap,
                    HeightRequest = 60,
                    //WidthRequest = 100,
                    IsSelectedItemsVisibleInDropDown = false,
                    ShowBorder = false,
                    BorderColor = Color.FromHex(Colores.JobMeOrange),
                    TokenSettings = token1,
                    ShowClearButton = false,
                };

                // Create Border control
                SfBorder border1 = new SfBorder();
                border1.CornerRadius = 10;
                //    border1.VerticalOptions = LayoutOptions.FillAndExpand;
                border1.HorizontalOptions = LayoutOptions.FillAndExpand;
                border1.BorderColor = Color.FromHex(Colores.JobMeOrange);

                border1.Content = comboExperience1;

                // comboExperience.DataSource = listExperience;
                comboExperience1.DisplayMemberPath = "Experience";
                comboExperience1.SetBinding(SfComboBox.DataSourceProperty, "listExperience");
                comboExperience1.SetBinding(SfComboBox.SelectedItemProperty, "Experiences1", BindingMode.TwoWay);
                comboExperience1.BindingContext = this;

                comboExperience1.HeightRequest = 90;
                // inputBusinessField.InputView = comboExperience;

                var lbbusiness1 = new Label
                {
                    //    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    HeightRequest = 60,
                };

                gridExperience1.Children.Add(lbbusiness1, 0, 0);
                gridExperience1.Children.Add(border1, 1, 0);

                return gridExperience1;
            }

            var lbaddmore1 = new Label
            {
                //Text = " +      Add more       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                //    VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };

            var lbaddmoretap1 = new TapGestureRecognizer();
            lbaddmoretap1.Tapped += (sender, args) =>
            {
                addJobsVisible1 = true;
                lbaddmore1.IsVisible = false;
            };
            lbaddmore1.SetBinding(Label.TextProperty, "TextAddMore");
            lbaddmore1.SetBinding(Label.IsVisibleProperty, "addJobsVisible");
            lbaddmore1.BindingContext = this;

            lbaddmore1.GestureRecognizers.Add(lbaddmoretap1);
            //////////////////////////////////////////////////////////
            View AddMoreFirm1()
            {
                //Firm

                var entryFirm1 = new Entry();
                entryFirm1.SetBinding(Entry.TextProperty, "Firm2");
                entryFirm1.SetBinding(Entry.IsVisibleProperty, "addJobsVisible1");
                entryFirm1.BindingContext = this;
                var inputFirm1 = new SfTextInputLayout
                {
                    Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empresa" : "Firm",
                    InputViewPadding = 5,
                    LeadingViewPosition = ViewPosition.Outside,
                    LeadingView = new Label()
                    {
                        Text = "\uf1ad",
                        FontFamily = this.MiFuente,
                        FontSize = 24,
                        FontAttributes = this.MiFontAttributes,
                        TextColor = Color.FromHex(Colores.JobMeGray),
                        //      VerticalOptions = LayoutOptions.Center,
                    },
                    ContainerType = ContainerType.Filled,
                    //inputName.HelperText = "Enter your name";
                    CharMaxLength = 50,
                    //inputName.ShowCharCount = true;
                    HintLabelStyle = new LabelStyle() { FontSize = 16 },
                    InputView = entryFirm1
                };
                inputFirm1.SetBinding(SfTextInputLayout.IsVisibleProperty, "addJobsVisible1");
                inputFirm1.BindingContext = this;

                return inputFirm1;
            }

            View AddMoreJobTitle1()
            {
                //Job title
                var entryJobTitle1 = new Entry();
                entryJobTitle1.SetBinding(Entry.TextProperty, "JobTitle2");
                entryJobTitle1.SetBinding(Entry.IsVisibleProperty, "addJobsVisible1");
                entryJobTitle1.BindingContext = this;
                var inputJobTitle1 = new SfTextInputLayout
                {
                    Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Puesto" : "Job Title",
                    InputViewPadding = 5,
                    LeadingViewPosition = ViewPosition.Outside,
                    LeadingView = new Label()
                    {
                        Text = "\uf0b1",
                        FontFamily = this.MiFuente,
                        FontSize = 24,
                        FontAttributes = this.MiFontAttributes,
                        TextColor = Color.FromHex(Colores.JobMeGray),
                        //    VerticalOptions = LayoutOptions.Center
                    },
                    ContainerType = ContainerType.Filled,
                    //inputCountry.HelperText = "Enter your country";
                    CharMaxLength = 50,
                    //inputCountry.ShowCharCount = true;
                    HintLabelStyle = new LabelStyle() { FontSize = 16 },
                    InputView = entryJobTitle1
                };

                inputJobTitle1.SetBinding(SfTextInputLayout.IsVisibleProperty, "addJobsVisible1");
                inputJobTitle1.BindingContext = this;
                return inputJobTitle1;
            }

            //Start date 1
            var gridStartDate2 = new Grid();
            gridStartDate2.SetBinding(Grid.IsVisibleProperty, "addJobsVisible1");
            gridStartDate2.BindingContext = this;
            gridStartDate2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridStartDate2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var LeadingView2 = new Label()
            {
                Text = "\uf073",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //    VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var entrydateinicial2 = new Entry()
            {
                Placeholder = "Start Date",
                TextColor = Color.FromHex(Colores.JobMeGray),
                BackgroundColor = Color.WhiteSmoke,
            };

            entrydateinicial2.SetBinding(Entry.TextProperty, "Mifecha2");
            entrydateinicial2.BindingContext = this;

            var customdate2 = new CustomDatePicker()
            {
                HeaderText = "Start date",
                CancelButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                OKButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                SelectedItemTextColor = Color.FromHex(Colores.JobMeOrange),
                HeaderBackgroundColor = Color.FromHex(Colores.JobMeOrange),
                ColumnHeaderHeight = 40,
                HorizontalOptions = LayoutOptions.Center,
                PickerHeight = 400,
                PickerMode = PickerMode.Dialog,
                PickerWidth = 300,
                //  VerticalOptions = LayoutOptions.Center,
            };

            customdate2.SetBinding(CustomDatePicker.SelectedItemProperty, "StartDate2");
            customdate2.BindingContext = this;

            entrydateinicial2.Focused += (sender, arg) =>
            {
                entrydateinicial2.Unfocus();
                customdate2.IsOpen = !customdate2.IsOpen;
            };

            gridStartDate2.Children.Add(LeadingView2, 0, 0);
            gridStartDate2.Children.Add(entrydateinicial2, 1, 0);

            //End date
            var gridEndDate2 = new Grid();
            gridEndDate2.SetBinding(Grid.IsVisibleProperty, "addJobsVisible1");
            gridEndDate2.BindingContext = this;
            gridEndDate2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridEndDate2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var LeadingEndView2 = new Label()
            {
                Text = "\uf073",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var entrydateend2 = new Entry()
            {
                Placeholder = "End Date",
                TextColor = Color.FromHex(Colores.JobMeGray),
                BackgroundColor = Color.WhiteSmoke,
            };

            entrydateend2.SetBinding(Entry.TextProperty, "MifechaFin2");
            entrydateend2.SetBinding(Entry.IsEnabledProperty, "WorkHereEnable3");
            entrydateend2.BindingContext = this;

            var customenddate2 = new CustomDatePicker()
            {
                HeaderText = "End date",
                CancelButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                OKButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                SelectedItemTextColor = Color.FromHex(Colores.JobMeOrange),
                HeaderBackgroundColor = Color.FromHex(Colores.JobMeOrange),
                ColumnHeaderHeight = 40,
                HorizontalOptions = LayoutOptions.Center,
                PickerHeight = 400,
                PickerMode = PickerMode.Dialog,
                PickerWidth = 300,
                //  VerticalOptions = LayoutOptions.Center,
            };

            customenddate2.SetBinding(CustomDatePicker.SelectedItemProperty, "EndDate2");
            customenddate2.BindingContext = this;

            entrydateend2.Focused += (sender, arg) =>
            {
                entrydateend2.Unfocus();
                customenddate2.IsOpen = !customdate2.IsOpen;
            };

            gridEndDate2.Children.Add(LeadingEndView2, 0, 0);
            gridEndDate2.Children.Add(entrydateend2, 1, 0);

            var gridchk2 = new Grid();

            CheckBox checkBox2 = new CheckBox { IsChecked = false, Color = Color.FromHex(Colores.JobMeOrange) };
            checkBox2.SetBinding(CheckBox.IsCheckedProperty, "WorkHere3");
            checkBox2.BindingContext = this;

            var lblchk2 = new Label()
            {
                FontSize = 12,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Trabajo aquí" : "I work here",
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center
            };
            gridchk2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridchk2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });
            gridchk2.SetBinding(Grid.IsVisibleProperty, "addJobsVisible1");
            gridchk2.BindingContext = this;
            gridchk2.Children.Add(checkBox2, 0, 0);
            gridchk2.Children.Add(lblchk2, 1, 0);

            View AddMoreExperience1()
            {
                var gridExperience1 = new Grid();
                gridExperience1.SetBinding(Grid.IsVisibleProperty, "addJobsVisible1");
                gridExperience1.BindingContext = this;
                gridExperience1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.30, GridUnitType.Star) });
                gridExperience1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.70, GridUnitType.Star) });

                // Token Customization
                TokenSettings token1 = new TokenSettings();
                token1.FontSize = 10;
                token1.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
                token1.IsCloseButtonVisible = true;
                token1.CornerRadius = 15;
                token1.DeleteButtonPlacement = DeleteButtonPlacement.Left;

                var comboExperience1 = new SfComboBox
                {
                    Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
                    MultiSelectMode = MultiSelectMode.Token,
                    TokensWrapMode = TokensWrapMode.Wrap,
                    HeightRequest = 60,
                    //WidthRequest = 100,
                    IsSelectedItemsVisibleInDropDown = false,
                    ShowBorder = false,
                    BorderColor = Color.FromHex(Colores.JobMeOrange),
                    TokenSettings = token1,
                    ShowClearButton = false,
                };

                // Create Border control
                SfBorder border1 = new SfBorder();
                border1.CornerRadius = 10;
                // border1.VerticalOptions = LayoutOptions.FillAndExpand;
                border1.HorizontalOptions = LayoutOptions.FillAndExpand;
                border1.BorderColor = Color.FromHex(Colores.JobMeOrange);

                border1.Content = comboExperience1;

                // comboExperience.DataSource = listExperience;
                comboExperience1.DisplayMemberPath = "Experience";
                comboExperience1.SetBinding(SfComboBox.DataSourceProperty, "listExperience");
                comboExperience1.SetBinding(SfComboBox.SelectedItemProperty, "Experiences2", BindingMode.TwoWay);
                comboExperience1.BindingContext = this;

                comboExperience1.HeightRequest = 90;
                // inputBusinessField.InputView = comboExperience;

                var lbbusiness1 = new Label
                {
                    //      VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    HeightRequest = 60,
                };

                gridExperience1.Children.Add(lbbusiness1, 0, 0);
                gridExperience1.Children.Add(border1, 1, 0);

                return gridExperience1;
            }

            var lbaddmore2 = new Label
            {
                // Text = " +      Add more       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                //  VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };

            var lbaddmoretap2 = new TapGestureRecognizer();
            lbaddmoretap2.Tapped += (sender, args) =>
            {
                addJobsVisible2 = true;
                lbaddmore2.IsVisible = false;
            };
            lbaddmore2.SetBinding(Label.IsVisibleProperty, "addJobsVisible1");
            lbaddmore2.SetBinding(Label.TextProperty, "TextAddMore");
            lbaddmore2.BindingContext = this;
            lbaddmore2.GestureRecognizers.Add(lbaddmoretap2);
            //////////////////////////////////////////////////////////

            View AddMoreFirm2()
            {
                //Firm

                var entryFirm1 = new Entry();
                entryFirm1.SetBinding(Entry.TextProperty, "Firm3");
                entryFirm1.SetBinding(Entry.IsVisibleProperty, "addJobsVisible2");
                entryFirm1.BindingContext = this;
                var inputFirm1 = new SfTextInputLayout
                {
                    Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empresa" : "Firm",
                    InputViewPadding = 5,
                    LeadingViewPosition = ViewPosition.Outside,
                    LeadingView = new Label()
                    {
                        Text = "\uf1ad",
                        FontFamily = this.MiFuente,
                        FontSize = 24,
                        FontAttributes = this.MiFontAttributes,
                        TextColor = Color.FromHex(Colores.JobMeGray),
                        //      VerticalOptions = LayoutOptions.Center
                    },
                    ContainerType = ContainerType.Filled,
                    //inputName.HelperText = "Enter your name";
                    CharMaxLength = 50,
                    //inputName.ShowCharCount = true;
                    HintLabelStyle = new LabelStyle() { FontSize = 16 },
                    InputView = entryFirm1
                };

                inputFirm1.SetBinding(SfTextInputLayout.IsVisibleProperty, "addJobsVisible2");
                inputFirm1.BindingContext = this;

                return inputFirm1;
            }

            View AddMoreJobTitle2()
            {
                //Job title
                var entryJobTitle1 = new Entry();
                entryJobTitle1.SetBinding(Entry.TextProperty, "JobTitle3");
                entryJobTitle1.SetBinding(Entry.IsVisibleProperty, "addJobsVisible2");
                entryJobTitle1.BindingContext = this;
                var inputJobTitle1 = new SfTextInputLayout
                {
                    Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Puesto" : "Job Title",
                    InputViewPadding = 5,
                    LeadingViewPosition = ViewPosition.Outside,
                    LeadingView = new Label()
                    {
                        Text = "\uf0b1",
                        FontFamily = this.MiFuente,
                        FontSize = 24,
                        FontAttributes = this.MiFontAttributes,
                        TextColor = Color.FromHex(Colores.JobMeGray),
                        //      VerticalOptions = LayoutOptions.Center
                    },
                    ContainerType = ContainerType.Filled,
                    //inputCountry.HelperText = "Enter your country";
                    CharMaxLength = 50,
                    //inputCountry.ShowCharCount = true;
                    HintLabelStyle = new LabelStyle() { FontSize = 16 },
                    InputView = entryJobTitle1
                };

                inputJobTitle1.SetBinding(SfTextInputLayout.IsVisibleProperty, "addJobsVisible2");
                inputJobTitle1.BindingContext = this;
                return inputJobTitle1;
            }

            //Start date 1
            var gridStartDate3 = new Grid();
            gridStartDate3.SetBinding(Grid.IsVisibleProperty, "addJobsVisible2");
            gridStartDate3.BindingContext = this;
            gridStartDate3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridStartDate3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var LeadingView3 = new Label()
            {
                Text = "\uf073",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var entrydateinicial3 = new Entry()
            {
                Placeholder = "Start Date",
                TextColor = Color.FromHex(Colores.JobMeGray),
                BackgroundColor = Color.WhiteSmoke,
            };

            entrydateinicial3.SetBinding(Entry.TextProperty, "Mifecha3");
            entrydateinicial3.BindingContext = this;

            var customdate3 = new CustomDatePicker()
            {
                HeaderText = "Start date",
                CancelButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                OKButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                SelectedItemTextColor = Color.FromHex(Colores.JobMeOrange),
                HeaderBackgroundColor = Color.FromHex(Colores.JobMeOrange),
                ColumnHeaderHeight = 40,
                HorizontalOptions = LayoutOptions.Center,
                PickerHeight = 400,
                PickerMode = PickerMode.Dialog,
                PickerWidth = 300,
                //  VerticalOptions = LayoutOptions.Center,
            };

            customdate3.SetBinding(CustomDatePicker.SelectedItemProperty, "StartDate3");
            customdate3.BindingContext = this;

            entrydateinicial3.Focused += (sender, arg) =>
            {
                entrydateinicial3.Unfocus();
                customdate3.IsOpen = !customdate3.IsOpen;
            };

            gridStartDate3.Children.Add(LeadingView3, 0, 0);
            gridStartDate3.Children.Add(entrydateinicial3, 1, 0);

            //End date
            var gridEndDate3 = new Grid();
            gridEndDate3.SetBinding(Grid.IsVisibleProperty, "addJobsVisible2");
            gridEndDate3.BindingContext = this;
            gridEndDate3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridEndDate3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var LeadingEndView3 = new Label()
            {
                Text = "\uf073",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var entrydateend3 = new Entry()
            {
                Placeholder = "End Date",
                TextColor = Color.FromHex(Colores.JobMeGray),
                BackgroundColor = Color.WhiteSmoke,
            };

            entrydateend3.SetBinding(Entry.TextProperty, "MifechaFin3");
            entrydateend3.SetBinding(Entry.IsEnabledProperty, "WorkHereEnable4");
            entrydateend3.BindingContext = this;

            var customenddate3 = new CustomDatePicker()
            {
                HeaderText = "End date",
                CancelButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                OKButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                SelectedItemTextColor = Color.FromHex(Colores.JobMeOrange),
                HeaderBackgroundColor = Color.FromHex(Colores.JobMeOrange),
                ColumnHeaderHeight = 40,
                HorizontalOptions = LayoutOptions.Center,
                PickerHeight = 400,
                PickerMode = PickerMode.Dialog,
                PickerWidth = 300,
                //   VerticalOptions = LayoutOptions.Center,
            };

            customenddate3.SetBinding(CustomDatePicker.SelectedItemProperty, "EndDate3");

            customenddate3.BindingContext = this;

            entrydateend3.Focused += (sender, arg) =>
            {
                entrydateend3.Unfocus();
                customenddate3.IsOpen = !customdate3.IsOpen;
            };

            gridEndDate3.Children.Add(LeadingEndView3, 0, 0);
            gridEndDate3.Children.Add(entrydateend3, 1, 0);

            var gridchk3 = new Grid();

            CheckBox checkBox3 = new CheckBox { IsChecked = false, Color = Color.FromHex(Colores.JobMeOrange) };
            checkBox3.SetBinding(CheckBox.IsCheckedProperty, "WorkHere4");
            checkBox3.BindingContext = this;

            var lblchk3 = new Label()
            {
                FontSize = 12,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Trabajo aquí" : "I work here",
                TextColor = Color.FromHex(Colores.JobMeGray),
                //    VerticalOptions = LayoutOptions.Center
            };
            gridchk3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridchk3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });
            gridchk3.SetBinding(Grid.IsVisibleProperty, "addJobsVisible2");
            gridchk3.BindingContext = this;
            gridchk3.Children.Add(checkBox3, 0, 0);
            gridchk3.Children.Add(lblchk3, 1, 0);

            View AddMoreExperience2()
            {
                var gridExperience1 = new Grid();
                gridExperience1.SetBinding(Grid.IsVisibleProperty, "addJobsVisible2");
                gridExperience1.BindingContext = this;
                gridExperience1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.30, GridUnitType.Star) });
                gridExperience1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.70, GridUnitType.Star) });

                // Token Customization
                TokenSettings token2 = new TokenSettings();
                token2.FontSize = 10;
                token2.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
                token2.IsCloseButtonVisible = true;
                token2.CornerRadius = 15;
                token2.DeleteButtonPlacement = DeleteButtonPlacement.Left;

                var comboExperience1 = new SfComboBox
                {
                    Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
                    MultiSelectMode = MultiSelectMode.Token,
                    TokensWrapMode = TokensWrapMode.Wrap,
                    HeightRequest = 60,
                    //WidthRequest = 100,
                    IsSelectedItemsVisibleInDropDown = false,
                    ShowBorder = false,
                    BorderColor = Color.FromHex(Colores.JobMeOrange),
                    TokenSettings = token2,
                    ShowClearButton = false,
                };

                // Create Border control
                SfBorder border1 = new SfBorder();
                border1.CornerRadius = 10;
                //   border1.VerticalOptions = LayoutOptions.FillAndExpand;
                border1.HorizontalOptions = LayoutOptions.FillAndExpand;
                border1.BorderColor = Color.FromHex(Colores.JobMeOrange);

                border1.Content = comboExperience1;

                // comboExperience.DataSource = listExperience;
                comboExperience1.DisplayMemberPath = "Experience";
                comboExperience1.SetBinding(SfComboBox.DataSourceProperty, "listExperience");
                comboExperience1.SetBinding(SfComboBox.SelectedItemProperty, "Experiences3", BindingMode.TwoWay);
                comboExperience1.BindingContext = this;

                comboExperience1.HeightRequest = 90;
                // inputBusinessField.InputView = comboExperience;

                var lbbusiness1 = new Label
                {
                    //       VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    HeightRequest = 60,
                };

                gridExperience1.Children.Add(lbbusiness1, 0, 0);
                gridExperience1.Children.Add(border1, 1, 0);

                return gridExperience1;
            }

            var lbaddmore3 = new Label
            {
                // Text = " +      Add more       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                //   VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };

            var lbaddmoretap3 = new TapGestureRecognizer();
            lbaddmoretap3.Tapped += (sender, args) =>
            {
                addJobsVisible3 = true;
                lbaddmore3.IsVisible = false;
            };
            lbaddmore3.SetBinding(Label.IsVisibleProperty, "addJobsVisible2");
            lbaddmore3.SetBinding(Label.TextProperty, "TextAddMore");
            lbaddmore3.BindingContext = this;
            lbaddmore3.GestureRecognizers.Add(lbaddmoretap3);
            //////////////////////////////////////////////////////////

            View AddMoreFirm3()
            {
                //Firm

                var entryFirm1 = new Entry();
                entryFirm1.SetBinding(Entry.TextProperty, "Firm4");
                entryFirm1.SetBinding(Entry.IsVisibleProperty, "addJobsVisible3");
                entryFirm1.BindingContext = this;
                var inputFirm1 = new SfTextInputLayout
                {
                    Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empresa" : "Firm",
                    InputViewPadding = 5,
                    LeadingViewPosition = ViewPosition.Outside,
                    LeadingView = new Label()
                    {
                        Text = "\uf1ad",
                        FontFamily = this.MiFuente,
                        FontSize = 24,
                        FontAttributes = this.MiFontAttributes,
                        TextColor = Color.FromHex(Colores.JobMeGray),
                        //            VerticalOptions = LayoutOptions.Center
                    },
                    ContainerType = ContainerType.Filled,
                    //inputName.HelperText = "Enter your name";
                    CharMaxLength = 50,
                    //inputName.ShowCharCount = true;
                    HintLabelStyle = new LabelStyle() { FontSize = 16 },
                    InputView = entryFirm1
                };
                inputFirm1.SetBinding(SfTextInputLayout.IsVisibleProperty, "addJobsVisible3");
                inputFirm1.BindingContext = this;
                return inputFirm1;
            }

            View AddMoreJobTitle3()
            {
                //Job title
                var entryJobTitle1 = new Entry();
                entryJobTitle1.SetBinding(Entry.TextProperty, "JobTitle4");
                entryJobTitle1.SetBinding(Entry.IsVisibleProperty, "addJobsVisible3");
                entryJobTitle1.BindingContext = this;
                var inputJobTitle1 = new SfTextInputLayout
                {
                    Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Puesto" : "Job Title",
                    InputViewPadding = 5,
                    LeadingViewPosition = ViewPosition.Outside,
                    LeadingView = new Label()
                    {
                        Text = "\uf0b1",
                        FontFamily = this.MiFuente,
                        FontSize = 24,
                        FontAttributes = this.MiFontAttributes,
                        TextColor = Color.FromHex(Colores.JobMeGray),
                        //      VerticalOptions = LayoutOptions.Center
                    },
                    ContainerType = ContainerType.Filled,
                    //inputCountry.HelperText = "Enter your country";
                    CharMaxLength = 50,
                    //inputCountry.ShowCharCount = true;
                    HintLabelStyle = new LabelStyle() { FontSize = 16 },
                    InputView = entryJobTitle1
                };

                inputJobTitle1.SetBinding(SfTextInputLayout.IsVisibleProperty, "addJobsVisible3");
                inputJobTitle1.BindingContext = this;
                return inputJobTitle1;
            }

            //Start date 1
            var gridStartDate4 = new Grid();
            gridStartDate4.SetBinding(Grid.IsVisibleProperty, "addJobsVisible3");
            gridStartDate4.BindingContext = this;
            gridStartDate4.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridStartDate4.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var LeadingView4 = new Label()
            {
                Text = "\uf073",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var entrydateinicial4 = new Entry()
            {
                Placeholder = "Start Date",
                TextColor = Color.FromHex(Colores.JobMeGray),
                BackgroundColor = Color.WhiteSmoke,
            };

            entrydateinicial4.SetBinding(Entry.TextProperty, "Mifecha4");
            entrydateinicial4.BindingContext = this;

            var customdate4 = new CustomDatePicker()
            {
                HeaderText = "Start date",
                CancelButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                OKButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                SelectedItemTextColor = Color.FromHex(Colores.JobMeOrange),
                HeaderBackgroundColor = Color.FromHex(Colores.JobMeOrange),
                ColumnHeaderHeight = 40,
                HorizontalOptions = LayoutOptions.Center,
                PickerHeight = 400,
                PickerMode = PickerMode.Dialog,
                PickerWidth = 300,
                //   VerticalOptions = LayoutOptions.Center,
            };

            customdate4.SetBinding(CustomDatePicker.SelectedItemProperty, "StartDate4");
            customdate4.BindingContext = this;

            entrydateinicial4.Focused += (sender, arg) =>
            {
                entrydateinicial4.Unfocus();
                customdate4.IsOpen = !customdate4.IsOpen;
            };

            gridStartDate4.Children.Add(LeadingView4, 0, 0);
            gridStartDate4.Children.Add(entrydateinicial4, 1, 0);

            //End date
            var gridEndDate4 = new Grid();
            gridEndDate4.SetBinding(Grid.IsVisibleProperty, "addJobsVisible3");
            gridEndDate4.BindingContext = this;
            gridEndDate4.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridEndDate4.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var LeadingEndView4 = new Label()
            {
                Text = "\uf073",
                FontFamily = this.MiFuente,
                FontSize = 24,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //    VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var entrydateend4 = new Entry()
            {
                Placeholder = "End Date",
                TextColor = Color.FromHex(Colores.JobMeGray),
                BackgroundColor = Color.WhiteSmoke,
            };

            entrydateend4.SetBinding(Entry.TextProperty, "MifechaFin4");
            entrydateend4.SetBinding(Entry.IsEnabledProperty, "WorkHereEnable5");
            entrydateend4.BindingContext = this;

            var customenddate4 = new CustomDatePicker()
            {
                HeaderText = "End date",
                CancelButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                OKButtonTextColor = Color.FromHex(Colores.JobMeOrange),
                SelectedItemTextColor = Color.FromHex(Colores.JobMeOrange),
                HeaderBackgroundColor = Color.FromHex(Colores.JobMeOrange),
                ColumnHeaderHeight = 40,
                HorizontalOptions = LayoutOptions.Center,
                PickerHeight = 400,
                PickerMode = PickerMode.Dialog,
                PickerWidth = 300,
                //     VerticalOptions = LayoutOptions.Center,
            };

            customenddate4.SetBinding(CustomDatePicker.SelectedItemProperty, "EndDate4");
            customenddate4.BindingContext = this;

            entrydateend4.Focused += (sender, arg) =>
            {
                entrydateend4.Unfocus();
                customenddate4.IsOpen = !customdate4.IsOpen;
            };

            gridEndDate4.Children.Add(LeadingEndView4, 0, 0);
            gridEndDate4.Children.Add(entrydateend4, 1, 0);

            var gridchk4 = new Grid();

            CheckBox checkBox4 = new CheckBox { IsChecked = false, Color = Color.FromHex(Colores.JobMeOrange) };
            checkBox4.SetBinding(CheckBox.IsCheckedProperty, "WorkHere5");
            checkBox4.BindingContext = this;

            var lblchk4 = new Label()
            {
                FontSize = 12,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Trabajo aquí" : "I work here",
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center
            };
            gridchk4.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridchk4.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });
            gridchk4.SetBinding(Grid.IsVisibleProperty, "addJobsVisible3");
            gridchk4.BindingContext = this;
            gridchk4.Children.Add(checkBox4, 0, 0);
            gridchk4.Children.Add(lblchk4, 1, 0);

            View AddMoreExperience3()
            {
                var gridExperience1 = new Grid();
                gridExperience1.SetBinding(Grid.IsVisibleProperty, "addJobsVisible3");
                gridExperience1.BindingContext = this;
                gridExperience1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.30, GridUnitType.Star) });
                gridExperience1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.70, GridUnitType.Star) });

                // Token Customization
                TokenSettings token3 = new TokenSettings();
                token3.FontSize = 10;
                token3.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
                token3.IsCloseButtonVisible = true;
                token3.CornerRadius = 15;
                token3.DeleteButtonPlacement = DeleteButtonPlacement.Left;

                var comboExperience1 = new SfComboBox
                {
                    Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
                    MultiSelectMode = MultiSelectMode.Token,
                    TokensWrapMode = TokensWrapMode.Wrap,
                    HeightRequest = 60,
                    //WidthRequest = 100,
                    IsSelectedItemsVisibleInDropDown = false,
                    ShowBorder = false,
                    BorderColor = Color.FromHex(Colores.JobMeOrange),
                    TokenSettings = token3,
                    ShowClearButton = false,
                };

                // Create Border control
                SfBorder border1 = new SfBorder();
                border1.CornerRadius = 10;
                // border1.VerticalOptions = LayoutOptions.FillAndExpand;
                border1.HorizontalOptions = LayoutOptions.FillAndExpand;
                border1.BorderColor = Color.FromHex(Colores.JobMeOrange);

                border1.Content = comboExperience1;

                // comboExperience.DataSource = listExperience;
                comboExperience1.DisplayMemberPath = "Experience";
                comboExperience1.SetBinding(SfComboBox.DataSourceProperty, "listExperience");
                comboExperience1.SetBinding(SfComboBox.SelectedItemProperty, "Experiences4", BindingMode.TwoWay);
                comboExperience1.BindingContext = this;

                comboExperience1.HeightRequest = 90;
                // inputBusinessField.InputView = comboExperience;

                var lbbusiness1 = new Label
                {
                    //      VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    HeightRequest = 60,
                };

                gridExperience1.Children.Add(lbbusiness1, 0, 0);
                gridExperience1.Children.Add(border1, 1, 0);

                return gridExperience1;
            }

            var lbPalomita = new SfButton()
            {
                Text = "Update",
                CornerRadius = 5,
                HeightRequest = 40,
                FontSize = 14,
                //   VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange)
            };
            lbPalomita.SetBinding(SfButton.CommandProperty, "BtnUpdateJobsCommand");
            lbPalomita.SetBinding(SfButton.IsVisibleProperty, "UpdateJobsVisible");
            lbPalomita.BindingContext = this;

            lbaddmore.GestureRecognizers.Add(lbaddmoretap);

            sl1.Orientation = StackOrientation.Vertical;

            // sl1.Children.Add(inputNM);{
            sl1.Children.Add(inputes);
            sl1.Children.Add(inputFirm);
            sl1.Children.Add(inputJobTitle);

            // sl1.Children.Add(gridFecha);
            sl1.Children.Add(gridStartDate);
            sl1.Children.Add(customdate);
            sl1.Children.Add(gridEndDate);
            sl1.Children.Add(customenddate);
            sl1.Children.Add(gridchk);
            sl1.Children.Add(gridExperience);
            sl1.Children.Add(lbaddmore);
            //////////////////////////////////////////////////////////////////
            sl1.Children.Add(AddMoreFirm());
            sl1.Children.Add(AddMoreJobTitle());
            sl1.Children.Add(gridStartDate1);
            sl1.Children.Add(customdate1);
            sl1.Children.Add(gridEndDate1);
            sl1.Children.Add(customenddate1);
            sl1.Children.Add(gridchk1);
            sl1.Children.Add(AddMoreExperience());
            sl1.Children.Add(lbaddmore1);
            //////////////////////////////////////////////////////////////////
            sl1.Children.Add(AddMoreFirm1());
            sl1.Children.Add(AddMoreJobTitle1());
            sl1.Children.Add(gridStartDate2);
            sl1.Children.Add(customdate2);
            sl1.Children.Add(gridEndDate2);
            sl1.Children.Add(customenddate2);
            sl1.Children.Add(gridchk2);
            sl1.Children.Add(AddMoreExperience1());
            sl1.Children.Add(lbaddmore2);
            //////////////////////////////////////////////////////////////////
            ///
            sl1.Children.Add(AddMoreFirm2());
            sl1.Children.Add(AddMoreJobTitle2());
            sl1.Children.Add(gridStartDate3);
            sl1.Children.Add(customdate3);
            sl1.Children.Add(gridEndDate3);
            sl1.Children.Add(customenddate3);
            sl1.Children.Add(gridchk3);
            sl1.Children.Add(AddMoreExperience2());
            sl1.Children.Add(lbaddmore3);
            ////////////////////////////////////////////////////////////////////
            ///
            sl1.Children.Add(AddMoreFirm3());
            sl1.Children.Add(AddMoreJobTitle3());
            sl1.Children.Add(gridStartDate4);
            sl1.Children.Add(customdate4);
            sl1.Children.Add(gridEndDate4);
            sl1.Children.Add(customenddate4);
            sl1.Children.Add(gridchk4);
            sl1.Children.Add(AddMoreExperience3());
            sl1.Children.Add(lbPalomita);

            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                //   VerticalOptions = LayoutOptions.FillAndExpand
            };
            scv.Content = sl1;

            return scv;
        }

        public View JobsVideo()
        {
            StackLayout sl1 = new StackLayout();

            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "       Video Empleos       " : "       Jobs Video      ",

                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                //  VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 60)
            };

            var lbImagen = new Label()
            {
                Text = "\uf0b1",
                FontFamily = this.MiFuente,
                FontSize = 80,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 0, 0, 40)
            };
            SfBadgeView sfBadgeView = new SfBadgeView();
            sfBadgeView.Content = lbImagen;
            BadgeSetting badgeSetting = new BadgeSetting
            {
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                BadgeIcon = BadgeIcon.None,
                BadgePosition = BadgePosition.BottomRight,
                BadgeType = BadgeType.Success,
                Offset = new Point(0, -10)
            };

            badgeSetting.SetBinding(BadgeSetting.BadgeIconProperty, "IconoOKjobs");
            badgeSetting.BindingContext = this;

            sfBadgeView.BadgeSettings = badgeSetting;

            Content = sfBadgeView;

            var lbl1 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Tienes 30 segundos" : "You have 30 seconds",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray)
            };

            var lbl2 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "para compartir lo que" : "to share everything",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray)
            };

            var lbl3 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "consideres relevante" : "you consider relevant",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray),
            };

            var lbl4 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "acerca de tu" : "about your professional",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray),
            };

            var lbl5 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "experiencia laboral" : "experience",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray),
                Margin = new Thickness(0, 0, 0, 40)
            };

            var imgUpload = new SfButton()
            {
                Text = "\uf093",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var lbUpload = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "COMPARTIR" : "UPLOAD",
                FontSize = 20,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var lbVideo = new Label()
            {
                Text = "video",
                FontSize = 16,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            //Camara y galeria
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            SfButton buttoncamera = new SfButton()
            {
                Text = "\uf030",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent,
                Margin = new Thickness(0, 10, 0, 0)
            };

            SfButton buttongallery = new SfButton()
            {
                Text = "\uf07c",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 10, 0, 0)
            };

            grid.Children.Add(buttoncamera, 0, 0);
            grid.Children.Add(buttongallery, 1, 0);

            buttoncamera.Clicked += async (sender, args) =>
            {
                try
                {
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    if (await JobMePermissions.CameraPermission())
                    {
                        JbVideo = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions
                        {
                            DesiredLength = TimeSpan.FromSeconds(30),
                            SaveToAlbum = false,
                            Quality = Device.RuntimePlatform == Device.Android ? VideoQuality.High : VideoQuality.Medium,
                            DefaultCamera = CameraDevice.Front,
                            Directory = "Media",
                            Name = "videojobs.mp4",//UserName + "_jobs.mp4",
                            CompressionQuality = 50,
                        });

                        if (JbVideo != null)
                        {
                            try
                            {
                                switch (Device.RuntimePlatform)
                                {
                                    case Device.iOS:
                                        JobsStream = JbVideo.GetStream();
                                        Preferences.Set("JobsVideo", JbVideo.Path);
                                        break;

                                    case Device.Android:
                                        UserDialogs.Instance.ShowLoading("Comprimiendo video");
                                        string compressedfile = await DependencyService.Get<IVideoCompress>().CompressVideo(JbVideo.Path);
                                        JobsStream = File.Open(compressedfile, FileMode.Open, System.IO.FileAccess.ReadWrite);
                                        Preferences.Set("JobsVideo", JbVideo.AlbumPath);
                                        UserDialogs.Instance.HideLoading();
                                        break;
                                };
                            }
                            catch (Exception)
                            {
                                //throw;
                            }

                            IconoOKjobs = BadgeIcon.Available;
                            //sl1.Children.Remove(lbImagen);
                            //VideoAcPath = JbVideo.AlbumPath;
                            //IsJobVideoVisible = true;
                            ////se reproduce video
                            //_video.Source = new FileVideoSource
                            //{
                            //    File = JbVideo.AlbumPath
                            //};
                            if (UpdateJobsVisible)
                            {
                                int idusuario = Preferences.Get("UserID", 0);
                                UserDialogs.Instance.ShowLoading("Updating video");
                                await UserService.UploadPhoto(JobsStream, idusuario + "_jobs.mp4");
                                // await UserService.UploadVideo(JbVideo, idusuario + "_jobs.mp4");
                                UserDialogs.Instance.HideLoading();
                                await Application.Current.MainPage.DisplayAlert("JobMe",
                                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video actualizado" : "Video Updated",
                                    "OK");
                            }

                            // Preferences.Set("JobsVideo", JbVideo.AlbumPath);
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe", "Permissions Denied Unable to take photos.", "OK");
                        //On iOS you may want to send your user to the settings screen.
                        //CrossPermissions.Current.OpenAppSettings();
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Job Me", "Error getting video", "OK");
                    //  throw;
                }
            };

            buttongallery.Clicked += async (sender, args) =>
            {
                try
                {
                    JbVideo = await CrossMedia.Current.PickVideoAsync();

                    if (JbVideo == null)
                    {
                        return;
                    }

                    int duracion = DependencyService.Get<IVideoLength>().GetVideoLength(JbVideo);
                    FileInfo fi = new FileInfo(JbVideo.Path);
                    long megas = fi.Length / 1480576; //megas

                    if (duracion <= 30 && megas <= 10)
                    {
                        Preferences.Set("UserName", UserName);
                        JobsStream = JbVideo.GetStream();

                        if (JbVideo != null)
                        {
                            IconoOKjobs = BadgeIcon.Available;

                            if (UpdateJobsVisible)
                            {
                                UserDialogs.Instance.ShowLoading("Updating video");
                                int idusuario = Preferences.Get("UserID", 0);

                                await UserService.UploadVideo(JbVideo, idusuario + "_jobs.mp4");
                                await Application.Current.MainPage.DisplayAlert("JobMe",
                                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video actualizado" : "Video Updated",
                                     "OK");

                                UserDialogs.Instance.HideLoading();
                            }

                            switch (Device.RuntimePlatform)
                            {
                                case Device.iOS:
                                    Preferences.Set("JobsVideo", JbVideo.Path);
                                    break;

                                case Device.Android:
                                    Preferences.Set("JobsVideo", JbVideo.Path);
                                    break;
                            };
                        }
                    }
                    else
                    {
                        if (duracion > 30)
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Maximum video duration is 30 seconds", "OK");
                        }
                        if (megas > 10)
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Maximum video size is 10 megas", "OK");
                        }
                    }
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "Can´t retrieve media info, please select different media", "OK");

                    // throw;
                }
            };

            //imgUpload.GestureRecognizers.Add(tapGestureRecognizer);

            sl1.Children.Add(inputes);

            sl1.Children.Add(sfBadgeView);
            //  sl1.Children.Add(_video);
            sl1.Children.Add(lbl1);
            sl1.Children.Add(lbl2);
            sl1.Children.Add(lbl3);
            sl1.Children.Add(lbl4);
            sl1.Children.Add(lbl5);
            sl1.Children.Add(grid);
            //sl1.Children.Add(imgUpload);
            sl1.Children.Add(lbUpload);
            sl1.Children.Add(lbVideo);

            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                // VerticalOptions = LayoutOptions.FillAndExpand
            };

            scv.Content = sl1;

            //CanSwipe = true;

            return scv;
        }

        public View Others()
        {
            StackLayout sl1 = new StackLayout();

            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "       Otros       " : "       Others       ",

                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                //  VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 60)
            };

            var lbImagen = new Label()
            {
                Text = "\uf630",
                FontFamily = this.MiFuente,
                FontSize = 80,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 0, 0, 40)
            };

            SfBadgeView sfBadgeView = new SfBadgeView();
            sfBadgeView.Content = lbImagen;
            BadgeSetting badgeSetting = new BadgeSetting
            {
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                BadgeIcon = BadgeIcon.None,
                BadgePosition = BadgePosition.BottomRight,
                BadgeType = BadgeType.Success,
                Offset = new Point(0, -10)
            };

            badgeSetting.SetBinding(BadgeSetting.BadgeIconProperty, "IconoOKothers");
            badgeSetting.BindingContext = this;

            sfBadgeView.BadgeSettings = badgeSetting;

            Content = sfBadgeView;

            var lbl1 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Tienes 30 segundos" : "You have 30 seconds",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray)
            };

            var lbl2 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "para compartir lo que" : "to share everything",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray)
            };

            var lbl3 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "consideres relevante" : "you consider relevant",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray)
            };

            var lbl4 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "acerca de ti" : "about yourself",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray)
            };

            var lbl5 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "[Deportivo ,Cultural, etc.]" : "[Sports, Culture, etc.]",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray),
                Margin = new Thickness(0, 0, 0, 40)
            };

            var imgUpload = new SfButton()
            {
                Text = "\uf093",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent,
            };

            var lbUpload = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Compartir" : "Upload",
                FontSize = 20,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //    VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var lbVideo = new Label()
            {
                Text = "video",
                FontSize = 16,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            ////Camara y galeria
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            SfButton buttoncamera = new SfButton()
            {
                Text = "\uf030",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent,
                Margin = new Thickness(0, 10, 0, 0)
            };

            SfButton buttongallery = new SfButton()
            {
                Text = "\uf07c",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 10, 0, 0)
            };

            grid.Children.Add(buttoncamera, 0, 0);
            grid.Children.Add(buttongallery, 1, 0);

            buttoncamera.Clicked += async (sender, args) =>
            {
                int idusuario = 0;
                try
                {
                    Preferences.Set("VideoOtros", string.Empty);

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    if (await JobMePermissions.CameraPermission())
                    {
                        OthersVideo = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions
                        {
                            DesiredLength = TimeSpan.FromSeconds(30),
                            SaveToAlbum = true,
                            Quality = Device.RuntimePlatform == Device.Android ? VideoQuality.High : VideoQuality.Medium,
                            DefaultCamera = CameraDevice.Front,
                            Directory = "Media",
                            Name = "videootros.mp4",//Preferences.Get("UserID", 0) + "_others.mp4",
                            CompressionQuality = 50,
                        });

                        if (OthersVideo != null)
                        {
                            switch (Device.RuntimePlatform)
                            {
                                case Device.iOS:
                                    OthersStream = OthersVideo.GetStream();
                                    Preferences.Set("VideoOtros", OthersVideo.Path);
                                    Preferences.Set("OthersVideo", OthersVideo.Path);
                                    break;

                                case Device.Android:
                                    UserDialogs.Instance.ShowLoading("Comprimiendo video");
                                    string compressedfile = await DependencyService.Get<IVideoCompress>().CompressVideo(OthersVideo.Path);
                                    OthersStream = File.Open(compressedfile, FileMode.Open, System.IO.FileAccess.ReadWrite);
                                    Preferences.Set("VideoOtros", OthersVideo.AlbumPath);
                                    Preferences.Set("OthersVideo", OthersVideo.AlbumPath);
                                    UserDialogs.Instance.HideLoading();
                                    break;
                            };

                            if (UpdateOthersVisible)
                            {
                                idusuario = Preferences.Get("UserID", 0);

                                UserDialogs.Instance.ShowLoading("Updating video");

                                await UserService.UploadPhoto(OthersStream, idusuario + "_others.mp4");
                                // await UserService.UploadVideo(OthersVideo, idusuario + "_others.mp4");

                                UserDialogs.Instance.HideLoading();

                                await Application.Current.MainPage.DisplayAlert("JobMe",
                                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video actualizado" : "Video Updated",
                                     "OK");
                            }
                        }

                        IconoOKothers = BadgeIcon.Available;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe", "Permissions Denied Unable to take photos.", "OK");
                    }
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "Error getting video.", "OK");
                    // throw;
                }
            };

            buttongallery.Clicked += async (sender, args) =>
            {
                try
                {
                    Preferences.Set("VideoOtros", string.Empty);
                    //if (await GalleryPermission())
                    //{
                    OthersVideo = await CrossMedia.Current.PickVideoAsync();

                    if (OthersVideo == null)
                    {
                        return;
                    }
                    int duracion = DependencyService.Get<IVideoLength>().GetVideoLength(OthersVideo);
                    FileInfo fi = new FileInfo(OthersVideo.Path);
                    long megas = fi.Length / 1480576; //megas

                    if (duracion <= 30 && megas <= 10)
                    {
                        Preferences.Set("UserName", UserName);
                        OthersStream = OthersVideo.GetStream();

                        if (OthersVideo != null)
                        {
                            IconoOKothers = BadgeIcon.Available;

                            if (UpdateOthersVisible)
                            {
                                UserDialogs.Instance.ShowLoading("Updating video");
                                int idusuario = Preferences.Get("UserID", 0);

                                await UserService.UploadVideo(OthersVideo, idusuario + "_others.mp4");
                                await Application.Current.MainPage.DisplayAlert("JobMe",
                                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video actualizado" : "Video Updated",
                                    "OK");

                                UserDialogs.Instance.HideLoading();
                            }

                            switch (Device.RuntimePlatform)
                            {
                                case Device.iOS:
                                    Preferences.Set("OthersVideo", OthersVideo.Path);
                                    Preferences.Set("VideoOtros", OthersVideo.Path);
                                    break;

                                case Device.Android:
                                    Preferences.Set("VideoOtros", OthersVideo.Path);
                                    Preferences.Set("OthersVideo", OthersVideo.Path);
                                    break;
                            };
                        }
                    }
                    else
                    {
                        if (duracion > 30)
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Maximum video duration is 30 seconds", "OK");
                        }
                        if (megas > 10)
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Maximum video size is 10 megas", "OK");
                        }
                    }
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "Can´t retrieve media info, please select different media", "OK");

                    // throw;
                }

                //}
                //else
                //{
                //    await Application.Current.MainPage.DisplayAlert("JobMe", "Permissions Denied Unable to select videos.", "OK");

                //}
            };

            sl1.Children.Add(inputes);

            sl1.Children.Add(sfBadgeView);
            //sl1.Children.Add(_video);
            sl1.Children.Add(lbl1);
            sl1.Children.Add(lbl2);
            sl1.Children.Add(lbl3);
            sl1.Children.Add(lbl4);
            sl1.Children.Add(lbl5);
            //sl1.Children.Add(imgUpload);
            sl1.Children.Add(grid);
            sl1.Children.Add(lbUpload);
            sl1.Children.Add(lbVideo);

            //return sl1;

            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                // VerticalOptions = LayoutOptions.FillAndExpand
            };

            scv.Content = sl1;

            //CanSwipe = true;

            return scv;
        }

        public View uploadPhoto()
        {
            StackLayout sl1 = new StackLayout();

            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "       Foto       " : "       Upload Photo       ",

                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 40)
            };

            var lbImagenusr = new Label()
            {
                Text = "\uf2bd",
                FontFamily = this.MiFuente,
                FontSize = 80,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 0, 0, 80)
            };
            lbImagenusr.SetBinding(Image.IsVisibleProperty, "IsImageVisible");
            lbImagenusr.BindingContext = this;

            var lbl1 = new Label()
            {
                Margin = new Thickness(0, 20, 0, 0),
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "No olvides compartir" : "Don´t forget to share",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray),
            };

            var lbl2 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "tu información" : "this helpful information",

                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 70),
                TextColor = Color.FromHex(Colores.JobMeGray),
            };

            var imgUpload = new Label()
            {
                Text = "\uf093",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 10, 0, 0)
            };

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            SfButton buttoncamera = new SfButton()
            {
                Text = "\uf030",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //  VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent,
                Margin = new Thickness(0, 10, 0, 0)
            };

            SfButton buttongallery = new SfButton()
            {
                Text = "\uf07c",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 10, 0, 0)
            };

            grid.Children.Add(buttoncamera, 0, 0);
            grid.Children.Add(buttongallery, 1, 0);

            SfAvatarView avatarview = new SfAvatarView();
            avatarview.VerticalOptions = LayoutOptions.Center;
            // avatarview.AvatarSize = AvatarSize.ExtraLarge;
            // avatarview.AvatarShape = AvatarShape.Circle;
            avatarview.HorizontalOptions = LayoutOptions.Center;
            avatarview.BackgroundColor = Color.FromHex(Colores.JobMeOrange);
            avatarview.ContentType = ContentType.Custom;
            avatarview.IsVisible = false;
            avatarview.WidthRequest = 120;
            avatarview.HeightRequest = 120;
            avatarview.CornerRadius = 60;

            avatarview.SetBinding(SfAvatarView.IsVisibleProperty, "IsPhotoVisible");

            avatarview.SetBinding(SfAvatarView.ImageSourceProperty, "PhotoPath");

            avatarview.BindingContext = this;

            var lbUpload = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Compartir" : "UPLOAD",

                FontSize = 20,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //   VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var lbVideo = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "tu foto" : "your photo",

                FontSize = 16,
                TextColor = Color.FromHex(Colores.JobMeGray),
                //    VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var mediaOptions = new StoreCameraMediaOptions()
            {
                SaveToAlbum = false,
                Directory = "Sample",
                Name = UserName + "_photo.jpg",
                PhotoSize = PhotoSize.Medium,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                RotateImage = false,
                CompressionQuality = 70,
                AllowCropping = true,
                SaveMetaData = false,
                CustomPhotoSize = 80 //Resize to 90% of original
            };

            int flag = 0;

            buttoncamera.Clicked += async (sender, args) =>
            {
                try
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        if (!CrossMedia.Current.IsTakePhotoSupported)
                        {
                            flag = 0;
                            return;
                        }
                        //var selectedImageFile
                        MyProperty = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

                        if (MyProperty == null)
                        {
                            flag = 0;
                            return;
                        };

                        // imgPhoto.Source = ImageSource.FromFile(selectedImageFile.Path);
                        PhotoSrc = MyProperty.Path;

                        //Obtenemos la imagen desde el path
                        //PhotoPath = ImageSource.FromFile(selectedImageFile.Path);
                        Preferences.Set("MyFoto", MyProperty.Path);

                        // PhotoPath = ImageSource.FromFile(selectedImageFile.Path);
                        //sl1.Children.Add(avatarview);
                        //imgPhoto.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
                        //Photo = selectedImageFile;

                        //    PhotoPath = ImageSource.FromStream(() =>
                        //{
                        //   // Esta variable es la que se sube
                        //    MyFoto = selectedImageFile;
                        PhotoStream = MyProperty.GetStreamWithImageRotatedForExternalStorage();

                        //DependencyService.Get<IFileService>().SavePicture("junitobanana.jpg", PhotoStream, "Images");

                        //var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                        //documentsPath = Path.Combine(documentsPath, "Images", idusuario + ".jpg");

                        PhotoPath = ImageSource.FromFile(Preferences.Get("MyFoto", null));

                        //});

                        IsPhotoVisible = true;
                        IsImageVisible = false;

                        //await UserService.UploadVideo(selectedImageFile, "mifoto.jpg");

                        //PhotoPath = imgPhoto.Source;

                        //using (var memoryStream = new MemoryStream())
                        //{
                        //    selectedImageFile.GetStreamWithImageRotatedForExternalStorage().CopyTo(memoryStream);
                        //    selectedImageFile.Dispose();

                        //    var signatureMemoryStream = memoryStream.ToArray();
                        //    Photo = signatureMemoryStream;

                        //}
                        flag = 0;
                    }
                }
                catch (Exception)
                {
                    // throw;
                }
            };

            buttongallery.Clicked += async (sender, args) =>
            {
                try
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        if (!await JobMePermissions.GalleryPermission())
                        {
                            flag = 0;
                            return;
                        }
                        var media = new PickMediaOptions()
                        {
                            PhotoSize = PhotoSize.Large,
                            SaveMetaData = false,
                            CompressionQuality = 92,
                        };
                        //var selectedImageFile
                        MyProperty = await CrossMedia.Current.PickPhotoAsync(media);

                        if (MyProperty == null)
                        {
                            flag = 0;
                            return;
                        };

                        PhotoSrc = MyProperty.Path;

                        Preferences.Set("MyFoto", MyProperty.Path);

                        PhotoStream = MyProperty.GetStreamWithImageRotatedForExternalStorage();

                        PhotoPath = ImageSource.FromFile(Preferences.Get("MyFoto", null));

                        IsPhotoVisible = true;
                        IsImageVisible = false;

                        flag = 0;
                    }
                }
                catch (Exception)
                {
                    //  throw;
                }
            };

            //imgUpload.GestureRecognizers.Add(tapGestureRecognizer);

            sl1.Children.Add(inputes);

            sl1.Children.Add(lbl1);
            sl1.Children.Add(lbl2);

            sl1.Children.Add(lbImagenusr);

            sl1.Children.Add(avatarview);
            //sl1.Children.Add(imgUpload);
            sl1.Children.Add(grid);
            sl1.Children.Add(lbUpload);
            sl1.Children.Add(lbVideo);

            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                // VerticalOptions = LayoutOptions.FillAndExpand
            };

            scv.Content = sl1;

            //CanSwipe = true;

            return scv;
        }

        public View uploadCV()
        {
            StackLayout sl1 = new StackLayout();

            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "     Compartir CV     " : "       Upload CV       ",

                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 40)
            };

            var lbImagen = new Label()
            {
                Text = "\uf15c",
                FontFamily = this.MiFuente,
                FontSize = 80,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 0, 0, 60)
            };

            SfBadgeView sfBadgeView = new SfBadgeView();
            sfBadgeView.Content = lbImagen;
            BadgeSetting badgeSetting = new BadgeSetting
            {
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                BadgeIcon = BadgeIcon.None,
                BadgePosition = BadgePosition.BottomRight,
                BadgeType = BadgeType.Success,
                Offset = new Point(0, -10)
            };

            badgeSetting.SetBinding(BadgeSetting.BadgeIconProperty, "IconoOKCV");
            badgeSetting.BindingContext = this;

            sfBadgeView.BadgeSettings = badgeSetting;

            Content = sfBadgeView;

            var espera = new ActivityIndicator()
            {
                Color = Color.FromHex(Colores.JobMeOrange)
            };
            espera.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            espera.SetBinding(ActivityIndicator.IsVisibleProperty, "IsVisible");
            espera.BindingContext = this;

            var lbl1 = new Label()
            {
                Margin = new Thickness(0, 20, 0, 0),
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "No olvides compartir" : "Don´t forget to share",

                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex(Colores.JobMeGray),
            };

            var lbl2 = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "tu información" : "this helpful information",

                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 70),
                TextColor = Color.FromHex(Colores.JobMeGray),
            };

            //Imagen de la hoja de documento
            var imgUpload = new Label()
            {
                Text = "\uf093",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var lbUpload = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Compartir" : "UPLOAD",

                FontSize = 20,
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var lbVideo = new Label()
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Tu CV" : "your CV",

                FontSize = 16,
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 0, 0, 10)
            };

            var lbPalomita = new SfButton()
            {
                Text = "\uf00c",
                FontFamily = this.MiFuente,
                FontSize = 40,
                FontAttributes = this.MiFontAttributes,
                TextColor = Color.FromHex(Colores.JobMeOrange),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 0, 0, 80),
                BackgroundColor = Color.WhiteSmoke,
                CornerRadius = 30,
                WidthRequest = 80,
            };

            lbPalomita.Clicked += async (sender, args) => await AddUser();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (sender, args) => await PickFile();

            imgUpload.GestureRecognizers.Add(tapGestureRecognizer);

            sl1.Children.Add(inputes);

            sl1.Children.Add(lbl1);
            sl1.Children.Add(lbl2);
            sl1.Children.Add(sfBadgeView);
            sl1.Children.Add(imgUpload);
            sl1.Children.Add(lbUpload);
            sl1.Children.Add(lbVideo);
            sl1.Children.Add(espera);
            sl1.Children.Add(lbPalomita);

            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                // VerticalOptions = LayoutOptions.FillAndExpand
            };

            scv.Content = sl1;

            return scv;
        }

        private bool _isLocked;

        private async Task AddUser()
        {
            if (_isLocked) return;
            _isLocked = true; /* your code here */

            IsRun = true;
            try
            {
                UserModel u = new UserModel()
                {
                    UserType = 1,
                    Name = Name,
                    BirthDate = BirthDate,
                    Country = Country,
                    City = City,
                    Mail = Mail,
                    Phone = Phone,
                    Gender = Gender,
                    UserName = UserName,
                    Password = Password,
                    BusinessFields = BusinessFields,
                    MiArea = MiArea,
                    TypeofJob = TypeofJob,
                    ChangeResidence = ChangeResidence,
                    TravelAvailable = TravelAvailable,
                    Salary = Salary,

                    School = School,
                    School1 = School1,
                    School2 = School2,
                    School3 = School3,
                    School4 = School4,

                    Degree = Degree,
                    Degree1 = Degree1,
                    Degree2 = Degree2,
                    Degree3 = Degree3,
                    Degree4 = Degree4,

                    GraduationYears = GraduationYears,
                    GraduationYears1 = GraduationYears1,
                    GraduationYears2 = GraduationYears2,
                    GraduationYears3 = GraduationYears3,
                    GraduationYears4 = GraduationYears4,

                    Certifications = Certifications,
                    Languajes = Languajes,

                    Firm = Firm,
                    Firm1 = Firm1,
                    Firm2 = Firm2,
                    Firm3 = Firm3,
                    Firm4 = Firm4,

                    JobTitle = JobTitle,
                    JobTitle1 = JobTitle1,
                    JobTitle2 = JobTitle2,
                    JobTitle3 = JobTitle3,
                    JobTitle4 = JobTitle4,

                    Experiences = Experiences,
                    Experiences1 = Experiences1,
                    Experiences2 = Experiences2,
                    Experiences3 = Experiences3,
                    Experiences4 = Experiences4,

                    Mifecha = Mifecha,
                    Mifecha1 = Mifecha1,
                    Mifecha2 = Mifecha2,
                    Mifecha3 = Mifecha3,
                    Mifecha4 = Mifecha4,

                    MifechaFin = MifechaFin,
                    MifechaFin1 = MifechaFin1,
                    MifechaFin2 = MifechaFin2,
                    MifechaFin3 = MifechaFin3,
                    MifechaFin4 = MifechaFin4,
                    Photo = Photo,
                    CV = CV,
                    CVName = !string.IsNullOrEmpty(CVName) ? CVName : string.Empty,
                    VideoAcPath = VideoAcPath,
                    VideoJobsPath = VideoJobsPath,
                    VideoOthersPath = VideoOthersPath,

                    WorkHere1 = WorkHere1,
                    WorkHere2 = WorkHere2,
                    WorkHere3 = WorkHere3,
                    WorkHere4 = WorkHere4,
                    WorkHere5 = WorkHere5
                };

                if (Valida(u))
                {
                    UserDialogs.Instance.ShowLoading("Creating account");

                    int idusuario = await UserService.AddUserNewAsync(u);
                    //int idusuario = await UserService.AddUserAsync(u);

                    if (idusuario > 0)
                    {
                        //Validar la respuesta
                        PhotoSrc = EndPoint.BACKEND_ENDPOINT + "/api/uploads/" + idusuario + ".jpg";
                        Preferences.Set("Name", Name);

                        //Obtener el degree mas actual

                        Preferences.Set("PhotoSrc", PhotoSrc);
                        DateTime now = DateTime.Today;
                        int age = now.Year - u.BirthDate.Year;
                        if (u.BirthDate > now.AddYears(-age)) age--;

                        GetActualDegree(u);

                        Preferences.Set("Age", age.ToString());

                        //string substr = MyProperty.Path.Substring(MyProperty.Path.Length - 3);

                        //if (substr.ToUpper() == "JPG")
                        //{
                        //    DependencyService.Get<IFileService>().SavePicture(idusuario + ".jpg", MyProperty.GetStreamWithImageRotatedForExternalStorage());
                        //}
                        //else
                        //{
                        //    DependencyService.Get<IFileService>().SavePicture(idusuario + "." + substr.ToLower(), MyProperty.GetStreamWithImageRotatedForExternalStorage());
                        //}

                        //Subir la multimedia

                        //if (!string.IsNullOrEmpty(Preferences.Get("VideoOtros", string.Empty)))
                        //{
                        //    OthersStream = System.IO.File.OpenRead(Preferences.Get("VideoOtros", string.Empty));
                        //}

                        var dTask = Task.Run(async () => await UserService.UploadPhoto(PhotoStream, idusuario + ".jpg"));
                        var aTask = Task.Run(async () => await UserService.UploadPhoto(AcadStream, idusuario + "_acads.mp4"));
                        var bTask = Task.Run(async () => await UserService.UploadPhoto(JobsStream, idusuario + "_jobs.mp4"));
                        var cTask = Task.Run(async () => await UserService.UploadPhoto(OthersStream, idusuario + "_others.mp4"));

                        await aTask;
                        await bTask;
                        await cTask;
                        await dTask;

                        //Vaciamos la variable de los videos
                        Preferences.Set("VideoOtros", string.Empty);

                        //  int idvalue = Convert.ToInt32(idusuario);

                        //Enviar el mail y activar
                        if (await UserService.ActivateUserAsync(idusuario))
                        {
                            Preferences.Set("UserID", idusuario);
                            UserDialogs.Instance.HideLoading();

                            //Actualiza el token de las push para android
                            MessagingCenter.Send(this, "DeleteToken");

                            await Navigation.PushModalAsync(new SuccessRegister());
                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            _isLocked = false;
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Ocurrio un error inesperado al guardar los datos", "Ok");
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        IsRun = false;
                        _isLocked = false;
                        await Application.Current.MainPage.DisplayAlert("JobMe", "Ocurrio un error inesperado al guardar los datos", "Ok");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                IsRun = false;

                await Application.Current.MainPage.DisplayAlert("JobMe", ex.Message, "Ok");
                //throw;
            }

            IsRun = false;

            await Task.Delay(600);
            _isLocked = false;
        }

        private void GetActualDegree(UserModel u)
        {
            try
            {
                int[] numbers = new int[] { u.GraduationYears!=null?u.GraduationYears.IDGraduationYear:0,
                                           u.GraduationYears2!=null?u.GraduationYears2.IDGraduationYear:0,
                                            u.GraduationYears3!=null?u.GraduationYears3.IDGraduationYear:0,
                                             u.GraduationYears4!=null?u.GraduationYears4.IDGraduationYear:0,
                                              u.GraduationYears1!=null?u.GraduationYears1.IDGraduationYear:0 };

                int maximumNumber = numbers.Max();

                if (maximumNumber == u.GraduationYears.IDGraduationYear)
                    Preferences.Set("Degree", u.Degree.Degree);

                if (maximumNumber == u.GraduationYears1.IDGraduationYear)
                    Preferences.Set("Degree", u.Degree1.Degree);

                if (maximumNumber == u.GraduationYears2.IDGraduationYear)
                    Preferences.Set("Degree", u.Degree2.Degree);

                if (maximumNumber == u.GraduationYears3.IDGraduationYear)
                    Preferences.Set("Degree", u.Degree3.Degree);

                if (maximumNumber == u.GraduationYears4.IDGraduationYear)
                    Preferences.Set("Degree", u.Degree4.Degree);
            }
            catch (Exception)
            {
                //Preferences.Set("Degree", u.Degree.Degree);
                // throw;
            }
        }

        private bool Valida(UserModel u)
        {
            if (MailHasError)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El correo ya existe" : "E-Mail already exists",
                    "Ok");
                return false;
            }

            if (u.Name == null || u.Name == string.Empty)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El nombre no puede estar vacío" : "Name can't be empty",
                    "Ok");
                return false;
            }

            if (u.UserName == null || u.UserName == string.Empty)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El usuario no puede estar vacío" : "Username can't be empty",
                    "Ok");
                return false;
            }

            if (UserHasError)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El usuario ya existe, por favor elige otro" : "UserName already exists",
                    "Ok");
                return false;
            }

            if (u.Password == null || u.Password == string.Empty)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El password no puede estar vacío" : "Password can't be empty",
                    "Ok");
                return false;
            }

            if (u.Gender == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El genero no puede estar vacío" : "Gender can't be empty",
                    "Ok");
                return false;
            }

            if (u.Phone == null || u.Phone == string.Empty)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El teléfono no puede estar vacío" : "Phone can't be empty",
                    "Ok");
                return false;
            }

            if (u.BusinessFields == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                     App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Industria puede estar vacío" : "Business Fields can't be empty",
                    "Ok");
                return false;
            }

            if (u.MiArea == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Áreas de interes no puede estar vacío" : "Areas of interests can't be empty",
                    "Ok");
                return false;
            }

            if (u.Salary == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Salario no puede estar vacío" : "Salary can't be empty",
                    "Ok");
                return false;
            }

            //Academics
            if (u.School == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "La escuela no puede estar vacío" : "School can't be empty",
                    "Ok");
                return false;
            }

            if (u.Degree == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "La escuela no puede estar vacío" : "School can't be empty",
                    "Ok");
                return false;
            }

            if (u.GraduationYears == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El año de graduación no puede estar vacío" : "Graduation year can't be empty",
                    "Ok");
                return false;
            }
            if (u.Languajes == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El idioma no puede estar vacío" : "Languajes can't be empty",
                    "Ok");
                return false;
            }

            if (PhotoStream == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "La foto no puede estar vacía" : "Photo can't be empty",
                    "Ok");
                return false;
            }

            if (AcadStream == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El video academico no puede estar vacío" : "Academics video can't be empty",
                    "Ok");
                return false;
            }

            if (u.CV == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Por favor sube tu CV" : "Please upload your CV",
                    "Ok");
                return false;
            }

            return true;
        }

        private async Task PickFile()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

                if (status != PermissionStatus.Granted)
                {
                    //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                    //{
                    //}

                    status = await Permissions.RequestAsync<Permissions.StorageRead>();
                }

                if (status == PermissionStatus.Granted)
                {
                    string[] fileTypes = null;

                    FileData file = await CrossFilePicker.Current.PickFile();

                    if (file != null)
                    {
                        CVName = file.FileName;

                        if (file.FileName.Substring(file.FileName.Length - 3).ToUpper() != "PDF" && file.FileName.Substring(file.FileName.Length - 3).ToUpper() != "JPG")
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Tipo de archivo no admitido, solo pdf o jpg", "Ok");
                            return;
                        }

                        using (var memoryStream = new MemoryStream())
                        {
                            file.GetStream().CopyTo(memoryStream);
                            file.Dispose();

                            //  var signatureMemoryStream = memoryStream.ToArray();
                            CV = memoryStream.ToArray();
                        }

                        IconoOKCV = BadgeIcon.Available;
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("JobMe", "Ocurrio un error al obtener el CV", "Ok");
                // throw;
            }
        }

        private async Task TakePhotoAsync()
        {
            var mediaOptions = new StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Directory = "Sample",
                Name = UserName + "_photo.jpg",
                PhotoSize = PhotoSize.Medium,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                CompressionQuality = 50
            };

            if (!await JobMePermissions.CameraPermission())
            {
                return;
            }

            var selectedImageFile = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

            if (selectedImageFile == null)
            {
                return;
            };

            PhotoPath = selectedImageFile.Path;

            using (var memoryStream = new MemoryStream())
            {
                selectedImageFile.GetStream().CopyTo(memoryStream);
                selectedImageFile.Dispose();

                var signatureMemoryStream = memoryStream.ToArray();
                Photo = signatureMemoryStream;
            }
        }
    }
}