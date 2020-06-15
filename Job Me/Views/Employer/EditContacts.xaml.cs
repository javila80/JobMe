using Acr.UserDialogs;
using JobMe.Models;
using JobMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContacts : ContentPage
    {
        EditContactsViewModel vm = new EditContactsViewModel();
        public EditContacts()
        {
            InitializeComponent();

            vm.Navigation = Navigation;
            BindingContext = vm;
        }


        private void listView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            vm.ItemIndex = -1;
        }

        private void listView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            vm.ItemIndex = e.ItemIndex;
        }

        protected override void OnAppearing()
        {
            vm.ListView = listView;
            base.OnAppearing();
        }

    }



    public class EditContactsViewModel : BaseViewModel
    {

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


        private object _SelectedItems;

        public object SelectedItems
        {
            get { return _SelectedItems; }
            set
            {
                _SelectedItems = value;
                OnPropertyChanged();

                if (SelectedItems != null)
                {
                    if (SelectedItems.ToString() ==( App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Agregar" : "Add"))
                    {
                        LimpiaCampos();

                        AddVisible = true;
                        ListaVisible = false;
                        IsEdit = false;
                    }
                    else if (SelectedItems.ToString() == (App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar / Quitar" : "Edit / Remove"))
                    {
                        AddVisible = false;
                        ListaVisible = true;
                        IsEdit = true;
                    }
                }

            }
        }

        private bool _AddVisible;

        public bool AddVisible
        {
            get { return _AddVisible; }
            set { _AddVisible = value; OnPropertyChanged(); }
        }

        private bool _ListaVisible;

        public bool ListaVisible
        {
            get { return _ListaVisible; }
            set { _ListaVisible = value; OnPropertyChanged(); }
        }

        public INavigation Navigation { get; set; }
        private ObservableCollection<UserModel> _ListContacts;

        public ObservableCollection<UserModel> ListContacts
        {
            get { return _ListContacts; }
            set { _ListContacts = value; OnPropertyChanged(); }
        }

        private Command<Object> tappedCommand;

        public Command DeleteCommand { get; set; }

        public Command SaveCommand { get; set; }
        public Command<object> TappedCommand
        {
            get { return tappedCommand; }
            set { tappedCommand = value; }
        }
        private int _itemIndex = -1;

        public int ItemIndex
        {
            get { return _itemIndex; }
            set { _itemIndex = value; OnPropertyChanged(); }
        }
        private Syncfusion.ListView.XForms.SfListView _ListView;

        public Syncfusion.ListView.XForms.SfListView ListView
        {
            get { return _ListView; }
            set { _ListView = value; OnPropertyChanged(); }
        }

        private bool _IsEdit;

        public bool IsEdit
        {
            get { return _IsEdit; }
            set { _IsEdit = value; OnPropertyChanged(); }
        }

        private int _UserID;

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; OnPropertyChanged(); }
        }

        private bool _IsEnabled;

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { _IsEnabled = value; OnPropertyChanged(); }
        }

        private List<String> _listaAcciones;

        public List<String> ListaAcciones
        {
            get { return _listaAcciones; }
            set { _listaAcciones = value; OnPropertyChanged(); }
        }
        private string _Addnewlbl;

        public string Addnewlbl
        {
            get { return _Addnewlbl; }
            set { _Addnewlbl = value; }
        }

        private string _Companylbl;

        public string Companylbl
        {
            get { return _Companylbl; }
            set { _Companylbl = value; OnPropertyChanged(); }
        }

        private string _Descriptionlbl;

        public string Descriptionlbl
        {
            get { return _Descriptionlbl; }
            set { _Descriptionlbl = value; OnPropertyChanged(); }
        }

        private string _Namelbl;

        public string Namelbl
        {
            get { return _Namelbl; }
            set { _Namelbl = value; OnPropertyChanged(); }
        }

        private string _Maillbl;

        public string Maillbl
        {
            get { return _Maillbl; }
            set { _Maillbl = value; OnPropertyChanged(); }
        }

        private string _Phonelbl;

        public string Phonelbl
        {
            get { return _Phonelbl; }
            set { _Phonelbl = value; OnPropertyChanged(); }
        }

        private string _Usernamelbl;

        public string Usernamelbl
        {
            get { return _Usernamelbl; }
            set { _Usernamelbl = value; OnPropertyChanged(); }
        }

        private string _Paswwordlbl;

        public string Passwordlbl
        {
            get { return _Paswwordlbl; }
            set { _Paswwordlbl = value; OnPropertyChanged(); }
        }

        private string _NameError;

        public string NameError
        {
            get { return _NameError; }
            set { _NameError = value; OnPropertyChanged(); }
        }

        private string _MailError;

        public string MailError
        {
            get { return _MailError; }
            set { _MailError = value; OnPropertyChanged(); }
        }

        private string _PhoneError;

        public string PhoneError
        {
            get { return _PhoneError; }
            set { _PhoneError = value; OnPropertyChanged(); }
        }

        private string _UserNameError;

        public string UserNameError
        {
            get { return _UserNameError; }
            set { _UserNameError = value; OnPropertyChanged(); }
        }

        private string _PasswordError;

        public string PasswordError

        {
            get { return _PasswordError; }
            set { _PasswordError = value; OnPropertyChanged(); }
        }

       



        public EditContactsViewModel()
        {

            NameError = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa tu nombre" : "Enter your name";
            MailError = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa un email válido" : "Please enter a valid email";
            PhoneError = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ingresa un teléfono de 10 dígitos" : "Please enter a 10 digit valid phone";
            UserNameError = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Mínimo 6 caracteres" : "Minimun 6 characters";
            PasswordError = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Mínimo 6 caracteres" : "Minimun 6 characters";

            Companylbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empresa" : "Company";
            Descriptionlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Descripción" : "Description";
            Namelbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Nombre" : "Name";
            Maillbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Correo " : "Mail";
            Phonelbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Teléfono" : "Telephone";
            Usernamelbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Usuario" : "Username";
            Passwordlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Contraseña" : "Password";
            Addnewlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Agregar contacto" : "Add new contact";

            ListaAcciones = new List<string>();
            ListaAcciones.Add(App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Agregar" : "Add");
            ListaAcciones.Add(App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar / Quitar" : "Edit / Remove");

            IsEnabled = true;

            GetCompany();

            TappedCommand = new Command<object>(TappedCommandMethod);
            DeleteCommand = new Command<object>(DeleteCommandMethod);
            SaveCommand = new Command<object>(AddEmployer);
            UnFocusedCommand = new Command(async () => await UserExist());

            SelectedItems = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Agregar" : "Add";
        }

        private async void GetCompany()
        {
            AddVisible = true;
            int idcompany = Preferences.Get("idCompany", 0);
            ListContacts = await Services.EmployerService.GetContactsAsync(idcompany);
        }

        private async void TappedCommandMethod(object obj)
        {
            var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;

            UserModel p = (UserModel)x;

            Name = p.Name;
            Mail = p.Mail;
            Telephone = p.Phone;
            UserName = p.UserName;
            Password = p.Password;
            UserID = p.UserID;

            ListaVisible = false;
            AddVisible = true;

        }

        private async void DeleteCommandMethod(object obj)
        {
            //var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;
            if (await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
            {
                CancelText = "Cancel",
                OkText = "Ok",
                Message = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "¿Estás seguro de borrar el contacto?" : "Are you sure you want to delete the contact ?",

            }))
            {
                var x = (UserModel)obj;

                if (ItemIndex >= 0)
                    ListContacts.RemoveAt(ItemIndex);

                //Agregar el metodo de borrado de usuario
                if (await Services.UserService.DeleteUserAsync(x.UserID))
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe!",
                                                                App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Contacto eliminado" : "Contact successfully deleted",
                                                                "OK");
                    
                    //MessagingCenter.Send<EditJobViewModel, int>(this, "UpdateList", 1);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe!",
                                                                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Error eliminando el contacto" :"Error deleting contact",
                                                                    "OK");
                }
              
                //sfListView.ResetSwipe();

            }
            ListView.ResetSwipe();

        }

        
        private bool _isLocked;
        async void AddEmployer(object obj)
        {

            UserDialogs.Instance.ShowLoading("Saving");
            int idcompany = Preferences.Get("idCompany", 0);

            if (_isLocked) return;
            _isLocked = true; /* your code here */

            //agregar validacion para que no se repitan            

            if (Valida())
            {
               
                  UserModel u = new UserModel
                {

                    IDCompany = idcompany,
                    UserID = this.UserID,
                    Name = this.Name,
                    Mail = this.Mail,
                    UserName = this.UserName,
                    Password = this.Password,
                    Phone = this.Telephone
                };

                int AddOk = 0;

                if (IsEdit)
                {
                    var resp = await Services.EmployerService.UpdateContactAsync(u);

                    if (resp)
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe", "Info updated succesfully", "Ok");
                    }
                    else
                    {
                        IsBusy = false;
                        await Application.Current.MainPage.DisplayAlert("JobMe", "Ocurrio un error al actualizar el contacto", "Ok");
                        //Error
                        return;

                    }
                }
                else
                {
                    AddOk = await Services.EmployerService.AddEmployerAsync(u);
                    if (AddOk > 0)
                    {

                        await Application.Current.MainPage.DisplayAlert("JobMe",
                                                                        App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Contacto agregado correctamente" : "Contact added succesfully",
                                                                        "Ok");
                        LimpiaCampos();

                    }
                    else
                    {
                        IsBusy = false;
                        await Application.Current.MainPage.DisplayAlert("JobMe",
                                                                        App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ocurrio un error al agregar el contacto" :"Errro adding contact",
                                                                        "Ok");

                        //Error
                        return;

                    }
                }


            }

            IsBusy = false;
            IsEnabled = true;
            Task.Delay(600);
            _isLocked = false;
         
            ListContacts = await Services.EmployerService.GetContactsAsync(idcompany);
            UserDialogs.Instance.HideLoading();
        }

        public bool Valida()
        {

            
            IsNameEmpty = string.IsNullOrEmpty(Name);
            IsPhoneNumberEmpty = string.IsNullOrEmpty(Telephone);
            IsUserNameEmpty = string.IsNullOrEmpty(UserName);
            IsPasswordEmpty = string.IsNullOrEmpty(Password);
            IsMailEmpty = string.IsNullOrEmpty(Mail);

            if ( string.IsNullOrEmpty(Name))
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
        public Command UnFocusedCommand { get; set; }
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
        public void LimpiaCampos()
        {

            Name = null;
            Telephone = null;
            UserName = null;
            Password = null;
            Mail =null;

        }
    }
}