using JobMe.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JobMe.Services
{
    public class EmployerService
    {
        public static async Task<bool> UpdateContactAsync(UserModel user)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/UpdateContact";

            //var uri = "https://localhost:44327/api/user";
            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<bool>(result);
                    }
                    catch (Exception)
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

        public static async Task<int> AddCompanyAsync(Companies company)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/AddCompany";

            //var uri = "https://localhost:44327/api/user";
            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(company));

            int msj = 0;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return Convert.ToInt32(result);
                    }
                    catch (Exception)
                    {
                        return 0;
                        throw;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public static async Task<int> AddEmployerAsync(UserModel user)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/AddEmployer";

            //var uri = "https://localhost:44327/api/user";
            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return Convert.ToInt32(result);
                    }
                    catch (Exception)
                    {
                        return 0;
                        throw;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public static async Task<Companies> GetCompanyAsync(int userid)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/GetCompany?userid=" + userid;

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject("{}"));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<Companies>(result);
                }
                else
                {
                    return null;
                }
            }
        }

        public static async Task<ObservableCollection<UserModel>> GetContactsAsync(int idcompany)
        {
            var client = new HttpClient();

            //var uri = EndPoint.BACKEND_ENDPOINT + "api/AddEmployer";
            var uri = EndPoint.BACKEND_ENDPOINT + "api/GetContacts?idCompany=" + idcompany;

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject("{}"));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ObservableCollection<UserModel>>(result);
                }
                else
                {
                    return null;
                }
            }
        }

        public static async Task<bool> UpdateLogoAsync(Companies company)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/UpdateLogo";

            //var uri = "https://localhost:44327/api/user";
            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(company));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<bool>(result);
                    }
                    catch (Exception)
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

        public static async Task<bool> UpdateCompanyAsync(Companies company)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/UpdateCompany";

            //var uri = "https://localhost:44327/api/user";
            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(company));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<bool>(result);
                    }
                    catch (Exception)
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

        public static async void AddCandidateLikedAsync(int IDPosition, int UserId)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/AddCandidateLiked/?idposition= " + IDPosition + "&userid=" + UserId;

            //var uri = "https://localhost:44327/api/user";
            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes("{}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    //try
                    //{
                    //    return JsonConvert.DeserializeObject<bool>(result);
                    //}
                    //catch (Exception)
                    //{
                    //    return false;
                    //    throw;
                    //}
                }
                //else
                //{
                //    return false;

                //}
            }
        }

        public static async void AddPositionsLikedAsync(int UserId, int IDPosition)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/AddPositionsLiked/?userid= " + UserId + "&idposition=" + IDPosition;

            //var uri = "https://localhost:44327/api/user";
            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes("{}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();
                }
                //else
                //{
                //    return false;

                //}
            }
        }
    }
}