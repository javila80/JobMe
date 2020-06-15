using JobMe.Models;
using JobMe.ViewModels.Employer;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMoreContacts : ContentPage
    {
       
        AddMoreContactsViewModel vm = new AddMoreContactsViewModel();
        public AddMoreContacts(int idCompany)
        {
            InitializeComponent();

            vm.myIDcompany = idCompany;
            vm.Navigation = Navigation;
            BindingContext = vm;

        }

      
    }
}