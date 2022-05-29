using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon;
using Newtonsoft.Json.Linq;
using static MultiCloudAutomation.Request;
using System.Net;
using Newtonsoft.Json;

namespace MultiCloudAutomation.AWSInstance
{
    class Instance
    {
        DataGridView dataGridView1;
        ResponseClass task;
        public static int selectedColumnIndex = 0;
        public static string region = "us-east-1";

        public Instance(DataGridView dataGridView1)
        {
            this.dataGridView1 = dataGridView1;
        }

        public async Task<ResponseClass> AWSAllInstance(string region)
        {
            AWS.getAllInstanceBody body = new AWS.getAllInstanceBody(region);
            string jsonbody = JsonConvert.SerializeObject(body);
            task = await Request.PostRequestAsync("aws/getAllInstance", jsonbody);
            return task;
        }

        public async Task<string> AWSDGVListAdd()
        {
            ResponseClass instances = await AWSAllInstance(region);
            if (instances.StatusCode == HttpStatusCode.OK)
            {
                AWSinstance_To_DataGridViewVMList(instances);
            }
            return instances.StatusCode.ToString();
        }

        public void AWSinstance_To_DataGridViewVMList(ResponseClass instances)
        {
            try
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
                            instance.InstanceName = tag["value"].ToString();
                            break;
                        }
                    }
                    instance.VMID = item["instances"][0]["instanceId"].ToString();
                    instance.InstanceState = item["instances"][0]["state"]["name"]["value"].ToString();
                    instance.InstanceType = item["instances"][0]["instanceType"]["value"].ToString();
                    instance.OSType = item["instances"][0]["platformDetails"].ToString();
                    instance.PublicIP = item["instances"][0]["publicIpAddress"].ToString();
                    Cloud.instanceDataGridViewList.Add(instance);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
            
        }


        public async Task<ResponseClass> AWSstartInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[1].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/startInstance", jsonbody);
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
            task = await Request.PostRequestAsync("aws/stopInstance", jsonbody);
            await WaitFiveSecond();
            return task;
        }

        public async Task<ResponseClass> AWSrebootInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[1].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/rebootInstance", jsonbody);
            await WaitFiveSecond();
            return task;
        }

        public async Task<ResponseClass> AWSterminateInstance()
        {
            List<string> templist = new List<string>();
            templist.Add(dataGridView1.Rows[selectedColumnIndex].Cells[1].Value.ToString());
            AWS.InstanceIDListBody loginbody = new AWS.InstanceIDListBody(templist, region);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            task = await Request.PostRequestAsync("aws/terminateInstance", jsonbody);
            await WaitFiveSecond();
            return task;
        }

        public async Task WaitFiveSecond()
        {
            await Task.Delay(5000);
            //dataGridViewRefresh();
        }
    }
}
