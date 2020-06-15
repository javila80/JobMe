﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using WindowsAzure.Messaging;
using Xamarin.Essentials;

namespace JobMe.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    internal class MyFirebaseMessagingService : FirebaseMessagingService
    {
        private const string TAG = "MyFirebaseMsgService";
        private NotificationHub hub;

        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);
            if (message.GetNotification() != null)
            {
                //These is how most messages will be received
                Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
                SendNotification(message.GetNotification().Body, "nada");
            }
            else
            {
                //Only used for debugging payloads sent from the Azure portal
                SendNotification(message.Data.Values.First(), message.Data.Values.Last());
            }
        }

        private void SendNotification(string messageBody, string titulo)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID);

            notificationBuilder.SetContentTitle(titulo)
                        .SetSmallIcon(Resource.Drawable.jobme)
                        .SetContentText(messageBody)
                        .SetAutoCancel(true)
                        .SetShowWhen(false)
                        .SetContentIntent(pendingIntent);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                notificationBuilder.SetChannelId(MainActivity.CHANNEL_ID);
            }

            var notificationManager = NotificationManager.FromContext(this);

            notificationManager.Notify(0, notificationBuilder.Build());
        }

        public override void OnNewToken(string token)
        {
            Log.Debug(TAG, "FCM token: " + token);
            SendRegistrationToServer(token);
        }

        private void SendRegistrationToServer(string token)
        {
            List<string> tags;

            // Register with Notification Hubs
            hub = new NotificationHub(Constants.NotificationHubName,
                                        Constants.ListenConnectionString, this);

            if (Preferences.Get("UserID", 0) != 0)
            {
                string x = Preferences.Get("UserID", 0).ToString();
                tags = new List<string>() { x };
                var regID = hub.Register(token, tags.ToArray()).RegistrationId;
                Log.Debug(TAG, $"Successful registration of ID {regID}");
            }
            //var regID = hub.Register(token, tags.ToArray()).RegistrationId;

            //Log.Debug(TAG, $"Successful registration of ID {regID}");
        }
    }
}