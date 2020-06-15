using JobMe.ViewModels.Employer;
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
    public partial class SuccesRegisterEmployer : ContentPage
    {
        public SuccesRegisterEmployer()
        {
            InitializeComponent();
            carouselView.HeightRequest=  App.ScreenHeight - 10;
            RegisterEmployerViewModel vm = new RegisterEmployerViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;


        }

      
    }
}