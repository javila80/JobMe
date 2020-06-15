using JobMe.Views.Employer;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JobMe
{
    class NewEmployerTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EssentialTemplate { get; set; }
        public DataTemplate ComplexTemplate { get; set; }

        public DataTemplate AddJobTemplate { get; set; }

        public DataTemplate AddJobDetailTemplate { get; set; }
        public NewEmployerTemplateSelector()
        {
            EssentialTemplate = new DataTemplate(typeof(EmpresaEssentialView));
            //AddJobTemplate = new DataTemplate(typeof(AddJobView));
            //AddJobDetailTemplate = new DataTemplate(typeof(AddJobDetailView));
           
        }

           protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            CustomCell cell = (CustomCell)item;


            switch (cell.TipoHoja)
            {
                case 1:
                    //var mytemplate = new DataTemplate(typeof(EssentialTemplate));
                    EssentialTemplate.SetValue(BaseTemplate.ParentBindingContextProperty, container.BindingContext);

                    return EssentialTemplate;
                //case "2":
                //    return AddJobTemplate;
                //case "3":
                //    return AddJobDetailTemplate;
                default:
                    return EssentialTemplate;

            }

            // return AddJobTemplate;
        }

     
    }
}


