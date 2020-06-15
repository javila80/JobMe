using JobMe.ViewModels;
using JobMe.Views.Employee;
using JobMe.Views.Employer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermsView : ContentPage
    {
        Stream fileStream;


        public TermsView()
        {

            InitializeComponent();



        }

        public int TipoLogin { get; set; }
        public TermsView(int tipo)
        {

            TipoLogin = tipo;

            InitializeComponent();

            btnaccept.IsEnabled = false;
        }

        protected override void OnAppearing()
        {

            lbaceptar.Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Acepto términos y condiciones" : "Accept terms and conditions";
            btnaccept.Text = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Aceptar" : "Accept";
            base.OnAppearing();

            try
            {
                fileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("JobMe.Assets.Termsandconditions.pdf");
                //Load the PDF
                pdfViewerControl.LoadDocument(fileStream);
            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            btnaccept.IsEnabled = chkterms.IsChecked;
        }

        private bool _isLocked;
        private async void btnaccept_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (_isLocked) return;
                _isLocked = true;

                //var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
                //if (status != PermissionStatus.Granted)
                //{
                //    //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                //    //{
                //    //    await DisplayAlert("Need location", "Gunna need to use camera", "OK");
                //    //}
                //    status = await Permissions.RequestAsync<Permissions.Camera>();
                //    //status = await CrossPermissions.Current.RequestPermissionAsync<CameraPermission>();
                //}

                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    // Connection to internet is available


                    switch (TipoLogin)
                    {
                        case 1: //Empleado

                            await Navigation.PushAsync(new RegisterEmployeeView() { BackgroundColor = Color.White });
                            pdfViewerControl.Unload();

                            break;
                        case 2: //Empresa

                            //await Navigation.PushModalAsync(new TermsView());

                            await Navigation.PushAsync(new RegisterEmployerView() { BackgroundColor = Color.White });
                            pdfViewerControl.Unload();
                            break;
                        default:
                            break;

                    }

                }
                else
                {

                    await DisplayAlert("JobMe", App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Necesitas internet para usar JobMe" : "You need internet to use JobMe", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("JobMe", ex.Message, "Ok");
                throw;
            }
            

            //await Task.Delay(600);
            _isLocked = false;
        }

        private async void btncancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }



        protected override void OnDisappearing()
        {

            base.OnDisappearing();
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}