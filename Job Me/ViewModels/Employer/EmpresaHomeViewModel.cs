using Acr.UserDialogs;
using JobMe.Behaviors;
using JobMe.Models;
using JobMe.Services;
using JobMe.Views;
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
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels.Employer
{
    class EmpresaHomeViewModel : BaseViewModel
    {

        #region "Propiedades

        private string _JobDescription;

        public string JobDescription
        {
            get { return _JobDescription; }
            set { _JobDescription = value; OnPropertyChanged(); }
        }

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
                        allschools = false;
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



        private bool _IsLogoVisible = false;

        public bool IsLogoVisible
        {
            get { return _IsLogoVisible; }
            set
            {
                _IsLogoVisible = value;
                OnPropertyChanged();
            }
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



        private NewPositionTemplateSelector _templateselector;

        public NewPositionTemplateSelector TemplateSelector
        {
            get { return _templateselector; }
            set { _templateselector = value; }
        }

        #endregion



        public async void UpdateData()
        {


            MessagingCenter.Subscribe<MainEmpresaView, int>(this, "Status", (sender, arg) =>
            {

                if (arg == 1)
                {
                    GetCompany();
                }


            });
        }

        private async void GetCompany()
        {
            IsBusy = true;

            var userid = Preferences.Get("UserID", 0);


            Companies c = new Companies();

            c = await Services.EmployerService.GetCompanyAsync(userid);

            if (c != null)
            {
                Preferences.Set("Company", c.Company);
               

                Company = c.Company;
                Description = c.Description;
                Logo = c.Logo;

                if (Logo == null)
                {

                    IsLogoVisible = true;
                }


            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("JobMe", "Ocurrio un error al cargar la información de la empresa", "Ok");

            }

            IsBusy = false;

        }
        private string _AddJobslbl;

        public string AddJobslbl
        {
            get { return _AddJobslbl; }
            set { _AddJobslbl = value; OnPropertyChanged(); }
        }
        private string _EditVacancieslbl;

        public string EditVacancieslbl
        {
            get { return _EditVacancieslbl; }
            set { _EditVacancieslbl = value; OnPropertyChanged(); }
        }


        public EmpresaHomeViewModel()
        {
            Preferences.Set("UserType", 2);

            AddJobslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Agregar vacante" : "Add Jobs";
            EditVacancieslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar vacante" : "Edit Vacancies";
            UpdateData();
            GetCompany();

            ///Empieza//////////////////
            ///
            //BtnSaveVisible = true;
            //BtnUpdateVisible = false;
            //// Text = "\uf00c",

            //IsEdit = false;
            //BindCountries();
            //BindCities();
            //BindSchool();
            //BindDegree();
            //BindYear();
            //BindCertification();
            //BindLanguaje();
            //BindSalaries();
            //BindBSFields();
            //BindAreas();
            //BindExperience();

            //////Se cargan las pestañas
            //CarouselColllection = new List<CustomCell>();
            //CarouselColllection.Add(new CustomCell { TipoHoja = 1 });
            //CarouselColllection.Add(new CustomCell { TipoHoja = 2 });

            //TemplateSelector = new NewPositionTemplateSelector
            //{
            //    AddJobTemplate = new DataTemplate(Essential),
            //    AddJobDetailTemplate = new DataTemplate(Details),
            //};




        }
        //public EmpresaHomeViewModel(int idposition)
        //{


        //    BtnSaveVisible = false;
        //    BtnUpdateVisible = true;
        //    IsEdit = true;
        //    BindCountries();
        //    BindCities();
        //    BindSchool();
        //    BindDegree();
        //    BindYear();
        //    BindCertification();
        //    BindLanguaje();
        //    BindSalaries();
        //    BindBSFields();
        //    BindAreas();
        //    BindExperience();

        //    ////Se cargan las pestañas
        //    CarouselColllection = new List<CustomCell>();
        //    CarouselColllection.Add(new CustomCell { TipoHoja = 1 });
        //    CarouselColllection.Add(new CustomCell { TipoHoja = 2 });

        //    TemplateSelector = new NewPositionTemplateSelector
        //    {
        //        AddJobTemplate = new DataTemplate(Essential),
        //        AddJobDetailTemplate = new DataTemplate(Details),
        //    };

        //    if (idposition != 0)
        //    {

        //        GetPosition(idposition);

        //    };
        //}

        //private async void GetPosition(int idposition)
        //{

        //    UserDialogs.Instance.ShowLoading("Loading position");
        //    try
        //    {
        //        await Task.Delay(1000);

        //        Positions p = new Positions();

        //        p = await Services.PositionService.GetPositionAsync(idposition);

        //        Name = p.Name;

        //        IDPosition = idposition;

        //        JobDescription = p.Description;

        //        TravelAvailable = p.TravelAvailable;

        //        ChangeResidence = p.ChangeResidence;

        //        TypeofJob = p.TypeofJob;

        //        //GraduationYear = new AñosGraduacion() { IDGraduationYear = p.IDGraduationYear, Year = p.GraduationYear };

        //        City = new Ciudades() { IDCity = p.IDCity, City = p.City };

        //        //Degree = new Titulos() { IDDegree = p.IDDegree, Degree = p.Degree };

        //        Salary = new Salarios() { IDSalary = p.IDSalary, Salary = p.Salary };

        //        Country = new Paises() { IDCountry = p.IDCountry, Country = p.Country };

        //        Gender = new Generos() { IDGender = p.IDGender, Gender = p.Gender };


        //        int idgradyear = 0;
        //        string gradyear = string.Empty;

        //        if (p.GraduationYear != null)
        //        {
        //            ObservableCollection<object> gy = new ObservableCollection<object>();
        //            //GRaduation years
        //            for (int i = 0; i < ((IList)p.GraduationYear).Count; i++)
        //            {
        //                JObject result = JObject.Parse(((IList)p.GraduationYear)[i].ToString());

        //                foreach (KeyValuePair<string, JToken> keyValuePair in result)
        //                {
        //                    if ("IDGraduationYear" == keyValuePair.Key)
        //                    {
        //                        idgradyear = (int)(keyValuePair.Value);
        //                    }

        //                    if ("Year" == keyValuePair.Key)
        //                    {
        //                        gradyear = keyValuePair.Value.ToString();
        //                    }

        //                }

        //                gy.Add(new AñosGraduacion { IDGraduationYear = idgradyear, Year = gradyear });


        //            }
        //            GraduationYear = gy;
        //        }


        //        int iddegree = 0;
        //        string degree = string.Empty;

        //        if (p.Degree != null)
        //        {
        //            ObservableCollection<object> dg = new ObservableCollection<object>();
        //            //Degrees
        //            for (int i = 0; i < ((IList)p.Degree).Count; i++)
        //            {
        //                JObject result = JObject.Parse(((IList)p.Degree)[i].ToString());

        //                foreach (KeyValuePair<string, JToken> keyValuePair in result)
        //                {
        //                    if ("IDDegree" == keyValuePair.Key)
        //                    {
        //                        iddegree = (int)(keyValuePair.Value);
        //                    }

        //                    if ("Degree" == keyValuePair.Key)
        //                    {
        //                        degree = keyValuePair.Value.ToString();
        //                    }

        //                }

        //                dg.Add(new Titulos { IDDegree = iddegree, Degree = degree });


        //            }
        //            Degree = dg;
        //        }


        //        int idarea = 0;
        //        string area = string.Empty;

        //        ObservableCollection<object> ar = new ObservableCollection<object>();
        //        //Areas
        //        for (int i = 0; i < ((IList)p.MisAreas).Count; i++)
        //        {
        //            JObject result = JObject.Parse(((IList)p.MisAreas)[i].ToString());

        //            foreach (KeyValuePair<string, JToken> keyValuePair in result)
        //            {
        //                if ("IDArea" == keyValuePair.Key)
        //                {
        //                    idarea = (int)(keyValuePair.Value);
        //                }

        //                if ("Area" == keyValuePair.Key)
        //                {
        //                    area = keyValuePair.Value.ToString();
        //                }

        //            }

        //            ar.Add(new Areas { IDArea = idarea, Area = area });


        //        }
        //        MisAreas = ar;

        //        //Areas
        //        int idbsfield = 0;
        //        string bsfield = string.Empty;
        //        ObservableCollection<object> bs = new ObservableCollection<object>();

        //        for (int i = 0; i < ((IList)p.BSFields).Count; i++)
        //        {
        //            JObject result = JObject.Parse(((IList)p.BSFields)[i].ToString());

        //            foreach (KeyValuePair<string, JToken> keyValuePair in result)
        //            {
        //                if ("IDBusinessField" == keyValuePair.Key)
        //                {
        //                    idbsfield = (int)(keyValuePair.Value);
        //                }

        //                if ("BusinessField" == keyValuePair.Key)
        //                {
        //                    bsfield = keyValuePair.Value.ToString();
        //                }

        //            }
        //            bs.Add(new BSFields { IDBusinessField = idbsfield, BusinessField = bsfield });
        //        }
        //        //MyBSFields=  new ObservableCollection<object>();
        //        MyBSFields = bs;

        //        //Experience
        //        int idexperience = 0;
        //        string exp = string.Empty;
        //        ObservableCollection<object> xp = new ObservableCollection<object>();
        //        for (int i = 0; i < ((IList)p.Experience).Count; i++)
        //        {
        //            JObject result = JObject.Parse(((IList)p.Experience)[i].ToString());

        //            foreach (KeyValuePair<string, JToken> keyValuePair in result)
        //            {
        //                if ("IDExperience" == keyValuePair.Key)
        //                {
        //                    idexperience = (int)(keyValuePair.Value);
        //                }

        //                if ("Experience" == keyValuePair.Key)
        //                {
        //                    exp = keyValuePair.Value.ToString();
        //                }

        //            }
        //            xp.Add(new Experiencias() { IDExperience = idexperience, Experience = exp });
        //        }
        //        MyExperience = xp;

        //        //Schools
        //        int idschool = 0;
        //        string sch = string.Empty;
        //        ObservableCollection<object> sc = new ObservableCollection<object>();
        //        for (int i = 0; i < ((IList)p.School).Count; i++)
        //        {
        //            JObject result = JObject.Parse(((IList)p.School)[i].ToString());

        //            foreach (KeyValuePair<string, JToken> keyValuePair in result)
        //            {
        //                if ("IDSchool" == keyValuePair.Key)
        //                {
        //                    idschool = (int)(keyValuePair.Value);
        //                }

        //                if ("School" == keyValuePair.Key)
        //                {
        //                    sch = keyValuePair.Value.ToString();
        //                }

        //            }
        //            sc.Add(new Escuelas() { IDSchool = idschool, School = sch });
        //        }
        //        this.School = sc;

        //        //Certifications
        //        int idcert = 0;
        //        string cert = string.Empty;
        //        ObservableCollection<object> crt = new ObservableCollection<object>();
        //        for (int i = 0; i < ((IList)p.Certifications).Count; i++)
        //        {
        //            JObject result = JObject.Parse(((IList)p.Certifications)[i].ToString());

        //            foreach (KeyValuePair<string, JToken> keyValuePair in result)
        //            {
        //                if ("IDCertification" == keyValuePair.Key)
        //                {
        //                    idcert = (int)(keyValuePair.Value);
        //                }

        //                if ("Certification" == keyValuePair.Key)
        //                {
        //                    cert = keyValuePair.Value.ToString();
        //                }

        //            }
        //            crt.Add(new Certificaciones() { IDCertification = idcert, Certification = cert });
        //        }
        //        this.Certifications = crt;

        //        //Languajes
        //        int idln = 0;
        //        string lng = string.Empty;
        //        ObservableCollection<object> ln = new ObservableCollection<object>();
        //        for (int i = 0; i < ((IList)p.Languajes).Count; i++)
        //        {
        //            JObject result = JObject.Parse(((IList)p.Languajes)[i].ToString());

        //            foreach (KeyValuePair<string, JToken> keyValuePair in result)
        //            {
        //                if ("IDLanguaje" == keyValuePair.Key)
        //                {
        //                    idln = (int)(keyValuePair.Value);
        //                }

        //                if ("Languaje" == keyValuePair.Key)
        //                {
        //                    lng = keyValuePair.Value.ToString();
        //                }

        //            }
        //            ln.Add(new Idiomas() { IDLanguaje = idln, Languaje = lng });
        //        }
        //        Languajes = ln;
        //        UserDialogs.Instance.HideLoading();
        //    }
        //    catch (Exception)
        //    {
        //        UserDialogs.Instance.HideLoading();
        //        await Application.Current.MainPage.DisplayAlert("JobMe", "Error loading position", "Ok");

        //        // throw;
        //    }

        //}

        //private View Essential()
        //{
        //    StackLayout sl1 = new StackLayout();
        //    sl1.Margin = new Thickness(10, 0, 10, 0);

        //    var inputes = new Label
        //    {
        //        Text = "       Position       ",
        //        HorizontalOptions = LayoutOptions.Center,
        //        FontSize = 18,
        //        // inputes.FontAttributes = FontAttributes.Bold;
        //        VerticalOptions = LayoutOptions.Center,
        //        TextColor = Color.White,
        //        BackgroundColor = Color.FromHex(Colores.JobMeOrange),
        //        Margin = new Thickness(0, 0, 0, 20)
        //    };


        //    string fuente = string.Empty;
        //    FontAttributes atributo = FontAttributes.None;

        //    switch (Device.RuntimePlatform)
        //    {
        //        case Device.iOS:
        //            fuente = "Font Awesome 5 Free";
        //            atributo = FontAttributes.Bold;
        //            break; ;
        //        case Device.Android:
        //            fuente = "FontSolid-900.otf#Font Awesome 5 Free Solid";
        //            atributo = FontAttributes.None;
        //            break;
        //    };

        //    // Token Customization
        //    TokenSettings token = new TokenSettings();
        //    token.FontSize = 10;
        //    token.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
        //    token.IsCloseButtonVisible = true;
        //    token.CornerRadius = 15;
        //    token.DeleteButtonPlacement = DeleteButtonPlacement.Left;

        //    //Name
        //    var entryPosName = new Entry();
        //    entryPosName.SetBinding(Entry.TextProperty, "Name");
        //    entryPosName.Behaviors.Add(new EntryLengthValidator() { MinLength = 5, MaxLength = 100 });
        //    entryPosName.BindingContext = this;

        //    var inputName = new SfTextInputLayout
        //    {
        //        Hint = "Position",
        //        ErrorText = "Enter a valid job name",
        //        InputViewPadding = 5,
        //        LeadingViewPosition = ViewPosition.Outside,
        //        LeadingView = new Label()
        //        {
        //            Text = "\uf0c0",
        //            FontFamily = fuente,
        //            FontSize = 24,
        //            FontAttributes = atributo,
        //            TextColor = Color.FromHex(Colores.JobMeGray),
        //            VerticalOptions = LayoutOptions.Center,


        //        },

        //        ContainerType = ContainerType.Filled,

        //        CharMaxLength = 50,
        //        //inputName.ShowCharCount = true;
        //        HintLabelStyle = new LabelStyle() { FontSize = 16 },
        //        InputView = entryPosName

        //    };

        //    ////cOUNTRY
        //    ///
        //    var gridCountry = new Grid();
        //    gridCountry.Margin = new Thickness(4, 0, 0, 10);

        //    gridCountry.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

        //    gridCountry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
        //    gridCountry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

        //    var comboCountry = new SfComboBox()
        //    {
        //        BackgroundColor = Color.WhiteSmoke,
        //        HeightRequest = 40,
        //        Watermark = "Country",
        //        WatermarkColor = Color.FromHex(Colores.JobMeGray),

        //    };


        //    var LeadingViewCountry = new Label()
        //    {
        //        Text = "\uf57d",
        //        FontFamily = fuente,
        //        FontSize = 24,
        //        FontAttributes = atributo,
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //        VerticalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(10, 0, 0, 0)
        //    };
        //    comboCountry.ItemPadding = 5;
        //    comboCountry.ShowBorder = false;


        //    comboCountry.DataSource = listCountries;
        //    comboCountry.DisplayMemberPath = "Country";

        //    comboCountry.SetBinding(SfComboBox.DataSourceProperty, "listCountries");

        //    //comboCountry.SelectionChanged += comboCountry_SelectionChanged;
        //    comboCountry.SetBinding(SfComboBox.SelectedItemProperty, "Country", BindingMode.TwoWay);
        //    comboCountry.BindingContext = this;

        //    gridCountry.Children.Add(LeadingViewCountry, 0, 0);
        //    gridCountry.Children.Add(comboCountry, 1, 0);

        //    ////City

        //    var gridCity = new Grid();
        //    gridCity.Margin = new Thickness(4, 0, 0, 10);

        //    gridCity.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

        //    gridCity.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
        //    gridCity.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

        //    var comboCity = new SfComboBox()
        //    {
        //        BackgroundColor = Color.WhiteSmoke,
        //        HeightRequest = 40,
        //        Watermark = "City",
        //        WatermarkColor = Color.FromHex(Colores.JobMeGray),

        //    };


        //    var LeadingViewCity = new Label()
        //    {
        //        Text = "\uf64f",
        //        FontFamily = fuente,
        //        FontSize = 24,
        //        FontAttributes = atributo,
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //        VerticalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(10, 0, 0, 0)
        //    };
        //    comboCity.ItemPadding = 5;
        //    comboCity.ShowBorder = false;
        //    //comboCity.DataSource = listCities;
        //    comboCity.DisplayMemberPath = "City";

        //    comboCity.SetBinding(SfComboBox.DataSourceProperty, "listCities");

        //    //comboCity.SelectionChanged += comboCity_SelectionChanged;
        //    comboCity.SetBinding(SfComboBox.SelectedItemProperty, "City", BindingMode.TwoWay);
        //    comboCity.SetBinding(SfComboBox.IsEnabledProperty, "IsCityEnabled", BindingMode.TwoWay);

        //    comboCity.BindingContext = this;


        //    gridCity.Children.Add(LeadingViewCity, 0, 0);
        //    gridCity.Children.Add(comboCity, 1, 0);


        //    //Degree
        //    var gridDegree = new Grid();
        //    gridDegree.Margin = new Thickness(4, 0, 0, 10);

        //    gridDegree.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

        //    gridDegree.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
        //    gridDegree.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

        //    var comboDegree = new SfComboBox()
        //    {
        //        //BackgroundColor = Color.WhiteSmoke,
        //        //HeightRequest = 40,
        //        Watermark = "Degree",
        //        WatermarkColor = Color.FromHex(Colores.JobMeGray),

        //        //BackgroundColor = Color.WhiteSmoke,
        //        //Watermark = "School",
        //        //WatermarkColor = Color.FromHex(Colores.JobMeGray),
        //        //BackgroundColor=Color.FromHex("#FFFFFF"),
        //        MultiSelectMode = MultiSelectMode.Token,
        //        TokensWrapMode = TokensWrapMode.Wrap,
        //        HeightRequest = 60,
        //        //WidthRequest = 100,
        //        IsSelectedItemsVisibleInDropDown = false,
        //        BorderColor = Color.FromHex(Colores.JobMeOrange),
        //        TokenSettings = token,
        //        ShowBorder = false,
        //        ShowClearButton = false,


        //    };


        //    var LeadingViewDegree = new Label()
        //    {
        //        Text = "\uf091",
        //        FontFamily = fuente,
        //        FontSize = 24,
        //        FontAttributes = atributo,
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //        VerticalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(10, 0, 0, 0)
        //    };
        //    comboDegree.ItemPadding = 5;
        //    comboDegree.ShowBorder = false;

        //    // Create Border control
        //    SfBorder border2 = new SfBorder();
        //    border2.CornerRadius = 10;
        //    border2.VerticalOptions = LayoutOptions.FillAndExpand;
        //    border2.HorizontalOptions = LayoutOptions.FillAndExpand;
        //    border2.BorderColor = Color.FromHex(Colores.JobMeOrange);

        //    border2.Content = comboDegree;

        //    comboDegree.DataSource = listDegrees;
        //    comboDegree.DisplayMemberPath = "Degree";

        //    comboDegree.SetBinding(SfComboBox.DataSourceProperty, "listDegrees");
        //    comboDegree.SetBinding(SfComboBox.SelectedItemProperty, "Degree", BindingMode.TwoWay);
        //    comboDegree.BindingContext = this;

        //    // comboDegree.SelectionChanged += comboDegree_SelectionChanged;

        //    gridDegree.Children.Add(LeadingViewDegree, 0, 0);
        //    gridDegree.Children.Add(border2, 1, 0);


        //    //School                             
        //    ///
        //    var gridSchool = new Grid();
        //    gridSchool.Margin = new Thickness(4, 0, 0, 10);

        //    gridSchool.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

        //    gridSchool.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
        //    gridSchool.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

        //    var comboSchool = new SfComboBox()
        //    {
        //        //BackgroundColor = Color.WhiteSmoke,
        //        Watermark = "School",
        //        //WatermarkColor = Color.FromHex(Colores.JobMeGray),
        //        //BackgroundColor=Color.FromHex("#FFFFFF"),
        //        MultiSelectMode = MultiSelectMode.Token,
        //        TokensWrapMode = TokensWrapMode.Wrap,
        //        HeightRequest = 60,
        //        //WidthRequest = 100,
        //        IsSelectedItemsVisibleInDropDown = false,
        //        BorderColor = Color.FromHex(Colores.JobMeOrange),
        //        TokenSettings = token,
        //        ShowBorder = false,
        //        ShowClearButton = false,
        //    };


        //    var LeadingViewSchool = new Label()
        //    {
        //        Text = "\uf549",
        //        FontFamily = fuente,
        //        FontSize = 24,
        //        FontAttributes = atributo,
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //        VerticalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(10, 0, 0, 0)
        //    };
        //    comboSchool.ItemPadding = 5;
        //    comboSchool.ShowBorder = false;
        //    comboSchool.DataSource = listSchools;
        //    comboSchool.DisplayMemberPath = "School";

        //    comboSchool.SetBinding(SfComboBox.DataSourceProperty, "listSchools");
        //    comboSchool.SetBinding(SfComboBox.SelectedItemProperty, "School", BindingMode.TwoWay);
        //    comboSchool.BindingContext = this;

        //    // Create Border control
        //    SfBorder border = new SfBorder();
        //    border.CornerRadius = 10;
        //    border.VerticalOptions = LayoutOptions.FillAndExpand;
        //    border.HorizontalOptions = LayoutOptions.FillAndExpand;
        //    border.BorderColor = Color.FromHex(Colores.JobMeOrange);

        //    border.Content = comboSchool;
        //    //comboSchool.SelectionChanged += comboSchool_SelectionChanged;

        //    gridSchool.Children.Add(LeadingViewSchool, 0, 0);
        //    gridSchool.Children.Add(border, 1, 0);

        //    ////Gender              
        //    var gridGender = new Grid();
        //    gridGender.Margin = new Thickness(4, 0, 0, 10);

        //    gridGender.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

        //    gridGender.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
        //    gridGender.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

        //    var combobox = new SfComboBox()
        //    {
        //        BackgroundColor = Color.WhiteSmoke,
        //        HeightRequest = 40,
        //        Watermark = "Gender",
        //        WatermarkColor = Color.FromHex(Colores.JobMeGray)

        //    };


        //    var LeadingViewGender = new Label()
        //    {
        //        Text = "\uf228",
        //        FontFamily = fuente,
        //        FontSize = 24,
        //        FontAttributes = atributo,
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //        VerticalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(10, 0, 0, 0)
        //    };
        //    combobox.ItemPadding = 5;
        //    combobox.ShowBorder = false;

        //    listGenders = new ObservableCollection<Generos>();
        //    listGenders.Add(new Generos() { IDGender = 0, Gender = "Prefer not to say" });
        //    listGenders.Add(new Generos() { IDGender = 1, Gender = "Female" });
        //    listGenders.Add(new Generos() { IDGender = 2, Gender = "Male" });



        //    combobox.DataSource = listGenders;
        //    combobox.DisplayMemberPath = "Gender";
        //    combobox.SetBinding(SfComboBox.SelectedItemProperty, "Gender", BindingMode.TwoWay);

        //    combobox.BindingContext = this;

        //    // combobox.SelectionChanged += comboGender_SelectionChanged;

        //    gridGender.Children.Add(LeadingViewGender, 0, 0);
        //    gridGender.Children.Add(combobox, 1, 0);


        //    //Año de nacimiento

        //    var gridGraduation = new Grid();
        //    gridGraduation.Margin = new Thickness(4, 0, 0, 10);

        //    gridGraduation.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

        //    gridGraduation.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
        //    gridGraduation.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

        //    var comboGraduation = new SfComboBox()
        //    {
        //        // BackgroundColor = Color.WhiteSmoke,
        //        // HeightRequest = 40,
        //        Watermark = "Graduation year",
        //        // WatermarkColor = Color.FromHex(Colores.JobMeGray)

        //        //BackgroundColor = Color.WhiteSmoke,
        //        //Watermark = "School",
        //        //WatermarkColor = Color.FromHex(Colores.JobMeGray),
        //        //BackgroundColor=Color.FromHex("#FFFFFF"),
        //        MultiSelectMode = MultiSelectMode.Token,
        //        TokensWrapMode = TokensWrapMode.Wrap,
        //        HeightRequest = 60,
        //        //WidthRequest = 100,
        //        IsSelectedItemsVisibleInDropDown = false,
        //        BorderColor = Color.FromHex(Colores.JobMeOrange),
        //        TokenSettings = token,
        //        ShowBorder = false,
        //        ShowClearButton = false,

        //    };


        //    var LeadingViewGraduation = new Label()
        //    {
        //        Text = "\uf501",
        //        FontFamily = fuente,
        //        FontSize = 24,
        //        FontAttributes = atributo,
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //        VerticalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(10, 0, 0, 0)
        //    };
        //    comboGraduation.ItemPadding = 5;
        //    comboGraduation.ShowBorder = false;

        //    comboGraduation.DataSource = ListAñosGraduacion;
        //    comboGraduation.DisplayMemberPath = "Year";

        //    // Create Border control
        //    SfBorder border3 = new SfBorder();
        //    border3.CornerRadius = 10;
        //    border3.VerticalOptions = LayoutOptions.FillAndExpand;
        //    border3.HorizontalOptions = LayoutOptions.FillAndExpand;
        //    border3.BorderColor = Color.FromHex(Colores.JobMeOrange);

        //    border3.Content = comboGraduation;
        //    // comboGraduation.SelectionChanged += comboGraduation_SelectionChanged;

        //    comboGraduation.SetBinding(SfComboBox.DataSourceProperty, "ListAñosGraduacion");
        //    comboGraduation.SetBinding(SfComboBox.SelectedItemProperty, "GraduationYear", BindingMode.TwoWay);
        //    comboGraduation.BindingContext = this;

        //    gridGraduation.Children.Add(LeadingViewGraduation, 0, 0);
        //    gridGraduation.Children.Add(border3, 1, 0);

        //    //Certifications
        //    var gridCertifications = new Grid();
        //    gridCertifications.Margin = new Thickness(4, 0, 0, 10);

        //    gridCertifications.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

        //    gridCertifications.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
        //    gridCertifications.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });

        //    var comboCertifications = new SfComboBox()
        //    {
        //        //BackgroundColor = Color.WhiteSmoke,
        //        WatermarkColor = Color.FromHex(Colores.JobMeGray),
        //        Watermark = "Certifications",
        //        //BackgroundColor=Color.FromHex("#FFFFFF"),
        //        MultiSelectMode = MultiSelectMode.Token,
        //        TokensWrapMode = TokensWrapMode.Wrap,
        //        HeightRequest = 60,
        //        IsSelectedItemsVisibleInDropDown = false,
        //        BorderColor = Color.FromHex(Colores.JobMeOrange),
        //        TokenSettings = token,
        //        ShowBorder = false,
        //        ShowClearButton = false,

        //    };



        //    var LeadingViewCertifications = new Label()
        //    {
        //        Text = "\uf091",
        //        FontFamily = fuente,
        //        FontSize = 24,
        //        FontAttributes = atributo,
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //        VerticalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(10, 0, 0, 0)
        //    };
        //    comboCertifications.ItemPadding = 5;
        //    comboCertifications.ShowBorder = false;

        //    // Create Border control
        //    SfBorder border1 = new SfBorder();
        //    border1.CornerRadius = 10;
        //    border1.VerticalOptions = LayoutOptions.FillAndExpand;
        //    border1.HorizontalOptions = LayoutOptions.FillAndExpand;
        //    border1.BorderColor = Color.FromHex(Colores.JobMeOrange);

        //    border1.Content = comboCertifications;

        //    comboCertifications.DataSource = listCertifications;
        //    comboCertifications.DisplayMemberPath = "Certification";

        //    comboCertifications.SetBinding(SfComboBox.DataSourceProperty, "listCertifications");
        //    comboCertifications.SetBinding(SfComboBox.SelectedItemProperty, "Certifications", BindingMode.TwoWay);

        //    comboCertifications.BindingContext = this;
        //    // comboCertifications.SelectionChanged += comboCertifications_SelectionChanged;

        //    gridCertifications.Children.Add(LeadingViewCertifications, 0, 0);
        //    gridCertifications.Children.Add(border1, 1, 0);

        //    //Languaje
        //    var gridLanguaje = new Grid();
        //    gridLanguaje.Margin = new Thickness(4, 0, 0, 10);

        //    gridLanguaje.RowDefinitions.Add(new RowDefinition { Height = new GridLength(.6, GridUnitType.Star) });

        //    gridLanguaje.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
        //    gridLanguaje.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });



        //    var comboLanguaje = new SfComboBox()
        //    {
        //        BackgroundColor = Color.White,
        //        Watermark = "Languaje",
        //        MultiSelectMode = MultiSelectMode.Token,
        //        TokensWrapMode = TokensWrapMode.Wrap,
        //        HeightRequest = 60,
        //        WatermarkColor = Color.FromHex(Colores.JobMeGray),
        //        IsSelectedItemsVisibleInDropDown = false,
        //        BorderColor = Color.FromHex(Colores.JobMeOrange),
        //        TokenSettings = token,
        //        ShowBorder = false,
        //        ShowClearButton = false,
        //    };

        //    // Create Border control
        //    SfBorder borderLanguaje = new SfBorder();
        //    borderLanguaje.CornerRadius = 10;
        //    borderLanguaje.VerticalOptions = LayoutOptions.FillAndExpand;
        //    borderLanguaje.HorizontalOptions = LayoutOptions.FillAndExpand;
        //    borderLanguaje.BorderColor = Color.FromHex(Colores.JobMeOrange);

        //    borderLanguaje.Content = comboLanguaje;

        //    var LeadingViewLanguaje = new Label()
        //    {
        //        Text = "\uf0ac",
        //        FontFamily = fuente,
        //        FontSize = 24,
        //        FontAttributes = atributo,
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //        VerticalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(10, 0, 0, 0)
        //    };
        //    comboLanguaje.ItemPadding = 5;
        //    comboLanguaje.ShowBorder = false;

        //    comboLanguaje.DataSource = listLanguajes;
        //    comboLanguaje.DisplayMemberPath = "Languaje";

        //    comboLanguaje.SetBinding(SfComboBox.DataSourceProperty, "listLanguajes");
        //    comboLanguaje.SetBinding(SfComboBox.SelectedItemProperty, "Languajes", BindingMode.TwoWay);
        //    comboLanguaje.BindingContext = this;

        //    gridLanguaje.Children.Add(LeadingViewLanguaje, 0, 0);
        //    gridLanguaje.Children.Add(borderLanguaje, 1, 0);


        //    //Salary         
        //    var gridSalary = new Grid();

        //    gridSalary.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.12, GridUnitType.Star) });
        //    gridSalary.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.88, GridUnitType.Star) });


        //    var combobox1 = new SfComboBox
        //    {

        //        BackgroundColor = Color.WhiteSmoke,
        //        HeightRequest = 40,
        //        Watermark = "Salary",
        //        WatermarkColor = Color.FromHex(Colores.JobMeGray)

        //    };
        //    var inputSalary = new Editor()
        //    {
        //        Text = "\uf0ac",
        //        FontFamily = fuente,
        //        FontSize = 24,
        //        FontAttributes = atributo,
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //        VerticalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(10, 0, 0, 0),
        //        AutoSize = EditorAutoSizeOption.TextChanges

        //    };

        //    combobox1.ShowBorder = false;

        //    //combobox1.DataSource = listSalaries;
        //    //combobox1.SelectionChanged += comboSalary_SelectionChanged;
        //    combobox1.DisplayMemberPath = "Salary";
        //    combobox1.SetBinding(SfComboBox.DataSourceProperty, "listSalaries");
        //    combobox1.SetBinding(SfComboBox.SelectedItemProperty, "Salary", BindingMode.TwoWay);
        //    combobox1.BindingContext = this;

        //    //  combobox1.SelectionChanged += comboSalary_SelectionChanged;

        //    //combobox1.BindingContext = this;

        //    gridSalary.Children.Add(inputSalary, 0, 0);
        //    gridSalary.Children.Add(combobox1, 1, 0);

        //    // inputSalary.InputView = combobox1;


        //    //Description

        //    var entryPosDesc = new Editor();
        //    entryPosDesc.AutoSize = EditorAutoSizeOption.TextChanges;
        //    entryPosDesc.SetBinding(Editor.TextProperty, "JobDescription");
        //    //entryPosDesc.Behaviors.Add(new EntryLengthValidator() { MinLength = 5, MaxLength = 100 });
        //    entryPosDesc.BindingContext = this;

        //    var inputDescription = new SfTextInputLayout
        //    {
        //        Hint = "Brief description about the job",
        //        //InputViewPadding = 5,
        //        ErrorText = "Enter a valid job description",
        //        LeadingViewPosition = ViewPosition.Outside,
        //        LeadingView = new Label()
        //        {
        //            Text = "\uf0c0",
        //            FontFamily = fuente,
        //            FontSize = 24,
        //            FontAttributes = atributo,
        //            TextColor = Color.FromHex(Colores.JobMeGray),
        //            VerticalOptions = LayoutOptions.Center
        //        },
        //        ContainerType = ContainerType.Filled,
        //        //inputName.HelperText = "Enter your name";
        //        CharMaxLength = 50,
        //        //inputName.ShowCharCount = true;
        //        HintLabelStyle = new LabelStyle() { FontSize = 16 },
        //        InputView = entryPosDesc
        //    };

        //    sl1.Orientation = StackOrientation.Vertical;

        //    //sl1.Children.Add(inputNM);
        //    sl1.Children.Add(inputes);

        //    sl1.Children.Add(inputName);
        //    sl1.Children.Add(gridDegree);
        //    sl1.Children.Add(gridSchool);
        //    sl1.Children.Add(gridGender);
        //    sl1.Children.Add(gridCountry);
        //    sl1.Children.Add(gridCity);
        //    sl1.Children.Add(gridGraduation);
        //    sl1.Children.Add(gridCertifications);
        //    sl1.Children.Add(gridLanguaje);
        //    sl1.Children.Add(gridSalary);
        //    sl1.Children.Add(inputDescription);

        //    ScrollView scv = new ScrollView()
        //    {
        //        Orientation = ScrollOrientation.Vertical,
        //        //VerticalOptions = LayoutOptions.FillAndExpand
        //    };
        //    scv.Content = sl1;

        //    return scv;

        //}

        //private View Details()
        //{

        //    StackLayout sl1 = new StackLayout();
        //    sl1.Margin = new Thickness(10, 0, 10, 0);


        //    var inputes = new Label
        //    {
        //        Text = "       Interest       ",
        //        HorizontalOptions = LayoutOptions.Center,
        //        FontSize = 18,
        //        // inputes.FontAttributes = FontAttributes.Bold;
        //        VerticalOptions = LayoutOptions.Center,
        //        TextColor = Color.White,
        //        BackgroundColor = Color.FromHex(Colores.JobMeOrange),
        //        Margin = new Thickness(0, 0, 0, 20)
        //    };


        //    string fuente = string.Empty;
        //    FontAttributes atributos = FontAttributes.None;

        //    //Fuente Iconos
        //    switch (Device.RuntimePlatform)
        //    {
        //        case Device.iOS:
        //            fuente = "Font Awesome 5 Free";
        //            atributos = FontAttributes.Bold;
        //            break;
        //        case Device.Android:
        //            fuente = "FontSolid-900.otf#Font Awesome 5 Free Solid";
        //            break;
        //    };

        //    //Business Field         
        //    var gridBusiness = new Grid();

        //    gridBusiness.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
        //    gridBusiness.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });


        //    // Token Customization
        //    TokenSettings token = new TokenSettings();
        //    token.FontSize = 10;
        //    token.DeleteButtonColor = Color.FromHex(Colores.JobMeOrange);
        //    token.IsCloseButtonVisible = true;
        //    token.CornerRadius = 15;
        //    token.DeleteButtonPlacement = DeleteButtonPlacement.Left;

        //    var combobox = new SfComboBox
        //    {
        //        Watermark = "Business Fields",
        //        //BackgroundColor=Color.FromHex("#FFFFFF"),
        //        MultiSelectMode = MultiSelectMode.Token,
        //        TokensWrapMode = TokensWrapMode.Wrap,
        //        HeightRequest = 60,
        //        //WidthRequest = 100,
        //        IsSelectedItemsVisibleInDropDown = false,
        //        BorderColor = Color.FromHex(Colores.JobMeOrange),
        //        TokenSettings = token
        //    };
        //    var inputBusinessField = new SfTextInputLayout
        //    {
        //        // Hint = "Gender",
        //        // InputViewPadding = 15,

        //        ContainerType = ContainerType.Outlined,
        //        ContainerBackgroundColor = Color.FromHex("#FFFFFF"),
        //        LeadingViewPosition = ViewPosition.Outside,
        //        InputViewPadding = new Thickness(0, 0, 0, 0),
        //        UnfocusedColor = Color.FromHex(Colores.JobMeOrange),

        //    };


        //    combobox.DisplayMemberPath = "BusinessField";
        //    combobox.SetBinding(SfComboBox.DataSourceProperty, "listbssfields");
        //    combobox.SetBinding(SfComboBox.SelectedItemProperty, "MyBSFields", BindingMode.TwoWay);
        //    combobox.BindingContext = this;

        //    combobox.HeightRequest = 90;
        //    inputBusinessField.InputView = combobox;

        //    var lbbusiness = new Label
        //    {
        //        VerticalOptions = LayoutOptions.Center,
        //        Text = "Business field"
        //    };

        //    gridBusiness.Children.Add(lbbusiness, 0, 0);
        //    gridBusiness.Children.Add(inputBusinessField, 1, 0);

        //    //  combobox.SelectionChanged += comboBussiness_SelectionChanged;


        //    //Area
        //    var gridArea = new Grid();

        //    gridArea.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
        //    gridArea.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });

        //    var comboArea = new SfComboBox
        //    {
        //        Watermark = "Areas",
        //        //BackgroundColor=Color.FromHex("#FFFFFF"),
        //        MultiSelectMode = MultiSelectMode.Token,
        //        TokensWrapMode = TokensWrapMode.Wrap,
        //        HeightRequest = 60,
        //        //WidthRequest = 100,
        //        //IsSelectedItemsVisibleInDropDown = true,
        //        BorderColor = Color.FromHex(Colores.JobMeOrange),
        //        TokenSettings = token
        //    };
        //    var inputArea = new SfTextInputLayout
        //    {
        //        // Hint = "Gender",
        //        // InputViewPadding = 15,

        //        ContainerType = ContainerType.Outlined,
        //        ContainerBackgroundColor = Color.FromHex("#FFFFFF"),
        //        LeadingViewPosition = ViewPosition.Outside,
        //        InputViewPadding = new Thickness(0, 0, 0, 0),
        //        UnfocusedColor = Color.FromHex(Colores.JobMeOrange),
        //        //LeadingView = new Label()
        //        //{
        //        //    WidthRequest = 180,
        //        //    Text = "Area",
        //        //    // FontFamily = fuente,
        //        //    FontSize = 18,
        //        //    TextColor = Color.FromHex(Colores.JobMeGray),
        //        //    VerticalOptions = LayoutOptions.Center
        //        //},
        //    };

        //    //comboArea.DataSource = listAreas;
        //    comboArea.DisplayMemberPath = "Area";
        //    comboArea.SetBinding(SfComboBox.DataSourceProperty, "listAreas");
        //    comboArea.SetBinding(SfComboBox.SelectedItemProperty, "MisAreas", BindingMode.TwoWay);
        //    comboArea.BindingContext = this;
        //    comboArea.HeightRequest = 90;
        //    inputArea.InputView = comboArea;

        //    var lbarea = new Label
        //    {
        //        VerticalOptions = LayoutOptions.Center,
        //        Text = "Area"
        //    };

        //    gridArea.Children.Add(lbarea, 0, 0);
        //    gridArea.Children.Add(inputArea, 1, 0);

        //    //comboArea.SelectionChanged += comboArea_SelectionChanged;

        //    //Experience
        //    var gridExperience = new Grid();

        //    gridExperience.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
        //    gridExperience.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });

        //    var comboExperience = new SfComboBox
        //    {
        //        Watermark = "Experience",
        //        MultiSelectMode = MultiSelectMode.Token,
        //        TokensWrapMode = TokensWrapMode.Wrap,
        //        HeightRequest = 60,
        //        //WidthRequest = 100,
        //        //IsSelectedItemsVisibleInDropDown = false,
        //        BorderColor = Color.FromHex(Colores.JobMeOrange),
        //        TokenSettings = token
        //    };
        //    var inputExperience = new SfTextInputLayout
        //    {

        //        ContainerType = ContainerType.Outlined,
        //        ContainerBackgroundColor = Color.FromHex("#FFFFFF"),
        //        LeadingViewPosition = ViewPosition.Outside,
        //        InputViewPadding = new Thickness(0, 0, 0, 0),
        //        UnfocusedColor = Color.FromHex(Colores.JobMeOrange),

        //    };

        //    //comboExperience.DataSource = listExperience;
        //    comboExperience.DisplayMemberPath = "Experience";
        //    comboExperience.SetBinding(SfComboBox.DataSourceProperty, "listExperience");
        //    comboExperience.SetBinding(SfComboBox.SelectedItemProperty, "MyExperience", BindingMode.TwoWay);
        //    comboExperience.BindingContext = this;

        //    comboExperience.HeightRequest = 90;
        //    inputExperience.InputView = comboExperience;

        //    var lbbusiness1 = new Label
        //    {
        //        VerticalOptions = LayoutOptions.Center,
        //        Text = "Experience"
        //    };

        //    gridExperience.Children.Add(lbbusiness1, 0, 0);
        //    gridExperience.Children.Add(inputExperience, 1, 0);

        //    //comboExperience.SelectionChanged += comboExperience_SelectionChanged;

        //    //Type of job
        //    var gridJob = new Grid();

        //    gridJob.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
        //    gridJob.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });

        //    SfSegmentedControl segmentedControlType = new SfSegmentedControl();
        //    List<String> typesjob = new List<String>
        //    {
        //        "Part Time","Full Time"
        //    };

        //    segmentedControlType.ItemsSource = typesjob;
        //    segmentedControlType.DisplayMode = SegmentDisplayMode.Text;
        //    segmentedControlType.Color = Color.FromHex("#FFFFFF");
        //    segmentedControlType.SegmentHeight = 40;
        //    segmentedControlType.VisibleSegmentsCount = 3;
        //    segmentedControlType.CornerRadius = 5;
        //    segmentedControlType.HeightRequest = 20;
        //    segmentedControlType.SelectedIndex = 1;
        //    segmentedControlType.BorderColor = Color.FromHex(Colores.JobMeOrange);
        //    segmentedControlType.FontColor = Color.FromHex(Colores.JobMeGray);
        //    segmentedControlType.FontSize = 18;
        //    segmentedControlType.VerticalOptions = LayoutOptions.Center;
        //    segmentedControlType.HorizontalOptions = LayoutOptions.End;
        //    segmentedControlType.SelectionTextColor = Color.FromHex("#FFFFFF");
        //    segmentedControlType.Margin = new Thickness(0, 10, 0, 10);
        //    SelectionIndicatorSettings selectionIndicator1 = new SelectionIndicatorSettings();
        //    selectionIndicator1.Color = Color.FromHex(Colores.JobMeGray);
        //    segmentedControlType.SelectionIndicatorSettings = selectionIndicator1;

        //    var lbJob = new Label
        //    {
        //        VerticalOptions = LayoutOptions.Center,
        //        Text = "Type of job",
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //    };
        //    segmentedControlType.SetBinding(SfSegmentedControl.SelectedIndexProperty, "TypeofJob");
        //    segmentedControlType.BindingContext = this;

        //    gridJob.Children.Add(lbJob, 0, 0);
        //    gridJob.Children.Add(segmentedControlType, 1, 0);

        //    //     segmentedControlType.SelectionChanged += (sender, e) =>
        //    //{

        //    //    if (e.Index == 1)
        //    //    {

        //    //        // pos.IDTypeofJob = 1;
        //    //    }
        //    //    else
        //    //    {
        //    //        //   pos.IDTypeofJob = 2;

        //    //    }


        //    //};

        //    //Residence
        //    var gridResidence = new Grid();

        //    gridResidence.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
        //    gridResidence.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });
        //    SfSegmentedControl segmentedControlResidence = new SfSegmentedControl();
        //    List<String> periodsList = new List<String>
        //    {
        //        "No","Yes"
        //    };
        //    segmentedControlResidence.ItemsSource = periodsList;
        //    segmentedControlResidence.DisplayMode = SegmentDisplayMode.Text;
        //    segmentedControlResidence.Color = Color.FromHex("#FFFFFF");
        //    segmentedControlResidence.SegmentHeight = 40;
        //    segmentedControlResidence.VisibleSegmentsCount = 3;
        //    segmentedControlResidence.CornerRadius = 5;
        //    segmentedControlResidence.HeightRequest = 20;
        //    segmentedControlResidence.SelectedIndex = 1;
        //    segmentedControlResidence.BorderColor = Color.FromHex(Colores.JobMeOrange); ;
        //    segmentedControlResidence.FontColor = Color.FromHex(Colores.JobMeGray); ;
        //    segmentedControlResidence.FontSize = 18;
        //    segmentedControlResidence.VerticalOptions = LayoutOptions.Center;
        //    segmentedControlResidence.HorizontalOptions = LayoutOptions.End;
        //    segmentedControlResidence.Margin = new Thickness(0, 10, 0, 10);
        //    segmentedControlResidence.SelectionTextColor = Color.FromHex("#FFFFFF");
        //    SelectionIndicatorSettings selectionIndicator = new SelectionIndicatorSettings();
        //    selectionIndicator.Color = Color.FromHex(Colores.JobMeGray);
        //    segmentedControlResidence.SelectionIndicatorSettings = selectionIndicator;

        //    //  segmentedControlResidence.SelectionChanged += (sender, e) =>
        //    //{

        //    //    if (e.Index == 1)
        //    //    {

        //    //        //  pos.ChangeResidence = true;
        //    //    }


        //    //};
        //    var lbResidence = new Label
        //    {

        //        VerticalOptions = LayoutOptions.Center,
        //        Text = "Change of residence",
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //    };

        //    segmentedControlResidence.SetBinding(SfSegmentedControl.SelectedIndexProperty, "ChangeResidence");
        //    segmentedControlResidence.BindingContext = this;

        //    gridResidence.Children.Add(lbResidence, 0, 0);
        //    gridResidence.Children.Add(segmentedControlResidence, 1, 0);

        //    //Travel
        //    var gridTravel = new Grid();

        //    gridTravel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) });
        //    gridTravel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.7, GridUnitType.Star) });
        //    SfSegmentedControl segmentedControlTravel = new SfSegmentedControl();
        //    List<String> travelList = new List<String>
        //    {
        //        "No","Yes"
        //    };
        //    segmentedControlTravel.HorizontalOptions = LayoutOptions.FillAndExpand;
        //    segmentedControlTravel.DisabledTextColor = Color.FromHex("Red");
        //    segmentedControlTravel.ItemsSource = travelList;
        //    segmentedControlTravel.DisplayMode = SegmentDisplayMode.Text;
        //    segmentedControlTravel.Color = Color.FromHex("#FFFFFF");
        //    segmentedControlTravel.SegmentHeight = 40;
        //    segmentedControlTravel.VisibleSegmentsCount = 3;
        //    segmentedControlTravel.CornerRadius = 5;
        //    segmentedControlTravel.HeightRequest = 20;
        //    segmentedControlTravel.SelectedIndex = 1;
        //    segmentedControlTravel.BorderColor = Color.FromHex(Colores.JobMeOrange);
        //    segmentedControlTravel.FontColor = Color.FromHex(Colores.JobMeGray); ;
        //    segmentedControlTravel.FontSize = 18;
        //    segmentedControlTravel.VerticalOptions = LayoutOptions.Center;
        //    segmentedControlTravel.HorizontalOptions = LayoutOptions.End;
        //    segmentedControlTravel.SelectionTextColor = Color.FromHex("#FFFFFF");
        //    segmentedControlTravel.Margin = new Thickness(0, 10, 0, 10);
        //    SelectionIndicatorSettings selectionIndicator2 = new SelectionIndicatorSettings();
        //    selectionIndicator2.Color = Color.FromHex(Colores.JobMeGray);
        //    segmentedControlTravel.SelectionIndicatorSettings = selectionIndicator2;

        //    var lbTravel = new Label
        //    {

        //        VerticalOptions = LayoutOptions.Center,
        //        Text = "Availability to travel",
        //        TextColor = Color.FromHex(Colores.JobMeGray),
        //    };

        //    segmentedControlTravel.SetBinding(SfSegmentedControl.SelectedIndexProperty, "TravelAvailable");
        //    segmentedControlTravel.BindingContext = this;

        //    gridTravel.Children.Add(lbTravel, 0, 0);
        //    gridTravel.Children.Add(segmentedControlTravel, 1, 0);

        //    //Palomita
        //    var lbPalomita = new SfButton()
        //    {
        //        Text = "\uf00c",
        //        FontFamily = fuente,
        //        FontSize = 30,
        //        WidthRequest = 60,
        //        HeightRequest = 60,
        //        FontAttributes = atributos,
        //        TextColor = Color.FromHex(Colores.JobMeOrange),
        //        VerticalOptions = LayoutOptions.Center,
        //        HorizontalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(0, 10, 0, 0),
        //        CornerRadius = 30,
        //        BackgroundColor = Color.WhiteSmoke

        //    };

        //    lbPalomita.SetBinding(SfButton.IsVisibleProperty, "BtnSaveVisible");
        //    lbPalomita.BindingContext = this;
        //    lbPalomita.Clicked += async (sender, args) => await AddPosition();



        //    //Palomita
        //    var btnUpdate = new SfButton()
        //    {
        //        Text = "Update",
        //        WidthRequest = 100,
        //        TextColor = Color.White,
        //        VerticalOptions = LayoutOptions.Center,
        //        HorizontalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(0, 10, 0, 0),
        //        CornerRadius = 30,
        //        BackgroundColor = Color.FromHex(Colores.JobMeOrange),
        //        FontAttributes = atributos

        //    };

        //    btnUpdate.SetBinding(SfButton.IsVisibleProperty, "BtnUpdateVisible");
        //    btnUpdate.BindingContext = this;
        //    btnUpdate.Clicked += async (sender, args) => await AddPosition();


        //    sl1.Orientation = StackOrientation.Vertical;

        //    sl1.Children.Add(inputes);

        //    sl1.Children.Add(gridBusiness);
        //    sl1.Children.Add(gridArea);
        //    sl1.Children.Add(gridExperience);
        //    sl1.Children.Add(gridJob);
        //    //  sl1.Children.Add(espera);
        //    sl1.Children.Add(gridResidence);
        //    sl1.Children.Add(gridTravel);
        //    sl1.Children.Add(lbPalomita);
        //    sl1.Children.Add(btnUpdate);

        //    ScrollView scv = new ScrollView()
        //    {
        //        Orientation = ScrollOrientation.Vertical,
        //        VerticalOptions = LayoutOptions.FillAndExpand
        //    };
        //    scv.Content = sl1;

        //    return scv;



        //}

        int flag = 0;
        private bool _isLocked;
        //private async Task AddPosition()
        //{
        //    if (_isLocked) return;
        //    _isLocked = true;

        //    try
        //    {
        //        Positions pos;

        //        //if (flag == 0)
        //        //{

        //        //    flag = 1;

        //        int resp = 0;
        //        if (Valida())
        //        {
        //            if (IsEdit)
        //            {


        //                UserDialogs.Instance.ShowLoading("Updating position");
        //                pos = new Positions()
        //                {

        //                    Name = Name,
        //                    IDCity = City.IDCity,
        //                    School = School,
        //                    Degree = Degree,
        //                    IDGender = Gender.IDGender,
        //                    IDCompany = (int)Preferences.Get("idCompany", 0),
        //                    IDSalary = Salary.IDSalary,
        //                    Description = JobDescription,
        //                    IDCountry = Country.IDCountry,
        //                    Languajes = Languajes,
        //                    Certifications = Certifications,
        //                    Experience = MyExperience,
        //                    MisAreas = MisAreas,
        //                    BSFields = MyBSFields,
        //                    GraduationYear = GraduationYear,
        //                    TypeofJob = (int)TypeofJob,
        //                    ChangeResidence = (bool)ChangeResidence,
        //                    TravelAvailable = (bool)TravelAvailable,
        //                    UserID = (int)Preferences.Get("UserID", 0),
        //                    IDPosition = IDPosition,

        //                };
        //                resp = await PositionService.UpdatePositionAsync(pos);



        //                // resp = await PositionService.AddPositionAsync(pos);

        //                if (resp > 0)
        //                {
        //                    await Task.Delay(2000);
        //                    UserDialogs.Instance.HideLoading();

        //                    await Application.Current.MainPage.DisplayAlert("JobMe", "Job updated correctly", "Ok");
        //                    //await Navigation.PopToRootAsync();
        //                     await Navigation.PopAsync();
                           
        //                }
        //                else
        //                {
        //                    flag = 0;
        //                    UserDialogs.Instance.HideLoading();
        //                    await Application.Current.MainPage.DisplayAlert("JobMe", "Can't save the position, please verify the info", "Ok");
        //                }

                       
        //            }
        //            else
        //            {

        //                if (Valida())
        //                {

        //                    UserDialogs.Instance.ShowLoading("Saving position");

        //                    pos = new Positions()
        //                    {

        //                        Name = Name,
        //                        IDCity = City != null ? City.IDCity : 0,
        //                        School = School,
        //                        Degree = Degree,
        //                        IDGender = Gender.IDGender,
        //                        IDCompany = (int)Preferences.Get("idCompany", 0),
        //                        IDSalary = Salary.IDSalary,
        //                        Description = JobDescription,
        //                        IDCountry = Country.IDCountry,
        //                        Languajes = Languajes,
        //                        Certifications = Certifications,
        //                        Experience = MyExperience,
        //                        MisAreas = MisAreas,
        //                        BSFields = MyBSFields,
        //                        GraduationYear = GraduationYear,
        //                        TypeofJob = (int)TypeofJob,  //1 es Full time   o es part time
        //                        ChangeResidence = (bool)ChangeResidence,  //0 es yes 1 es false
        //                        TravelAvailable = (bool)TravelAvailable, //0 es yes  1 es false
        //                        UserID = (int)Preferences.Get("UserID", 0),

        //                    };

        //                    resp = await PositionService.AddPositionAsync(pos);

        //                    if (resp > 0)
        //                    {
        //                        await Task.Delay(2000);
        //                        UserDialogs.Instance.HideLoading();
        //                        await Application.Current.MainPage.DisplayAlert("JobMe", "Job added correctly", "Ok");
        //                        MessagingCenter.Send(this, "UpdateList", 1);
        //                        await Navigation.PopAsync();

        //                        //Actualizar la pagina 
        //                        GetPositions();

        //                    }
        //                    else
        //                    {
        //                        flag = 0;
        //                        await Task.Delay(2000);
        //                        await Application.Current.MainPage.DisplayAlert("JobMe", "Can't save the position, please verify the info", "Ok");
        //                    }

        //                }

        //                // }

        //            }


                

                    
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        flag = 0;
        //        UserDialogs.Instance.HideLoading();
        //        _isLocked = false;
        //        await Application.Current.MainPage.DisplayAlert("JobMe", "Ocurrio un error al guardar el puesto", "Ok");
        //        //throw;
        //    }

        //    Task.Delay(600);
        //    _isLocked = false;
        //}

        ////private bool Valida()
        ////{


        ////    if (Name == null || Name == string.Empty)
        ////    {
        ////        Application.Current.MainPage.DisplayAlert("JobMe", "Position can't be empty", "Ok");
        ////        return false;
        ////    }

        ////    if (Country == null)
        ////    {
        ////        Application.Current.MainPage.DisplayAlert("JobMe", "Country can't be empty", "Ok");
        ////        return false;
        ////    }

        ////    if (City == null && Country.IDCountry == 117)
        ////    {
        ////        Application.Current.MainPage.DisplayAlert("JobMe", "City can't be empty", "Ok");
        ////        return false;
        ////    }


        ////    if (Degree == null)
        ////    {
        ////        Application.Current.MainPage.DisplayAlert("JobMe", "Degree can't be empty", "Ok");
        ////        return false;
        ////    }

        ////    if (School == null)
        ////    {
        ////        Application.Current.MainPage.DisplayAlert("JobMe", "School can't be empty", "Ok");
        ////        return false;
        ////    }
        ////    if (Gender == null)
        ////    {
        ////        Application.Current.MainPage.DisplayAlert("JobMe", "Gender can't be empty", "Ok");
        ////        return false;
        ////    }
        ////    if (Salary == null)
        ////    {
        ////        Application.Current.MainPage.DisplayAlert("JobMe", "Salary can't be empty", "Ok");
        ////        return false;
        ////    }
        ////    if (JobDescription == null || JobDescription == string.Empty)
        ////    {
        ////        Application.Current.MainPage.DisplayAlert("JobMe", "Description can't be empty", "Ok");
        ////        return false;
        ////    }
        ////    if (MyBSFields == null)
        ////    {
        ////        Application.Current.MainPage.DisplayAlert("JobMe", "Business Fields can't be empty", "Ok");
        ////        return false;
        ////    }
        ////    if (MisAreas == null)
        ////    {
        ////        Application.Current.MainPage.DisplayAlert("JobMe", "Areas of interest can't be empty", "Ok");
        ////        return false;
        ////    }
        ////    //if (MyExperience == null)
        ////    //{
        ////    //    Application.Current.MainPage.DisplayAlert("JobMe", "Experience can't be empty", "Ok");
        ////    //    return false;
        ////    //}
        ////    return true;

        ////}

        //#region "Items Seleccionados"

        //private ObservableCollection<Areas> _SelectedAreas;
        //public ObservableCollection<Areas> SelectedAreas
        //{
        //    get { return _SelectedAreas; }
        //    set
        //    {
        //        _SelectedAreas = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private Certificaciones _SelectedCertification;
        //public Certificaciones SelectedCertification
        //{
        //    get
        //    {
        //        return _SelectedCertification;
        //    }
        //    set
        //    {
        //        _SelectedCertification = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private Ciudades _selectedCity;
        //public Ciudades SelectedCity
        //{
        //    get { return _selectedCity; }
        //    set { _selectedCity = value; OnPropertyChanged(); }
        //}

        //private Titulos _SelectedDegree;
        //public Titulos SelectedDegree
        //{
        //    get
        //    {
        //        return _SelectedDegree;

        //    }
        //    set
        //    {
        //        _SelectedDegree = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private Escuelas _SelectedSchool;
        //public Escuelas SelectedSchool
        //{
        //    get
        //    {
        //        return _SelectedSchool;

        //    }
        //    set
        //    {
        //        _SelectedSchool = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private Generos _SelectedGender;
        //public Generos SelectedGender
        //{
        //    get { return _SelectedGender; }
        //    set { _SelectedGender = value; OnPropertyChanged(); }
        //}

        //private Paises _SelectedCountry;
        //public Paises SelectedCountry
        //{
        //    get { return _SelectedCountry; }
        //    set { _SelectedCountry = value; OnPropertyChanged(); }
        //}

        //private Idiomas _SelectedLanguaje;
        //public Idiomas SelectedLanguaje
        //{
        //    get { return _SelectedLanguaje; }
        //    set { _SelectedLanguaje = value; OnPropertyChanged(); }
        //}

        //private Salarios _SelectedSalary;
        //public Salarios SelectedSalary
        //{
        //    get { return _SelectedSalary; }
        //    set { _SelectedSalary = value; OnPropertyChanged(); }
        //}

        //private AñosGraduacion _SelectedGradYear;
        //public AñosGraduacion SelectedGradYear
        //{
        //    get
        //    {
        //        return _SelectedGradYear;

        //    }
        //    set
        //    {
        //        _SelectedGradYear = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private ObservableCollection<BSFields> _BSFieldsSelected;
        //public ObservableCollection<BSFields> BSFieldsSelected
        //{
        //    get
        //    {
        //        return _BSFieldsSelected;

        //    }
        //    set
        //    {
        //        _BSFieldsSelected = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private ObservableCollection<Areas> _AreasSelected;
        //public ObservableCollection<Areas> AreasSelected
        //{
        //    get
        //    {
        //        return _AreasSelected;

        //    }
        //    set
        //    {
        //        _AreasSelected = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private ObservableCollection<Experiencias> _ExperienceSelected;
        //public ObservableCollection<Experiencias> ExperienceSelected
        //{
        //    get
        //    {
        //        return _ExperienceSelected;

        //    }
        //    set
        //    {
        //        _ExperienceSelected = value;
        //        OnPropertyChanged();
        //    }
        //}
        //#endregion


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

        //private ObservableCollection<ListaPositions> _ListPos;

        //public ObservableCollection<ListaPositions> ListPositions
        //{
        //    get { return _ListPos; }
        //    set
        //    {
        //        _ListPos = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private Command<Object> tappedCommand;

        //public Command DeleteCommand { get; set; }
        //public Command<object> TappedCommand
        //{
        //    get { return tappedCommand; }
        //    set { tappedCommand = value; }
        //}




        //private async void GetPositions()
        //{
        //    IsBusy = true;

        //    int idcompany = (int)Preferences.Get("idCompany", 0);

        //    ListPositions = await Services.PositionService.GetPositionsAsync(idcompany);


        //    await Task.Delay(500);

        //    IsBusy = false;
        //}


        ////Editar vacantes
        //private async void TappedCommandMethod(object obj)
        //{
        //    var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;

        //    ListaPositions p = (ListaPositions)x;

        //    //   Navigation.PushAsync(new EditJobView() { Title="Edit Position"  });

        //    // var secondPage = new AddJobView(p.IDPosition) { Title = "Edit Position" };

        //    await Navigation.PushAsync(new AddJobView(p.IDPosition) { Title = "Edit Position" });

        //    //AddJobViewModel(p.IDPosition);

        //}

        ////Borrar vacantes
        //private async void DeleteCommandMethod(object obj)
        //{
        //    //var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;

        //    var x = (ListaPositions)obj;

        //    if (ItemIndex >= 0)
        //        ListPositions.RemoveAt(ItemIndex);

        //    //Agregar el metodo de borrado de position
        //    if (await Services.PositionService.DeletePositionAsync(x.IDPosition))
        //    {
        //        Application.Current.MainPage.DisplayAlert("JobMe!", "Position successfully deleted", "OK");
        //        ListView.ResetSwipe();
        //        //MessagingCenter.Send<EditJobViewModel, int>(this, "UpdateList", 1);
        //    }
        //    else
        //    {
        //        Application.Current.MainPage.DisplayAlert("JobMe!", "Error deleting position", "OK");
        //    }

        //    //sfListView.ResetSwipe();


        //}


    }
}
