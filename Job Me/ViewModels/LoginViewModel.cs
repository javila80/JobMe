using JobMe.Models;
using JobMe.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private Command logincommand;

        public INavigation Navigation { get; set; }

        private string _User;

        public string User
        {
            get { return _User; }
            set
            {
                _User = value;
                LogInCommand?.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                LogInCommand?.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        private int _UserType;

        public int MyUserType
        {
            get { return _UserType; }
            set { _UserType = value; OnPropertyChanged(); }
        }

        private bool _HasError;

        public bool HasError
        {
            get { return _HasError; }
            set { _HasError = value; OnPropertyChanged(); }
        }

        public enum UserType
        {
            Employee = 1,
            Employer = 2
        }

        public int Tipo { get; set; }
        private string _mitipo;

        public string MiTipo
        {
            get { return _mitipo; }
            set { _mitipo = value; OnPropertyChanged(); }
        }

        public Command ForgotPasswordCommand { get; set; }

        public Command LogInCommand
        {
            get { return logincommand; }
            set { logincommand = value; }
        }

        private string _Signinlbl;

        public string Signinlbl
        {
            get { return _Signinlbl; }
            set { _Signinlbl = value; OnPropertyChanged(); }
        }

        private string _Passwordlbl;

        public string Passwordlbl
        {
            get { return _Passwordlbl; }
            set { _Passwordlbl = value; OnPropertyChanged(); }
        }

        private string _Usernamelbl;

        public string Usernamelbl
        {
            get { return _Usernamelbl; }
            set { _Usernamelbl = value; OnPropertyChanged(); }
        }

        private string _Forgotlbl;

        public string Forgotlbl
        {
            get { return _Forgotlbl; }
            set { _Forgotlbl = value; OnPropertyChanged(); }
        }

        private string _Version;

        public string Version
        {
            get { return _Version; }
            set { _Version = value; OnPropertyChanged(); }
        }

        public LoginViewModel(int tipo)
        {
            Version = VersionTracking.CurrentVersion;

            Usernamelbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Usuario" : "UserName";
            Passwordlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Contraseña" : "Password";
            Signinlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Inicia sesión" : "SIGN IN";
            Forgotlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Olvidé mi password" : "Forgot password";

            Tipo = tipo;

            if (Tipo == (int)UserType.Employee)
            {
                MiTipo = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Candidato" : "Employee";
            }
            else if (Tipo == (int)UserType.Employer)
            {
                MiTipo = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empresa" : "Employer";
            }

            ForgotPasswordCommand = new Command(ForgotPassword);
            LogInCommand = new Command(LoginCommandMethod, () => CanBeExecuted());
        }

        private bool _isLocked;

        private async void LoginCommandMethod()
        {
            if (_isLocked) return;
            _isLocked = true;

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                CanExecute = false;

                if (await LoginUser(User, Password))
                {
                    //Actualiza el token de las push para android
                    MessagingCenter.Send(this, "DeleteToken");
                    //Verifica el tipo de usuario

                    if (Tipo == MyUserType && MyUserType == (int)UserType.Employee)
                    {
                        Preferences.Set("UserType", (int)UserType.Employee);
                        Application.Current.MainPage = new NavigationPage(new MainEmployeeView() { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                        CanExecute = true;
                    }
                    else if (Tipo == MyUserType && MyUserType == (int)UserType.Employer)
                    {
                        Preferences.Set("UserType", (int)UserType.Employer);
                        Application.Current.MainPage = new NavigationPage(new MainEmpresaView() { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                        CanExecute = true;
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("JobMe", "Account not found", "Ok");
                        CanExecute = true;
                    }
                }
                else
                {
                    User = string.Empty;
                    Password = string.Empty;

                    await Application.Current.MainPage.DisplayAlert("JobMe", "Usuario o contraseña incorrecta", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("JobMe", "Necesitas internet para iniciar sesion", "OK");
            }

            await Task.Delay(600);
            _isLocked = false;
        }

        private async Task<bool> LoginUser(string username, string password)
        {
            try
            {
                UserModel u = new UserModel();
                u = await Services.UserService.LoginAsync(username, password);

                //Valida que no este vacio

                if (u.UserID > 0)
                {
                    MyUserType = u.UserType;

                    Preferences.Set("UserID", Convert.ToInt32(u.UserID));
                    Preferences.Set("Name", u.Name);
                    Preferences.Set("UserType", Convert.ToInt32(u.UserType));
                    Preferences.Set("UserName", u.UserName);
                    Preferences.Set("idCompany", Convert.ToInt32(u.IDCompany));

                    Preferences.Set("IsMainContact", Convert.ToBoolean(u.IsMainContact));

                    return true;
                }
                else
                {
                    //await Application.Current.MainPage.DisplayAlert("JobMe", "Error al intenatr iniciar sesion", "OK");
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }

        private bool CanBeExecuted()
        {
            if (User != null && Password != null && User.Length > 3 && Password.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void ForgotPassword()
        {
            await Navigation.PushModalAsync(new ForgotPasswordView());
        }
    }
}