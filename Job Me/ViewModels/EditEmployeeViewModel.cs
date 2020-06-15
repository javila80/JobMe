using JobMe.Models;
using JobMe.Services;
using JobMe.Views;
using JobMe.Views.Employee;
using Plugin.FilePicker;
using Plugin.Media;
using Plugin.Media.Abstractions;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels
{
    class EditEmployeeViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private Command _LogOutCommand;

        public Command LogOutCommand
        {
            get { return _LogOutCommand; }
            set
            {
                _LogOutCommand = value;
                OnPropertyChanged();
            }
        }

        private Command<object> _BtnCommand;

        public Command<object> BntCommand
        {
            get { return _BtnCommand; }
            set { _BtnCommand = value; }
        }

        private byte[] _Photo;

        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; OnPropertyChanged(); }
        }


        public Command AvatarTapCommand { get; set; }

        public Command CVTapCommand { get; set; }
        public EditEmployeeViewModel()
        {
            
            if (Preferences.Get("MyFoto", string.Empty) != string.Empty)
            {
                string path = Preferences.Get("MyFoto", string.Empty);
                PhotoURL = ImageSource.FromFile(path);
            }
            else
            {
                PhotoURL = ImageSource.FromUri(new Uri(EndPoint.BACKEND_ENDPOINT + "/uploads/" + Preferences.Get("UserID", 0).ToString() + ".jpg"));
            }


            //GetUser();

            CVTapCommand = new Command((x) => UpdateCV());

            AvatarTapCommand = new Command((x) => TakePhoto());

            LogOutCommand = new Command((x) => LogOut());

            BntCommand = new Command<object>(TappedCommandMethod);

        }

        private ImageSource _PhotoURL;

        public ImageSource PhotoURL
        {
            get { return _PhotoURL; }
            set { _PhotoURL = value; OnPropertyChanged(); }
        }


        public async void GetUser()
        {

            UserModel u = new UserModel();
            u = await Services.UserService.GetUserAsync((int)Preferences.Get("UserID", 0));

            int idusuario = Preferences.Get("UserID", 0);

            Photo = u.Photo;

        }

        private async void UpdateCV()
        {

            int userid = (int)Preferences.Get("UserID", 0);
            var u = new UserModel();
            u.UserID = userid;
            try
            {

                var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

                if (status != PermissionStatus.Granted)
                {
                    //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                    //{

                    //}
                    status = await Permissions.RequestAsync<Permissions.StorageRead>();
                   // status = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                }

                if (status == PermissionStatus.Granted)
                {
                    var file = await CrossFilePicker.Current.PickFile();

                    if (file != null)
                    {
                        u.CVName = file.FileName;

                        using (var memoryStream = new MemoryStream())
                        {
                            file.GetStream().CopyTo(memoryStream);
                            file.Dispose();
                            u.CV = memoryStream.ToArray();


                        }

                        var response = await Services.UserService.UpdateCV(u);

                        if (response)
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "CV Updated", "Ok");
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Ocurrio un error al actualizar el CV", "Ok");
                        }


                    }
                }


            }
            catch (Exception)
            {

                // throw;
            }

        }


        private async void TappedCommandMethod(object obj)
        {

            string btn = (string)obj;

            switch (btn)
            {

                case "Essential":
                    await Navigation.PushAsync(new EditEmployeeDetail(1) { Title = "Edit Essential" });
                    break;
                case "Interest":
                    await Navigation.PushAsync(new EditEmployeeDetail(2) { Title = "Edit Interests" });
                    break;
                case "Academics":
                    await Navigation.PushAsync(new EditEmployeeDetail(3) { Title = "Edit Academics" });
                    break;
                case "Jobs":
                    await Navigation.PushAsync(new EditEmployeeDetail(4) { Title = "Edit Jobs" });
                    break;
                case "Others":
                    await Navigation.PushAsync(new EditEmployeeDetail(5) { Title = "Edit Others" });
                    break;

                default:
                    break;
            }

        }

        private async void TakePhoto()
        {
            try
            {
                int userid = (int)Preferences.Get("UserID", 0);

                var mediaOptions = new StoreCameraMediaOptions()
                {
                    SaveToAlbum = false,
                    Directory = "Sample",
                    Name = userid + "_photo.jpg",
                    PhotoSize = PhotoSize.Small,
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                    RotateImage = false,
                    CompressionQuality = 50,
                    AllowCropping = true,
                    SaveMetaData = false,
                    CustomPhotoSize = 70 //Resize to 90% of original
                };

                if (!CrossMedia.Current.IsTakePhotoSupported)
                {

                    return;
                }
                var selectedImageFile = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

                if (selectedImageFile != null)
                {
                    try
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            selectedImageFile.GetStreamWithImageRotatedForExternalStorage();


                            //var signatureMemoryStream = memoryStream.ToArray();
                            //Photo = signatureMemoryStream;
                            await UserService.UploadPhoto(selectedImageFile.GetStreamWithImageRotatedForExternalStorage(), userid.ToString() + ".jpg");

                            PhotoURL = ImageSource.FromFile(selectedImageFile.Path);
                            // = EndPoint.BACKEND_ENDPOINT + "/uploads/" + userid.ToString() + ".jpg";
                            Preferences.Set("MyFoto", selectedImageFile.Path);
                            selectedImageFile.Dispose();
                        }
                    }
                    catch (Exception)
                    {
                        await Application.Current.MainPage.DisplayAlert("Job Me", "Ocurrio un error al actualizar la foto", "Ok");
                        // throw;
                    }

                    return;
                };
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Job Me", "Ocurrio un error al actualizar la foto", "Ok");
                //throw;
            }

        }
        private void LogOut()
        {

            Preferences.Remove("AcademicsVideo");
            Preferences.Remove("JobsVideo");
            Preferences.Remove("OthersVideo");
            Preferences.Remove("UserID");
            Preferences.Remove("UserName");
            Preferences.Remove("Age", "");
            Preferences.Remove("Degree", "");
            Preferences.Remove("Name", "");
            Preferences.Clear();

            Application.Current.MainPage = new NavigationPage(new LandingPage()) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange) };
            //Application.Current.MainPage = new LandingPage();
        }
    }
}
