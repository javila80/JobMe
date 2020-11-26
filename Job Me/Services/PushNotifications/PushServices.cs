using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JobMe.Services.PushNotifications
{
    class PushServices
    {
        public static async Task SendPushAsync(int UserID, string titulo, string mensaje, string pns = "fcm")
        {

            // Esto es para enviar a Android
            //string pns = "fcm";

            // Dim POST_URL As String = BACKEND_ENDPOINT + "/api/notifications?pns=" + pns + "&to_tag=" + idmasterusuario

            string POST_URL = EndPoint.PUSH_ENDPOINT + "/api/notifications?pns=" + pns + "&to_tag=" + UserID.ToString();


            using (var httpClient = new HttpClient())
            {
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType.Tls12);

                string user = "juan";
                string password = "abc123";

                Dictionary<string, string> message = new Dictionary<string, string>();
                message.Add("message", mensaje);
                message.Add("Titulo", titulo);

                var byteArray = Encoding.ASCII.GetBytes(user + ":" + password);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                try
                {
                    string msj = (JsonConvert.SerializeObject(message));

                    HttpContent httpContent = new StringContent(msj, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(POST_URL, httpContent);

                    if (response.IsSuccessStatusCode)
                    {

                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    var z = ex.ToString();

                    return;
                }
            }
        }
    }
}
