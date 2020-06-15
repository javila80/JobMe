using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace JobMe
{
    public class JobMePermissions
    {

        public static async Task<bool> GalleryPermission()
        {
            await CrossMedia.Current.Initialize();

            var cameraStatus = await Permissions.CheckStatusAsync<Permissions.Media>();
            var storageStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                cameraStatus = await Permissions.RequestAsync<Permissions.Media>();
                storageStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
            }

            if (cameraStatus == PermissionStatus.Denied || storageStatus == PermissionStatus.Denied)
            {
                await App.Current.MainPage.DisplayAlert("JobMe", "Please change camera permission settings in Settings > Privacy.", "Ok");
                return false;
            }

            if (cameraStatus == PermissionStatus.Granted & storageStatus == PermissionStatus.Granted)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static async Task<bool> CameraPermission()
        {
            await CrossMedia.Current.Initialize();

            var cameraStatus = await Permissions.CheckStatusAsync<Permissions.Camera>();
            var storageStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
                storageStatus = await Permissions.RequestAsync<Permissions.StorageRead>();


            }
            if (cameraStatus == PermissionStatus.Denied || storageStatus == PermissionStatus.Denied)
            {
                await App.Current.MainPage.DisplayAlert("JobMe", "Please change camera permission settings in Settings > Privacy.", "Ok");
                return false;
            }

            if (cameraStatus == PermissionStatus.Granted & storageStatus == PermissionStatus.Granted)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
