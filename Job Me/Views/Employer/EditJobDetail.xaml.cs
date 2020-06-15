using JobMe.ViewModels.Employer;
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
    public partial class EditJobDetail : ContentPage
    {

       // EditJobDetailViewModel vm = new EditJobDetailViewModel();
        public EditJobDetail(int idposition)
        {


            InitializeComponent();
        }



    }
}