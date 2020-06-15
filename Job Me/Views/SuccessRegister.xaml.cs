using JobMe.ViewModels;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessRegister : ContentPage
    {
        public SuccessRegister()
        {
            InitializeComponent();
            SuccessRegisterViewModel vm = new SuccessRegisterViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    Application.Current.MainPage = new NavigationPage(new MainEmployeeView() { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
        //   // Application.Current.MainPage = new MainEmployeeView();
        //}
    }

    public class SuccessRegisterViewModel : BaseViewModel
    {
        private List<CustomCell> _CarouselColllection;

        public List<CustomCell> CarouselColllection
        {
            get { return _CarouselColllection; }
            set { _CarouselColllection = value; OnPropertyChanged(); }
        }

        public Command StartCommand { get; set; }

        public INavigation Navigation { get; set; }

        private string _Newmemberlbl;

        public string NewMemberlbl
        {
            get { return _Newmemberlbl; }
            set { _Newmemberlbl = value; OnPropertyChanged(); }
        }

        private string _Congratslbl;

        public string Congratslbl
        {
            get { return _Congratslbl; }
            set { _Congratslbl = value; OnPropertyChanged(); }
        }

        private string _Starthere;

        public string StarHerelbl
        {
            get { return _Starthere; }
            set { _Starthere = value; OnPropertyChanged(); }
        }

        private string _txt2;

        public string txt2
        {
            get { return _txt2; }
            set { _txt2 = value; OnPropertyChanged(); }
        }

        private string _txt3;

        public string txt3
        {
            get { return _txt3; }
            set { _txt3 = value; OnPropertyChanged(); }
        }

        private string _txt1;

        public string txt1
        {
            get { return _txt1; }
            set { _txt1 = value; OnPropertyChanged(); }
        }

        private string _txt4;

        public string txt4
        {
            get { return _txt4; }
            set { _txt4 = value; OnPropertyChanged(); }
        }

        private string _txt5;

        public string txt5
        {
            get { return _txt5; }
            set { _txt5 = value; OnPropertyChanged(); }
        }

        public SuccessRegisterViewModel()
        {
            NewMemberlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "     Nuevo usuario     " : "      NEW MEMBER     ";
            Congratslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "     Felicidades     " : "     Congratulations     ";
            StarHerelbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Iniciar" : "Start Here";

            txt1 = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Recibirás" : "You will receive an";
            txt2 = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "un correo de " : "e-mail with your";
            txt3 = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "verificación" : "verification";

            txt4 = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Enséñale al mundo" : "Show the world";
            txt5 = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "quien eres" : " who you really are";

            //Se cargan las pestañas
            CarouselColllection = new List<CustomCell>();
            CarouselColllection.Add(new CustomCell { TipoHoja = 2 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 3 });

            StartCommand = new Command(StartMethod);
        }

        private void StartMethod()
        {
            //Actualiza el token de las push para android

            Application.Current.MainPage = new NavigationPage(new MainEmployeeView() { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
        }
    }
}