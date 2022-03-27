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
using Amazon;
using Newtonsoft.Json.Linq;

namespace MultiCloudAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string task;

        private async void button1_Click(object sender, EventArgs e)
        {
            if (Request.done == true)
            {
                label2.Text = "Waiting Request";
                label2.ForeColor = Color.DarkRed    ;
                AWS.getAllInstanceBody body = new AWS.getAllInstanceBody("us-east-1");
                string jsonbody = JsonConvert.SerializeObject(body);
                task = await Request.PostRequestAsync("aws/instance/getAllInstance",jsonbody);
                label1.Text = task;
                label2.Text = "Done";
                label2.ForeColor = Color.DarkOliveGreen;

                JArray json_data = (JArray) JsonConvert.DeserializeObject(task);
                List<Data.Root> dr = new List<Data.Root>();

                var z = JsonConvert.SerializeObject(json_data[0]["instances"][0]);                
                var result = JsonConvert.DeserializeObject<Data.Root>(z);
                dr.Add(result);
                 z = JsonConvert.SerializeObject(json_data[1]["instances"][0]);
                 result = JsonConvert.DeserializeObject<Data.Root>(z);
                dr.Add(result);
                 z = JsonConvert.SerializeObject(json_data[2]["instances"][0]);
                 result = JsonConvert.DeserializeObject<Data.Root>(z);
                dr.Add(result);

                dataGridView1.DataSource = dr;
                
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
