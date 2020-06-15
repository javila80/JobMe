using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JobMe
{
    class BaseTemplate : ContentView
    {

        public static BindableProperty ParentBindingContextProperty = BindableProperty.Create(nameof(ParentBindingContext), typeof(object), typeof(BaseTemplate), null);

        public object ParentBindingContext
        {
            get { return GetValue(ParentBindingContextProperty); }
            set { SetValue(ParentBindingContextProperty, value); }
        }

    }
}
