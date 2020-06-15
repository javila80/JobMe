using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobMe.Models.Chat;
using JobMe.ViewModels.Chat;
using Syncfusion.DataSource;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Chat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatNew : ContentPage
    {
        public ChatNew()
        {


            InitializeComponent();

            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor
            {
                PropertyName = "Time",
                KeySelector = obj =>
                {
                    var item = obj as ChatMessage;
                    return item.Time.Date;
                }
            });
        }
    }
}