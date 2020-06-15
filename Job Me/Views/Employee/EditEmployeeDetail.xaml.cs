using JobMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Employee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditEmployeeDetail : ContentPage
    {
        
        public EditEmployeeDetail(int Tipo)
        {
            MainEmployeeViewModel vm = new MainEmployeeViewModel(Tipo);
            vm.Navigation = Navigation;
            InitializeComponent();
            BindingContext = vm;
        }
    }
}