using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Android.App;
using Android.Content;
using Android.Hardware;
using Android.Views;
using Android.Graphics;
using Android.Widget;
using JobMe.Droid;

[assembly: ExportRenderer(typeof(CameraPage), typeof(CameraPageRenderer))]

namespace JobMe.Droid
{
    public class CameraPageRenderer : PageRenderer, TextureView.ISurfaceTextureListener
    {
        private global::Android.Hardware.Camera camera;
        private global::Android.Widget.Button takePhotoButton;
        private global::Android.Widget.Button toggleFlashButton;
        private global::Android.Widget.Button switchCameraButton;
        private global::Android.Views.View view;

        private Activity activity;
        private CameraFacing cameraType;
        private TextureView textureView;
        private SurfaceTexture surfaceTexture;

        private bool flashOn;

        public CameraPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                SetupUserInterface();
                SetupEventHandlers();
                AddView(view);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"			ERROR: ", ex.Message);
            }
        }

        private void SetupUserInterface()
        {
            activity = this.Context as Activity;
            view = activity.LayoutInflater.Inflate(Resource.Layout.CameraLayout, this, false);
            cameraType = CameraFacing.Back;

            textureView = view.FindViewById<TextureView>(Resource.Id.textureView);
            textureView.SurfaceTextureListener = this;
        }

        private void SetupEventHandlers()
        {
            takePhotoButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.takePhotoButton);
            takePhotoButton.Click += TakePhotoButtonTapped;

            switchCameraButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.switchCameraButton);
            switchCameraButton.Click += SwitchCameraButtonTapped;

            toggleFlashButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.toggleFlashButton);
            toggleFlashButton.Click += ToggleFlashButtonTapped;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
        }

        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            camera = global::Android.Hardware.Camera.Open((int)cameraType);
            textureView.LayoutParameters = new FrameLayout.LayoutParams(width, height);
            surfaceTexture = surface;

            camera.SetPreviewTexture(surface);
            PrepareAndStartCamera();
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            camera.StopPreview();
            camera.Release();
            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
            PrepareAndStartCamera();
        }

        private void PrepareAndStartCamera()
        {
            camera.StopPreview();

            var display = activity.WindowManager.DefaultDisplay;
            if (display.Rotation == SurfaceOrientation.Rotation0)
            {
                camera.SetDisplayOrientation(90);
            }

            if (display.Rotation == SurfaceOrientation.Rotation270)
            {
                camera.SetDisplayOrientation(180);
            }

            camera.StartPreview();
        }

        private void ToggleFlashButtonTapped(object sender, EventArgs e)
        {
            flashOn = !flashOn;
            if (flashOn)
            {
                if (cameraType == CameraFacing.Back)
                {
                    toggleFlashButton.SetBackgroundResource(Resource.Drawable.FlashButton);
                    cameraType = CameraFacing.Back;

                    camera.StopPreview();
                    camera.Release();
                    camera = global::Android.Hardware.Camera.Open((int)cameraType);
                    var parameters = camera.GetParameters();
                    parameters.FlashMode = global::Android.Hardware.Camera.Parameters.FlashModeTorch;
                    camera.SetParameters(parameters);
                    camera.SetPreviewTexture(surfaceTexture);
                    PrepareAndStartCamera();
                }
            }
            else
            {
                toggleFlashButton.SetBackgroundResource(Resource.Drawable.NoFlashButton);
                camera.StopPreview();
                camera.Release();

                camera = global::Android.Hardware.Camera.Open((int)cameraType);
                var parameters = camera.GetParameters();
                parameters.FlashMode = global::Android.Hardware.Camera.Parameters.FlashModeOff;
                camera.SetParameters(parameters);
                camera.SetPreviewTexture(surfaceTexture);
                PrepareAndStartCamera();
            }
        }

        private void SwitchCameraButtonTapped(object sender, EventArgs e)
        {
            if (cameraType == CameraFacing.Front)
            {
                cameraType = CameraFacing.Back;

                camera.StopPreview();
                camera.Release();
                camera = global::Android.Hardware.Camera.Open((int)cameraType);
                camera.SetPreviewTexture(surfaceTexture);
                PrepareAndStartCamera();
            }
            else
            {
                cameraType = CameraFacing.Front;

                camera.StopPreview();
                camera.Release();
                camera = global::Android.Hardware.Camera.Open((int)cameraType);
                camera.SetPreviewTexture(surfaceTexture);
                PrepareAndStartCamera();
            }
        }

        private async void TakePhotoButtonTapped(object sender, EventArgs e)
        {
            camera.StopPreview();

            var image = textureView.Bitmap;

            try
            {
                var absolutePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath;
                var folderPath = absolutePath + "/Camera";
                var filePath = System.IO.Path.Combine(folderPath, string.Format("photo_{0}.jpg", Guid.NewGuid()));

                var fileStream = new FileStream(filePath, FileMode.Create);
                await image.CompressAsync(Bitmap.CompressFormat.Jpeg, 50, fileStream);
                fileStream.Close();
                image.Recycle();

                var intent = new Android.Content.Intent(Android.Content.Intent.ActionMediaScannerScanFile);
                var file = new Java.IO.File(filePath);
                var uri = Android.Net.Uri.FromFile(file);
                intent.SetData(uri);
                MainActivity.Instance.SendBroadcast(intent);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"				", ex.Message);
            }

            camera.StartPreview();
        }
    }

    //    internal class VideoTranscode
    //    {
    //    }

    //    public class For640x360Format : Java.Lang.Object, IMediaFormatStrategy
    //    {
    //        public static int AUDIO_BITRATE_AS_IS = -1;
    //        public static int AUDIO_CHANNELS_AS_IS = -1;
    //        private static String TAG = "640x360FormatStrategy";
    //        private static int LONGER_LENGTH = 640;
    //        private static int SHORTER_LENGTH = 360;
    //        private static int DEFAULT_VIDEO_BITRATE = 8000 * 1000; // From Nexus 4 Camera in 720p
    //        private int mVideoBitrate;
    //        private int mAudioBitrate;
    //        private int mAudioChannels;

    //        public For640x360Format()
    //        {
    //            mVideoBitrate = DEFAULT_VIDEO_BITRATE;
    //            mAudioBitrate = AUDIO_BITRATE_AS_IS;
    //            mAudioChannels = AUDIO_CHANNELS_AS_IS;
    //        }

    //        public For640x360Format(int videoBitrate)
    //        {
    //            mVideoBitrate = videoBitrate;
    //            mAudioBitrate = AUDIO_BITRATE_AS_IS;
    //            mAudioChannels = AUDIO_CHANNELS_AS_IS;
    //        }

    //        public For640x360Format(int videoBitrate, int audioBitrate, int audioChannels)
    //        {
    //            mVideoBitrate = videoBitrate;
    //            mAudioBitrate = audioBitrate;
    //            mAudioChannels = audioChannels;
    //        }

    //        public MediaFormat CreateAudioOutputFormat(MediaFormat inputFormat)
    //        {
    //            if (mAudioBitrate == AUDIO_BITRATE_AS_IS || mAudioChannels == AUDIO_CHANNELS_AS_IS) return null;

    //            // Use original sample rate, as resampling is not supported yet.
    //            MediaFormat format = MediaFormat.CreateAudioFormat(MediaFormatExtraConstants.MimetypeAudioAac,
    //                                                                inputFormat.GetInteger(MediaFormat.KeySampleRate),
    //                                                                mAudioChannels);
    //            // this is obsolete: MediaCodecInfo.CodecProfileLevel.AACObjectLC, so using MediaCodecProfileType.Aacobjectlc instead
    //            format.SetInteger(MediaFormat.KeyAacProfile, (int)MediaCodecProfileType.Aacobjectlc);
    //            format.SetInteger(MediaFormat.KeyBitRate, mAudioBitrate);
    //            return format;
    //        }

    //        public MediaFormat CreateVideoOutputFormat(MediaFormat inputFormat)
    //        {
    //            int width = inputFormat.GetInteger(MediaFormat.KeyWidth);
    //            int height = inputFormat.GetInteger(MediaFormat.KeyHeight);
    //            int longer, shorter, outWidth, outHeight;

    //            if (width >= height)
    //            {
    //                longer = width;
    //                shorter = height;
    //                outWidth = LONGER_LENGTH;
    //                outHeight = SHORTER_LENGTH;
    //            }
    //            else
    //            {
    //                shorter = width;
    //                longer = height;
    //                outWidth = SHORTER_LENGTH;
    //                outHeight = LONGER_LENGTH;
    //            }

    //            if (longer * 9 != shorter * 16)
    //            {
    //                throw new OutputFormatUnavailableException("This video is not 16:9, and is not able to transcode. (" + width + "x" + height + ")");
    //            }
    //            if (shorter <= SHORTER_LENGTH)
    //            {
    //#if DEBUG
    //                Console.WriteLine("This video is less or equal to 720p, pass-through. (" + width + "x" + height + ")");
    //#endif

    //                return null;
    //            }

    //            MediaFormat format = MediaFormat.CreateVideoFormat("video/avc", outWidth, outHeight);
    //            format.SetInteger(MediaFormat.KeyBitRate, mVideoBitrate);
    //            format.SetInteger(MediaFormat.KeyFrameRate, 30);
    //            format.SetInteger(MediaFormat.KeyIFrameInterval, 3);
    //            // this is obsolete: MediaCodecInfo.CodecCapabilities.COLORFormatSurface, so using MediaCodecCapabilities.Formatsurface instead
    //            format.SetInteger(MediaFormat.KeyColorFormat, (int)MediaCodecCapabilities.Formatsurface);

    //            return format;
    //        }
    //    }
}