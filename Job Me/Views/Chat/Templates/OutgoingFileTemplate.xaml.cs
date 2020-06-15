using JobMe.Models.Chat;
using JobMe.Views.Chat.Selectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Chat.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OutgoingFileTemplate : BindableViewCell
    {
              

        public Command TappedCommand { get; set; }

        public OutgoingFileTemplate()
        {
           
            InitializeComponent();
            //TappedCommand = new Command(ClikcMethod);
            //BindingContext = this;
        }

        private void ClikcMethod(object obj)
        {

            string url = EndPoint.BLOB_ENDPOINT+ ((ChatMessage)obj).Message;
            Launcher.OpenAsync(new Uri(url));

        }

        
    }
}