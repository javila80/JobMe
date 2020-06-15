using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Employee.Register
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class EmployeeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EssentialTemplate { get; set; }
        public DataTemplate InterestTemplate { get; set; }
        public DataTemplate AcademicsTemplate { get; set; }
        public DataTemplate AcademicsVideoTemplate { get; set; }
        public DataTemplate JobsVTemplate { get; set; }
        public DataTemplate JobsVideoTemplate { get; set; }
        public DataTemplate OthersTemplate { get; set; }
        public DataTemplate uploadPhotoTemplate { get; set; }
        public DataTemplate uploadCVTemplate { get; set; }

        //public EmployeeTemplateSelector()
        //{
        //    this.EssentialTemplate = new DataTemplate(typeof(EssentialTemplate));
        //    this.InterestTemplate = new DataTemplate(typeof(InterestTemplate));
        //}

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            CustomCell cell = (CustomCell)item;

            switch (cell.TipoHoja)            {

                case 1:
                    return EssentialTemplate;
                case 2:
                    return InterestTemplate;
                case 3:
                    return AcademicsTemplate;
                case 4:
                    return AcademicsVideoTemplate;
                case 5:
                    return JobsVTemplate;
                case 6:
                    return JobsVideoTemplate;
                case 7:
                    return OthersTemplate;
                case 8:
                    return uploadPhotoTemplate;
                case 9:
                    return uploadCVTemplate;
                default:
                    return InterestTemplate;

            }
        }
    }
}
