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
    public partial class PrivacyView : ContentPage
    {
        Stream fileStream;
        public PrivacyView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                fileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("JobMe.Assets.Privacy.pdf");
                //Load the PDF
                pdfViewerControl.LoadDocument(fileStream);
            }
            catch (Exception)
            {

                //throw;
            }
          
        }

    }
}