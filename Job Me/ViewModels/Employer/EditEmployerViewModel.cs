using JobMe.Views;
using JobMe.Views.Employer;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels.Employer
{
    class EditEmployerViewModel: BaseViewModel    {

        public Command LogOutCommand { get; set; }
        public Command BntCommand { get; set; }
        public Command EditInfoCommand { get; set; }
        public Command EditContactsCommand { get; set; }
        public INavigation Navigation { get; set; }

        private bool _IsMainContact;

        private string _Editinfolbl;

        public string Editinfolbl
        {
            get { return _Editinfolbl; }
            set { _Editinfolbl = value; OnPropertyChanged(); }
        }

        private string _Addremovelbl;

        public string Addremovelbl
        {
            get { return _Addremovelbl; }
            set { _Addremovelbl = value; OnPropertyChanged(); }
        }

        public bool IsMainContact
        {
            get { return _IsMainContact; }
            set { _IsMainContact = value;
                EditContactsCommand?.ChangeCanExecute();
                OnPropertyChanged(); }
        }

        private string _Logoutlbl;

        public string Logoutlbl
        {
            get { return _Logoutlbl; }
            set { _Logoutlbl = value; OnPropertyChanged(); }
        }

        public EditEmployerViewModel()
        {
            Addremovelbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Agregar / quitar contactos" : "Add / remove contacts";
            Editinfolbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar información" : "Edit info"; 
            Logoutlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Cerrar sesión" : "Log out";

            IsMainContact = Preferences.Get("IsMainContact", false);

            LogOutCommand = new Command((x) => LogOut());

            EditInfoCommand = new Command(UpdateInfo);

            EditContactsCommand = new Command(UpdateContacts, () => IsMainContact);

        }

        private async void UpdateInfo()
        {
            await Navigation.PushAsync(new EditInfo() { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar empresa" : "Edit Company", });
        }

        private async void UpdateContacts()
        {
            await Navigation.PushAsync(new EditContacts() { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Agregar / Quitar contactos" :"Add / Remove Contacts" });
        }
       
        private void LogOut()
        {

            Preferences.Set("UserID", null);
            Preferences.Set("Name",null);
            Preferences.Set("UserType",null);
            Preferences.Set("idCompany", null);

            Application.Current. MainPage = new NavigationPage(new LandingPage()) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange) };
         
        }
    }
}
