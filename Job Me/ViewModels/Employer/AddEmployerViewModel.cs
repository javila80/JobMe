using JobMe.Models;
using JobMe.Views;
using JobMe.Views.Employer;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JobMe.ViewModels.Employer
{
    class AddEmployerViewModel : RegisterEmployerViewModel
    {
        #region "Propiedades"
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

        private bool _addMoreVisible;

        public bool addMoreVisible
        {
            get { return _addMoreVisible; }
            set { _addMoreVisible = value; OnPropertyChanged(); }
        }


        ICommand tapCommand { get; set; }
        public ICommand TapCommand
        {
            get { return tapCommand; }
        }

        public ICommand FocusedCommand { get; set; }

        public Command SaveCommand { get; set; }

        public INavigation Navigation { get; set; }
        #endregion

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
        public AddEmployerViewModel()
        {
            IsEnabled = true;
            addMoreVisible = false;
            tapCommand = new Command(OnTapped);
            SaveCommand = new Command(AddEmployer, () => CanBeExecuted());
            FocusedCommand = new Command(ImageFocused);
        }

        public bool Valida()
        {

            IsCompanyNameEmpty = string.IsNullOrEmpty(CompanyName);
            IsNameEmpty = string.IsNullOrEmpty(Name);
            IsDescriptionEmpty = string.IsNullOrEmpty(CompanyDescription);
            IsPhoneNumberEmpty = string.IsNullOrEmpty(Telephone);
            IsUserNameEmpty = string.IsNullOrEmpty(UserName);
            IsPasswordEmpty = string.IsNullOrEmpty(Password);
            IsMailEmpty = string.IsNullOrEmpty(Mail);

            ////Si todo esta bien valida

            if (!string.IsNullOrEmpty(Name)
                && !string.IsNullOrEmpty(CompanyDescription)
                && !string.IsNullOrEmpty(CompanyName)
                && !string.IsNullOrEmpty(Telephone)
                && !string.IsNullOrEmpty(UserName)
                && !string.IsNullOrEmpty(Password)
                && !string.IsNullOrEmpty(Mail))
            {
                return true;

            }
            else
            {
                return false;
            }

        }
        async void OnTapped(object s)
        {
            await Navigation.PushAsync(new AddMoreContacts(MyIDCompany) { Title = "Add more contacts" });
        }

        private bool CanBeExecuted()
        {

            return !DisableBtn;

        }

        async void AddEmployer()
        {


            IsEnabled = false;

            if (Valida())
            {
                DisableBtn = true;

                IsBusy = true;

                Companies c = new Companies
                {
                    Company = CompanyName,
                    Logo = Logo,
                    Description = CompanyDescription
                };

                int idcompany = await Services.EmployerService.AddCompanyAsync(c);
                MyIDCompany = idcompany;

                if (idcompany > 0)
                {

                    UserModel u = new UserModel
                    {
                        IDCompany = idcompany,
                        Name = Name,
                        Mail = Mail,
                        UserName = UserName,
                        Password = Password,
                        Phone = Telephone
                    };

                    int AddOk = await Services.EmployerService.AddEmployerAsync(u);

                    if (AddOk > 0)
                    {
                        addMoreVisible = true;
                        await Navigation.PushModalAsync(new SuccesRegisterEmployer() { BackgroundColor = Color.White });
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

        }

        async void ImageFocused(object s)
        {

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };

            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImageFile == null)
            {
                return;
            }

            using (var memoryStream = new MemoryStream())
            {
                selectedImageFile.GetStream().CopyTo(memoryStream);
                selectedImageFile.Dispose();

                var signatureMemoryStream = memoryStream.ToArray();
                //Photo = signatureMemoryStream;
                Logo = signatureMemoryStream;

            }

        }
    }
}
