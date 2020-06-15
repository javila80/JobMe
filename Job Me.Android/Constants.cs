using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace JobMe.Droid
{
    public static class Constants
    {
       
        public const string ListenConnectionString = "Endpoint=sb://jobmenamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=YxgC+CNwbYH2k7qs+tqzQSmoCbZHHK0zRLL0+qJ3TY0=";
        public const string NotificationHubName = "JobMeHub";
    }
}