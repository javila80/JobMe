using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.XForms.TextInputLayout;
using Xamarin.Forms;

namespace JobMe.Behaviors
{
    public class PhoneNumberMaskBehavior : Behavior<Entry>
    {
       //public static PhoneNumberMaskBehavior Instance = new PhoneNumberMaskBehavior();

        ///  
        /// Attaches when the page is first created.  
        ///   
        public int MaxLength { get; set; } 
        protected override void OnAttachedTo(Entry entry)
        {
           
            base.OnAttachedTo(entry);
            entry.TextChanged += OnEntryTextChanged;
        }

        ///  
        /// Detaches when the page is destroyed.  
        ///   

        protected override void OnDetachingFrom(Entry entry)
        {
           
            base.OnDetachingFrom(entry);
            entry.TextChanged -= OnEntryTextChanged;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;
            bool IsValid = false;


            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {

                

                // if Entry text is longer than valid length  
                if (entry.Text.Length > this.MaxLength)
                {
                    string entryText = entry.Text;

                    entryText = entryText.Remove(entryText.Length - 1); // remove last char  

                    entry.Text = entryText;
                    IsValid = true;
                    ((Entry)sender).TextColor = Color.Default;
                    (((Entry)sender).Parent.Parent.Parent as SfTextInputLayout).HasError = IsValid ? false : true;

                }
                else
                {
                    if (entry.Text.Length <=11)
                    {
                        IsValid = false;
                        ((Entry)sender).TextColor = Color.Red;
                        (((Entry)sender).Parent.Parent.Parent as SfTextInputLayout).HasError = IsValid ? false : true;
                    }
                    else
                    {
                        IsValid = true;
                        ((Entry)sender).TextColor = Color.Default;
                        (((Entry)sender).Parent.Parent.Parent as SfTextInputLayout).HasError = IsValid ? false : true;
                    }

                    // If the new value is longer than the old value, the user is  
                    if (args.OldTextValue != null && args.NewTextValue.Length < args.OldTextValue.Length)
                        return;

                    var value = args.NewTextValue;

                    if (value.Length == 3)
                    {
                        ((Entry)sender).Text += "-";
                        return;
                    }

                    if (value.Length == 7)
                    {
                     ((Entry)sender).Text += "-";
                        return;
                    }

                    ((Entry)sender).Text = args.NewTextValue;

                    if (value.Length == 10 && !value.Contains("-"))
                    {

                        var res = value.Insert(3, "-");

                        var res1 = res.Insert(7, "-");
                        //((Entry)sender).Text += res;
                        ((Entry)sender).Text = res1;
                        return;
                    }

                   
                }
              
            }
        }
    }
}
