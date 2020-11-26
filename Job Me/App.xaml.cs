using System;
using System.IO;
using System.Runtime.CompilerServices;
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
using JobMe.Data;
using JobMe.Models.Chat;
using TheChat.Core.Services;
using JobMe.Views.Employee.Register;
using JobMe.Views.Chat;
//using UserNotifications;

namespace JobMe
{
    public partial class App : Application
    {
        static UsersDatabase database;

        public static UsersDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UsersDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.db3"));
                }
                return database;
            }
        }

        public static INavigation Navigation { get; set; }
        public static double ScreenHeight;
        public static double ScreenWidth;
        public static HubConnection hubConnection;

        public static IChatService ChatService1;
        public static System.Globalization.CultureInfo Idioma;

        public static bool chat;

        public App(bool shallNavigate )
        {
            try
            {
                Idioma = System.Globalization.CultureInfo.CurrentCulture;
            }
            catch (Exception)
            {
            }
            //Device.SetFlags(new string[] { "MediaElement_Experimental" });
            //Device.SetFlags(new string[] { "MediaElement_Experimental" });
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ1MzA0QDMxMzgyZTMxMmUzMEhGN0JDK081MlJqLzRqMWxQcW5SN3JzUXp2K3BONWpRMkdNT3N3cThCWVE9");
            InitializeComponent();

            //Application.Current.MainPage = new NavigationPage(new ChatNew() { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };

            //Mensaje para navegar al tab desde IOs;
            MessagingCenter.Subscribe<object, string>(this, "Push", async (sender, favoriteID) =>
            {
                //var favorite = new AboutPage();
                //
                //Current.MainPage = new NavigationPage(new MainEmployeeView(2) { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                //await (MainPage as NavigationPage).PushAsync(favorite, true);

                if (Preferences.Get("UserType", 0) == (int)UserType.Employee)
                {
                    Current.MainPage = new NavigationPage(new MainEmployeeView(2) { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                }
                else if (Preferences.Get("UserType", 0) == (int)UserType.Employer)
                {
                    Current.MainPage = new NavigationPage(new MainEmpresaView(2) { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                }
            });

            var n = shallNavigate;

            shallNavigate = true;

            if (Preferences.Get("UserID", 0) > 0 && Preferences.Get("UserType", 0) > 0 && !shallNavigate)
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
            else if (Preferences.Get("UserID", 0) > 0 && Preferences.Get("UserType", 0) > 0 && shallNavigate )
            {
                if (Preferences.Get("UserType", 0) == (int)UserType.Employee)
                {
                    //var chatdetail = new ChatDetail()
                    //{
                    //    ContactID = 1252,
                    //    IDPosition = 1254,
                    //};

                    //Current.MainPage = new NavigationPage(new MainEmployeeView(2) { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };

                    //Current.MainPage.Navigation.PushAsync(new ChatMessagePage(chatdetail));

                    Current.MainPage = new NavigationPage(new MainEmployeeView(2) { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                }
                else if (Preferences.Get("UserType", 0) == (int)UserType.Employer)
                {
                    Current.MainPage = new NavigationPage(new MainEmpresaView(2) { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                }
            }
            else
            {
                MainPage = new NavigationPage(new LandingPage()) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange) };
            }


            //if (shallNavigate)
            //{
            //    MainPage = new NavigationPage(new DashboardPage());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new MainPage());
            //}

            Navigation = Current.MainPage.Navigation;
        }

        protected override async void OnStart()
        {
            try
            {
                await Registra();

                await LogService.WriteLogAsync(Preferences.Get("UserID", 0));
            }
            catch (Exception ex)
            {
                // throw;

            }

            // Handle when your app starts
        }

        protected override async void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override async void OnResume()
        {
            try
            {

                //Actualiza el token de las push
                if (Device.RuntimePlatform == Device.iOS)
                {
                    MessagingCenter.Send(this, "DeleteToken");
                }

                //var favorite = new AboutPage();
                //   Current.MainPage = new NavigationPage(new MainEmployeeView(2) { Title = "Job Me" }) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange), BarTextColor = Color.White };
                //await (MainPage as NavigationPage).PushAsync(favorite, true);


                //Registra();
                await LogService.WriteLogAsync(Preferences.Get("UserID", 0));
            }
            catch (Exception ex)
            {
                // throw;
            }
            // Handle when your app resumes
        }

        public static async Task Registra()
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