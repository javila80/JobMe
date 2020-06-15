using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobMe.Services;
using JobMe.Views;
using JobMe.Views.Employee;
using Xamarin.Essentials;
using static JobMe.ViewModels.LoginViewModel;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using Acr.UserDialogs;
using TheChat.Core.Services;
using JobMe.Views.Employee.Register;
using JobMe.Views.Chat;

namespace JobMe
{
    public partial class App : Application
    {
        public static INavigation Navigation { get; set; }
        public static double ScreenHeight;
        public static double ScreenWidth;
        public static HubConnection hubConnection;

        public static IChatService ChatService1;
        public static System.Globalization.CultureInfo Idioma;

        public App()
        {
            try
            {
                Idioma = System.Globalization.CultureInfo.CurrentCulture;
            }
            catch (Exception)
            {
            }

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ1MzA0QDMxMzgyZTMxMmUzMEhGN0JDK081MlJqLzRqMWxQcW5SN3JzUXp2K3BONWpRMkdNT3N3cThCWVE9");
            InitializeComponent();

            //Application.Current.MainPage = new NavigationPage(new ChatNew() { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };

            //return;

            if (Preferences.Get("UserID", 0) > 0 && Preferences.Get("UserType", 0) > 0)
            {
                if (Preferences.Get("UserType", 0) == (int)UserType.Employee)
                {
                    Current.MainPage = new NavigationPage(new MainEmployeeView() { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                }
                else if (Preferences.Get("UserType", 0) == (int)UserType.Employer)
                {
                    Current.MainPage = new NavigationPage(new MainEmpresaView() { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                }
            }
            else
            {
                MainPage = new NavigationPage(new LandingPage()) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange) };
            }

            Navigation = Current.MainPage.Navigation;
        }

        protected override void OnStart()
        {
            try
            {
                Registra();

                LogService.WriteLogAsync(Preferences.Get("UserID", 0));
            }
            catch (Exception ex)
            {
                // throw;
            }

            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            try
            {
                Registra();
                LogService.WriteLogAsync(Preferences.Get("UserID", 0));
            }
            catch (Exception ex)
            {
                // throw;
            }
            // Handle when your app resumes
        }

        public static async void Registra()
        {
            ChatService1 = new TheChat.Core.Services.ChatService();

            if (!ChatService1.IsConnected)
            {
                if (Preferences.Get("UserID", 0) > 0)
                {
                    await ChatService1.InitAsync(Preferences.Get("UserID", 0).ToString());
                }
            }
        }
    }
}