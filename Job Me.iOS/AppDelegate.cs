using Syncfusion.XForms.iOS.PopupLayout;
using Syncfusion.XForms.iOS.Cards;
using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.iOS.TabView;
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Syncfusion.SfRotator.XForms.iOS;
using Syncfusion.XForms.iOS.TextInputLayout;
using Syncfusion.XForms.iOS.MaskedEdit;
using Syncfusion.ListView.XForms.iOS;
using WindowsAzure.Messaging;
using UserNotifications;
using Syncfusion.SfPicker.XForms.iOS;
using Syncfusion.XForms.iOS.EffectsView;
using CarouselView.FormsPlugin.iOS;
using Syncfusion.XForms.iOS.BadgeView;
using Syncfusion.XForms.iOS.Core;
using Syncfusion.SfPdfViewer.XForms.iOS;
using Syncfusion.SfRangeSlider.XForms.iOS;
using Syncfusion.XForms.iOS.Border;
using Xamarin.Essentials;
//using Octane.Xamarin.Forms.VideoPlayer.iOS;
using MediaManager;
using Syncfusion.SfPullToRefresh.XForms.iOS;
using Octane.Xamarin.Forms.VideoPlayer.iOS;
using JobMe.Views;
using Xamarin.Forms;
using AudioToolbox;
using System.Threading.Tasks;
using JobmeApp.iOS;
using PanCardView.iOS;

namespace JobMe.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        private SBNotificationHub Hub { get; set; }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.SetFlags(new string[] { "CarouselView_Experimental", "SwipeView_Experimental", "IndicatorView_Experimental", "MediaElement_Experimental" });
            UINavigationBar.Appearance.TintColor = UIColor.Red;

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes() { TextColor = UIColor.Red });


            //Actualizar el token de las notificaciones
            MessagingCenter.Subscribe<JobMe.ViewModels.MainEmployeeViewModel>(this, "DeleteToken", sender =>
            {
                if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
                {
                    UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                        (granted, error) =>
                        {
                            if (granted)
                                InvokeOnMainThread(UIApplication.SharedApplication.RegisterForRemoteNotifications);
                        });
                }
                else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
                {
                    var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                        new NSSet());

                    UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                    UIApplication.SharedApplication.RegisterForRemoteNotifications();
                }
                else
                {
                    UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                    UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
                }
            });

            MessagingCenter.Subscribe<JobMe.ViewModels.LoginViewModel>(this, "DeleteToken", sender =>
            {
                if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
                {

                    InvokeOnMainThread(UIApplication.SharedApplication.RegisterForRemoteNotifications);

                }
                else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
                {
                    var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                        new NSSet());

                    UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                    UIApplication.SharedApplication.RegisterForRemoteNotifications();
                }
                else
                {
                    UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                    UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
                }
            });


            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                                                                        (granted, error) =>
                {
                    if (granted)
                        InvokeOnMainThread(UIApplication.SharedApplication.RegisterForRemoteNotifications);
                });
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                        new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }

            global::Xamarin.Forms.Forms.Init();
            SfPopupLayoutRenderer.Init();

            SfPullToRefreshRenderer.Init();
            SfCardLayoutRenderer.Init();
            CarouselViewRenderer.Init();
            SfTabViewRenderer.Init();
            SfRotatorRenderer.Init();
            SfBadgeViewRenderer.Init();
            Syncfusion.XForms.iOS.Chat.SfChatRenderer.Init();
            SfBorderRenderer.Init();
            new SfComboBoxRenderer();
            SfTextInputLayoutRenderer.Init();
            SfMaskedEditRenderer.Init();
            SfPdfDocumentViewRenderer.Init();
            SfRangeSliderRenderer.Init();
            SfPickerRenderer.Init();
            SfListViewRenderer.Init();
            SfEffectsViewRenderer.Init();
            SfAvatarViewRenderer.Init();
            SfMaskedEditRenderer.Init();
            Syncfusion.XForms.iOS.PopupLayout.SfPopupLayoutRenderer.Init();
            //SfRotatorRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfSegmentedControlRenderer.Init();

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();

            FormsVideoPlayer.Init();

            CardsViewRenderer.Preserve();

            App.ScreenWidth = UIScreen.MainScreen.Bounds.Width;
            App.ScreenHeight = UIScreen.MainScreen.Bounds.Height;

            LoadApplication(new App(false));
          //  LoadApplication(new App(false));

            // Watch for notifications while the app is active
            UNUserNotificationCenter.Current.Delegate = new UserNotificationCenterDelegate();

            return base.FinishedLaunching(app, options);
        }


        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            Hub = new SBNotificationHub(Constants.ListenConnectionString, Constants.NotificationHubName);


            Hub.UnregisterAll(deviceToken, (error) =>
            {
                if (error != null)
                {
                    System.Diagnostics.Debug.WriteLine("Error calling Unregister: {0}", error.ToString());
                    return;
                }

                string userid = Preferences.Get("UserID", 0).ToString();
                NSSet tags = new NSSet(userid);// create tags if you want
                Hub.RegisterNativeAsync(deviceToken, tags);
            });
        }

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            try
            {
                SystemSound.Vibrate.PlaySystemSound();
            }
            catch (Exception e)
            {

            }

            ProcessNotification(userInfo, false);
        }

        private void ProcessNotification(NSDictionary options, bool fromFinishedLaunching)
        {
            try
            {
                // Check to see if the dictionary has the aps key.  This is the notification payload you would have sent
                if (null != options && options.ContainsKey(new NSString("aps")))
                {
                    //Get the aps dictionary
                    NSDictionary aps = options.ObjectForKey(new NSString("aps")) as NSDictionary;
                    NSDictionary dic1 = aps.ObjectForKey(new NSString("alert")) as NSDictionary;

                    string alert = string.Empty;

                    //Extract the alert text
                    // NOTE: If you're using the simple alert by just specifying
                    // "  aps:{alert:"alert msg here"}  ", this will work fine.
                    // But if you're using a complex alert with Localization keys, etc.,
                    // your "alert" object from the aps dictionary will be another NSDictionary.
                    // Basically the JSON gets dumped right into a NSDictionary,
                    // so keep that in mind.
                    if (aps.ContainsKey(new NSString("alert")))
                        alert = (aps[new NSString("alert")] as NSString).ToString();

                    //If this came from the ReceivedRemoteNotification while the app was running,
                    // we of course need to manually process things like the sound, badge, and alert.
                    if (!fromFinishedLaunching)
                    {
                        //Manually show an alert
                        if (!string.IsNullOrEmpty(alert))
                        {
                            //UIAlertView avAlert = new UIAlertView("JobMe", alert, null, "OK", null);
                            //avAlert.Show();
                        }

                        if (dic1.ContainsKey(new NSString("subtitle")))
                        {
                            if ((dic1[new NSString("subtitle")] as NSString).ToString() == "chat")

                            {
                                //Es un mensaje de chat
                                MessagingCenter.Send<object, string>(this, "Push", "01");

                            }
                        }
                        //if (!string.IsNullOrEmpty(alert))
                        //{
                        //    var myAlert = UIAlertController.Create("Notificacion JobMe", alert, UIAlertControllerStyle.Alert);
                        //    myAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                        //    UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(myAlert, true, null);

                        //}


                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

       
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            var mainPage = Xamarin.Forms.Application.Current.MainPage;

            if (mainPage.Navigation.NavigationStack.Last() is VideoPublicidad)
            {
                return UIInterfaceOrientationMask.Landscape;
            }
            return UIInterfaceOrientationMask.AllButUpsideDown;
        }
    }


}