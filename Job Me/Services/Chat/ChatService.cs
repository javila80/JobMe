using JobMe.Models;
using JobMe.Models.Chat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JobMe.Services.Chat
{
    internal class ChatService
    {
        public static async void UpdateContador(ChatDetail ch)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Chat/UpdateContador";
                      
            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ch));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                   
                    msj = "Ocurrio un error al agregar la vacante";
                }
            }
        }
        public static async Task<int> AddContactAsync(ChatContact ch)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Chat/AddContact";

            //var uri = "https://localhost:44327/api/user";
            // Request body

            //  byte[] byteData = Encoding.UTF8.GetBytes("{}");
            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ch));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<int>(result);
                    }
                    catch (Exception ex)
                    {
                        return 0;
                        throw;
                    }
                }
                else
                {
                    return 0;
                    msj = "Ocurrio un error al agregar la vacante";
                }
            }
        }

        public static async Task<ObservableCollection<ChatDetail>> GetContactsEmployeeAsync(int UserID)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Chat/GetContactsEmployee?UserID=" + UserID;

            //var uri = "https://localhost:44327/api/user";
            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes("{}");
            //byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ch));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<ChatDetail>>(result);
                    }
                    catch (Exception ex)
                    {
                        return null;
                        throw;
                    }
                }
                else
                {
                    return null;
                    msj = "Ocurrio un error al agregar la vacante";
                }
            }
        }

        public static async Task<ObservableCollection<ChatDetail>> GetContactsEmployerAsync(int UserID)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Chat/GetContactsEmployer?UserID=" + UserID;

            //var uri = "https://localhost:44327/api/user";
            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes("{}");
            //byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ch));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<ChatDetail>>(result);
                    }
                    catch (Exception ex)
                    {
                        return null;
                        throw;
                    }
                }
                else
                {
                    return null;
                    msj = "Ocurrio un error al agregar la vacante";
                }
            }
        }

        public static async Task<bool> AddMessageAsync(ChatMessage msg)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Chat/AddMessage";

            //var uri = "https://localhost:44327/api/user";
            // Request body

            //  byte[] byteData = Encoding.UTF8.GetBytes("{}");
            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<bool>(result);
                    }
                    catch (Exception ex)
                    {
                        return false;
                        throw;
                    }
                }
                else
                {
                    return false;
                    msj = "Ocurrio un error al agregar la vacante";
                }
            }
        }

        public static async Task<ObservableCollection<ChatMessage>> GetMessagesAsync(ChatDetail ch)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Chat/GetMessages";

            //var uri = "https://localhost:44327/api/user";
            // Request body

            //   byte[] byteData = Encoding.UTF8.GetBytes("{}");
            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ch));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<ChatMessage>>(result);
                    }
                    catch (Exception ex)
                    {
                        return null;
                        throw;
                    }
                }
                else
                {
                    return null;
                    msj = "Ocurrio un error al agregar la vacante";
                }
            }
        }

        public static async Task<bool> DeleteChatAsync(ChatDetail ch)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Chat/DeleteChat";

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ch));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<bool>(result);
                    }
                    catch (Exception ex)
                    {
                        return false;
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static async Task<bool> DeleteContactAsync(ChatContact ch)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Chat/DeleteContact";

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ch));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<bool>(result);
                    }
                    catch (Exception ex)
                    {
                        return false;
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static async Task<ObservableCollection<ChatMessage>> GetMessagesNewAsync(ChatDetail ch)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Chat/GetMessagesNew";

            //var uri = "https://localhost:44327/api/user";
            // Request body

            //   byte[] byteData = Encoding.UTF8.GetBytes("{}");
            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ch));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<ChatMessage>>(result);
                    }
                    catch (Exception ex)
                    {
                        return null;
                        throw;
                    }
                }
                else
                {
                    return null;
                    msj = "Ocurrio un error al agregar la vacante";
                }
            }
        }

        public static async Task AddJobMatchAsync(JobMatch jm)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Chat/AddJobMatch";

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(jm));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    msj = "Ocurrio un error al agregar la vacante";
                }
            }
        }
    }
}