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
using static MultiCloudAutomation.Request;
using System.Net;

namespace MultiCloudAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newFormClossing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        //Beginning Variables
        ResponseClass task;
        List<AWS.InstanceDataGridView> instanceDataGridViewList;
        int selectedColumnIndex = 0;
        string region = "us-east-1";


        

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1_Tick(sender,e);
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                await dataGridViewRefresh();
            }
            catch (Exception)
            {
                
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewRefresh();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //ResponseClass loginList = await login();
            //MessageBox.Show(loginList.Content);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddInstance addInstanceForm = new AddInstance();
            addInstanceForm.Show();
            addInstanceForm.FormClosing += newFormClossing;
        }   
        
        private async void button5_Click(object sender, EventArgs e)
        {
            var tempresult = await startInstance();
            MessageBox.Show(tempresult.Content.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            stopInstance();
        }

        private void buttonTerminate_Click(object sender, EventArgs e)
        {
            terminateInstance();
        }

        private void buttonReboot_Click(object sender, EventArgs e)
        {
            rebootInstance();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (selectedColumnIndex != dataGridView1.CurrentCell.RowIndex)
            {
                selectedColumnIndex = dataGridView1.CurrentCell.RowIndex;
                buttonStart.Enabled = true;
                buttonStop.Enabled = true;
                buttonTerminate.Enabled = true;
                buttonReboot.Enabled = true;
            }

        }
        
        public async Task<ResponseClass> getAllInstance(string region)
        {
            AWS.getAllInstanceBody body = new AWS.getAllInstanceBody(region);
            string jsonbody = JsonConvert.SerializeObject(body);
            task = await Request.PostRequestAsync("aws/instance/getAllInstance", jsonbody);
            return task;
        }        

        public async Task<HttpStatusCode> dataGridViewRefresh()
        {
            ResponseClass getallinstances = await getAllInstance(region);
            instanceDataGridViewList = new List<AWS.InstanceDataGridView>();
            if (getallinstances.StatusCode == HttpStatusCode.OK)
            {
                instanceToListInstanceAWS(getallinstances);
                dataGridView1.DataSource = instanceDataGridViewList.ToList();
            }
            else if (getallinstances.StatusCode == HttpStatusCode.Unauthorized)
            {
                //MessageBox.Show("Unauthorized Please First Login");
            }
            else
            {
                MessageBox.Show(getallinstances.StatusCode.ToString());
            }
            label2.Text = getallinstances.StatusCode.ToString();
            return getallinstances.StatusCode;
        }        

        public void instanceToListInstanceAWS(ResponseClass getallinstances)
        {
            string jsonbody = JsonConvert.SerializeObject(getallinstances);
            JArray json_data = (JArray)JsonConvert.DeserializeObject(task.Content);
            foreach (var item in json_data)
            {
                AWS.InstanceDataGridView instance = new AWS.InstanceDataGridView();
                instance.InstanceId = item["instances"][0]["instanceId"].ToString();
                instance.InstanceState = item["instances"][0]["state"]["name"]["value"].ToString();
                instance.InstanceType = item["instances"][0]["instanceType"]["value"].ToString();
                instance.AvailabilityZone = item["instances"][0]["placement"]["availabilityZone"].ToString();
                instance.PublicIPv4DNS = item["instances"][0]["publicDnsName"].ToString();
                instance.PublicIPv4Address = item["instances"][0]["publicIpAddress"].ToString();
                instance.LaunchTime = item["instances"][0]["launchTime"].ToString();

                instanceDataGridViewList.Add(instance);
            }
        }

        public async Task<ResponseClass> startInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/instance/startInstance", jsonbody);
            System.Threading.Thread.Sleep(1000);
            await WaitFiveSecond();
            return task;
        }

        public async Task<ResponseClass> stopInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/instance/stopInstance", jsonbody);
            await WaitFiveSecond();
            return task;
        }

        public async Task<ResponseClass> rebootInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/instance/rebootInstance", jsonbody);
            await WaitFiveSecond();
            return task;
        }

        public async Task<ResponseClass> terminateInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/instance/terminateInstance", jsonbody);
            await WaitFiveSecond();
            return task;
        }

        public async Task WaitFiveSecond()
        {
            await Task.Delay(2000);
            dataGridViewRefresh();
        }



        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*
            switch (e.ColumnIndex)
            {
                case 0:
                    dataGridView1.DataSource = instanceDataGridViewList.OrderBy(o => o.InstanceId).ToList();
                    break;
            }
            */
        }

        
    }
}
