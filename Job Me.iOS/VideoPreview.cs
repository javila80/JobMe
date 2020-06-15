using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AVFoundation;
using CoreGraphics;
using CoreMedia;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(JobMe.iOS.VideoPreview))]

namespace JobMe.iOS
{
    public class VideoPreview : IVideoBitMap
    {
        public MemoryStream GenerateThumbImage(string url, long usecond)
        {

            var asset = AVAsset.FromUrl(NSUrl.FromFilename(url));
            var imageGenerator = AVAssetImageGenerator.FromAsset(asset);
            imageGenerator.AppliesPreferredTrackTransform = true;
            var actualTime = asset.Duration;
            CoreMedia.CMTime cmTime = new CoreMedia.CMTime(usecond, 2000000);
            NSError error;
            var cgImage = imageGenerator.CopyCGImageAtTime(cmTime, out actualTime, out error);

            //AVAssetImageGenerator imageGenerator = new AVAssetImageGenerator(AVAsset.FromUrl((new Foundation.NSUrl(url))));
            //imageGenerator.AppliesPreferredTrackTransform = true;
            //var actualTime = asset.Duration;
            //CoreMedia.CMTime cmTime = new CoreMedia.CMTime(usecond, 1000000);
            //NSError error;
            //var cgImage = imageGenerator.CopyCGImageAtTime(cmTime, out actualTime, out error);
            //CMTime actualTime;
            //NSError error;
            //CGImage cgImage = imageGenerator.CopyCGImageAtTime(new CMTime(usecond, 1000000), out actualTime, out error);

            var zz = new UIImage(cgImage).AsJPEG().AsStream();
            var a = new MemoryStream();
            zz.CopyTo(a);          

            return a;
            //return ImageSource.FromStream(() => new UIImage(cgImage).AsJPEG().AsStream()); //mageSource.FromStream(() => new UIImage(cgImage).AsPNG().AsStream());
        }
    }
}