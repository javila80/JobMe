using JobMe.Models;
using JobMe.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels.Employer
{
    class AddMoreContactsViewModel : BaseViewModel
    {
        private string _Mail;

        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; OnPropertyChanged(); }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(); }
        }

        private string _Telephone;

        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; OnPropertyChanged(); }
        }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged(); }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; OnPropertyChanged(); }
        }

        private int _myIDcompany;

        public int myIDcompany
        {
            get { return _myIDcompany; }
            set { _myIDcompany = value; }
        }

        private bool _IsEnabled;

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { _IsEnabled = value; OnPropertyChanged(); }
        }

        private bool _IsNameEmpty;

        public bool IsNameEmpty
        {
            get { return _IsNameEmpty; }
            set
            {
                _IsNameEmpty = value;

                OnPropertyChanged();
            }
        }

        private bool _IsPhoneNumberEmpty;

        public bool IsPhoneNumberEmpty
        {
            get { return _IsPhoneNumberEmpty; }
            set
            {
                _IsPhoneNumberEmpty = value;
                OnPropertyChanged();

            }
        }

        private bool _IsUserNameEmpty;

        public bool IsUserNameEmpty
        {
            get { return _IsUserNameEmpty; }
            set
            {
                _IsUserNameEmpty = value;
                OnPropertyChanged();

            }
        }

        private bool _IsPasswordEmpty;

        public bool IsPasswordEmpty
        {
            get { return _IsPasswordEmpty; }
            set
            {
                _IsPasswordEmpty = value;
                OnPropertyChanged();

            }
        }

        private bool _IsMailEmpty;

        public bool IsMailEmpty
        {
            get { return _IsMailEmpty; }
            set
            {
                _IsMailEmpty = value;
                OnPropertyChanged();
            }
        }

        public INavigation Navigation { get; set; }
        public async Task<bool> Valida()
        {


            IsNameEmpty = string.IsNullOrEmpty(Name);
            IsPhoneNumberEmpty = string.IsNullOrEmpty(Telephone);
            IsUserNameEmpty = string.IsNullOrEmpty(UserName);
            IsPasswordEmpty = string.IsNullOrEmpty(Password);
            IsMailEmpty = string.IsNullOrEmpty(Mail);

            if (await UserExist())
            {
                return false;
            }
            if (string.IsNullOrEmpty(Name))
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Name can't be empty", "Ok");
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Password can't be empty", "Ok");
                return false;
            }
            if (string.IsNullOrEmpty(UserName))
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "Username can't be empty", "Ok");
                return false;
            }
            if (MailHasError)
            {

                Application.Current.MainPage.DisplayAlert("JobMe", "E-Mail already exists", "Ok");
                return false;
            }
            if (UserHasError)
            {
                Application.Current.MainPage.DisplayAlert("JobMe", "UserName already exists", "Ok");
                return false;
            }

            //if (!IsNameEmpty && !IsPhoneNumberEmpty && !IsUserNameEmpty && !IsPasswordEmpty && !IsMailEmpty)
            //{
            //    IsEnabled = true;
            //    return true;

            //}
            //else
            //{
            //    IsEnabled = false;
            //    return false;
            //}
            return true;
        }

        private bool _PopVisible;

        public bool PopVisible
        {
            get { return _PopVisible; }
            set { _PopVisible = value; OnPropertyChanged(); }
        }

        public Command SaveCommand { get; set; }

        public ICommand NoButtonCommand { get; set; }

        public ICommand YesButtonCommand { get; set; }

        private bool disablebtn;

        public bool DisableBtn
        {
            get { return disablebtn; }
            set
            {
                disablebtn = value; OnPropertyChanged();
                SaveCommand?.ChangeCanExecute();
            }

        }
        private bool CanBeExecuted()
        {

            return !DisableBtn;

        }

        public Command UnFocusedCommand { get; set; }

        private string _txt1;

        public string txt1
        {
            get { return _txt1; }
            set { _txt1 = value; OnPropertyChanged(); }
        }

        private string _txt2;

        public string txt2
        {
            get { return _txt2; }
            set { _txt2 = value; OnPropertyChanged(); }
        }

        

        public AddMoreContactsViewModel()
        {
            txt1 = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Contacto agregado correctamente" : "Contact added successfully!!";
            txt2 = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "¿Agregar otro contacto?" : "Add another contact?";
            //Si = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Si" : "Yes";

            IsEnabled = true;

            SaveCommand = new Command(AddEmployer, () => CanBeExecuted());

            YesButtonCommand = new Command(CleanFields);

            NoButtonCommand = new Command(GotoLogin);
            UnFocusedCommand = new Command(async () => await UserExist());
        }

        async void AddEmployer()
        {


            if (await Valida())
            {
                IsBusy = true;
                IsEnabled = false;
                DisableBtn = true;

                int idcompany = Preferences.Get("idCompany", 0) ;
                UserModel u = new UserModel
                {


                    IDCompany = idcompany,
                    Name = this.Name,
                    Mail = this.Mail,
                    UserName = this.UserName,
                    Password = this.Password,
                    Phone = this.Telephone
                };

                int AddOk = await Services.EmployerService.AddEmployerAsync(u);

                // int AddOk = 6;

                if (AddOk > 0)
                {
                    //addMoreVisible = true;
                    PopVisible = true;
                    //await Application.Current.MainPage.DisplayAlert("JobMe", "Contact added succesfully", "Ok");
                    // await Navigation.PushModalAsync(new SuccessRegister() { BackgroundColor = Color.White });
                }
                else
                {
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("JobMe", "Ocurrio un error al agregar el contacto", "Ok");
                    //Error
                    return;

                }
            }
            else
            {
                DisableBtn = false;
            }


            IsBusy = false;
        }

        private void CleanFields()
        {

            Name = null;
            Mail = null;
            UserName = null;
            Password = null;
            Telephone = null;

            DisableBtn = false;
            IsEnabled = true;
            PopVisible = false;

        }

        private async void GotoLogin()
        {
            PopVisible = false;
            await Navigation.PopAsync();
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

        private async Task<bool> UserExist()
        {

            try
            {
                var x = await Services.JobMe.UserExistAsync(Mail != null ? Mail : "null", UserName != null ? UserName : "null");


                if (x == 1) //Existe el usuario
                {
                    UserHasError = true;
                    UserErrorText = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El usuario ya existe, elige otro" : "The username already exist, please choose another one";
                    return true;
                }
                else if (x == 2)//Existe el correo
                {
                    MailHasError = true;
                    MailErrorText = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El correo ya existe" : "The email already exist";

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

    }

}

