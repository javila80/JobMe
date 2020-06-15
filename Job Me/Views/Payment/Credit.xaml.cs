using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Credit : ContentPage
    {
        public Credit()
        {
            InitializeComponent();
        }

        private void GestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (Device.RuntimePlatform != Device.UWP)
            {
                date_Picker.Focus();
            }
        }
        protected override void OnAppearing()
        {
            popupLayout.IsOpen = true;
            base.OnAppearing();
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            popupLayout.IsOpen = false;
        }
    }
}