using JobMe.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Employee.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterNew : ContentPage
    {
        public RegisterNew()
        {
            InitializeComponent();
            BindingContext = new RegisterEmployeeViewmodel();
        }
    }
}