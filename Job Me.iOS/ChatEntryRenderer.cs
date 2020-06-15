using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using JobMe.iOS;
using JobMe.ViewModels.Chat;
using JobMe.Views.Chat;
using Syncfusion.XForms.Border;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(JobMe.ChatEntry), typeof(ChatEntryRenderer))]

namespace JobMe.iOS
{
    public class ChatEntryRenderer : EditorRenderer
    {
        public ChatEntryRenderer()
        {
            UIKeyboard.Notifications.ObserveWillShow((sender, args) =>
            {
                if (Element != null)
                {
                    if (Element.AutomationId == "ChatMessageEntry")
                    {
                        Grid st = (Grid)Element.Parent;
                        SfBorder st1 = (SfBorder)st.Parent;

                        Grid st2 = (Grid)st1.Parent;

                        st2.Margin = new Thickness(0, 0, 0, args.FrameEnd.Height - 5); //push the entry up to keyboard height when keyboard is activated
                    }
                }
            });

            UIKeyboard.Notifications.ObserveWillHide((sender, args) =>
            {
                if (Element != null)
                {
                    if (Element.AutomationId == "ChatMessageEntry")
                    {
                        Grid st = (Grid)Element.Parent;
                        SfBorder st1 = (SfBorder)st.Parent;
                        st1.Padding = new Thickness(5, 0, 0, 0);
                        Grid st2 = (Grid)st1.Parent;

                        st2.Margin = new Thickness(0); //set the margins to zero when keyboard is dismissed
                    }

                    //Grid st = (Grid)Element.Parent;
                    //SfBorder st1 = (SfBorder)st.Parent;
                    //Grid st2 = (Grid)st1.Parent;
                    //st2.Margin = new Thickness(0); //set the margins to zero when keyboard is dismissed
                }
            });
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            var element = this.Element as ChatEntry;

            if (element != null)
            {
                Control.InputAccessoryView = null;
                Control.ShouldEndEditing += DisableHidingKeyboard;
            }

            MessagingCenter.Subscribe<ChatMessageViewModel>(this, "FocusKeyboardStatus", (sender) =>
            {
                if (Control != null)
                {
                    Control.ShouldEndEditing += EnableHidingKeyboard;
                }

                // MessagingCenter.Unsubscribe<ChatMessageViewModel>(this, "FocusKeyboardStatus");
            });

            //MessagingCenter.Subscribe<ChatNew, int>(this, "Status", (sender, arg) =>
            //{
            //    if (arg == 1)
            //    {
            //        if (Control != null)
            //        {
            //            Control.ShouldEndEditing += DisableHidingKeyboard;
            //        }
            //    }

            //});
        }

        private bool DisableHidingKeyboard(UITextView textView)
        {
            return false;
        }

        private bool EnableHidingKeyboard(UITextView textView)
        {
            return true;
        }

        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
        //    {
        //        if (Control != null)
        //        {
        //            Control.ShouldEndEditing =
        //                (UITextView textField) =>
        //                {
        //                    Control.BecomeFirstResponder();
        //                   //Control.ResignFirstResponder();
        //                    //do here coding first check flag and then fire an event
        //                    return true;
        //                };
        //        }
        //        base.OnElementPropertyChanged(sender, e);
        //    }
        //}
    }
}