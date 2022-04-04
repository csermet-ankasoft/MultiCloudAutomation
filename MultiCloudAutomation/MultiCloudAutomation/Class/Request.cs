using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation
{
    class Request
    {
        public static bool  done = true;

        public static async Task<string> PostRequest(string url, string jsonbody)
        {
            done = false;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44328/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("t");
            var httpContent = new StringContent(jsonbody, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PostAsync(url, httpContent))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                done = true;
                return responseContent;
            }
        }

        public static Task<string> PostRequestAsync(string url, string jsonbody)
        {
            return Task.Run(() =>  PostRequest(url, jsonbody));
        }

        public static async Task<string> GetRequest(string url)
        {
            done = false;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44328/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                done = true;
                return responseContent;
            }
        }

        public static Task<string> GetRequestAsync(string url)
        {
            return Task.Run(() => GetRequest(url));
        }

    }
}
