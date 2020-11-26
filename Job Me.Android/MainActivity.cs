using System;
using Android.Gms.Common;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using System.Threading.Tasks;
using Android.Content;

//using Plugin.Permissions;
using Acr.UserDialogs;
using PanCardView.Droid;

using MediaManager;
using Octane.Xamarin.Forms.VideoPlayer.Android;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms;
using JobMe.Views;

namespace JobMe.Droid
{
    [Activity(Label = "JobMe", Icon = "@drawable/jobme", Theme = "@style/MainTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "JobMe_notifications";
        internal static readonly int NOTIFICATION_ID = 100;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            //abrir la pagina de chats en push notification click
            var flag = false;
          
            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    if (key != null)
                    {
                        if (key == "chat")
                        {
                            flag = true;
                        }

                        var value = Intent.Extras.GetString(key);
                        Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                    }
                }
            }

            MessagingCenter.Subscribe<VideoPublicidad>(this, "PreventLandscape", sender =>
            {
                RequestedOrientation = ScreenOrientation.Portrait;
            });

            MessagingCenter.Subscribe<VideoPublicidad>(this, "AllowLandscape", sender =>
            {
                RequestedOrientation = ScreenOrientation.Unspecified;
            });
            //Register Syncfusion license
            // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
            Xamarin.Forms.Forms.SetFlags(new string[] { "CarouselView_Experimental", "SwipeView_Experimental", "IndicatorView_Experimental","MediaElement_Experimental" });
            //global::Xamarin.Forms.Forms.SetFlags(new[] { "CollectionView_Experimental", "Shell_Experimental" });
            IsPlayServicesAvailable();

            MessagingCenter.Subscribe<JobMe.ViewModels.LoginViewModel>(this, "DeleteToken", sender =>
            {
                Task.Run(() =>
                {
                    // This may not be executed on the main thread.
                    FirebaseInstanceId.Instance.DeleteInstanceId();
                    // Console.WriteLine("Forced token: " + FirebaseInstanceId.Instance.Token);
                });
            });

            MessagingCenter.Subscribe<JobMe.ViewModels.MainEmployeeViewModel>(this, "DeleteToken", sender =>
            {
                Task.Run(() =>
                {
                    // This may not be executed on the main thread.
                    FirebaseInstanceId.Instance.DeleteInstanceId();
                    // Console.WriteLine("Forced token: " + FirebaseInstanceId.Instance.Token);
                });
            });

            Task.Run(() =>
             {
                 // This may not be executed on the main thread.
                 FirebaseInstanceId.Instance.DeleteInstanceId();
                 // Console.WriteLine("Forced token: " + FirebaseInstanceId.Instance.Token);
             });
            CreateNotificationChannel();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            
            UserDialogs.Init(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Change the Status Bar Color
            Window.SetStatusBarColor(Android.Graphics.Color.Black);

            var width = Resources.DisplayMetrics.WidthPixels;
            var height = Resources.DisplayMetrics.HeightPixels;
            var density = Resources.DisplayMetrics.Density;

            App.ScreenWidth = (width - 0.5f) / density;
            App.ScreenHeight = (height - 0.5f) / density;

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            LoadApplication(new App(flag));

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            FormsVideoPlayer.Init();

            CardsViewRenderer.Preserve();
            //CrossMediaManager.Current.Init(this);
            // CrossCurrentActivity.Current.Init(this, savedInstanceState);

            //Esto es para que no se oculte el teclado
            //App.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

        }

        
        public static MainActivity Current { private set; get; }

        public static readonly int PickImageId = 1000;

        public TaskCompletionSource<string> PickImageTaskCompletionSource { set; get; }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (data != null))
                {
                    // Set the filename as the completion of the Task
                    PickImageTaskCompletionSource.SetResult(data.DataString);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Log.Debug(TAG, GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    Log.Debug(TAG, "This device is not supported");
                    Finish();
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            // PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {
                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        private bool _lieAboutCurrentFocus;

        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            var focused = CurrentFocus;
            bool customEntryRendererFocused = focused != null && focused.Parent is ChatEntryRenderer;

            _lieAboutCurrentFocus = customEntryRendererFocused;
            var result = base.DispatchTouchEvent(ev);
            _lieAboutCurrentFocus = false;

            return result;
        }

        public override Android.Views.View CurrentFocus
        {
            get
            {
                if (_lieAboutCurrentFocus)
                {
                    return null;
                }

                return base.CurrentFocus;
            }
        }
    }
}