using AVFoundation;
using JobMe.FormsVideoLibrary;
using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FormsVideoLibrary.iOS.VideoLength))]

namespace FormsVideoLibrary.iOS
{
    public class VideoLength : IVideoLength
    {
        public int GetVideoLength(MediaFile media)
        {
            AVAsset avasset = AVAsset.FromUrl((new Foundation.NSUrl(media.Path)));
            var length = avasset.Duration.Seconds.ToString();
            var lengthseconds = Convert.ToInt32(length) / 1000;
            TimeSpan t = TimeSpan.FromSeconds(lengthseconds);
            //var timeformat = Convert.ToInt32(t);
            return t.Seconds; 

        }
    }
}

