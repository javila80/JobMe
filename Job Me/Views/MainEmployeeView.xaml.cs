using JobMe.Services.Chat;
using JobMe.ViewModels;
using JobMe.Views.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainEmployeeView : ContentPage
    {
        private HomeViewModel vm = new HomeViewModel();

        public MainEmployeeView()
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            var z = tabview.SelectedIndex;

            if (z == 0) // Actualiza los datos del tab HOME
            {
                MessagingCenter.Send<MainEmployeeView, int>(this, "Status", 1);
            }

            if (z == 2)
            {
                MessagingCenter.Send<MainEmployeeView>(this, "Hi");
            }

            base.OnAppearing();
        }

        private async void TapGestureRecognizer_Premium(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditEmployeeView() { Title = "Edit profile" });
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

                    foreach (var item in newList)
                    {
                        item.ContadorVisible = item.CuentaMensajes > 0 ? true : false;
                    }

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
            }
        }

        private void tabview_TabItemTapped(object sender, Syncfusion.XForms.TabView.TabItemTappedEventArgs e)
        {
            //var tabIndex = tabview.Items.IndexOf(e.TabItem);

            //if (tabview.Items[tabIndex].Content == null)
            //{
            //    tabview.Items[tabIndex].Content = null;
            //}
        }
    }
}