using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(JobMe.iOS.FileService))]

namespace JobMe.iOS{


    public class FileService : IFileService
    {
        public void SavePicture(string name, Stream data, string location = "temp")
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //documentsPath = Path.Combine(documentsPath, location);
            Directory.CreateDirectory(documentsPath);


           // Stream v = System.IO.File.OpenRead(name);

            string filePath = Path.Combine(documentsPath, name);


            if (data != null)
            {

                byte[] bArray = new byte[data.Length];
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    using (data)
                    {
                        data.Read(bArray, 0, (int)data.Length);
                    }
                    int length = bArray.Length;
                    fs.Write(bArray, 0, length);
                }
            }
           
        }
    }

}