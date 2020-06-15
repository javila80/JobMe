using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JobMe.Droid;
using System.ComponentModel;
using Android.Graphics;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(handler:typeof(JobMe.ChatEntry), target:typeof(ChatEntryRenderer))]

namespace JobMe.Droid
{
    public class ChatEntryRenderer : EditorRenderer
    {
        public ChatEntryRenderer(Context context) : base(context)
        { 
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }

        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == Entry.TextProperty.PropertyName)
        //    {
        //        base.Control.Text = base.Element.Text;
        //        if (base.Control.IsFocused)
        //        {
        //            base.Control.SetSelection(base.Control.Text.Length);
        //        }
        //        return;
        //    }

        //    base.OnElementPropertyChanged(sender, e);

        //}


    }
}