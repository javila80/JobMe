using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace JobMe.Services
{
    public class LogService
    {
        public static async void WriteLogAsync(int UserID)
        {


            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/WriteLog?" + "&UserID=" + UserID; ;

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("{}");




            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);




            }

        }
    }
}
