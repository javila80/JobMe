using Acr.UserDialogs;
using JobMe.ViewModels;

using Syncfusion.SfRotator.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace JobMe.Views.Employee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterEmployeeView : ContentPage
    {

        MainEmployeeViewModel vm = new MainEmployeeViewModel();
        public RegisterEmployeeView()
        {
            InitializeComponent();

           // VerificaPermisos();
            vm.Navigation = Navigation;
            BindingContext = vm;

        }


        protected override bool OnBackButtonPressed()
        {
            //Deshabilita la navegacion hacia atras
            return true;
            // return base.OnBackButtonPressed();
        }

        private async void VerificaPermisos()
        {

            try
            {



                var status =  await Permissions.CheckStatusAsync<Permissions.Camera>();
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        private async void carouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            // 
            UserDialogs.Instance.ShowLoading("Loading...");
            await Task.Delay(500);
            UserDialogs.Instance.HideLoading();
            var z = e.PreviousItem;


        }
        private bool _isLocked;


        private async void rotator_SelectedIndexChanged(object sender, SelectedIndexChangedEventArgs e)
        {

            if (_isLocked) return;
            _isLocked = true; /* your code here */

          

            rotator.EnableSwiping = false;
            if (rotator.SelectedIndex == 1)
            {
                if (!await vm.ValidaEssential())
                {
                    rotator.SetValue(SfRotator.SelectedIndexProperty, rotator.SelectedIndex - 1);
                    rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
                else
                {
                    rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }


            }
            else if (rotator.SelectedIndex == 2)
            {
                if (!await vm.ValidaInterest())
                {
                    rotator.SetValue(SfRotator.SelectedIndexProperty, rotator.SelectedIndex - 1);
                    rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
                else
                {
                    rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
            }
            else if (rotator.SelectedIndex == 3)
            {
                if (!await vm.ValidaAcademics())
                {
                    rotator.SetValue(SfRotator.SelectedIndexProperty, rotator.SelectedIndex - 1);
                    rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
                else
                {
                    rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
            }
            else if (rotator.SelectedIndex == 4)
            {
                if (!await vm.ValidaVideoAcademics())
                {
                    rotator.SetValue(SfRotator.SelectedIndexProperty, rotator.SelectedIndex - 1);
                    rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
                else
                {
                    rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
            }
            else if (rotator.SelectedIndex != 0)
            {
                UserDialogs.Instance.ShowLoading();
                await Task.Delay(600);
                UserDialogs.Instance.HideLoading();
            }

            rotator.EnableSwiping = true;

            _isLocked = false;

            //Aqui se podria validar
            //rotator.EnableSwiping = false;
            //await vm.Validame(sender);

            //rotator.EnableSwiping = true;
        }
    }
}