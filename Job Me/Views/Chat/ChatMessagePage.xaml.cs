using JobMe.Models.Chat;
using JobMe.ViewModels.Chat;
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Chat
{
    /// <summary>
    /// Page to show chat message list
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatMessagePage : ContentPage
    {
        //ChatMessageViewModel vm;
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatNew" /> class.
        /// </summary>
        ///
        public ChatDetail selectedchat { get; set; }

        public int Count { get; set; }

        private ChatMessageViewModel viewmodel;

        public ChatMessagePage(ChatDetail selecteditem)
        {
            ChatMessageViewModel vm = new ChatMessageViewModel(selecteditem)
            {
                Navigation = Navigation,
                listView = listView
            };

            viewmodel = vm;
            BindingContext = vm;
            vm.Navigation = Navigation;
            selectedchat = selecteditem;

            InitializeComponent();
            listView.IsVisible = false;
            //listView.Loaded += ListView_Loaded;

            vm.listView = this.listView;

            //visualContainer = ListView.GetVisualContainer();
            // var x = App.ScreenHeight;

            listView.HeightRequest = App.ScreenHeight - 120;

            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor
            {
                PropertyName = "Time",
                KeySelector = obj =>
                {
                    var item = obj as ChatMessage;
                    return item.Time.Date;
                }
            });

            listView.IsVisible = true;
        }

        private void ListView_Loaded(object sender, Syncfusion.ListView.XForms.ListViewLoadedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                listView.IsVisible = false;

                // listView.LayoutManager.ScrollToRowIndex(listView.DataSource.DisplayItems.Count - 1, true);

                listView.IsVisible = true;
            });

            //(ListView.LayoutManager as LinearLayout).ScrollToRowIndex(vm.ChatMessageInfo.Count - 1, true);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            App.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            //Verificar que este conectado al hub
            if (!App.ChatService1.IsConnected)
            {
                App.ChatService1 = new TheChat.Core.Services.ChatService();

                if (Preferences.Get("UserID", 0) > 0)
                {
                    await App.ChatService1.InitAsync(Preferences.Get("UserID", 0).ToString());

                    App.ChatService1.OnReceivedMessage -= viewmodel.ChatService_OnReceivedMessage;
                    App.ChatService1.OnReceivedMessage += viewmodel.ChatService_OnReceivedMessage;
                }
            }
            else
            {
                App.ChatService1.OnReceivedMessage -= viewmodel.ChatService_OnReceivedMessage;
                App.ChatService1.OnReceivedMessage += viewmodel.ChatService_OnReceivedMessage;
            }

            if (Count < 1)
            {
                var z = await Services.Chat.ChatService.GetMessagesNewAsync(selectedchat);
                Count = z.Count + 1;
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                if (Count > 0)
                {
                    listView.IsVisible = false;

                    ((LinearLayout)listView.LayoutManager).ScrollToRowIndex(
                      listView.DataSource.DisplayItems.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.End, true);

                    //listView.LayoutManager.ScrollToRowIndex(listView.DataSource.DisplayItems.Count - 1, true);

                    listView.IsVisible = true;
                }
            });
            //  listView.LayoutManager.ScrollToRowIndex(listView.DataSource.DisplayItems.Count - 1, true);
            //App.ChatService1.OnReceivedMessage += ChatService_OnReceivedMessage;
        }

        protected override void OnDisappearing()
        {
            App.ChatService1.OnReceivedMessage -= viewmodel.ChatService_OnReceivedMessage;
            base.OnDisappearing();
            App.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Pan);
        }

        private void ChatEntry_Focused(object sender, FocusEventArgs e)
        {
            MessagingCenter.Send<ChatMessagePage, int>(this, "UpdateList", 1);
        }

        //private void ListView_Loaded(object sender, ListViewLoadedEventArgs e)
        //{
        //    //ScrollView scrollView = listView.Parent as ScrollView;
        //    //this.listView.HeightRequest = scrollView.Height;

        //        ((LinearLayout)ListView.LayoutManager).ScrollToRowIndex(
        //           ListView.DataSource.DisplayItems.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.End, true);

        //}

        //private async void ChatService_OnReceivedMessage(object sender, Core.EventHandlers.MessageEventArgs e)
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        if (Messages.All(x => x.Id != e.Message.Id))
        //        {
        //            if (e.Message.TypeInfo.Name == nameof(UserConnectedMessage))
        //            {
        //                var users = await ChatService.GetUsersGroup(GroupName);
        //                Users = new ObservableCollection<User>(users);
        //            }
        //            if (e.Message.TypeInfo.Name != nameof(UserConnectedMessage))
        //            {
        //                //var user = Users.FirstOrDefault(x => x.UserId ==
        //                //    e.Message.Sender);
        //                //e.Message.Color = user.Color;
        //                //e.Message.Avatar = user.Avatar;
        //            }
        //            Messages.Add(e.Message);
        //        }
        //    });
        //}
    }
}