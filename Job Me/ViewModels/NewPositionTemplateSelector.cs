using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JobMe.ViewModels
{
    public class NewPositionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AddJobTemplate { get; set; }
        public DataTemplate AddJobDetailTemplate { get; set; }


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            CustomCell cell = (CustomCell)item;

            switch (cell.TipoHoja)
            {

                case 1:
                    return AddJobTemplate;
                case 2:
                    return AddJobDetailTemplate;

                default:
                    return AddJobTemplate;

            }
        }
    }
}
