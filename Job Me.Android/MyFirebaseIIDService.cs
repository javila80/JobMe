using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Iid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WindowsAzure.Messaging;
using Android.Util;
using Xamarin.Essentials;

namespace JobMe.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {

        const string TAG = "MyFirebaseIIDService";
        NotificationHub hub;

        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "FCM token: " + refreshedToken);
            try
            {
                SendRegistrationToServer(refreshedToken);
            }
            catch (Exception)
            {

               // throw;
            }
            
        }

        void SendRegistrationToServer(string token)
        {

            List<string> tags;

            // Register with Notification Hubs
            hub = new NotificationHub(Constants.NotificationHubName,
                                        Constants.ListenConnectionString, this);

            //if (Preferences.Get("UserID",0))
            //{
               if (Preferences.Get("UserID", 0) != 0)
                {

                    string x = Preferences.Get("UserID", 0).ToString();
                    tags = new List<string>() { x };
                    var regID = hub.Register(token, tags.ToArray()).RegistrationId;
                    Log.Debug(TAG, $"Successful registration of ID {regID}");
                }

                else
                {

                    tags = new List<string>() { };


                }

            //}
            //else
            //{
            //    tags = new List<string>() { };
            //}






        }
    }
}