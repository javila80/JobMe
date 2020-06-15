using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content;
using Android.Media;
using JobMe.Droid;
using JobMe.FormsVideoLibrary;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

// Need application's MainActivity

[assembly: Dependency(typeof(FormsVideoLibrary.Droid.VideoLength))]

namespace FormsVideoLibrary.Droid
{
    public class VideoLength : IVideoLength
    {

        public int GetVideoLength(MediaFile media)
        {

            MediaMetadataRetriever retriever = new MediaMetadataRetriever();
            retriever.SetDataSource(media.Path);
            var length = retriever.ExtractMetadata(MetadataKey.Duration);
            var lengthseconds = Convert.ToInt32(length) / 1000;
            TimeSpan t = TimeSpan.FromSeconds(lengthseconds);
           // var timeformat = t.Seconds;
            return t.Seconds;
        }
    }
}