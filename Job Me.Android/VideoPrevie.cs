using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(JobMe.Droid.VideoPreview))]

namespace JobMe.Droid
{
    public class VideoPreview: IVideoBitMap
    {
        public MemoryStream GenerateThumbImage(string url, long usecond)
        {
            MediaMetadataRetriever retriever = new MediaMetadataRetriever();
            retriever.SetDataSource(url);
            Bitmap bitmap = retriever.GetFrameAtTime(usecond);
            if (bitmap != null)
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 10, stream);
                byte[] bitmapData = stream.ToArray();
                return stream;
                
                // return ImageSource.FromStream(() => new MemoryStream(bitmapData));
            }
            return null;
        }
    }
}