using JobMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordView : ContentPage
    {

        private string _lbForgot;

        public string Forgot
        {
            get { return _lbForgot; }
            set { _lbForgot = value; OnPropertyChanged(); }
        }

        private string _hepl;

        public string Help
        {
            get { return _hepl; }
            set { _hepl = value; OnPropertyChanged(); }
        }

        private string _send;

        public string Send
        {
            get { return _send; }
            set { _send = value; OnPropertyChanged(); }
        }

        private string _Back;

        public string Back
        {
            get { return _Back; }   
            set { _Back = value; OnPropertyChanged(); }
        }

        private string _Usuario ;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; OnPropertyChanged(); }
        }



        public ForgotPasswordView()
        {
            InitializeComponent();
            BindingContext = this;
            Send = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Enviar" : "Send";
            Help = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Déjanos ayudarte" : "Let us help you";
            Back = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Atrás" : "Back";
            Forgot = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Olvidaste tu contraseña?" : "Forgot your pasword?";
            Usuario = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Usuario" : "Username";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            if (txtuser.Text != string.Empty || txtuser.Text != null)
            {

                btnsend.IsEnabled = false;
                if (await Services.JobMe.ForgotPassword(txtuser.Text))
                {
                    await DisplayAlert("JobMe", "You will receive a mail with your password", "Ok");

                    // Go to login
                    await Navigation.PopModalAsync();

                }
                else
                {
                    await DisplayAlert("JobMe", "Error al recuperar el usuario", "Ok");
                }

            }


        }

        private async void btnback_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}