using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JobMe.Converter
{
    class General
    {
        private static bool CheckValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return true;

            //var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            var regex = new Regex(@"\w{2,}\S");
            return regex.IsMatch(email) && !email.EndsWith(".");
        }

    }
}
