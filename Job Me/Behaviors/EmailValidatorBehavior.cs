using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace JobMe.Behaviors
{
    public class EmailValidatorBehavior : Behavior<Entry>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";


        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            bool IsValid = false;

            var entry = (Entry)sender;

            if (entry.Text != null)
            {
                IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
                try
                {
                    (((Entry)sender).Parent.Parent.Parent as SfTextInputLayout).HasError = IsValid ? false : true;
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            else
            {
                try
                {
                    IsValid = true;
                    (((Entry)sender).Parent.Parent.Parent as SfTextInputLayout).HasError =  IsValid ? false : true;
                    ((Entry)sender).TextColor = Color.Default;
                }
                catch (Exception)
                {

                    //throw;
                }
            }



        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
