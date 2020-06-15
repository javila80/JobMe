using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobMe.FormsVideoLibrary
{
    public interface IVideoLength
    {
        int  GetVideoLength(MediaFile path);
    }
}
