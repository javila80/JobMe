using JobMe.ViewModels;
using JobMe.ViewModels.Employer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditEmployerView : ContentPage
    {
        EditEmployerViewModel vm = new EditEmployerViewModel();
        public EditEmployerView()
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("JobMe",
                 App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "¿Estás seguro que quieres borrar la cuenta?" : "Are you sure you want to delete your account, this action can´t be undone",
                "Yes", "No");

            int userid = Preferences.Get("UserID", 0);

            if (answer)
            {
                if (await Services.UserService.DeleteUserAsync(userid))
                {
                    Application.Current.MainPage = new NavigationPage(new LandingPage()) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange) };
                }
                else
                {
                    await DisplayAlert("JobMe", "Ocurrio un error al borra la cuenta", "Ok");
                }
            }
        }
    }
}