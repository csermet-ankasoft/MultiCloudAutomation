using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiCloudAutomation.Forms
{
    public partial class AzureAddInstance : Form
    {
        public AzureAddInstance()
        {
            InitializeComponent();
        }
        ResponseClass task;

        private async void AzureAddInstance_Load(object sender, EventArgs e)
        {
            var resourceGroupRequest = await ResourceGroupRequest();
            ResourceGroupAddComboBox(resourceGroupRequest);
        }

        public async Task<ResponseClass> ResourceGroupRequest()
        {
            task = await Request.GetRequestAsync("azure/ResourceGroupsGet");
            return task;
        }

        public void ResourceGroupAddComboBox(ResponseClass instances)
        {
            comboBoxResourceGroup.Items.Clear();
            JArray json_data = (JArray)JsonConvert.DeserializeObject(instances.Content);
            foreach (var item in json_data)
            {
                
                comboBoxResourceGroup.Items.Add(item["name"].ToString());
            }
        }

        public async void networkInterfacenamesAddComboBox(string resourceGroup)
        {
            comboBoxnic.Items.Clear();
            AZURE.NameByResourceGroupBody body = new AZURE.NameByResourceGroupBody(resourceGroup);
            string jsonbody = JsonConvert.SerializeObject(body);
            var response = await Request.PostRequestAsync("azure/networkInterfacenames", jsonbody);
            JArray json_data = (JArray)JsonConvert.DeserializeObject(response.Content);
            foreach (var item in json_data)
            {
                comboBoxnic.Items.Add(item);
            }
        }

        public async Task<string> createInstance()
        {
            AZURE.AddInstancebody body = null;
            if (comboBoxOsType.Text == "Linux")
            {
                body = new AZURE.AddInstancebody(textBoxVMName.Text, comboBoxResourceGroup.Text, comboBoxRegion.Text, textBoxComputerName.Text
                , "Standard_B1s", comboBoxOsType.Text, "OpenLogic", "CentOS", "7.3"
                , comboBoxnic.Text, textBoxadminusername.Text, textBoxadminpass.Text);
            }
            else if (comboBoxOsType.Text == "Windows")
            {
                body = new AZURE.AddInstancebody(textBoxVMName.Text, comboBoxResourceGroup.Text, comboBoxRegion.Text, textBoxComputerName.Text
                , "Standard_B1s", comboBoxOsType.Text, "MicrosoftWindowsServer", "WindowsServer", "2012-R2-Datacenter"
                , comboBoxnic.Text, textBoxadminusername.Text, textBoxadminpass.Text);
            }
            
            string jsonbody = JsonConvert.SerializeObject(body);
            var response = await Request.PostRequestAsync("azure/createInstance", jsonbody);
            MessageBox.Show(response.Content);
            return response.Content;
        }




        private async void button1_Click(object sender, EventArgs e)
        {
            string response = await createInstance();
        }

        private void comboBoxResourceGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            networkInterfacenamesAddComboBox(comboBoxResourceGroup.Items[comboBoxResourceGroup.SelectedIndex].ToString());
        }
    }
}
