
using System;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using JobMe.Droid;
using Xamarin.Forms;



[assembly: Dependency(typeof(JobMe.Droid.FileService))]

namespace JobMe.Droid
{
    public class FileService : IFileService
    {
        public void SavePicture(string name, Stream data, string location = "temp")
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
           // documentsPath = Path.Combine(documentsPath, location);
            Directory.CreateDirectory(documentsPath);

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