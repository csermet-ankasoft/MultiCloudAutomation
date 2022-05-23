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
            var t = await ResourceGroupRequest();
            ResourceGroup_toResponse(t);
        }

        public async Task<ResponseClass> ResourceGroupRequest()
        {
            task = await Request.GetRequestAsync("azure/ResourceGroupsGet");
            return task;
        }

        public void ResourceGroup_toResponse(ResponseClass instances)
        {
            string jsonbody = JsonConvert.SerializeObject(instances);
            JArray json_data = (JArray)JsonConvert.DeserializeObject(task.Content);
            foreach (var item in json_data)
            {
                
                comboBoxResourceGroup.Items.Add(item["name"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
