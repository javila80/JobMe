using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrivacyHtml : ContentPage
    {
        public PrivacyHtml()
        {
            InitializeComponent();
            GetFileContent();


        }

        public void GetFileContent()
        {
            string content;

            var stream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("JobMe.Assets.page1.html");
            
            using (var reader = new StreamReader(stream))
                content = reader.ReadToEnd();

            webview1.Source = content;
        }


    }
}