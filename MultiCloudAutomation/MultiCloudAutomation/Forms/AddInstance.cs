using Amazon.EC2;
using Amazon.EC2.Model;
using Newtonsoft.Json;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            ResponseClass getallinstances = await createInstance(textBox1.Text, textBox2.Text, textBox3.Text);
            if (getallinstances.StatusCode == System.Net.HttpStatusCode.Created)
            {
                MessageBox.Show(getallinstances.StatusCode.ToString());
            }
            else if (getallinstances.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Unauthorized Please First Login");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
