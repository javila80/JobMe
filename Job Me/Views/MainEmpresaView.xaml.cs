using JobMe.Services.Chat;
using JobMe.ViewModels.Employer;
using JobMe.Views.Employer;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainEmpresaView : ContentPage
    {
        private MainEmpresaViewModel vm = new MainEmpresaViewModel();

        public MainEmpresaView()
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditEmployerView() { Title = "Edit " });
        }

        protected override void OnAppearing()
        {
            var z = tabview.SelectedIndex;
            MessagingCenter.Send<MainEmpresaView, int>(this, "Status", 1);

            base.OnAppearing();
        }

        private async void tabview_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {
            if (e.Index == 2)
            {
                // vm.IsRunning = true;
                //vm.GetContacts();
                int userid = Preferences.Get("UserID", 0);
                //    ChatItems = null;
                if (Preferences.Get("UserType", 0) == 1)
                {
                    var newList = await ChatService.GetContactsEmployeeAsync(userid);

                    vm.ChatItems = newList;

                    //vm.ChatItems = await ChatService.GetContactsEmployeeAsync(userid);
                }
                else if (Preferences.Get("UserType", 0) == 2)
                {
                    var newList = await ChatService.GetContactsEmployerAsync(userid);

                    vm.ChatItems = newList;

                    //vm.ChatItems = await ChatService.GetContactsEmployerAsync(userid);
                }

                vm.IsVisible = vm.ChatItems.Count == 0 ? true : false;
                //  vm.IsRunning = false;

                //Actualiza la lista de contactos
                //MessagingCenter.Send<MainEmployeeView>(this, "Hi");
                //GetCandidatesLiked(Preferences.Get("UserID", 0));
            }
        }

        //private async void tabview_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        //{
        //    if (e.Index == 2)
        //    {
        //        vm.IsRunning = true;
        //        //vm.GetContacts();
        //        int userid = Preferences.Get("UserID", 0);
        //        //    ChatItems = null;
        //        if (Preferences.Get("UserType", 0) == 1)
        //        {
        //            vm.ChatItems = await ChatService.GetContactsEmployeeAsync(userid);
        //        }
        //        else if (Preferences.Get("UserType", 0) == 2)
        //        {
        //            vm.ChatItems = await ChatService.GetContactsEmployerAsync(userid);
        //        }

        //        vm.IsRunning = false;

        //        //Actualiza la lista de contactos
        //        //MessagingCenter.Send<MainEmployeeView>(this, "Hi");
        //        //GetCandidatesLiked(Preferences.Get("UserID", 0));
        //    }
        //}
    }
}