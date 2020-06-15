using Acr.UserDialogs;
using JobMe.Models;
using JobMe.Services;
using JobMe.Views;
using JobMe.Views.Employer;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels.Employer
{
    internal class RegisterEmployerViewModel : BaseViewModel
    {
        #region "Propiedades"

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

        private string _CompanyName;

        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                _CompanyName = value;
                //SaveCommand?.ChangeCanExecute();
                IsCompanyNameEmpty = false;
                OnPropertyChanged();
            }
        }

        private string _CompanyDescription;

        public string CompanyDescription
        {
            get { return _CompanyDescription; }
            set
            {
                _CompanyDescription = value;
                //   SaveCommand?.ChangeCanExecute();
                IsDescriptionEmpty = false;
                OnPropertyChanged();
            }
        }

        private string _Mail;

        public string Mail
        {
            get { return _Mail; }
            set
            {
                _Mail = value;
                IsMailEmpty = false;
                // SaveCommand?.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                IsNameEmpty = false;
                //    SaveCommand?.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        private string _Telephone;

        public string Telephone
        {
            get { return _Telephone; }
            set
            {
                _Telephone = value;
                IsPhoneNumberEmpty = false;
                // SaveCommand?.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                IsUserNameEmpty = false;
                //SaveCommand?.ChangeCanExecute();
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
                IsPasswordEmpty = false;

                OnPropertyChanged();
            }
        }

        private byte[] _Logo;

        public byte[] Logo
        {
            get { return _Logo; }
            set { _Logo = value; OnPropertyChanged(); }
        }

        private Stream _LogoStream;

        public Stream LogoStream
        {
            get { return _LogoStream; }
            set { _LogoStream = value; OnPropertyChanged(); }
        }

        private bool _addMoreVisible;

        public bool addMoreVisible
        {
            get { return _addMoreVisible; }
            set { _addMoreVisible = value; OnPropertyChanged(); }
        }

        private int _MyIDCompany;

        public int MyIDCompany
        {
            get { return _MyIDCompany; }
            set { _MyIDCompany = value; }
        }

        private bool _IsEnabled;

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set
            {
                _IsEnabled = value;
                OnPropertyChanged();
                //((Command)SaveCommand).ChangeCanExecute();
            }
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

        private bool _IsCompanyNameEmpty;

        public bool IsCompanyNameEmpty
        {
            get { return _IsCompanyNameEmpty; }
            set
            {
                _IsCompanyNameEmpty = value;
                OnPropertyChanged();
            }
        }

        private bool _IsDescriptionEmpty;

        public bool IsDescriptionEmpty
        {
            get { return _IsDescriptionEmpty; }
            set
            {
                _IsDescriptionEmpty = value;
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

        private ICommand tapCommand { get; set; }

        public ICommand TapCommand
        {
            get { return tapCommand; }
        }

        public ICommand FocusedCommand { get; set; }
        public Command UnFocusedCommand { get; set; }

        public Command SaveCommand { get; set; }

        public INavigation Navigation { get; set; }

        private List<CustomCell> _CarouselColllection;

        public List<CustomCell> CarouselColllection
        {
            get { return _CarouselColllection; }
            set { _CarouselColllection = value; OnPropertyChanged(); }
        }

        private NewEmployerTemplateSelector _TemplateSelector;

        public NewEmployerTemplateSelector TemplateSelector
        {
            get { return _TemplateSelector; }
            set { _TemplateSelector = value; OnPropertyChanged(); }
        }

        private int _Position = 0;

        public int Position
        {
            get { return _Position; }
            set { _Position = value; OnPropertyChanged(); }
        }

        private bool _HasNavigationPage;

        public bool HasNavigationPage
        {
            get { return _HasNavigationPage; }
            set { _HasNavigationPage = value; OnPropertyChanged(); }
        }

        private bool _CanSwipe = false;

        public bool CanSwipe
        {
            get { return _CanSwipe; }
            set { _CanSwipe = value; OnPropertyChanged(); }
        }

        private string _LogoName;

        public string LogoName
        {
            get { return _LogoName; }
            set { _LogoName = value; OnPropertyChanged(); }
        }

        public Command StartCommand { get; set; }

        private bool _UserExist;

        public bool MyUserExist
        {
            get { return _UserExist; }
            set { _UserExist = value; OnPropertyChanged(); }
        }

        private bool _EmailExist;

        public bool MyEmailExist
        {
            get { return _EmailExist; }
            set { _EmailExist = value; OnPropertyChanged(); }
        }

        private string _ErrorText;

        private bool _showlabel;

        public bool ShowLabel
        {
            get { return _showlabel; }
            set { _showlabel = value; OnPropertyChanged(); }
        }

        public string ErrorText
        {
            get { return _ErrorText; }
            set { _ErrorText = value; OnPropertyChanged(); }
        }

        #endregion "Propiedades"

        private string _txt3;

        public string txt3
        {
            get { return _txt3; }
            set { _txt3 = value; OnPropertyChanged(); }
        }

        public Command TermsCommand { get; set; }

        public Command PrivacyCommand { get; set; }

        public RegisterEmployerViewModel()
        {
            txt3 = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Encuentra al mejor talento y crea el mejor equipo." : "Find the best talent &  Form the best team";
            txt1 = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Encuentra al mejor talento" : "Find the best talent and";
            txt2 = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "y crea el mejor equipo." : "Form the best team";

            NewMemberlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "     Nuevo usuario     " : "      NEW MEMBER     ";
            Congratslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "     Felicidades     " : "     Congratulations     ";

            HasNavigationPage = true;

            //Se cargan las pestañas
            CarouselColllection = new List<CustomCell>();
            // CarouselColllection.Add(new CustomCell { TipoHoja = 1 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 2 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 3 });

            IsEnabled = true;
            addMoreVisible = true;
            tapCommand = new Command(OnTapped);
            SaveCommand = new Command(AddEmployer);
            FocusedCommand = new Command(ImageFocused);
            StartCommand = new Command(StartMethod);
            UnFocusedCommand = new Command(async () => await UserExist());
            TermsCommand = new Command(ViewTerms);
            PrivacyCommand = new Command(PrivacyTerms);
        }

        private async void ViewTerms()
        {
            await Navigation.PushAsync(new TermsView() { Title = "Terms & conditions" });
        }

        private async void PrivacyTerms()
        {
            await Navigation.PushAsync(new PrivacyView() { Title = App.Idioma.TwoLetterISOLanguageName == "es" ? "Política de privacidad" : "Privacy policy" });
        }

        private void StartMethod()
        {
            Application.Current.MainPage = new NavigationPage(new MainEmpresaView() { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
        }

        private async Task<bool> UserExist()
        {
            try
            {
                var x = await Services.JobMe.UserExistAsync(Mail ?? "null", UserName ?? "null");

                if (x == 1) //Existe el usuario
                {
                    MyUserExist = true;
                    IsUserNameEmpty = true;
                    ErrorText = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El nombre de usuario ya existe, elige otro" : "The username already exist, please choose another one";
                    ShowLabel = true;
                    return true;
                }
                else if (x == 2)//Existe el correo
                {
                    IsMailEmpty = true;
                    ErrorText = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "El correo ya existe" : "The email already exist";
                    MyEmailExist = true;
                    ShowLabel = true;
                    return true;
                }
                else
                {
                    ShowLabel = false;
                    MyUserExist = false;
                    MyEmailExist = false;
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
            return !DisableBtn;
        }

        private async void ImageFocused(object s)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    return;
                }

                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium,
                    SaveMetaData = false
                };

                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (selectedImageFile == null)
                {
                    return;
                }

                Preferences.Set("CompanyLogo", selectedImageFile.Path);
                LogoName = Path.GetFileName(selectedImageFile.Path);
                using (var memoryStream = new MemoryStream())
                {
                    LogoStream = selectedImageFile.GetStream();

                    selectedImageFile.GetStreamWithImageRotatedForExternalStorage().CopyTo(memoryStream);
                    selectedImageFile.Dispose();

                    var signatureMemoryStream = memoryStream.ToArray();
                    //Photo = signatureMemoryStream;
                    Logo = signatureMemoryStream;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("JobMe", ex.Message, "Ok");
                // throw;
            }
        }

        private async void OnTapped()
        {
            await Navigation.PushAsync(new AddMoreContacts(MyIDCompany) { Title = AddMorellbljunto });
        }

        public async Task<bool> Valida()
        {
            IsCompanyNameEmpty = string.IsNullOrEmpty(CompanyName);
            IsNameEmpty = string.IsNullOrEmpty(Name);
            IsDescriptionEmpty = string.IsNullOrEmpty(CompanyDescription);
            IsPhoneNumberEmpty = string.IsNullOrEmpty(Telephone);
            IsUserNameEmpty = string.IsNullOrEmpty(UserName);
            IsPasswordEmpty = string.IsNullOrEmpty(Password);
            IsMailEmpty = string.IsNullOrEmpty(Mail);
            const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
         @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            ////Si todo esta bien valida
            ///
            bool IsValid = (Regex.IsMatch(Mail ?? string.Empty, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));

            if (await UserExist())
            {
                return false;
            }

            if ((Name != null ? Name.Length : 0) < 3)
            {
                IsNameEmpty = true;
                return false;
            }

            if ((CompanyDescription != null ? CompanyDescription.Length : 0) < 5)
            {
                IsDescriptionEmpty = true;
                return false;
            }

            if ((CompanyName != null ? CompanyName.Length : 0) < 1)
            {
                IsCompanyNameEmpty = true;
                return false;
            }

            if ((UserName != null ? UserName.Length : 0) < 6)
            {
                IsUserNameEmpty = true;
                return false;
            }

            if ((Password != null ? Password.Length : 0) < 6)
            {
                IsPasswordEmpty = true;
                return false;
            }

            if (!IsValid)
            {
                IsMailEmpty = true;
                return false;
            }

            if (MyEmailExist)
            {
                IsMailEmpty = true;
                return false;
            }

            if (MyUserExist)
            {
                IsUserNameEmpty = true;
                return false;
            }
            return true;
        }

        private bool _isLocked;

        private async void AddEmployer()
        {
            if (_isLocked) return;
            _isLocked = true;

            IsEnabled = false;

            if (await Valida())
            {
                UserDialogs.Instance.ShowLoading("Creating account");

                DisableBtn = true;

                IsBusy = true;

                Companies c = new Companies
                {
                    Company = this.CompanyName,
                    Logo = this.Logo,
                    Description = this.CompanyDescription,
                    LogoName = this.LogoName
                };

                //UploadLogo
                var dTask = Task.Run(async () => await UserService.UploadPhoto(LogoStream, LogoName));

                int idcompany = await Services.EmployerService.AddCompanyAsync(c);
                MyIDCompany = idcompany;
                await dTask;
                if (idcompany > 0)
                {
                    UserModel u = new UserModel
                    {
                        IDCompany = idcompany,
                        Name = Name,
                        Mail = Mail,
                        UserName = UserName,
                        Password = Password,
                        Phone = Telephone,
                        IsMainContact = true
                    };

                    Preferences.Set("idCompany", idcompany);
                    int AddOk = await Services.EmployerService.AddEmployerAsync(u);

                    if (AddOk > 0)
                    {
                        await Task.Delay(1000);

                        UserDialogs.Instance.HideLoading();
                        addMoreVisible = true;
                        Preferences.Set("UserID", AddOk);
                        Preferences.Set("UserType", 2);
                        Preferences.Set("IsMainContact", true);
                        HasNavigationPage = true;

                        await Navigation.PushAsync(new SuccesRegisterEmployer());
                        Position = 1;

                        CanSwipe = true;

                        //    //Ir al index 2
                        //    Position = 1;

                        //CanSwipe = true;
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        IsBusy = false;
                        await Application.Current.MainPage.DisplayAlert("JobMe", "Error saving info", "Ok");
                        //Error
                        return;
                    }
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("JobMe", "Ocurrio un error al agregar la empresa", "Ok");
                    //Error
                    return;
                }

                IsBusy = false;
            }
            else
            {
                DisableBtn = false;
                IsEnabled = true;
            }

            Task.Delay(600);

            _isLocked = false;
        }
    }
}