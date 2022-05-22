using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiCloudAutomation
{
    public partial class AddInstance : Form
    {
        public AddInstance()
        {
            InitializeComponent();
        }

        ResponseClass task;
        List<string> regionEndpointList = new List<string>();

        public async Task<ResponseClass> createInstance(string instanceType, string region, string imageID, int count = 1)
        {
            AWS.createInstanceBody body = new AWS.createInstanceBody(instanceType, region, imageID, count = 1);
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("Name", textBox4.Text);
            body.tagDictionary = test;
            string jsonbody = JsonConvert.SerializeObject(body);
            task = await Request.PostRequestAsync("aws/instance/createInstance", jsonbody);
            return task;
        }

        public async Task<ResponseClass> getAllInstanceType()
        {
            task = await Request.GetRequestAsync("aws/getAllInstanceTypes");
            return task;
        }

        public async Task<ResponseClass> getAllRegion()
        {
            task = await Request.GetRequestAsync("aws/getAllRegion");
            return task;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string instanceType = regionNameToValueFinder(comboBoxInstanceType.Text);
            string regionEndpoint = regionEndpointList[comboBoxRegion.SelectedIndex];
            string imageID = textBox3.Text;
            if (instanceType == "t2.micro" && regionEndpoint == "us-east-1")
            {
                ResponseClass getallinstances = await createInstance(instanceType, regionEndpoint, imageID);
                if (getallinstances.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show(getallinstances.StatusCode.ToString());
                }
                else if (getallinstances.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Unauthorized Please First Login");
                }
                else
                {
                    MessageBox.Show(getallinstances.StatusCode.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please Select Free Tier (T2Micro and US EAST Virginia)");
            }
            
        }

        public string regionNameToValueFinder(string regionName)
        {
            for (int i = 0; i < regionName.ToString().Length - 2; i++)
            {
                string tempstring = regionName;
                tempstring = tempstring.Insert(i + 2, ".");
                if (InstanceType.FindValue(tempstring).Value != tempstring)
                {
                    return InstanceType.FindValue(tempstring).Value;
                }

            }
            return "";
        }

        public async void comboboxInstanceTypeAdd()
        {
            ResponseClass responsegetAllInstanceType = await getAllInstanceType();
            JArray json_data = (JArray)JsonConvert.DeserializeObject(responsegetAllInstanceType.Content);
            foreach (var item in json_data)
            {
                comboBoxInstanceType.Items.Add(item);
            }
            comboBoxInstanceType.SelectedIndex = 418;
        }
        public async void comboboxInstanceRegionAdd()
        {
            ResponseClass responsegetAllInstanceType = await getAllRegion();
            JArray json_data = (JArray)JsonConvert.DeserializeObject(responsegetAllInstanceType.Content);
            foreach (var item in json_data)
            {
                regionEndpointList.Add(item["systemName"].ToString());
                comboBoxRegion.Items.Add(item["displayName"].ToString());
            }
            comboBoxRegion.SelectedIndex = 18;
        }


        private void AddInstance_Load(object sender, EventArgs e)
        {
            comboboxInstanceTypeAdd();
            comboboxInstanceRegionAdd();
        }

        private void AddInstance_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
