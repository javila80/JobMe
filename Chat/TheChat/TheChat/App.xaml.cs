using Acr.UserDialogs;
using FreshMvvm;
using System;
using TheChat.Core.Services;
using TheChat.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TheChat
{
    public partial class App : Application
    {
        IUserDialogs n = UserDialogs.Instance;
        IChatService ChatService;

       
        public App()
        {
            InitializeComponent();


            ConfigureContainer();

            var loginPage =
                FreshPageModelResolver
                    .ResolvePageModel<LoginViewModel>();

            var navPage =
                new FreshNavigationContainer(loginPage);

            MainPage = navPage;



        }

        private void ConfigureContainer()
        {
            FreshIOC.Container.Register<IChatService, ChatService>();
            FreshIOC.Container.Register<IUserDialogs>(UserDialogs.Instance);
        }

        protected override void OnStart()
        {
            //Registra();
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        //private async void Registra()
        //{

        //    ChatService1 = new TheChat.Core.Services.ChatService();

        //    if (Preferences.Get("UserID", string.Empty) != string.Empty)
        //    {

        //        await ChatService1.InitAsync(Preferences.Get("UserID", string.Empty));
        //    }


        //}
    }
}
