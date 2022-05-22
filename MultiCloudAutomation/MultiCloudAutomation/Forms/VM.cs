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

        //Başlangıç Variables
        ResponseClass task;
        List<DataGridViewVM> instanceDataGridViewList;
        int selectedColumnIndex = 0;
        string region = "us-east-1";


        

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1_Tick(sender,e);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                dataGridViewRefresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }            
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            labelHTTPAWS.Text = "AWS HTTP: Waiting...";
            labelHTTPAZURE.Text = "AZURE HTTP: Waiting...";
            dataGridViewRefresh();

        }

        private void buttonCreateInstance_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddInstance addInstanceForm = new AddInstance();
            addInstanceForm.Show();
            addInstanceForm.FormClosing += newFormClossing;
        }   
        
        private async void startInstance_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {

            }
            else if(dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                await AWSstartInstance();
            }
                
        }

        private async void stopInstance_Click(object sender, EventArgs e)
        {            
            if (dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {

            }
            else if (dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                await AWSstopInstance();
            }
        }

        private async void buttonTerminate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {

            }
            else if (dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                await AWSterminateInstance();
            }
            
        }

        private async void buttonReboot_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {

            }
            else if (dataGridView1.Rows[selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                await AWSrebootInstance();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (selectedColumnIndex != dataGridView1.CurrentCell.RowIndex)
            {
                selectedColumnIndex = dataGridView1.CurrentCell.RowIndex;
                buttonStart.Enabled = true;
                buttonTerminate.Enabled = true;
                buttonReboot.Enabled = true;
                buttonStop.Enabled = true;                
            }

        }     

        public async void dataGridViewRefresh()
        {
            instanceDataGridViewList = new List<DataGridViewVM>();
            await AWSDGVListAdd();
            await AZUREDGVListAdd();
            dataGridView1.DataSource = instanceDataGridViewList.ToList();
        }

        public async Task<string> AWSDGVListAdd()
        {
            ResponseClass instances = await AWSAllInstance(region);            
            if (instances.StatusCode == HttpStatusCode.OK)
            {
                AWSinstance_To_DataGridViewVMList(instances);
            }
            labelHTTPAWS.Text = "AWS HTTP: " + instances.StatusCode.ToString();
            return instances.StatusCode.ToString();
        }
        public async Task<string> AZUREDGVListAdd()
        {
            ResponseClass instances = await AZUREAllInstance();
            if (instances.StatusCode == HttpStatusCode.OK)
            {
                AZUREinstance_To_DataGridViewVMList(instances);
            }
            labelHTTPAZURE.Text = "AZURE HTTP: " + instances.StatusCode.ToString();
            return instances.StatusCode.ToString();
        }

        public async Task<ResponseClass> AWSAllInstance(string region)
        {
            AWS.getAllInstanceBody body = new AWS.getAllInstanceBody(region);
            string jsonbody = JsonConvert.SerializeObject(body);
            task = await Request.PostRequestAsync("aws/instance/getAllInstance", jsonbody);
            return task;
        }

        public void AWSinstance_To_DataGridViewVMList(ResponseClass instances)
        {
            string jsonbody = JsonConvert.SerializeObject(instances);
            JArray json_data = (JArray)JsonConvert.DeserializeObject(task.Content);
            foreach (var item in json_data)
            {
                DataGridViewVM instance = new DataGridViewVM();
                instance.CloudType = "AWS";
                instance.InstanceName = "";
                foreach (var tag in item["instances"][0]["tags"])
                {
                    if (tag["key"].ToString() == "Name")
                    {
                        instance.InstanceName =tag["value"].ToString();
                        break;
                    }
                }                
                instance.VMID = item["instances"][0]["instanceId"].ToString();
                instance.InstanceState = item["instances"][0]["state"]["name"]["value"].ToString();
                instance.InstanceType = item["instances"][0]["instanceType"]["value"].ToString();
                instance.OSType = item["instances"][0]["platformDetails"].ToString();
                instance.PublicIP= item["instances"][0]["publicIpAddress"].ToString();
                instanceDataGridViewList.Add(instance);
            }
        }

        public async Task<ResponseClass> AZUREAllInstance()
        {
            task = await Request.GetRequestAsync("azure/getVMSimple");
            return task;
        }

        public void AZUREinstance_To_DataGridViewVMList(ResponseClass instances)
        {
            string jsonbody = JsonConvert.SerializeObject(instances);
            JArray json_data = (JArray)JsonConvert.DeserializeObject(task.Content);
            foreach (var item in json_data)
            {
                DataGridViewVM instance = new DataGridViewVM();
                instance.CloudType = "AZURE";
                instance.VMID = item["vmid"].ToString();
                instance.InstanceName = item["instanceName"].ToString();
                instance.InstanceState = item["instanceState"].ToString();
                instance.InstanceType = item["instanceType"].ToString();
                instance.OSType = item["osType"].ToString();
                instance.PublicIP = item["publicIP"].ToString();
                instanceDataGridViewList.Add(instance);
            }
        }

        public async Task<ResponseClass> AWSstartInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[1].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/instance/startInstance", jsonbody);
            System.Threading.Thread.Sleep(1000);
            await WaitFiveSecond();
            return task;
        }

        public async Task<ResponseClass> AWSstopInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[1].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/instance/stopInstance", jsonbody);
            await WaitFiveSecond();
            return task;
        }

        public async Task<ResponseClass> AWSrebootInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[1].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/instance/rebootInstance", jsonbody);
            await WaitFiveSecond();
            return task;
        }

        public async Task<ResponseClass> AWSterminateInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[1].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/instance/terminateInstance", jsonbody);
            await WaitFiveSecond();
            return task;
        }

        public async Task WaitFiveSecond()
        {
            await Task.Delay(5000);
            dataGridViewRefresh();
        }



        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + dataGridView1.Rows[selectedColumnIndex].Cells[1].Value.ToString());
        }
    }
}
