using Acr.UserDialogs;
using JobMe.Models;
using JobMe.Views.Employer;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels.Employer
{
    class EditInfoViewModel : BaseViewModel
    {

        private string _CompanyName;

        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                _CompanyName = value;
                //SaveCommand?.ChangeCanExecute();

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

                // SaveCommand?.ChangeCanExecute();
                OnPropertyChanged();
            }
        }


        public int UserID { get; set; }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;

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


                OnPropertyChanged();
            }
        }

        private byte[] _Logo;

        public byte[] Logo
        {
            get { return _Logo; }
            set { _Logo = value; OnPropertyChanged(); }
        }

        private bool _IsLogoVisible;

        public bool IsLogoVisible
        {
            get { return _IsLogoVisible; }
            set { _IsLogoVisible = value; OnPropertyChanged(); }
        }

        public INavigation Navigation { get; set; }
        public Command UpdateCommand { get; set; }
        public Command SaveCommand { get; set; }
        public Command AddRemoveCommand { get; set; }
        private bool _IsMainContact;

        public bool IsMainContact
        {
            get { return _IsMainContact; }
            set { _IsMainContact = value; OnPropertyChanged(); }
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

        private string _EditLogo;

        public string EditLogo
        {
            get { return _EditLogo; }
            set { _EditLogo = value; OnPropertyChanged(); }
        }

        public EditInfoViewModel()
        {

            EditLogo = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar Logo" : "Edit Logo";
            Companylbl =App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empresa" : "Company";
            Descriptionlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Descripción" : "Description";
            Namelbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Nombre" : "Name";
            Maillbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Correo " : "Mail";
            Phonelbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Teléfono" : "Telephone";
            Usernamelbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Usuario" : "Username";
            Passwordlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Contraseña" : "Password";


            IsMainContact = Preferences.Get("IsMainContact", false);
            int userid = Preferences.Get("UserID", 0);
           
            GetCompanyInfo(userid);
            UpdateCommand = new Command(UpdateLogo);
            SaveCommand = new Command(UpdateCompany);
            AddRemoveCommand = new Command(AddRemove);
        }


        private async void GetCompanyInfo(int userid)
        {

            UserDialogs.Instance.ShowLoading("Loading...");
            //var idCompany = Preferences.Get("idCompany", 0);

            try
            {
                Companies c = await Services.EmployerService.GetCompanyAsync(userid);


                Logo = c.Logo;
                CompanyName = c.Company;
                CompanyDescription = c.Description;

                if (Logo == null)
                {

                    IsLogoVisible = true;
                }

                Name = c.MainUser.Name;
                UserName = c.MainUser.UserName;
                Telephone = c.MainUser.Phone;
                Mail = c.MainUser.Mail;
                Password = c.MainUser.Password;
                UserID = c.MainUser.UserID;

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                throw;
            }
           

           
        }

        async void UpdateLogo(object s)
        {

            if (IsMainContact)
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
                        CustomPhotoSize = 50,
                        CompressionQuality = 80
                    };

                    var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                    if (selectedImageFile == null)
                    {
                        return;
                    }

                    Preferences.Set("CompanyLogo", selectedImageFile.Path);

                    using (var memoryStream = new MemoryStream())
                    {
                        IsLogoVisible = false;
                        selectedImageFile.GetStreamWithImageRotatedForExternalStorage().CopyTo(memoryStream);
                        selectedImageFile.Dispose();

                        var signatureMemoryStream = memoryStream.ToArray();
                        //Photo = signatureMemoryStream;
                        Logo = signatureMemoryStream;

                    }
                    UserDialogs.Instance.ShowLoading("Updating...");
                    var idCompany = Preferences.Get("idCompany", 0);
                    Companies c = new Companies
                    {
                        IDCompany = idCompany,
                        Logo = this.Logo,

                    };

                    if (!await Services.EmployerService.UpdateLogoAsync(c))
                    {

                        await Application.Current.MainPage.DisplayAlert("JobMe Error", "Ocurrio un error al actualizar la info", "Ok");
                    }

                    UserDialogs.Instance.HideLoading();

                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    await Application.Current.MainPage.DisplayAlert("JobMe Error", ex.Message, "Ok");
                    //throw;
                }
            }
            

        }

        async void UpdateCompany(object s)
        {
            var idCompany = Preferences.Get("idCompany", 0);

            try
            {
                if (Valida())
                {

                    UserDialogs.Instance.ShowLoading("Updating account...");

                    Companies c = new Companies
                    {
                        IDCompany = idCompany,
                        Logo = this.Logo,
                        Company = this.CompanyName,
                        Description = this.CompanyDescription
                    };

                    UserModel u = new UserModel
                    {
                        IDCompany = idCompany,
                        Name = Name,
                        Mail = Mail,
                        UserName = UserName,
                        Password = Password,
                        Phone = Telephone,
                        UserID = UserID
                    };

                    if(IsMainContact)
                    {

                        if (await Services.EmployerService.UpdateCompanyAsync(c))
                        {

                            if (await Services.EmployerService.UpdateContactAsync(u))
                            {
                                await Task.Delay(1000);
                                UserDialogs.Instance.HideLoading();
                                await Application.Current.MainPage.DisplayAlert("JobMe", "Info updated", "Ok");
                            }
                            else
                            {
                                UserDialogs.Instance.HideLoading();
                                await Application.Current.MainPage.DisplayAlert("JobMe Error", "Ocurrio un error al actualizar la info", "Ok");
                            }

                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            await Application.Current.MainPage.DisplayAlert("JobMe Error", "Ocurrio un error al actualizar la info", "Ok");
                        }

                    }
                    else
                    {
                        if (await Services.EmployerService.UpdateContactAsync(u))
                        {
                            await Task.Delay(1000);
                            UserDialogs.Instance.HideLoading();
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Info updated", "Ok");
                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            await Application.Current.MainPage.DisplayAlert("JobMe Error", "Ocurrio un error al actualizar la info", "Ok");
                        }
                    }   
                   
                }
               

                
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("JobMe Error",ex.Message , "Ok");
                //throw;
            }
           
        }

        async void AddRemove()
        {
            await Navigation.PushAsync(new EditContacts() { Title = "Add / Remove contacts" });
        }

        public  bool Valida()
        {
            try
            {
                if (this.CompanyName == null || this.CompanyName.Length < 3)
                {
                    Application.Current.MainPage.DisplayAlert("JobMe Error", "CompanyName can't be empty", "Ok");
                    return false;
                }


                if (this.CompanyDescription == null || this.CompanyDescription.Length < 3)
                {
                    Application.Current.MainPage.DisplayAlert("JobMe Error", "Company description can't be empty", "Ok");
                    return false;
                }

                if (this.Name == null || this.Name.Length < 3)
                {
                    Application.Current.MainPage.DisplayAlert("JobMe Error", "Name can't be empty", "Ok");
                    return false;
                }
                if (this.Mail == null || this.Mail.Length < 3)
                {
                    Application.Current.MainPage.DisplayAlert("JobMe Error", "Mail can't be empty", "Ok");
                    return false;
                }
                if (this.UserName == null || this.UserName.Length < 3 )
                {
                    Application.Current.MainPage.DisplayAlert("JobMe Error", "Username can't be empty", "Ok");
                    return false;
                }
                if (this.Telephone == null)
                {
                    Application.Current.MainPage.DisplayAlert("JobMe Error", "Telephone can't be empty", "Ok");
                    return false;
                }
                if (this.Password == null || this.Password.Length < 3)
                {
                    Application.Current.MainPage.DisplayAlert("JobMe Error", "Password can't be empty", "Ok");
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
          

        }
    }
}
