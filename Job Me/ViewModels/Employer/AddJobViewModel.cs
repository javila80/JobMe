using Acr.UserDialogs;
using JobMe.Behaviors;
using JobMe.Models;
using JobMe.Services;
using JobMe.Views.Employer;
using Newtonsoft.Json.Linq;
using Syncfusion.XForms.Border;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.ComboBox;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels
{
    public class AddJobViewModel : BaseViewModel
    {

        #region "Propiedades

        private int _IDPosition;

        public int IDPosition
        {
            get { return _IDPosition; }
            set { _IDPosition = value; OnPropertyChanged(); }
        }

        private string btntext;

        public string BtnText
        {
            get { return btntext; }
            set { btntext = value; OnPropertyChanged(); }
        }


        private object _Languaje;
        public object Languajes
        {
            get { return _Languaje; }
            set { _Languaje = value; OnPropertyChanged(); }
        }

        private object _Certifications;
        public object Certifications
        {
            get { return _Certifications; }
            set { _Certifications = value; OnPropertyChanged(); }
        }

        private bool _ChangeResidence;
        public bool ChangeResidence
        {
            get { return _ChangeResidence; }
            set { _ChangeResidence = value; OnPropertyChanged(); }
        }


        private int _TypeofJob;

        public int TypeofJob
        {
            get { return _TypeofJob; }
            set { _TypeofJob = value; OnPropertyChanged(); }
        }

        private bool _travel;
        public bool TravelAvailable
        {
            get { return _travel; }
            set { _travel = value; OnPropertyChanged(); }
        }

        private Salarios _Salary;

        public Salarios Salary
        {
            get { return _Salary; }
            set { _Salary = value; OnPropertyChanged(); }
        }



        private Ciudades ciudades;

        public Ciudades City
        {
            get { return ciudades; }
            set { ciudades = value; OnPropertyChanged(); }
        }


        private bool _todaselegido;

        public bool todaselegido
        {
            get { return _todaselegido; }
            set { _todaselegido = value; }
        }


        private object titulos;

        public object Degree
        {
            get
            {

                if (titulos != null)
                {

                    bool todas = false;

                    foreach (Titulos item in (ObservableCollection<object>)titulos)
                    {

                        if (item.IDDegree == 0)
                        {

                            todas = true;

                        }

                    }

                    if (todas && !todaselegido)
                    {
                        titulos = null;
                        todaselegido = true;
                        titulos = new ObservableCollection<object> { new Titulos() { IDDegree = 0, Degree = "All" } };

                    }
                    else
                    {
                        todaselegido = false;
                    }

                    return titulos;

                }
                else
                {
                    return titulos;
                }

            }
            set
            {
                titulos = value;
                //Si escoge la opcion de ALL quitar las demas
                OnPropertyChanged();
            }
        }

        private object escuelas;

        private bool _allschools;

        public bool allschools
        {
            get { return _allschools; }
            set { _allschools = value; }
        }

        public object School
        {
            get
            {

                if (escuelas != null)
                {

                    bool todas = false;

                    foreach (Escuelas item in (ObservableCollection<object>)escuelas)
                    {

                        if (item.IDSchool == 0)
                        {
                            todas = true;
                        }
                    }

                    if (todas && !allschools)
                    {
                        escuelas = null;
                        allschools = true;
                        escuelas = new ObservableCollection<object> { new Escuelas() { IDSchool = 0, School = "All" } };
                    }
                    else
                    {
                        allschools = false;
                    }
                    return escuelas;

                }
                else
                {
                    return escuelas;
                }

            }
            set { escuelas = value; OnPropertyChanged(); }
        }

        private Generos gender;

        public Generos Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged(); }
        }

        private Paises _Country;

        public Paises Country
        {
            get { return _Country; }
            set
            {
                _Country = value;
                OnPropertyChanged();
                if (_Country != null)
                {
                    if (Country.IDCountry != 117)
                    {
                        //Mexico
                        IsCityEnabled = false;
                    }
                    else
                    {
                        //Mexico
                        IsCityEnabled = true;
                    }
                }
            }
        }

        private object graduacion;
        public bool allgradyears { get; set; }
        public object GraduationYear
        {
            get
            {
                if (graduacion != null)
                {

                    bool todas = false;

                    foreach (AñosGraduacion item in (ObservableCollection<object>)graduacion)
                    {

                        if (item.IDGraduationYear == 0)
                        {
                            todas = true;
                        }
                    }

                    if (todas && !allgradyears)
                    {
                        graduacion = null;
                        allgradyears = true;
                        graduacion = new ObservableCollection<object> { new AñosGraduacion() { IDGraduationYear = 0, Year = "All" } };
                    }
                    else
                    {
                        allgradyears = false;
                    }
                    return graduacion;

                }
                else
                {
                    return graduacion;
                }

            }
            set
            {
                graduacion = value;


                OnPropertyChanged();
            }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(); }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; OnPropertyChanged(); }
        }

        private object _MyExperience;

        public object MyExperience
        {
            get { return _MyExperience; }
            set { _MyExperience = value; OnPropertyChanged(); }
        }

        private object _MisAreas;

        public object MisAreas
        {
            get { return _MisAreas; }
            set { _MisAreas = value; OnPropertyChanged(); }
        }
        private object _EmpBSFields;

        public object MyBSFields
        {
            get { return _EmpBSFields; }
            set { _EmpBSFields = value; OnPropertyChanged(); }
        }

        private bool _IsEdit;

        public bool IsEdit
        {
            get { return _IsEdit; }
            set { _IsEdit = value; OnPropertyChanged(); }
        }

        private bool _BtnUpdateVisible;

        public bool BtnUpdateVisible
        {
            get { return _BtnUpdateVisible; }
            set { _BtnUpdateVisible = value; OnPropertyChanged(); }
        }

        private bool _BtnSaveVisible;

        public bool BtnSaveVisible
        {
            get { return _BtnSaveVisible; }
            set { _BtnSaveVisible = value; OnPropertyChanged(); }
        }

        private bool _IsCityEnabled = true;

        public bool IsCityEnabled
        {
            get { return _IsCityEnabled; }
            set { _IsCityEnabled = value; OnPropertyChanged(); }
        }


        #endregion
        public DataTemplate AddJobTemplate { get; set; }
        public DataTemplate AddJobDetailTemplate { get; set; }

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
        public INavigation Navigation { get; set; }
        public NewPositionTemplateSelector TemplateSelector { get; set; }

        private ObservableCollection<ListaPositions> _ListPos;

        public ObservableCollection<ListaPositions> ListPositions
        {
            get { return _ListPos; }
            set
            {
                _ListPos = value;
                OnPropertyChanged();
            }
        }

        //private Command<Object> tappedCommand;
        public Command DeleteCommand { get; set; }
        public Command<object> TappedCommand { get; set; }

        public AddJobViewModel(int idposition = 0)
        {

            BindCountries();
            BindCities();
            BindSchool();
            BindDegree();
            BindYear();
            BindCertification();
            BindLanguaje();
            BindSalaries();
            BindBSFields();
            BindAreas();
            BindExperience();
            BtnSaveVisible = true;

            //Se cargan las pestañas
            CarouselColllection = new List<CustomCell>();
            CarouselColllection.Add(new CustomCell { TipoHoja = 1 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 2 });

            TemplateSelector = new NewPositionTemplateSelector
            {
                AddJobTemplate = new DataTemplate(Essential),
                AddJobDetailTemplate = new DataTemplate(Interest),
            };

            if (idposition > 0)
            {



                BtnSaveVisible = false;
                BtnUpdateVisible = true;
                IsEdit = true;



                GetPosition(idposition);
            }


            TappedCommand = new Command<object>(TappedCommandMethod);
            DeleteCommand = new Command<object>(DeleteCommandMethod);
        }

        private int _Position;

        public int Position
        {
            get { return _Position; }
            set
            {
                _Position = value;

                if (_Position == 1 && IsEdit)
                {
                    int idarea = 0;
                    string area = string.Empty;

                    ObservableCollection<object> ar = new ObservableCollection<object>();
                    //Areas
                    for (int i = 0; i < ((IList)p.MisAreas).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)p.MisAreas)[i].ToString());

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
                    MisAreas = ar;

                    //Areas
                    int idbsfield = 0;
                    string bsfield = string.Empty;
                    ObservableCollection<object> bs = new ObservableCollection<object>();

                    for (int i = 0; i < ((IList)p.BSFields).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)p.BSFields)[i].ToString());

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
                        bs.Add(new BSFields { IDBusinessField = idbsfield, BusinessField = bsfield });
                    }
                    //MyBSFields=  new ObservableCollection<object>();
                    MyBSFields = bs;

                    //Experience
                    int idexperience = 0;
                    string exp = string.Empty;
                    ObservableCollection<object> xp = new ObservableCollection<object>();
                    for (int i = 0; i < ((IList)p.Experience).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)p.Experience)[i].ToString());

                        foreach (KeyValuePair<string, JToken> keyValuePair in result)
                        {
                            if ("IDExperience" == keyValuePair.Key)
                            {
                                idexperience = (int)(keyValuePair.Value);
                            }

                            if ("Experience" == keyValuePair.Key)
                            {
                                exp = keyValuePair.Value.ToString();
                            }

                        }
                        xp.Add(new Experiencias() { IDExperience = idexperience, Experience = exp });
                    }
                    MyExperience = xp;
                }
                else if (_Position == 0 && IsEdit)
                {
                    MisAreas = null;
                    MyExperience = null;
                    MyBSFields = null;
                }

                if (_Position == 1 && !IsEdit)
                {

                    int idarea = 0;
                    string area = string.Empty;

                    if (vartemp1 != null)
                    {
                        ObservableCollection<object> ar = new ObservableCollection<object>();

                        var z = (IList)vartemp1;

                        foreach (var item in z)
                        {
                            var n = (Areas)item;

                            ar.Add(new Areas { IDArea = n.IDArea, Area = n.Area });
                        }
                        
                        //Areas
                        
                        MisAreas = ar;
                    }

                    if (vartemp2 != null)
                    {
                        ObservableCollection<object> bs = new ObservableCollection<object>();

                        var z = (IList)vartemp2;

                        foreach (var item in z)
                        {
                            var n = (BSFields)item;

                            bs.Add(new BSFields { IDBusinessField = n.IDBusinessField, BusinessField = n.BusinessField });
                        }

                        //Areas

                        MyBSFields = bs;
                    }

                    if (vartemp3 != null)
                    {
                        ObservableCollection<object> ar = new ObservableCollection<object>();

                        var z = (IList)vartemp3;

                        foreach (var item in z)
                        {
                            var n = (Experiencias)item;

                            ar.Add(new Experiencias { IDExperience = n.IDExperience, Experience = n.Experience });
                        }

                        //Areas

                        MyExperience = ar;
                    }

                }
                else if (_Position == 0 && !IsEdit)
                {
                    vartemp1 = MisAreas;                    
                    vartemp2 = MyBSFields ;                    
                    vartemp3 = MyExperience;

                    MyBSFields = null;
                    MisAreas = null;
                    MyExperience = null;
                }
                OnPropertyChanged();
            }
        }

        public object vartemp1 { get; set; }
        public object vartemp2 { get; set; }
        public object vartemp3 { get; set; }


        Positions p = new Positions();


        private async void GetPosition(int idposition)
        {

            try
            {
                UserDialogs.Instance.ShowLoading("Loading...");

                await Task.Delay(1000);


                p = await Services.PositionService.GetPositionAsync(idposition);

                Name = p.Name;

                IDPosition = idposition;

                Description = p.Description;

                TravelAvailable = p.TravelAvailable;

                ChangeResidence = p.ChangeResidence;

                TypeofJob = p.TypeofJob;


                var countryselected = new Paises() { IDCountry = p.Country.IDCountry, Country = p.Country.Country };
                Country = listCountries.Where(x => x.IDCountry == countryselected.IDCountry).First();

                if (Country.IDCountry != 117)
                {
                    //Mexico
                    IsCityEnabled = false;
                }
                else
                {
                    //Mexico
                    IsCityEnabled = true;
                }


                if (p.City != null)
                {
                    var cityselected = new Ciudades() { IDCity = p.City.IDCity, City = p.City.City };
                    City = listCities.Where(x => x.IDCity == cityselected.IDCity).First();
                }

                var salaryselected = new Salarios() { IDSalary = p.Salary.IDSalary, Salary = p.Salary.Salary };
                Salary = listSalaries.Where(x => x.IDSalary == salaryselected.IDSalary).First();


                var genderselected = new Generos() { IDGender = p.Gender.IDGender, Gender = p.Gender.Gender };
                Gender = listGenders.Where(x => x.IDGender == genderselected.IDGender).First();


                int idgradyear = 0;
                string gradyear = string.Empty;

                if (p.GraduationYear != null)
                {
                    ObservableCollection<object> gy = new ObservableCollection<object>();
                    //GRaduation years
                    for (int i = 0; i < ((IList)p.GraduationYear).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)p.GraduationYear)[i].ToString());

                        foreach (KeyValuePair<string, JToken> keyValuePair in result)
                        {
                            if ("IDGraduationYear" == keyValuePair.Key)
                            {
                                idgradyear = (int)(keyValuePair.Value);
                            }

                            if ("Year" == keyValuePair.Key)
                            {
                                gradyear = keyValuePair.Value.ToString();
                            }

                        }

                        gy.Add(new AñosGraduacion { IDGraduationYear = idgradyear, Year = gradyear });


                    }
                    GraduationYear = gy;
                }


                int iddegree = 0;
                string degree = string.Empty;

                if (p.Degree != null)
                {
                    ObservableCollection<object> dg = new ObservableCollection<object>();
                    //Degrees
                    for (int i = 0; i < ((IList)p.Degree).Count; i++)
                    {
                        JObject result = JObject.Parse(((IList)p.Degree)[i].ToString());

                        foreach (KeyValuePair<string, JToken> keyValuePair in result)
                        {
                            if ("IDDegree" == keyValuePair.Key)
                            {
                                iddegree = (int)(keyValuePair.Value);
                            }

                            if ("Degree" == keyValuePair.Key)
                            {
                                degree = keyValuePair.Value.ToString();
                            }

                        }

                        dg.Add(new Titulos { IDDegree = iddegree, Degree = degree });


                    }
                    Degree = dg;
                }




                //Schools
                int idschool = 0;
                string sch = string.Empty;
                ObservableCollection<object> sc = new ObservableCollection<object>();
                for (int i = 0; i < ((IList)p.School).Count; i++)
                {
                    JObject result = JObject.Parse(((IList)p.School)[i].ToString());

                    foreach (KeyValuePair<string, JToken> keyValuePair in result)
                    {
                        if ("IDSchool" == keyValuePair.Key)
                        {
                            idschool = (int)(keyValuePair.Value);
                        }

                        if ("School" == keyValuePair.Key)
                        {
                            sch = keyValuePair.Value.ToString();
                        }

                    }
                    sc.Add(new Escuelas() { IDSchool = idschool, School = sch });
                }
                this.School = sc;

                //Certifications
                int idcert = 0;
                string cert = string.Empty;
                ObservableCollection<object> crt = new ObservableCollection<object>();
                for (int i = 0; i < ((IList)p.Certifications).Count; i++)
                {
                    JObject result = JObject.Parse(((IList)p.Certifications)[i].ToString());

                    foreach (KeyValuePair<string, JToken> keyValuePair in result)
                    {
                        if ("IDCertification" == keyValuePair.Key)
                        {
                            idcert = (int)(keyValuePair.Value);
                        }

                        if ("Certification" == keyValuePair.Key)
                        {
                            cert = keyValuePair.Value.ToString();
                        }

                    }
                    crt.Add(new Certificaciones() { IDCertification = idcert, Certification = cert });
                }
                this.Certifications = crt;

                //Languajes
                int idln = 0;
                string lng = string.Empty;
                ObservableCollection<object> ln = new ObservableCollection<object>();
                for (int i = 0; i < ((IList)p.Languajes).Count; i++)
                {
                    JObject result = JObject.Parse(((IList)p.Languajes)[i].ToString());

                    foreach (KeyValuePair<string, JToken> keyValuePair in result)
                    {
                        if ("IDLanguaje" == keyValuePair.Key)
                        {
                            idln = (int)(keyValuePair.Value);
                        }

                        if ("Languaje" == keyValuePair.Key)
                        {
                            lng = keyValuePair.Value.ToString();
                        }

                    }
                    ln.Add(new Idiomas() { IDLanguaje = idln, Languaje = lng });
                }
                Languajes = ln;

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe", "Error loading position", "Ok");

                // throw;
            }

        }


        private View Essential()
        {
            StackLayout sl1 = new StackLayout();
            sl1.Margin = new Thickness(10, 0, 10, 0);

            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "       Puesto       " : "       Position       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };


            string fuente = string.Empty;
            FontAttributes atributo = FontAttributes.None;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    fuente = "Font Awesome 5 Free";
                    atributo = FontAttributes.Bold;
                    break; ;
                case Device.Android:
                    fuente = "FontSolid-900.otf#Font Awesome 5 Free Solid";
                    atributo = FontAttributes.None;
                    break;
            };

            // Token Customization
            TokenSettings token = new TokenSettings();
            token.FontSize = 10;
            token.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
            token.IsCloseButtonVisible = true;
            token.CornerRadius = 15;
            token.DeleteButtonPlacement = DeleteButtonPlacement.Left;

            //Name
            var entryPosName = new Entry();
            entryPosName.SetBinding(Entry.TextProperty, "Name");
            entryPosName.Behaviors.Add(new EntryLengthValidator() { MinLength = 5, MaxLength = 100 });
            entryPosName.BindingContext = this;

            var inputName = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Puesto" : "Position",
                ErrorText = "Enter a valid job name",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf0c0",
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    VerticalOptions = LayoutOptions.Center,


                },

                ContainerType = ContainerType.Filled,

                CharMaxLength = 50,
                //inputName.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = entryPosName

            };

            ////cOUNTRY
            ///
            //var gridCountry = new Grid();
            //gridCountry.Margin = new Thickness(4, 0, 0, 10);

            //gridCountry.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            //gridCountry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            //gridCountry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });


            var pickerCountry = new Picker()
            {

                BackgroundColor = Color.WhiteSmoke,
                Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "País" : "Country",
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
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = pickerCountry
            };
            //var LeadingViewCountry = new Label()
            //{
            //    Text = "\uf57d",
            //    FontFamily = fuente,
            //    FontSize = 24,
            //    FontAttributes = atributo,
            //    TextColor = Color.FromHex(Colores.JobMeGray),
            //    VerticalOptions = LayoutOptions.Center,
            //    Margin = new Thickness(10, 0, 0, 0)
            //};

            //gridCountry.Children.Add(LeadingViewCountry, 0, 0);
            //gridCountry.Children.Add(pickerCountry, 1, 0);

            ////City

            //var gridCity = new Grid();
            //gridCity.Margin = new Thickness(4, 0, 0, 10);

            //gridCity.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            //gridCity.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            //gridCity.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });


            var pickerCity = new Picker()
            {

                BackgroundColor = Color.WhiteSmoke,
                Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ciudad" : "City",
                TitleColor = Color.FromHex(Colores.JobMeGray),

            };

            pickerCity.SetBinding(Picker.ItemsSourceProperty, "listCities");
            pickerCity.SetBinding(Picker.SelectedItemProperty, "City", BindingMode.TwoWay);
            pickerCity.SetBinding(Picker.IsEnabledProperty, "IsCityEnabled");
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
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = pickerCity
            };

            var LeadingViewCity = new Label()
            {
                Text = "\uf64f",
                FontFamily = fuente,
                FontSize = 24,
                FontAttributes = atributo,
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };


            //gridCity.Children.Add(LeadingViewCity, 0, 0);
            //gridCity.Children.Add(pickerCity, 1, 0);


            //Degree
            var gridDegree = new Grid();
            gridDegree.Margin = new Thickness(4, 0, 0, 10);

            gridDegree.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            gridDegree.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridDegree.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var comboDegree = new SfComboBox()
            {

                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Título" : "Degree",
                //WatermarkColor = Color.FromHex(Colores.JobMeGray),
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                ShowBorder = false,
                ShowClearButton = false,
                EnableAutoSize = true,
            };


            var LeadingViewDegree = new Label()
            {
                Text = "\uf091",
                FontFamily = fuente,
                FontSize = 24,
                FontAttributes = atributo,
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };
            comboDegree.ItemPadding = 5;
            comboDegree.ShowBorder = false;

            // Create Border control
            SfBorder border2 = new SfBorder();
            border2.CornerRadius = 10;
            border2.VerticalOptions = LayoutOptions.FillAndExpand;
            border2.HorizontalOptions = LayoutOptions.FillAndExpand;
            border2.BorderColor = Color.FromHex(Colores.JobMeOrange);

            border2.Content = comboDegree;

            comboDegree.DataSource = listDegrees;
            comboDegree.DisplayMemberPath = "Degree";

            comboDegree.SetBinding(SfComboBox.DataSourceProperty, "listDegrees");
            comboDegree.SetBinding(SfComboBox.SelectedItemProperty, "Degree", BindingMode.TwoWay);
            comboDegree.BindingContext = this;

            // comboDegree.SelectionChanged += comboDegree_SelectionChanged;

            gridDegree.Children.Add(LeadingViewDegree, 0, 0);
            gridDegree.Children.Add(border2, 1, 0);


            //School                             
            ///
            var gridSchool = new Grid();
            gridSchool.Margin = new Thickness(4, 0, 0, 10);

            gridSchool.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            gridSchool.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridSchool.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var comboSchool = new SfComboBox()
            {
                //BackgroundColor = Color.WhiteSmoke,
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Escuela" : "School",
                //WatermarkColor = Color.FromHex(Colores.JobMeGray),
                //BackgroundColor=Color.FromHex("#FFFFFF"),
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                //HeightRequest = 60,
                //WidthRequest = 100,
                IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                ShowBorder = false,
                ShowClearButton = false,
                EnableAutoSize = true,
            };


            var LeadingViewSchool = new Label()
            {
                Text = "\uf549",
                FontFamily = fuente,
                FontSize = 24,
                FontAttributes = atributo,
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };
            comboSchool.ItemPadding = 5;
            comboSchool.ShowBorder = false;
            comboSchool.DataSource = listSchools;
            comboSchool.DisplayMemberPath = "School";

            comboSchool.SetBinding(SfComboBox.DataSourceProperty, "listSchools");
            comboSchool.SetBinding(SfComboBox.SelectedItemProperty, "School", BindingMode.TwoWay);
            comboSchool.BindingContext = this;

            // Create Border control
            SfBorder border = new SfBorder();
            border.CornerRadius = 10;
            border.VerticalOptions = LayoutOptions.FillAndExpand;
            border.HorizontalOptions = LayoutOptions.FillAndExpand;
            border.BorderColor = Color.FromHex(Colores.JobMeOrange);

            border.Content = comboSchool;
            //comboSchool.SelectionChanged += comboSchool_SelectionChanged;

            gridSchool.Children.Add(LeadingViewSchool, 0, 0);
            gridSchool.Children.Add(border, 1, 0);

            ////Gender              
            //var gridGender = new Grid();
            //gridGender.Margin = new Thickness(4, 0, 0, 10);

            //gridGender.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            //gridGender.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            //gridGender.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });


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
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = pickerGender
            };

            //var LeadingViewGender = new Label()
            //{
            //    Text = "\uf228",
            //    FontFamily = fuente,
            //    FontSize = 24,
            //    FontAttributes = atributo,
            //    TextColor = Color.FromHex(Colores.JobMeGray),
            //    VerticalOptions = LayoutOptions.Center,
            //    Margin = new Thickness(10, 0, 0, 0)
            //};
            //combobox.ItemPadding = 5;
            //combobox.ShowBorder = false;

            listGenders = new ObservableCollection<Generos>();
            listGenders.Add(new Generos() { IDGender = 0, Gender = "Prefer not to say" });
            listGenders.Add(new Generos() { IDGender = 1, Gender = "Female" });
            listGenders.Add(new Generos() { IDGender = 2, Gender = "Male" });


            //gridGender.Children.Add(LeadingViewGender, 0, 0);
            //gridGender.Children.Add(pickerGender, 1, 0);


            //Año de nacimiento

            var gridGraduation = new Grid();
            gridGraduation.Margin = new Thickness(4, 0, 0, 10);

            gridGraduation.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            gridGraduation.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridGraduation.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var comboGraduation = new SfComboBox()
            {
                // BackgroundColor = Color.WhiteSmoke,
                // HeightRequest = 40,
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Año de graduación" : "Graduation year",

                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                // HeightRequest = 60,
                //WidthRequest = 100,
                IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                ShowBorder = false,
                ShowClearButton = false,
                EnableAutoSize = true,

            };


            var LeadingViewGraduation = new Label()
            {
                Text = "\uf501",
                FontFamily = fuente,
                FontSize = 24,
                FontAttributes = atributo,
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };
            comboGraduation.ItemPadding = 5;
            comboGraduation.ShowBorder = false;

            comboGraduation.DataSource = ListAñosGraduacion;
            comboGraduation.DisplayMemberPath = "Year";

            // Create Border control
            SfBorder border3 = new SfBorder();
            border3.CornerRadius = 10;
            border3.VerticalOptions = LayoutOptions.FillAndExpand;
            border3.HorizontalOptions = LayoutOptions.FillAndExpand;
            border3.BorderColor = Color.FromHex(Colores.JobMeOrange);

            border3.Content = comboGraduation;
            // comboGraduation.SelectionChanged += comboGraduation_SelectionChanged;

            comboGraduation.SetBinding(SfComboBox.DataSourceProperty, "ListAñosGraduacion");
            comboGraduation.SetBinding(SfComboBox.SelectedItemProperty, "GraduationYear", BindingMode.TwoWay);
            comboGraduation.BindingContext = this;

            gridGraduation.Children.Add(LeadingViewGraduation, 0, 0);
            gridGraduation.Children.Add(border3, 1, 0);

            //Certifications
            var gridCertifications = new Grid();
            gridCertifications.Margin = new Thickness(4, 0, 0, 10);

            gridCertifications.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            gridCertifications.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridCertifications.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

            var comboCertifications = new SfComboBox()
            {
                //BackgroundColor = Color.WhiteSmoke,
                //WatermarkColor = Color.FromHex(Colores.JobMeGray),
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Certificaciones" : "Certifications",
                //BackgroundColor=Color.FromHex("#FFFFFF"),
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                //HeightRequest = 60,
                IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                ShowBorder = false,
                ShowClearButton = false,
                EnableAutoSize = true,

            };



            var LeadingViewCertifications = new Label()
            {
                Text = "\uf091",
                FontFamily = fuente,
                FontSize = 24,
                FontAttributes = atributo,
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };
            comboCertifications.ItemPadding = 5;
            comboCertifications.ShowBorder = false;

            // Create Border control
            SfBorder border1 = new SfBorder();
            border1.CornerRadius = 10;
            border1.VerticalOptions = LayoutOptions.FillAndExpand;
            border1.HorizontalOptions = LayoutOptions.FillAndExpand;
            border1.BorderColor = Color.FromHex(Colores.JobMeOrange);

            border1.Content = comboCertifications;

            comboCertifications.DataSource = listCertifications;
            comboCertifications.DisplayMemberPath = "Certification";

            comboCertifications.SetBinding(SfComboBox.DataSourceProperty, "listCertifications");
            comboCertifications.SetBinding(SfComboBox.SelectedItemProperty, "Certifications", BindingMode.TwoWay);

            comboCertifications.BindingContext = this;
            // comboCertifications.SelectionChanged += comboCertifications_SelectionChanged;

            gridCertifications.Children.Add(LeadingViewCertifications, 0, 0);
            gridCertifications.Children.Add(border1, 1, 0);

            //Languaje
            var gridLanguaje = new Grid();
            gridLanguaje.Margin = new Thickness(4, 0, 0, 10);

            gridLanguaje.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

            gridLanguaje.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            gridLanguaje.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });



            var comboLanguaje = new SfComboBox()
            {
                BackgroundColor = Color.White,
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Idiomas" : "Languajes",
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                //HeightRequest = 60,
                //WatermarkColor = Color.FromHex(Colores.JobMeGray),
                IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                ShowBorder = false,
                ShowClearButton = false,
                EnableAutoSize = true,
            };

            // Create Border control
            SfBorder borderLanguaje = new SfBorder();
            borderLanguaje.CornerRadius = 10;
            borderLanguaje.VerticalOptions = LayoutOptions.FillAndExpand;
            borderLanguaje.HorizontalOptions = LayoutOptions.FillAndExpand;
            borderLanguaje.BorderColor = Color.FromHex(Colores.JobMeOrange);

            borderLanguaje.Content = comboLanguaje;

            var LeadingViewLanguaje = new Label()
            {
                Text = "\uf0ac",
                FontFamily = fuente,
                FontSize = 24,
                FontAttributes = atributo,
                TextColor = Color.FromHex(Colores.JobMeGray),
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };
            comboLanguaje.ItemPadding = 5;
            comboLanguaje.ShowBorder = false;

            comboLanguaje.DataSource = listLanguajes;
            comboLanguaje.DisplayMemberPath = "Languaje";

            comboLanguaje.SetBinding(SfComboBox.DataSourceProperty, "listLanguajes");
            comboLanguaje.SetBinding(SfComboBox.SelectedItemProperty, "Languajes", BindingMode.TwoWay);
            comboLanguaje.BindingContext = this;

            gridLanguaje.Children.Add(LeadingViewLanguaje, 0, 0);
            gridLanguaje.Children.Add(borderLanguaje, 1, 0);


            //Salary         
            //var gridSalary = new Grid();

            //gridSalary.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
            //gridSalary.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });



            var pickerSalary = new Picker()
            {

                BackgroundColor = Color.WhiteSmoke,
                Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Salario" : "Salary",
                TitleColor = Color.FromHex(Colores.JobMeGray)
            };

            pickerSalary.SetBinding(Picker.ItemsSourceProperty, "listSalaries");
            pickerSalary.SetBinding(Picker.SelectedItemProperty, "Salary", BindingMode.TwoWay);
            pickerSalary.ItemDisplayBinding = new Binding("Salary");
            pickerSalary.BindingContext = this;

            //var inputSalary = new Editor()
            //{
            //    Text = "\uf155",
            //    FontFamily = fuente,
            //    FontSize = 24,
            //    FontAttributes = atributo,
            //    TextColor = Color.FromHex(Colores.JobMeGray),
            //    VerticalOptions = LayoutOptions.Center,
            //    Margin = new Thickness(10, 0, 0, 0),
            //    AutoSize = EditorAutoSizeOption.TextChanges

            //};

            var SalaryLayout = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Salario" : "Salary",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf155",
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    //VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = pickerSalary
            };

            //gridSalary.Children.Add(inputSalary, 0, 0);
            //gridSalary.Children.Add(pickerSalary, 1, 0);

            // inputSalary.InputView = combobox1;


            //Description

            var entryPosDesc = new Editor();
            entryPosDesc.AutoSize = EditorAutoSizeOption.TextChanges;
            entryPosDesc.SetBinding(Editor.TextProperty, "Description");
            //entryPosDesc.Behaviors.Add(new EntryLengthValidator() { MinLength = 5, MaxLength = 100 });
            entryPosDesc.BindingContext = this;

            var inputDescription = new SfTextInputLayout
            {
                Hint = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Breve descripción del puesto" : "Brief description about the job",
                //InputViewPadding = 5,
                ErrorText = "Enter a valid job description",
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf0c0",
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                //inputName.HelperText = "Enter your name";
                CharMaxLength = 50,
                //inputName.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = entryPosDesc
            };

            sl1.Orientation = StackOrientation.Vertical;

            //sl1.Children.Add(inputNM);
            sl1.Children.Add(inputes);

            sl1.Children.Add(inputName);
            sl1.Children.Add(gridDegree);
            sl1.Children.Add(gridSchool);
            sl1.Children.Add(genderly);
            sl1.Children.Add(CountryLayout);
            sl1.Children.Add(CityLayout);
            sl1.Children.Add(gridGraduation);
            sl1.Children.Add(gridCertifications);
            sl1.Children.Add(gridLanguaje);
            sl1.Children.Add(SalaryLayout);
            sl1.Children.Add(inputDescription);

            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            scv.Content = sl1;

            return scv;

        }

        private View Interest()
        {

            StackLayout sl1 = new StackLayout();
            sl1.Margin = new Thickness(10, 0, 10, 0);


            var inputes = new Label
            {
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "       Intereses       " : "       Interest       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 15)
            };


            string fuente = string.Empty;
            FontAttributes atributos = FontAttributes.None;

            //Fuente Iconos
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    fuente = "Font Awesome 5 Free";
                    atributos = FontAttributes.Bold;
                    break;
                case Device.Android:
                    fuente = "FontSolid-900.otf#Font Awesome 5 Free Solid";
                    break;
            };

            //Business Field         
            var gridBusiness = new Grid();

            gridBusiness.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
            gridBusiness.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });


            // Token Customization
            TokenSettings token = new TokenSettings();
            token.FontSize = 10;
            token.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
            token.IsCloseButtonVisible = true;
            token.CornerRadius = 15;
            token.DeleteButtonPlacement = DeleteButtonPlacement.Left;

            var combobox = new SfComboBox
            {
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Industria" : "Business Fields",
                //BackgroundColor=Color.FromHex("#FFFFFF"),
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                //HeightRequest = 60,
                //WidthRequest = 100,
                IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                EnableAutoSize = true,
            };
            var inputBusinessField = new SfTextInputLayout
            {
                // Hint = "Gender",
                // InputViewPadding = 15,

                ContainerType = ContainerType.Outlined,
                ContainerBackgroundColor = Color.FromHex("#FFFFFF"),
                LeadingViewPosition = ViewPosition.Outside,
                InputViewPadding = new Thickness(0, 0, 0, 0),
                UnfocusedColor = Color.FromHex(Colores.JobMeOrange),

            };


            combobox.DisplayMemberPath = "BusinessField";
            combobox.SetBinding(SfComboBox.DataSourceProperty, "listbssfields");
            combobox.SetBinding(SfComboBox.SelectedItemProperty, "MyBSFields", BindingMode.TwoWay);
            combobox.BindingContext = this;

            //combobox.HeightRequest = 90;
            inputBusinessField.InputView = combobox;

            var lbbusiness = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Industria" : "Business Fields",
            };

            gridBusiness.Children.Add(lbbusiness, 0, 0);
            gridBusiness.Children.Add(inputBusinessField, 1, 0);

            //  combobox.SelectionChanged += comboBussiness_SelectionChanged;


            //Area
            var gridArea = new Grid();

            gridArea.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
            gridArea.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });

            var comboArea = new SfComboBox
            {
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Áreas" : "Areas",
                //BackgroundColor=Color.FromHex("#FFFFFF"),
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                //HeightRequest = 60,
                //WidthRequest = 100,
                //IsSelectedItemsVisibleInDropDown = true,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                EnableAutoSize = true,
            };
            var inputArea = new SfTextInputLayout
            {
                // Hint = "Gender",
                // InputViewPadding = 15,

                ContainerType = ContainerType.Outlined,
                ContainerBackgroundColor = Color.FromHex("#FFFFFF"),
                LeadingViewPosition = ViewPosition.Outside,
                InputViewPadding = new Thickness(0, 0, 0, 0),
                UnfocusedColor = Color.FromHex(Colores.JobMeOrange),

            };

            //comboArea.DataSource = listAreas;
            comboArea.DisplayMemberPath = "Area";
            comboArea.SetBinding(SfComboBox.DataSourceProperty, "listAreas");
            comboArea.SetBinding(SfComboBox.SelectedItemProperty, "MisAreas", BindingMode.TwoWay);
            comboArea.BindingContext = this;
            //comboArea.HeightRequest = 90;
            inputArea.InputView = comboArea;

            var lbarea = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Áreas" : "Areas",
            };

            gridArea.Children.Add(lbarea, 0, 0);
            gridArea.Children.Add(inputArea, 1, 0);

            //comboArea.SelectionChanged += comboArea_SelectionChanged;

            //Experience
            var gridExperience = new Grid();

            gridExperience.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
            gridExperience.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });

            var comboExperience = new SfComboBox
            {
                Watermark = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
                MultiSelectMode = MultiSelectMode.Token,
                TokensWrapMode = TokensWrapMode.Wrap,
                //HeightRequest = 60,
                //WidthRequest = 100,
                //IsSelectedItemsVisibleInDropDown = false,
                BorderColor = Color.FromHex(Colores.JobMeOrange),
                TokenSettings = token,
                EnableAutoSize = true,
            };
            var inputExperience = new SfTextInputLayout
            {

                ContainerType = ContainerType.Outlined,
                ContainerBackgroundColor = Color.FromHex("#FFFFFF"),
                LeadingViewPosition = ViewPosition.Outside,
                InputViewPadding = new Thickness(0, 0, 0, 0),
                UnfocusedColor = Color.FromHex(Colores.JobMeOrange),

            };

            //comboExperience.DataSource = listExperience;
            comboExperience.DisplayMemberPath = "Experience";
            comboExperience.SetBinding(SfComboBox.DataSourceProperty, "listExperience");
            comboExperience.SetBinding(SfComboBox.SelectedItemProperty, "MyExperience", BindingMode.TwoWay);
            comboExperience.BindingContext = this;

            //comboExperience.HeightRequest = 90;
            inputExperience.InputView = comboExperience;

            var lbbusiness1 = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Experiencia" : "Experience",
            };

            gridExperience.Children.Add(lbbusiness1, 0, 0);
            gridExperience.Children.Add(inputExperience, 1, 0);

            //comboExperience.SelectionChanged += comboExperience_SelectionChanged;

            //Type of job
            var gridJob = new Grid();

            gridJob.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
            gridJob.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });

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

            gridResidence.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
            gridResidence.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });
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

            gridTravel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
            gridTravel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });
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
            // segmentedControlTravel.VerticalOptions = LayoutOptions.Center;
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

            //Palomita
            var lbPalomita = new SfButton()
            {
                Text = "\uf00c",
                FontFamily = fuente,
                FontSize = 30,
                WidthRequest = 60,
                HeightRequest = 60,
                FontAttributes = atributos,
                TextColor = Color.FromHex(Colores.JobMeOrange),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20, 0, 0),
                CornerRadius = 30,
                BackgroundColor = Color.WhiteSmoke

            };

            lbPalomita.SetBinding(SfButton.IsVisibleProperty, "BtnSaveVisible");
            lbPalomita.BindingContext = this;
            lbPalomita.Clicked += async (sender, args) => await AddPosition();

            //Palomita
            var btnUpdate = new SfButton()
            {
                Text = "Update",
                WidthRequest = 100,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 15, 0, 10),
                CornerRadius = 30,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                FontAttributes = atributos

            };

            btnUpdate.SetBinding(SfButton.IsVisibleProperty, "BtnUpdateVisible");
            btnUpdate.BindingContext = this;
            btnUpdate.Clicked += async (sender, args) => await AddPosition();


            sl1.Orientation = StackOrientation.Vertical;

            sl1.Children.Add(inputes);

            sl1.Children.Add(gridBusiness);
            sl1.Children.Add(gridArea);
            sl1.Children.Add(gridExperience);
            sl1.Children.Add(gridJob);
            //sl1.Children.Add(espera);
            sl1.Children.Add(gridResidence);
            sl1.Children.Add(gridTravel);
            sl1.Children.Add(lbPalomita);
            sl1.Children.Add(btnUpdate);

            ScrollView scv = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            scv.Content = sl1;

            return scv;



        }

        int flag = 0;
        private bool _isLocked;
        private async Task AddPosition()
        {
            if (_isLocked) return;
            _isLocked = true;

            try
            {
                Positions pos;

                //if (flag == 0)
                //{

                //    flag = 1;

                int resp = 0;
                if (Valida())
                {
                    if (IsEdit)
                    {


                        UserDialogs.Instance.ShowLoading("Updating position");
                        pos = new Positions()
                        {

                            Name = Name,
                            City = City,
                            School = School,
                            Degree = Degree,
                            Gender = Gender,
                            IDCompany = (int)Preferences.Get("idCompany", 0),
                            Salary = Salary,
                            Description = Description,
                            Country = Country,
                            Languajes = Languajes,
                            Certifications = Certifications,
                            Experience = MyExperience,
                            MisAreas = MisAreas,
                            BSFields = MyBSFields,
                            GraduationYear = GraduationYear,
                            TypeofJob = (int)TypeofJob,
                            ChangeResidence = (bool)ChangeResidence,
                            TravelAvailable = (bool)TravelAvailable,
                            UserID = (int)Preferences.Get("UserID", 0),
                            IDPosition = IDPosition,

                        };
                        resp = await PositionService.UpdatePositionAsync(pos);

                        // resp = await PositionService.AddPositionAsync(pos);

                        if (resp > 0)
                        {

                            UserDialogs.Instance.HideLoading();
                            await Application.Current.MainPage.DisplayAlert("JobMe",
                                "Job updated correctly",
                                "Ok");
                            MessagingCenter.Send(this, "UpdateList", 1);

                            await Navigation.PopAsync();
                            // await Navigation.PopAsync();
                        }
                        else
                        {
                            flag = 0;
                            UserDialogs.Instance.HideLoading();
                            await Application.Current.MainPage.DisplayAlert("JobMe",
                                App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "No se pudo agregar la vacante, verifica la información" : "Can't save the position, please verify the info",
                                "Ok");
                        }

                    }
                    else
                    {

                        // if (Valida())
                        //{

                        UserDialogs.Instance.ShowLoading("Saving position");

                        pos = new Positions()
                        {

                            Name = Name,
                            City = City,
                            IDCity = City != null ? City.IDCity : 0,
                            School = School,
                            Degree = Degree,
                            Gender = Gender,
                            IDCompany = (int)Preferences.Get("idCompany", 0),
                            Salary = Salary,
                            Description = Description,
                            Country = Country,
                            Languajes = Languajes,
                            Certifications = Certifications,
                            Experience = MyExperience,
                            MisAreas = MisAreas,
                            BSFields = MyBSFields,
                            GraduationYear = GraduationYear,
                            TypeofJob = (int)TypeofJob,  //1 es Full time   o es part time
                            ChangeResidence = (bool)ChangeResidence,  //0 es yes 1 es false
                            TravelAvailable = (bool)TravelAvailable, //0 es yes  1 es false
                            UserID = (int)Preferences.Get("UserID", 0),

                        };

                        resp = await PositionService.AddPositionAsync(pos);

                        if (resp > 0)
                        {

                            UserDialogs.Instance.HideLoading();
                            await Application.Current.MainPage.DisplayAlert("JobMe",
                                App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Se agrego correctamente la vacante" : "Job added correctly",
                                "Ok");
                            MessagingCenter.Send(this, "UpdateList", 1);
                            await Navigation.PopAsync();

                            //Actualizar la pagina 


                        }
                        else
                        {
                            flag = 0;
                            UserDialogs.Instance.HideLoading();
                            await Application.Current.MainPage.DisplayAlert("JobMe",
                                App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "No se pudo agregar la vacante, verifica la información" : "Can't save the position, please verify the info",
                                "Ok");
                        }

                        //}

                        //}

                    }

                }
            }


            catch (Exception ex)
            {
                flag = 0;
                UserDialogs.Instance.HideLoading();
                _isLocked = false;
                await Application.Current.MainPage.DisplayAlert("JobMe",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ocurrio un error al guardar el puesto" : "Can't save the position, please verify the info",
                    "Ok");
                //throw;
            }

            Task.Delay(600);
            _isLocked = false;
        }

        private bool Valida()
        {


            if (Name == null || Name == string.Empty)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Position can't be empty", "Ok");
                return false;
            }

            if (Country == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Country can't be empty", "Ok");
                return false;
            }

            if ((City == null && Country.IDCountry == 117))
            {


            }

            if (City != null)
            {
                if (Country.IDCountry == 117 && City.IDCity == 0)
                {
                    Application.Current.MainPage.DisplayAlert("JobMe", "Please choose a city", "Ok");
                    return false;
                }
            }


            if (Degree == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Degree can't be empty", "Ok");
                return false;
            }

            if (School == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "School can't be empty", "Ok");
                return false;
            }
            if (Gender == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Gender can't be empty", "Ok");
                return false;
            }
            if (Salary == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Salary can't be empty", "Ok");
                return false;
            }
            if (String.IsNullOrEmpty(Description))
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Description can't be empty", "Ok");
                return false;
            }
            if (MyBSFields == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Business Fields can't be empty", "Ok");
                return false;
            }
            if (MisAreas == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Areas of interest can't be empty", "Ok");
                return false;
            }

            if (((IList)GraduationYear).Count < 1)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Graduation year can't be empty", "Ok");
                return false;
            }
            if (Languajes == null)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Languaje can't be empty", "Ok");
                return false;
            }
            return true;

        }


        #region "Listas par llenar los combos"

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
        #endregion

        #region "bind combos"

        private async void BindBSFields()
        {
            listbssfields = await Services.JobMe.GetBSFields();

        }
        private async void BindExperience()
        {
            listExperience = await Services.JobMe.GetExperience();
        }

        private async void BindAreas()
        {
            listAreas = await Services.JobMe.GetAreas();
        }
        private async void BindCountries()
        {
            listCountries = await Services.JobMe.GetCountries();
        }
        private async void BindCities()
        {
            listCities = await Services.JobMe.GetCities();

        }

        private async void BindSchool()
        {
            listSchools = await Services.JobMe.GetSchools(true);
        }
        private async void BindDegree()
        {
            listDegrees = await Services.JobMe.GetDegrees(true);
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
        #endregion


        private async void TappedCommandMethod(object obj)
        {

            var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;

            ListaPositions p = (ListaPositions)x;

            //   Navigation.PushAsync(new EditJobView() { Title="Edit Position"  });

            var secondPage = new AddJobView(p.IDPosition) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar vacante" : "Edit Position" };

            await Navigation.PushAsync(secondPage);

            //AddJobViewModel(p.IDPosition);

        }

        private async void DeleteCommandMethod(object obj)
        {
            //var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;
            try
            {
                var x = (ListaPositions)obj;

                Device.BeginInvokeOnMainThread(() =>
                {
                    if (ItemIndex >= 0)
                        ListPositions.Remove(ListPositions[ItemIndex]);
                    ListView.ResetSwipe();

                });


                // ListPositions.RemoveAt(ItemIndex);

                //Agregar el metodo de borrado de position
                //if (await Services.PositionService.DeletePositionAsync(x.IDPosition))
                //{
                //    await Application.Current.MainPage.DisplayAlert("JobMe!", "Position successfully deleted", "OK");
                //    ListView.ResetSwipe();
                //    //MessagingCenter.Send<EditJobViewModel, int>(this, "UpdateList", 1);
                //}
                //else
                //{
                //    await Application.Current.MainPage.DisplayAlert("JobMe!", "Error deleting position", "OK");
                //}
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("JobMe!", "Error deleting position", "OK");
                //throw;
            }


            //sfListView.ResetSwipe();


        }

        private Syncfusion.ListView.XForms.SfListView _ListView;

        public Syncfusion.ListView.XForms.SfListView ListView
        {
            get { return _ListView; }
            set { _ListView = value; OnPropertyChanged(); }
        }


        private int _itemIndex = -1;

        public int ItemIndex
        {
            get { return _itemIndex; }
            set { _itemIndex = value; OnPropertyChanged(); }
        }

    }



}
