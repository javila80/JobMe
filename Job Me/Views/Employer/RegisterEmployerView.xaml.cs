using JobMe.Behaviors;
using JobMe.Models;
using JobMe.ViewModels.Employer;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static JobMe.ViewModels.AddJobViewModel;

namespace JobMe.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterEmployerView : ContentPage
    {

        public RegisterEmployerView()
        {

            RegisterEmployerViewModel vm = new RegisterEmployerViewModel();
            InitializeComponent();
            //VerificaPermisos();
            vm.Navigation = Navigation;
            BindingContext = vm;
            
        }

        private async void VerificaPermisos()
        {

            try
            {



                var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
                if (status != PermissionStatus.Granted)
                {
                    //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    //{
                    //    await DisplayAlert("Need location", "Gunna need to use camera", "OK");
                    //}
                    status = await Permissions.RequestAsync<Permissions.Camera>();
                    //status = await CrossPermissions.Current.RequestPermissionAsync<CameraPermission>();
                }

                if (status == PermissionStatus.Granted)
                {
                    //Query permission
                }
                else if (status != PermissionStatus.Unknown)
                {
                    //location denied
                }
            }
            catch (Exception ex)
            {
               await DisplayAlert("JobMe", ex.Message, "Ok");
                //Something went wrong
            }
        }

    }

}