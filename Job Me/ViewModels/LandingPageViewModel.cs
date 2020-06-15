using JobMe.Views;
using JobMe.Views.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using JobMe.Views.Employer;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Xamarin.Essentials;

namespace JobMe.ViewModels
{
    class LandingPageViewModel : BaseViewModel
    {


        private object _SelectedItems;

        public object SelectedItems
        {
            get { return _SelectedItems; }
            set { _SelectedItems = value; }
        }


        private Command signincommand;
        private Command logincommand;

        public Command SignInCommand
        {
            get { return signincommand; }
            set { signincommand = value; }
        }

        public Command LoginCommand
        {
            get { return logincommand; }
            set { logincommand = value; }
        }

        public Command TermsCommand { get; set; }

        public Command PrivacyCommand { get; set; }
        public INavigation Navigation { get; set; }



        private string _Login;
        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }

        private string _SignIn;

        public string SignIn
        {
            get { return _SignIn; }
            set { _SignIn = value; }
        }

        private ObservableCollection<Opciones> _Opciones;
        public ObservableCollection<Opciones> Opciones
        {
            get { return _Opciones; }
            set
            {
                _Opciones = value;
                OnPropertyChanged();

            }

        }

        private string _Registo;

        public string Registro
        {
            get { return _Registo; }
            set { _Registo = value; OnPropertyChanged(); }
        }

        private string _Terms;

        public string Terms
        {
            get { return _Terms; }
            set { _Terms = value; OnPropertyChanged(); }
        }

        private string _Privacy;

        public string Privacy
        {
            get { return _Privacy; }
            set { _Privacy = value; OnPropertyChanged(); }
        }

        private string _Version;
        public string Version
        {
            get { return _Version; }
            set { _Version = value; OnPropertyChanged(); }
        }


        public LandingPageViewModel()
        {

            Version = VersionTracking.CurrentVersion;

            Opciones = new ObservableCollection<Opciones>();

            switch (App.Idioma.TwoLetterISOLanguageName)
            {
                case "es":
                    Opciones.Add(new Opciones() { ID = 1, Opcion = "Candidato" });
                    Opciones.Add(new Opciones() { ID = 2, Opcion = "Empresa" });
                    SelectedItems = new Opciones() { ID = 1, Opcion = "Candidato" };
                    Registro = "Registro";
                    SignIn = "Regístrate";
                    Login = "Inicia sesión";
                    Terms = "Términos y condiciones";
                    Privacy = "Política de privacidad";
                    break;

                default:
                    Opciones.Add(new Opciones() { ID = 1, Opcion = "Employees" });
                    Opciones.Add(new Opciones() { ID = 2, Opcion = "Employer" });
                    SelectedItems = new Opciones() { ID = 1, Opcion = "Employees" };
                    Registro = "Register";
                    SignIn = "Sign In";
                    Login = "Log In";
                    Terms = "Terms and conditions";
                    Privacy = "Privacy policy";
                    break;
            }



            SignInCommand = new Command(SignCommandMethod);

            LoginCommand = new Command(LoginCommandMethod, () => CanExecute);

            TermsCommand = new Command(ViewTerms);

            PrivacyCommand = new Command(PrivacyTerms);

        }

        public enum UserType
        {
            Employee = 1,
            Employer = 2
        }

        private async void SignCommandMethod()
        {


            CanExecute = false;
            switch (((Opciones)SelectedItems).ID)
            {
                case 1: //Empleado

                    await Navigation.PushAsync(new RegisterEmployeeView() { BackgroundColor = Color.White });
                    //Application.Current.MainPage = new NavigationPage(new RegisterEmployeeView());

                    CanExecute = true;
                    break;
                case 2: //Empresa

                    //    Application.Current.MainPage = new NavigationPage(new RegisterEmployerView() { Title = "Add contacts" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                    await Navigation.PushAsync(new RegisterEmployerView() { BackgroundColor = Color.White });
                    CanExecute = true;
                    break;
                default:
                    break;

            }

        }

        private async void LoginCommandMethod()
        {
            int tipo = 0;

            switch (((Opciones)SelectedItems).ID)
            {
                case 1: //Empleado
                    tipo = (int)UserType.Employee;

                    break;
                case 2: //Empresa

                    tipo = (int)UserType.Employer;
                    break;
                default:
                    break;

            }

            CanExecute = false;

            await Navigation.PushAsync(new Login(tipo));

            //Application.Current.MainPage = new Login();

            CanExecute = true;
        }

        private async void ViewTerms()
        {
            await Navigation.PushAsync(new TermsView() { Title = App.Idioma.TwoLetterISOLanguageName == "es" ? "Términos y condiciones" : "Terms & conditions" });
        }

        private async void PrivacyTerms()
        {
            await Navigation.PushAsync(new PrivacyView() { Title = App.Idioma.TwoLetterISOLanguageName == "es" ? "Política de privacidad" : "Privacy policy" });
        }

    }

    public class Opciones
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Opcion
        {
            get { return name; }
            set { name = value; }
        }
    }
}
