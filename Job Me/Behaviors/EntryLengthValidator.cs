using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JobMe.Behaviors
{
    public class EntryLengthValidator : Behavior<Entry>
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; } = 0;

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            bool IsValid = false;
            var entry = (Entry)sender;



            if (entry.Text != null) {

                // if Entry text is longer than valid length  
                if (entry.Text.Length > this.MaxLength)
                {
                    string entryText = entry.Text;

                    entryText = entryText.Remove(entryText.Length - 1); // remove last char  

                    entry.Text = entryText;
                }

                try
                {


                    if (MinLength > 0)
                        if (entry.Text.Length < this.MinLength)
                        {
                            IsValid = false;
                            ((Entry)sender).TextColor = Color.Red;
                            (((Entry)sender).Parent.Parent.Parent as SfTextInputLayout).HasError = IsValid ? false : true;
                        }
                        else
                        {
                            IsValid = true;
                            (((Entry)sender).Parent.Parent.Parent as SfTextInputLayout).HasError = IsValid ? false : true;
                            ((Entry)sender).TextColor = Color.Default;
                        }
                }
                catch (Exception)
                {

                    // throw;
                }

            }
            else
            {
                try
                {
                    IsValid = true;
                    (((Entry)sender).Parent.Parent.Parent as SfTextInputLayout).HasError = IsValid ? false : true;
                    ((Entry)sender).TextColor = Color.Default;
                }
                catch (Exception)
                {

                    //throw;
                }
               

            }
           
        }
    }
}
