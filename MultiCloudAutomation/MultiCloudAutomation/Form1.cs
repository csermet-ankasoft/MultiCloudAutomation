using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util;
using Google.Apis.Services;
using Google.Apis.Compute.v1;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace MultiCloudAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public async Task<string> GetTask(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", textBox1.Text);
            label2.Text = "waiting";
            label2.ForeColor = Color.Orange;
            using (HttpResponseMessage response = await client.GetAsync(new Uri(url)))
            {
                var x = await response.Content.ReadAsStringAsync();
                label2.Text = "Done";
                label2.ForeColor = Color.Green;

                return x;
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = await GetTask("https://compute.googleapis.com/compute/v1/projects/phonic-weaver-337111/zones/us-central1-a/disks");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            OAUTH();
        }

        internal class Token
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }
        }

        public async void OAUTH()
        {
            string baseAddress = @"https://accounts.google.com/o/oauth2/token";
            HttpClient client = new HttpClient();
            string grant_type = "client_credentials";
            string client_id = "427210027681-eofsddhskvdugg5ub5trlhl0874h6tnl.apps.googleusercontent.com";
            string client_secret = "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";

            var form = new Dictionary<string, string>
                {
                    {"grant_type", grant_type},
                    {"client_id", client_id},
                    {"client_secret", client_secret},
                };

            HttpResponseMessage tokenResponse = await client.PostAsync(baseAddress, new FormUrlEncodedContent(form));
            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
            MessageBox.Show(tok.ToString());
        }
        /*
        string clientId = "427210027681-eofsddhskvdugg5ub5trlhl0874h6tnl.apps.googleusercontent.com";
        string clientSecret = "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";
        string[] scopes = { "https://www.googleapis.com/auth/cloud-platform" };

        ComputeService computeService = new ComputeService(new BaseClientService.Initializer
        {
            HttpClientInitializer = GetCredential(),
            ApplicationName = "Google-ComputeSample/0.1",
        });
        
        public static GoogleCredential GetCredential()
        {
            GoogleCredential credential = Task.Run(() => GoogleCredential.GetApplicationDefaultAsync()).Result;
            if (credential.IsCreateScopedRequired)
            {
                credential = credential.CreateScoped("https://www.googleapis.com/auth/cloud-platform");
            }
            return credential;
        }
        // Project ID for this request.
        string project = "my-project";  // TODO: Update placeholder value.

        // Name of the region for this request.
        string region = "my-region";  // TODO: Update placeholder value.

        */

        private static async Task<List<string>> LaunchInstances(IAmazonEC2 ec2Client, RunInstancesRequest requestLaunch)
        {
            var instanceIds = new List<string>();
            RunInstancesResponse responseLaunch = await ec2Client.RunInstancesAsync(requestLaunch);

            MessageBox.Show("\nNew instances have been created.");
            foreach (Instance item in responseLaunch.Reservation.Instances)
            {
                instanceIds.Add(item.InstanceId);
                MessageBox.Show($"  New instance: {item.InstanceId}");
            }

            return instanceIds;
        }

        
        public void getAllInstance(AmazonEC2Client ec2)
        {            
            DescribeInstancesRequest req = new DescribeInstancesRequest();
            List<Amazon.EC2.Model.Reservation> result = ec2.DescribeInstances(req).Reservations;

            foreach (Amazon.EC2.Model.Reservation reservation in result)
            {
                foreach (var runningInstance in reservation.Instances)
                {
                    MessageBox.Show(runningInstance.InstanceId + runningInstance.InstanceType);
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //var awskey = new Amazon.Runtime.BasicAWSCredentials("AKIARLTYWTQ2SUQSPH5P", "JSAoZRYXwulUh8IOhuFMkzKDXWH2fCaV911o1/F4");
            AmazonEC2Client ec2 = new AmazonEC2Client();
            getAllInstance(ec2);            
            RunInstancesRequest req = new RunInstancesRequest("ami-0c02fb55956c7d316", 1,1);

            InstanceType t2  = new InstanceType("t2.micro");
            req.InstanceType = t2;
            await LaunchInstances(ec2, req);


            /*
            RegionDisksResource.ListRequest request = computeService.RegionDisks.List(project, region);
            Google.Apis.Compute.v1.Data.DiskList response;
            do
            {
                // To execute asynchronously in an async method, replace `request.Execute()` as shown:
                response = request.Execute();
                // response = await request.ExecuteAsync();

                if (response.Items == null)
                {
                    continue;
                }
                foreach (Google.Apis.Compute.v1.Data.Disk disk in response.Items)
                {
                    // TODO: Change code below to process each `disk` resource:
                    MessageBox.Show(JsonConvert.SerializeObject(disk));
                }
                request.PageToken = response.NextPageToken;
            } while (response.NextPageToken != null);
            */
        }
    }
}
