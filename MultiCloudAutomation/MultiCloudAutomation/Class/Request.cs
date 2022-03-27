using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.Class
{
    class Request
    {
        public async Task<string> GetRequest(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "nope");
            //label2.Text = "waiting";
            //label2.ForeColor = Color.Orange;
            using (HttpResponseMessage response = await client.GetAsync(new Uri(url)))
            {
                var x = await response.Content.ReadAsStringAsync();
                //label2.Text = "Done";
                //label2.ForeColor = Color.Green;

                return x;
            }
        }
        Task<string> test;
    }
}
