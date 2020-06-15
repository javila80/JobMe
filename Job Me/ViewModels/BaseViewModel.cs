using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using JobMe.Models;
using JobMe.Services;

namespace JobMe.ViewModels
{

    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        bool isVisible = false;
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetProperty(ref isVisible, value); OnPropertyChanged(); }
        }
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private bool _CanExecute = true;

        public bool CanExecute
        {
            get { return _CanExecute; }
            set
            {
                _CanExecute = value;
                OnPropertyChanged();
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region "Traduccion"

        private string _si;
        public string Si
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Si" : "Yes" ; }
            set { _si = value; OnPropertyChanged(); }
        }

        private string _NameError;

        public string NameError
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa tu nombre" : "Enter your name"; }
            set { _NameError = value; OnPropertyChanged(); }
        }      

        private string _MailError;

        public string MailError
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa un email válido" : "Please enter a valid email"; }
            set { _MailError = value; OnPropertyChanged(); }
        }

        private string _PhoneError;

        public string PhoneError
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa un teléfono de 10 dígitos" : "Please enter a 10 digit valid phone"; }
            set { _PhoneError = value; OnPropertyChanged(); }
        }

        private string _UserNameError;

        public string UserNameError
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Mínimo 6 caracteres" : "Minimun 6 characters"; }
            set { _UserNameError = value; OnPropertyChanged(); }
        }

        private string _PasswordError;

        public string PasswordError

        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Mínimo 6 caracteres" : "Minimun 6 characters"; }
            set { _PasswordError = value; OnPropertyChanged(); }
        }
        private string _DescriptionError;

        public string DescriptionError
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa una descripción de la empresa" : "Enter company description"; }
            set { _DescriptionError = value; OnPropertyChanged(); }
        }
        private string _CompanyError;

        public string CompanyError
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa el nombre de la empresa" : "Enter company name"; }
            set { _CompanyError = value; OnPropertyChanged(); }
        }

        private string _Escencial;

        public string Esencial
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "       Esencial       " : "       Essential       "; }
            set { _Escencial = value; OnPropertyChanged(); }
        }

        private string _Privacy;

        public string Privacy
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Política de privacidad" : "Privacy policy"; }
            set { _Privacy = value; OnPropertyChanged(); }
        }

        private string _CompanyHint;

        public string CompanyHint
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empresa" : "Company"; }
            set { _CompanyHint = value; OnPropertyChanged(); }
        }

        private string _DescriptionHint;

        public string DescriptionHint
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Descripción" : "Description"; }
            set { _DescriptionHint = value; OnPropertyChanged(); }
        }

        private string _NameHint;

        public string NameHint
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Nombre" : "Name"; }
            set { _NameHint = value; OnPropertyChanged(); }
        }

        private string _PhoneHint;

        public string PhoneHint
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Teléfono" : "Telephone"; }
            set { _PhoneHint = value; OnPropertyChanged(); }
        }

        private string _PasswordHint;

        public string PasswordHint
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Contraseña" : "Password"; }
            set { _PasswordHint = value; OnPropertyChanged(); }
        }

        private string _UserNameHint;

        public string UserNameHint
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Usuario" : "UserName"; }
            set { _UserNameHint = value; OnPropertyChanged(); }
        }

        private string _NewMember;

        public string NewMember
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "NUEVO USUARIO" : "NEW MEMBER"; }
            set { _NewMember = value; OnPropertyChanged(); }
        }

        private string _StartHere;

        public string StartHere
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Iniciar" : "Start Here"; }
            set { _StartHere = value; OnPropertyChanged(); }
        }

        private string _Recibiras;

        public string Recibiras
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Recibirás" : "You will receive an"; }
            set { _Recibiras = value; OnPropertyChanged(); }
        }

        private string _Emaillbl;

        public string Emaillbl
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "un correo de" : "e-mail with your"; ; }
            set { _Emaillbl = value; OnPropertyChanged(); }
        }

        private string _Verificacion;

        public string Verificacionlbl
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "verificación" : "verification"; }
            set { _Verificacion = value; OnPropertyChanged(); }
        }

        private string _addmorelbl;

        public string AddMorellbl
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? " +      Agregar más contactos      " : " +      Add more contacts      "; ; }
            set { _addmorelbl = value; OnPropertyChanged(); }
        }

        private string _addmorelbljunto;

        public string AddMorellbljunto
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Agregar más contactos" : "Add more contacts"; ; }
            set { _addmorelbljunto = value; OnPropertyChanged(); }
        }

        private string _GotoChat;

        public string GotoChat
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ir a Chat Me" : "Go to Chat Me"; }
            set { _GotoChat = value; OnPropertyChanged(); }
        }

        private string _Congrats;

        public string Congrats
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Felicidades" : "Congratulations"; }
            set { _Congrats = value; OnPropertyChanged(); }
        }

        private string _Usernamelogin;

        public string UsernameError
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa un usuario válido" : "Please enter a valid username"; }
            set { _Usernamelogin = value; OnPropertyChanged(); }
        }

        private string _PasswordLogin;

        public string PasswordLogin
        {
            get { return App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa una contraseña válida" : "Please enter a valid password"; }
            set { _PasswordLogin = value; OnPropertyChanged(); }
        }

        #endregion
    }
}
