using Acr.UserDialogs;
using JobMe.Models.Chat;
using JobMe.Services.Chat;
using JobMe.Views.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels.Employer
{
    internal class MainEmpresaViewModel : BaseViewModel
    {
        public MainEmpresaViewModel()
        {
            GetContacts();
            CheckChatStatus();

            ItemSelectedCommand = new Command(ItemSelected);
            this.DeleteCommand = new Command(this.DeleteMethod);
        }

        private async void CheckChatStatus()
        {
            App.Registra();

            App.ChatService1.OnReceivedMessage += ChatService_OnReceivedMessage;

            //Verificar que esta conectado al HUb

            if (!App.ChatService1.IsConnected)
            {
                App.ChatService1 = new TheChat.Core.Services.ChatService();

                if (Preferences.Get("UserID", 0) > 0)
                {
                    await App.ChatService1.InitAsync(Preferences.Get("UserID", 0).ToString());
                }
            }
        }

        private void ChatService_OnReceivedMessage(object sender, TheChat.Core.EventHandlers.MessageEventArgs e)
        {
            string nombre;

            if (Preferences.Get("UserType", 0) == 1) //Employee
            {
                nombre = Preferences.Get("Name", string.Empty);
            }
            else
            {
                nombre = Preferences.Get("Company", string.Empty);
            }
            JobMe.Models.Chat.ChatMessage msg = new JobMe.Models.Chat.ChatMessage();

            Device.BeginInvokeOnMainThread(() =>
            {
                //si el mensaje es para mi
                if (nombre == e.Message.Sender)
                {
                    GetContacts();
                }
            });
        }

        public async void GetContacts()
        {
            //UserType
            int userid = Preferences.Get("UserID", 0);

            if (Preferences.Get("UserType", 0) == 1)
            {
                ChatItems = await ChatService.GetContactsEmployeeAsync(userid);
            }
            else if (Preferences.Get("UserType", 0) == 2)
            {
                ChatItems = await ChatService.GetContactsEmployerAsync(userid);
            }
            else if (Preferences.Get("UserType", 0) == 0)
            {
                await App.Current.MainPage.DisplayAlert("JobMe", "Error cargando lista de contactos", "Ok");
            }

            IsVisible = ChatItems.Count == 0 ? true : false;
        }

        private Syncfusion.ListView.XForms.SfListView _ListView;

        public Syncfusion.ListView.XForms.SfListView ListView
        {
            get { return _ListView; }
            set { _ListView = value; OnPropertyChanged(); }
        }

        public Command DeleteCommand { get; set; }
        public INavigation Navigation { get; set; }
        public ICommand ItemSelectedCommand { get; set; }

        private bool _IsRunning;

        public bool IsRunning
        {
            get { return _IsRunning; }
            set { _IsRunning = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ChatDetail> chatItems;

        public ObservableCollection<ChatDetail> ChatItems
        {
            get
            {
                return this.chatItems;
            }

            set
            {
                if (this.chatItems == value)
                {
                    return;
                }

                this.chatItems = value;
                this.OnPropertyChanged();
            }
        }

        private async void ItemSelected(object obj)
        {
            var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;
            var z = (ChatDetail)x;

            if (Preferences.Get("UserType", 0) == 1)
            {
                z.TipoMensaje = 1;
            }
            else
            {
                z.TipoMensaje = 2;
            }

            try
            {
                await Navigation.PushAsync(new ChatMessagePage(z));
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private async void DeleteMethod(object obj)
        {
            try
            {
                if (await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
                {
                    CancelText = "Cancel",
                    OkText = "Ok",
                    Message = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "¿Estás seguro de eliminar el chat?" : "Are you sure you want to delete the chat ?",
                }))
                {
                    var x = (ChatDetail)obj;

                    ChatContact ch = new ChatContact()
                    {
                        UserID = x.UserID,
                        ContactUserID = x.ContactID,
                        IDPosition = x.IDPosition
                    };

                    //Agregar el metodo de borrado de position
                    if (await Services.Chat.ChatService.DeleteContactAsync(ch))
                    {
                        //if (ItemIndex >= 0)

                        var takeoffsSelected = ChatItems.Where(z => z.IDPosition == ch.IDPosition && z.UserID == ch.UserID && z.ContactID == ch.ContactUserID).FirstOrDefault();
                        ChatItems.Remove(takeoffsSelected);

                        await Application.Current.MainPage.DisplayAlert("JobMe",
                            App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Se elimino correctamente el chat" : "Chat successfully deleted",
                            "OK");
                        //ListView.ResetSwipe();
                        //Activar la etiqueta de no tienes contactos
                        IsVisible = ChatItems.Count > 0 ? false : true;
                        //MessagingCenter.Send<EditJobViewModel, int>(this, "UpdateList", 1);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe",
                            App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ocurrío un error al eliminar el chat" : "Error deleting chat",
                            "OK");
                    }
                }

                //ListView.ResetSwipe();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("JobMe",
                          App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ocurrío un error al eliminar el chat" : "Error deleting chat",
                          "OK");
                //throw;
            }
        }
    }
}