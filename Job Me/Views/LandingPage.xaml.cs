using JobMe.ViewModels;
using JobMe.Views.Employee;
using JobMe.Views.Employer;
using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {

        LandingPageViewModel vm = new LandingPageViewModel();
        public LandingPage()
        {

            vm.Navigation = Navigation;
            BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            btnlogin.IsEnabled = true;
            btnsign.IsEnabled = true;
            base.OnAppearing();
        }

        private async void SfButton_Clicked(object sender, EventArgs e)
        {
            btnsign.IsEnabled = false;

            //switch (((Opciones)comboBox.SelectedItem).ID)
            //{
            //    case 1: //Empleado
            //        await Navigation.PushAsync(new TermsView(((Opciones)comboBox.SelectedItem).ID) { });

            //        break;
            //    case 2: //Empresa

            //  await Navigation.PushAsync(new TermsView(((Opciones)comboBox.SelectedItem).ID));
            await Navigation.PushAsync(new TermsView(((Opciones)comboBox.SelectedItem).ID)
            { Title = App.Idioma.TwoLetterISOLanguageName == "es" ? "Términos y condiciones" : "Terms & conditions" });
            //        break;
            //    default:
            //        break;

            //}
            //switch (z)
            //{
            //    case "Employees": //Empleado


            //        await Navigation.PushAsync(new TermsView(z) { });

            //      //  await Navigation.PushAsync(new RegisterEmployeeView() { BackgroundColor = Color.White });


            //        break;
            //    case "Employers": //Empresa

            //        await Navigation.PushModalAsync(new TermsView(z));

            //       // await Navigation.PushAsync(new RegisterEmployerView() { BackgroundColor = Color.White });

            //        break;
            //    default:
            //        break;

            //}
        }

        private async void btnlogin_Clicked(object sender, EventArgs e)
        {
            btnlogin.IsEnabled = false;

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available


                // var z = comboBox.SelectedItem.ToString();
                switch (((Opciones)comboBox.SelectedItem).ID)
                {
                    case 1: //Empleado
                        await Navigation.PushAsync(new Login(1));

                        break;
                    case 2: //Empresa

                        await Navigation.PushAsync(new Login(2));
                        break;
                    default:
                        break;

                }


            }
            else
            {
                await DisplayAlert("JobMe", App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Necesitas internet para usar JobMe" : "You need internet to use JobMe", "Ok");
                btnlogin.IsEnabled = true;
            }


        }


    }
}