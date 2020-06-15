using JobMe.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TheChat.Core.Models;

namespace JobMe.Services
{
    class PositionService
    {

        public static async Task<int> AddPositionAsync(Positions pos)
        {


            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT +  "api/AddPosition";

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(pos));



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
                        var z = Convert.ToInt32(result);
                        return z;
                    }
                    catch (Exception)
                    {
                        return 0;
                       // throw;
                    }

                }
                else
                {

                    return 0;
                }


            }
                                  
        }

        public static async Task<ObservableCollection<ListaPositions>> GetPositionsAsync(int IDEmployer, int userid = 0)
        {


            var client = new HttpClient();
             ObservableCollection<ListaPositions> c = new ObservableCollection<ListaPositions>();

            var uri = EndPoint.BACKEND_ENDPOINT +  "api/GetPositions?IDEmployer=" + IDEmployer + "&UserID=" + userid;

           // var uri = EndPoint.BACKEND_ENDPOINT + "api/GetPositions?IDEmployer=" + IDEmployer + "&UserID=" + userid;

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

                     c = JsonConvert.DeserializeObject<ObservableCollection<ListaPositions>>(result);

                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al agregar la vacante";
                }


            }


            return c;

        }

        public static async Task<Positions> GetPositionAsync(int IDPosition)
        {


            var client = new HttpClient();
            Positions c = new Positions();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/GetPosition?IDPosition=" + IDPosition;

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

                    try
                    {
                        c = JsonConvert.DeserializeObject<Positions>(result);
                        return c;
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
        public static async Task<ObservableCollection<PositionsLiked>> GetPositionsLiked(int idJobPosition)
        {
                        
            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "/api/User/GetPositionsLiked?idPosition=" + idJobPosition;

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

                    return  JsonConvert.DeserializeObject<ObservableCollection<PositionsLiked>>(result);

                    msj = (result.ToString());
                }
                else
                {
                    return null;
                    msj = "Ocurrio un error al agregar la vacante";
                }


            }





        }

        public static async Task<ObservableCollection<CandidatesLiked>> GetCandidatesLiked(int UserID)
        {

          
            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "/api/User/GetCandidatesLiked?UserID=" + UserID;

          
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

                    return JsonConvert.DeserializeObject<ObservableCollection<CandidatesLiked>>(result);

                    msj = (result.ToString());
                }
                else
                {
                    return null;
                    msj = "Ocurrio un error al agregar la vacante";
                }


            }

        }

        public static async Task<int> GetCandidateLiked(int UserID, int IDPosition)
        {


            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "/api/User/GetCandidateLiked?UserID=" + UserID + "&IDPosition=" + IDPosition;


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

                    return JsonConvert.DeserializeObject<int>(result);
                   
                }
                else
                {
                    return 0;
                    msj = "Ocurrio un error al agregar la vacante";
                }


            }

        }

        public static async Task<int> GetPositionLiked(int IDPosition, int UserID)
        {

            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "/api/User/GetPositionLiked?idPosition=" + IDPosition + "&UserID=" + UserID;

          

            byte[] byteData = Encoding.UTF8.GetBytes("{}");


            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<int>(result);

                 
                }
                else
                {
                    return 0;
                  
                }


            }





        }

        public static async Task<ObservableCollection<UserModel>> GetCandidatesByPositionAsync(int idJobPosition) {

            ObservableCollection<UserModel> usr = new ObservableCollection<UserModel>();

            var client = new HttpClient();
          

            var uri = EndPoint.BACKEND_ENDPOINT + "/api/User/GetCandidatesByPosition?idPosition=" + idJobPosition;

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

                    usr = JsonConvert.DeserializeObject<ObservableCollection<UserModel>>(result);

                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al agregar la vacante";
                }


            }


            return usr;


        
        }

        public static async Task<ObservableCollection<Positions>> GetPositionsbyCandidateAsync(int userID)
        {

            ObservableCollection<Positions> pos = new ObservableCollection<Positions>();

            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "/api/GetPositionsbyCandidateAsync?UserID=" + userID;

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

                    pos = JsonConvert.DeserializeObject<ObservableCollection<Positions>>(result);

                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al agregar la vacante";
                }


            }


            return pos;



        }

        public static async Task<int> UpdatePositionAsync(Positions pos)
        {


            var client = new HttpClient();


            var uri = EndPoint.BACKEND_ENDPOINT + "api/UpdatePosition";

            //var uri = "https://localhost:44327/api/user";
            // Request body


            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(pos));



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
                        var z = Convert.ToInt32(result);
                        return z;
                    }
                    catch (Exception)
                    {
                        return 0;
                        // throw;
                    }

                }
                else
                {

                    return 0;
                }


            }

        }

        public static async Task<bool> DeletePositionAsync(int IDPosition)
        {


            var client = new HttpClient();
         

            var uri = EndPoint.BACKEND_ENDPOINT + "api/DeletePosition?idposition=" + IDPosition;

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
    }
}
