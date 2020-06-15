using JobMe.Models;
using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static JobMe.Models.UserModel;

namespace JobMe.Services
{
    class UserService
    {
        public static async Task<bool> UpdateCV(UserModel user)
        {


            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/Employee/UpdateCV";
                     
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<bool>(result);

                   
                }
                else
                {
                    return false;

                }


            }




        }
        public static async Task<bool> ActivateUserAsync(int userid)
        {

                        var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/ActivateUser?userid=" + userid; 

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("");

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<bool>(result);                    
                }
                else
                {
                    return false;

                }


            }

        }
        public static async Task<int> AddUserAsync(UserModel user)
        {

            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/AddUser";

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    int id = JsonConvert.DeserializeObject<int>(result);

                    msj = (result.ToString());

                    return id;
                }
                else
                {
                    return 0;

                }


            }
            
        }
        public static async Task<int> AddUserNewAsync(UserModel user)
        {

            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/AddUserNew";

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var z = response.ReasonPhrase;

                    var result = await response.Content.ReadAsStringAsync();

                    int id = JsonConvert.DeserializeObject<int>(result);

                    msj = (result.ToString());

                    return id;
                }
                else
                {
                    return 0;

                }


            }

        }
        public static async Task<string> UploadVideo(MediaFile mivideo, string filename)
        {

            var content = new MultipartFormDataContent();
            //content.Headers.ContentType.MediaType = "multipart/form-data";
            //switch (tipo)
            //{
            //    case (int)TipoVideo.Academics:
            //        content.Add(new StreamContent(video.GetStream()), "\"file\"",
            //    $"\"{path}\"");
            //        break;
            //    case (int)TipoVideo.Jobs:
            //        content.Add(new StreamContent(video.GetStream()), "\"file\"",
            //  $"\"{path}\"");
            //        break;
            //    case (int)TipoVideo.Others:
            //        content.Add(new StreamContent(video.GetStream()), "\"file\"",
            //  $"\"{path}\"");
            //        break;
            //    default:
            //        break;
            //}
            var str = mivideo.GetStream();

            //byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(usr));

            //content.Add(new StreamContent(usr.AcademicsVideo.GetStream()), "\"file\"",
            //    $"\"{usr.AcademicsVideo.Path}\"");

            // content.Add(new ByteArrayContent(byteData));

            content.Add(new StreamContent(str), "\"file\"", filename);


            var httpClient = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Video";

            var httpResponseMessage = await httpClient.PostAsync(uri, content);

            string resp = await httpResponseMessage.Content.ReadAsStringAsync();

            return resp;

        }

        public static async Task<string> UploadVideo(Stream file, string filename)
        {

            var content = new MultipartFormDataContent();
            //content.Headers.ContentType.MediaType = "multipart/form-data";
            //switch (tipo)
            //{
            //    case (int)TipoVideo.Academics:
            //        content.Add(new StreamContent(video.GetStream()), "\"file\"",
            //    $"\"{path}\"");
            //        break;
            //    case (int)TipoVideo.Jobs:
            //        content.Add(new StreamContent(video.GetStream()), "\"file\"",
            //  $"\"{path}\"");
            //        break;
            //    case (int)TipoVideo.Others:
            //        content.Add(new StreamContent(video.GetStream()), "\"file\"",
            //  $"\"{path}\"");
            //        break;
            //    default:
            //        break;
            //}
            //var str = mivideo.GetStream();

            //byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(usr));

            //content.Add(new StreamContent(usr.AcademicsVideo.GetStream()), "\"file\"",
            //    $"\"{usr.AcademicsVideo.Path}\"");

            // content.Add(new ByteArrayContent(byteData));

            content.Add(new StreamContent(file), "\"file\"", filename);


            var httpClient = new HttpClient();

            httpClient.Timeout = new TimeSpan(0, 5, 0); 

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Video";

            var httpResponseMessage = await httpClient.PostAsync(uri, content);

            string resp = await httpResponseMessage.Content.ReadAsStringAsync();

            return resp;

        }
        public static async Task<string> UploadPhoto(Stream foto, string filename)
        {

            var content = new MultipartFormDataContent();
            //content.Headers.ContentType.MediaType = "multipart/form-data";
            //switch (tipo)
            //{
            //    case (int)TipoVideo.Academics:
            //        content.Add(new StreamContent(video.GetStream()), "\"file\"",
            //    $"\"{path}\"");
            //        break;
            //    case (int)TipoVideo.Jobs:
            //        content.Add(new StreamContent(video.GetStream()), "\"file\"",
            //  $"\"{path}\"");
            //        break;
            //    case (int)TipoVideo.Others:
            //        content.Add(new StreamContent(video.GetStream()), "\"file\"",
            //  $"\"{path}\"");
            //        break;
            //    default:
            //        break;
            //}
            //var str = mivideo.GetStream();

            //byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(usr));

            //content.Add(new StreamContent(usr.AcademicsVideo.GetStream()), "\"file\"",
            //    $"\"{usr.AcademicsVideo.Path}\"");

            // content.Add(new ByteArrayContent(byteData));

            if (foto != null)
            {
                content.Add(new StreamContent(foto), "\"file\"", filename);


                var httpClient = new HttpClient();

                var uri = EndPoint.BACKEND_ENDPOINT + "api/Video";

                var httpResponseMessage = await httpClient.PostAsync(uri, content);

                string resp = await httpResponseMessage.Content.ReadAsStringAsync();

                return resp;
            }

            return "Error";
           

        }
        public static async Task<UserModel> GetUserAsync(int idusuario)
        {

            UserModel user = new UserModel();
            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/User/GetUser?idusuario=" + idusuario;

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("{}");



            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    user = JsonConvert.DeserializeObject<UserModel>(result);

                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return user;

        }
        public static async Task<UserModel> GetUserInterestAsync(int idusuario)
        {

            UserModel user = new UserModel();
            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/User/GetUserInterest?idusuario=" + idusuario;

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("{}");



            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    user = JsonConvert.DeserializeObject<UserModel>(result);

                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return user;

        }
        public static async Task<UserModel> GetUserEssentialAsync(int idusuario)
        {

            UserModel user = new UserModel();
            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/User/GetUserEssential?idusuario=" + idusuario;

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("{}");



            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    user = JsonConvert.DeserializeObject<UserModel>(result);

                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return user;

        }
        public static async Task<UserModel> GetUserAcademicsAsync(int idusuario)
        {

            UserModel user = new UserModel();
            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/User/GetUserAcademics?idusuario=" + idusuario;

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("{}");



            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    user = JsonConvert.DeserializeObject<UserModel>(result);

                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return user;

        }
        public static async Task<UserModel> GetUserJobsAsync(int idusuario)
        {

            UserModel user = new UserModel();
            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/User/GetUserJobs?idusuario=" + idusuario;

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("{}");



            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    user = JsonConvert.DeserializeObject<UserModel>(result);

                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return user;

        }
        public static async Task<byte[]> GetCVAsync(int idusuario)
        {

            byte[] CV;

            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/User/GetCV?idusuario=" + idusuario;

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("{}");



            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    CV = JsonConvert.DeserializeObject<byte[]>(result);
                    return CV;
                }
                else
                {
                    return null;
                    // msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }




        }
        public static async Task<Curriculum> GetCVModelAsync(int idusuario)
        {

            var z = new Curriculum();

            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/User/GetCVModel?idusuario=" + idusuario;

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("{}");



            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    z = JsonConvert.DeserializeObject<Curriculum>(result);
                    return z;
                }
                else
                {
                    return null;
                    // msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }




        }
        public static async Task<UserModel> LoginAsync(string username, string password)
        {

            UserModel user = new UserModel();
            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/User/Login?username=" + username + "&password=" + password;

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("{}");



            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    user = JsonConvert.DeserializeObject<UserModel>(result);

                }
                else
                {

                    msj = "Ocurrio un error al iniciar sesion";
                }


            }


            return user;

        }
        public static async Task<bool> DeleteUserAsync(int idusuario)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/User/DeleteAccount?idusuario=" + idusuario;


            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes("{}");



            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<bool>(result);

                }
                else
                {
                    return false;

                }


            }

        }
        public static async Task<bool> UpdatetUserEssentialAsync(UserModel u)
        {

            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/Employee/UpdateEssential";

            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(u));


            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<bool>(result);

                }
                else
                {
                    return false;

                }


            }




        }
        public static async Task<bool> UpdateUserInterestAsync(UserModel u)
        {

            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Employee/UpdateInterest";

            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(u));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<bool>(result);

                }
                else
                {
                    return false;
                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }



        }
        public static async Task<bool> UpdateUserAcademicsAsync(UserModel u)
        {

            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Employee/UpdateAcademics";

            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(u));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<bool>(result);

                }
                else
                {
                    return false;
                   
                }

            }


        }
        public static async Task<bool> UpdateUserJobsAsync(UserModel u)
        {

            UserModel user = new UserModel();
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/Employee/UpdateJobs";

            // Request body

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(u));

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<bool>(result);

                }
                else
                {
                    return false;
                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }

        }
    }
}
