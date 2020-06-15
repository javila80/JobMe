using JobMe.ViewModels;
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
public partial class Login : ContentPage
{

       
    public Login(int tipo)
    {
            LoginViewModel vm = new LoginViewModel(tipo);
            BindingContext = vm;
            vm.Navigation = Navigation;
        InitializeComponent();
    }
}
}