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
    class JobMe
    {
        public static async Task<int> UserExistAsync(string Mail, string UserName)
        {
            var client = new HttpClient();

            var uri = EndPoint.BACKEND_ENDPOINT + "api/UserExist/?mail=" + Mail + "&username=" + UserName;

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
                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }




        }
        public static async Task<bool> ForgotPassword(string UserName)
        {
            var client = new HttpClient();            

            var uri = EndPoint.BACKEND_ENDPOINT + "api/ForgotPassword/?username=" + UserName ;

          
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

                    return  JsonConvert.DeserializeObject<bool>(result);
                   
                }
                else
                {
                    return false;
                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


           

        }
        public static async Task<ObservableCollection<Paises>> GetCountries()
        {


            var client = new HttpClient();
            ObservableCollection<Paises> c = new ObservableCollection<Paises>();

            var uri = EndPoint.BACKEND_ENDPOINT + "/api/GetCountries";

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
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<Paises>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }


        public static async Task<ObservableCollection<Ciudades>> GetCities()
        {


            var client = new HttpClient();
            ObservableCollection<Ciudades> c = new ObservableCollection<Ciudades>();

            var uri = EndPoint.BACKEND_ENDPOINT +   "/api/GetCities";

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
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<Ciudades>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }

        public static async Task<ObservableCollection<Escuelas>> GetSchools(bool todas = false)
        {


            var client = new HttpClient();
            var uri = string.Empty;
            ObservableCollection<Escuelas> c = new ObservableCollection<Escuelas>();

            if(todas)
            {
                 uri = EndPoint.BACKEND_ENDPOINT + "api/GetSchools?todas=1";
            }
            else
            {

                 uri = EndPoint.BACKEND_ENDPOINT + "api/GetSchools?todas=0";
            }

            //var uri = EndPoint.BACKEND_ENDPOINT + "api/GetSchools";

            byte[] byteData = Encoding.UTF8.GetBytes("");

            string msj = string.Empty;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<Escuelas>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }

        public static async Task<ObservableCollection<Titulos>> GetDegrees(bool todas = false)
        {


            var client = new HttpClient();
            var uri = string.Empty;

            ObservableCollection<Titulos> c = new ObservableCollection<Titulos>();
            if (todas)
            {
                 uri = EndPoint.BACKEND_ENDPOINT + "api/GetDegrees?todas=1";

            }
            else
            {
                 uri = EndPoint.BACKEND_ENDPOINT +  "api/GetDegrees?todas=0";

            }

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
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<Titulos>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }

        public static async Task<ObservableCollection<AñosGraduacion>> GetYears()
        {


            var client = new HttpClient();
            ObservableCollection<AñosGraduacion> c = new ObservableCollection<AñosGraduacion>();

            var uri = EndPoint.BACKEND_ENDPOINT + "/api/GetYears";

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
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<AñosGraduacion>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }

        public static async Task<ObservableCollection<Certificaciones>> GetCertifications()
        {


            var client = new HttpClient();
            ObservableCollection<Certificaciones> c = new ObservableCollection<Certificaciones>();

            var uri = EndPoint.BACKEND_ENDPOINT +  "/api/GetCertifications";

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
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<Certificaciones>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }

        public static async Task<ObservableCollection<Experiencias>> GetExperience()
        {


            var client = new HttpClient();
            ObservableCollection<Experiencias> c = new ObservableCollection<Experiencias>();

            var uri = EndPoint.BACKEND_ENDPOINT +  "/api/GetExperience";

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
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<Experiencias>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }

        public static async Task<ObservableCollection<Idiomas>> GetLanguajes()
        {


            var client = new HttpClient();
            ObservableCollection<Idiomas> c = new ObservableCollection<Idiomas>();

            var uri = EndPoint.BACKEND_ENDPOINT + "/api/GetLanguajes";

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
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<Idiomas>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }

        public static async Task<ObservableCollection<Salarios>> GetSalaries()
        {


            var client = new HttpClient();
            ObservableCollection<Salarios> c = new ObservableCollection<Salarios>();

            var uri = EndPoint.BACKEND_ENDPOINT +  "/api/GetSalaries";

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
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<Salarios>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }

        public static async Task<ObservableCollection<BSFields>> GetBSFields()
        {


            var client = new HttpClient();
            ObservableCollection<BSFields> c = new ObservableCollection<BSFields>();

            var uri = EndPoint.BACKEND_ENDPOINT + "/api/GetBSFields";

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
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<BSFields>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }

        public static async Task<ObservableCollection<Areas>> GetAreas()
        {


            var client = new HttpClient();
            ObservableCollection<Areas> c = new ObservableCollection<Areas>();

            var uri = EndPoint.BACKEND_ENDPOINT + "/api/GetAreas";

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
                    var result = await response.Content.ReadAsStringAsync();

                    c = JsonConvert.DeserializeObject<ObservableCollection<Areas>>(result);
                    msj = (result.ToString());
                }
                else
                {

                    msj = "Ocurrio un error al solicitar tus vacaciones";
                }


            }


            return c;

        }
    }

}
