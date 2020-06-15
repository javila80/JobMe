using System;
using System.Collections.Generic;

using System.Linq;
using Xamarin.Forms;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Net.Ypresto.Androidtranscoder.Format;
using Android.Support.V7.View.Menu;

[assembly: Dependency(typeof(JobMe.Droid.VideoCompress))]

namespace JobMe.Droid
{
    public class VideoCompress : IVideoCompress
    {
        public int onProgress { get; set; }

        public async Task<string> CompressVideo(string path)
        {
            if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                File inputFile = new File(path);
                var path1 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
               
                //var z = inputFile.AbsolutePath;

                //string p = path.Contains("video") ? path.Replace("video","caca") : p = path.Replace(".mp4", DateTime.Now.Minute.ToString() + ".mp4");

                string p = path.Replace("video", "caca2" + DateTime.Now.Millisecond.ToString());

                //p = path.Replace("acads", "caca");
                File ouputFile = new File(path1+ DateTime.Now.Millisecond.ToString()+ ".mp4");

                //p = path.Replace(".mp4", DateTime.Now.Minute.ToString() + ".mp4");
                //string p1 = path.Replace("video", "caca12");

                //File ouputFile1 = new File(p1);

                //File ouputFile1 = new File(p);

               
                 

                    //    MediaFormat obj = MediaFormat.CreateVideoFormat("video/mp4", 480, 640);

                    //MediaFormat c = new For640x360Format().CreateVideoOutputFormat(obj);

                    //IMediaFormatStrategy x = 

                    IMediaFormatStrategy n = new For640x360Format();

                    await Xamarin.MP4Transcoder.Transcoder.For(n).ConvertAsync(inputFile, ouputFile);

                    //await Xamarin.MP4Transcoder.Transcoder.For960x540Format().ConvertAsync(inputFile, ouputFile, f =>
                    //{
                    //    var z = f * 100;
                    //});
                  

                    //await Xamarin.MP4Transcoder.Transcoder.For720pFormat(600000).ConvertAsync(inputFile, ouputFile1);

                    
              
                if (ouputFile == null)
                {
                    return path;

                }
                //var c = inputFile.Length();
                var cx = ouputFile.Length();
                //var cx1 = ouputFile1.Length();

                if (cx > 0)
                {

                    
                        //cx
                        return ouputFile.Path;
                  
                    
                }
                else
                {
                    return path;
                }
            }
            else
            {
                return path;
            }
        }



    }

    public class For640x360Format : Java.Lang.Object, IMediaFormatStrategy
    {
        public static int AUDIO_BITRATE_AS_IS = -1;
        public static int AUDIO_CHANNELS_AS_IS = -1;
        static String TAG = "640x360FormatStrategy";
        static int LONGER_LENGTH = 640;
        static int SHORTER_LENGTH = 360;
        static int DEFAULT_VIDEO_BITRATE = 400000;//8000 * 1000; // From Nexus 4 Camera in 720p
        int mVideoBitrate;
        int mAudioBitrate;
        int mAudioChannels;

        public For640x360Format()
        {
            mVideoBitrate = DEFAULT_VIDEO_BITRATE;
            mAudioBitrate = AUDIO_BITRATE_AS_IS;
            mAudioChannels = AUDIO_CHANNELS_AS_IS;
        }

        public For640x360Format(int videoBitrate)
        {
            mVideoBitrate = videoBitrate;
            mAudioBitrate = AUDIO_BITRATE_AS_IS;
            mAudioChannels = AUDIO_CHANNELS_AS_IS;
        }

        public For640x360Format(int videoBitrate, int audioBitrate, int audioChannels)
        {
            mVideoBitrate = videoBitrate;
            mAudioBitrate = audioBitrate;
            mAudioChannels = audioChannels;
        }

        public MediaFormat CreateAudioOutputFormat(MediaFormat inputFormat)
        {
            if (mAudioBitrate == AUDIO_BITRATE_AS_IS || mAudioChannels == AUDIO_CHANNELS_AS_IS) return null;

            // Use original sample rate, as resampling is not supported yet.
            MediaFormat format = MediaFormat.CreateAudioFormat(MediaFormatExtraConstants.MimetypeAudioAac,
                                                                inputFormat.GetInteger(MediaFormat.KeySampleRate),
                                                                mAudioChannels);
            // this is obsolete: MediaCodecInfo.CodecProfileLevel.AACObjectLC, so using MediaCodecProfileType.Aacobjectlc instead
            format.SetInteger(MediaFormat.KeyAacProfile, (int)MediaCodecProfileType.Aacobjectlc);
            format.SetInteger(MediaFormat.KeyBitRate, mAudioBitrate);
            return format;
        }

        public MediaFormat CreateVideoOutputFormat(MediaFormat inputFormat)
        {
            int width = inputFormat.GetInteger(MediaFormat.KeyWidth);
            int height = inputFormat.GetInteger(MediaFormat.KeyHeight);
            int longer, shorter, outWidth, outHeight;

            if (width >= height)
            {
                longer = width;
                shorter = height;
                outWidth = LONGER_LENGTH;
                outHeight = SHORTER_LENGTH;
            }
            else
            {
                shorter = width;
                longer = height;
                outWidth = SHORTER_LENGTH;
                outHeight = LONGER_LENGTH;
            }

            //if (longer * 9 != shorter * 16)
            //{
            //    throw new OutputFormatUnavailableException("This video is not 16:9, and is not able to transcode. (" + width + "x" + height + ")");
            //}
            if (shorter <= SHORTER_LENGTH)
            {
#if DEBUG
                System.Console.WriteLine("This video is less or equal to 720p, pass-through. (" + width + "x" + height + ")");
#endif

                return null;
            }

            MediaFormat format = MediaFormat.CreateVideoFormat("video/avc", outWidth, outHeight);
            format.SetInteger(MediaFormat.KeyBitRate, mVideoBitrate);
            format.SetInteger(MediaFormat.KeyFrameRate, 30);
            format.SetInteger(MediaFormat.KeyIFrameInterval, 3);
            // this is obsolete: MediaCodecInfo.CodecCapabilities.COLORFormatSurface, so using MediaCodecCapabilities.Formatsurface instead
            format.SetInteger(MediaFormat.KeyColorFormat, (int)MediaCodecCapabilities.Formatsurface);

            return format;
        }
    }
}