
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace JobMe
{
    public interface IVideoBitMap
    {
        MemoryStream GenerateThumbImage(string url, long usecond);
    }
}
