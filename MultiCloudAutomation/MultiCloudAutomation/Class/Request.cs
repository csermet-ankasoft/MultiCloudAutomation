using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation
{
    class Request
    {
        public static bool  done = true;

        public static HttpClient HttpClientStandart()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44328/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("t");
            return client;
        }
        public static async Task<ResponseClass> responsereturn(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            HttpStatusCode responseStatusCode = response.StatusCode;
            ResponseClass responseclass = new ResponseClass(responseContent, responseStatusCode);
            return responseclass;
        }


        public static async Task<ResponseClass> PostRequest(string url, string jsonbody)
        {
            HttpClient client = HttpClientStandart();            
            var httpContent = new StringContent(jsonbody, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PostAsync(url, httpContent))
            {
                return await responsereturn(response);
            }
        }

        public static Task<ResponseClass> PostRequestAsync(string url, string jsonbody)
        {
            return Task.Run(() =>  PostRequest(url, jsonbody));
        }

        public static async Task<ResponseClass> GetRequest(string url)
        {
            HttpClient client = HttpClientStandart();
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                return await responsereturn(response);
            }
        }

        public static Task<ResponseClass> GetRequestAsync(string url)
        {
            return Task.Run(() => GetRequest(url));
        }

    }
}
