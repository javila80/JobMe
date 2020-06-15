using Acr.UserDialogs;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TheChat.Core.Models;
using TheChat.Core.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TheChat.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        public string UserName { get; set; }
        public bool IsBusy { get; set; }
        public ICommand ConnectCommand => new Command(async () =>
        {
            if (!IsBusy)
            {
                IsBusy = true;

                dialogs.ShowLoading("Connecting");

                if (UserName == "juan")
                {
                                       
                    await ChatService.InitAsync("1");
                    
                    Tuple<string, string> data =
                           new Tuple<string, string>("1", "SalaChat1");
                    await CoreMethods.PushPageModel<ChatViewModel>(data);

                }
                else if (UserName == "rodrigo")
                {
                    await ChatService.InitAsync("2");
                    Tuple<string, string> data =
                           new Tuple<string, string>("2", "SalaChat1");
                    await CoreMethods.PushPageModel<ChatViewModel>(data);
                }
                else
                {
                    await ChatService.InitAsync("643");
                    Tuple<string, string> data =
                           new Tuple<string, string>("643", "SalaChat1");
                    await CoreMethods.PushPageModel<ChatViewModel>(data);
                }


                //Tuple<string, string> data =
                //       new Tuple<string, string>(UserName, "SalaChat");
                //await CoreMethods.PushPageModel<ChatViewModel>(data);



                dialogs.HideLoading();

                IsBusy = false;
            }
        });

        IChatService ChatService;
        IUserDialogs dialogs;

        public ICommand EnterRoomCommand { get; set; }
        public Room CurrentRoom { get; set; }

        public LoginViewModel(IChatService _chatService, IUserDialogs _userDialogs)
        {
            ChatService = _chatService;
            dialogs = _userDialogs;
        }

    }
}
