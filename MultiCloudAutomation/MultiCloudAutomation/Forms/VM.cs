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
        AWSInstance.Instance AWSinstanceCode = null;
        AZUREInstance.Instance AZUREinstanceCode = null;



        private void Form1_Load(object sender, EventArgs e)
        {
            AWSinstanceCode = new AWSInstance.Instance(dataGridView1);
            AZUREinstanceCode = new AZUREInstance.Instance();
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

        private void buttonCreateInstanceAzure_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.AzureAddInstance addInstanceForm = new  Forms.AzureAddInstance();
            addInstanceForm.Show();
            addInstanceForm.FormClosing += newFormClossing;
        }

        private async void startInstance_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {
                labelHTTPAZURE.Text = "AZURE HTTP: Starting...";
                var responseinstance = await AZUREinstanceCode.AZUREInstanceStart(dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[1].Value.ToString());
                labelHTTPAZURE.Text = "AZURE HTTP: " + responseinstance.StatusCode;
            }
            else if(dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                labelHTTPAWS.Text = "AWS HTTP: Starting...";
                var responseinstance= await AWSinstanceCode.AWSstartInstance();
                labelHTTPAWS.Text = "AWS HTTP: " + responseinstance.StatusCode;
            }
                
        }

        private async void stopInstance_Click(object sender, EventArgs e)
        {            
            if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {
                labelHTTPAZURE.Text = "AZURE HTTP: Stopping...";
                var responseinstance = await AZUREinstanceCode.AZUREInstanceStop(dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[1].Value.ToString());
                labelHTTPAZURE.Text = "AZURE HTTP: " + responseinstance.StatusCode;

            }
            else if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                labelHTTPAWS.Text = "AWS HTTP: Stopping...";
                var responseinstance = await AWSinstanceCode.AWSstopInstance();
                labelHTTPAWS.Text = "AWS HTTP: " + responseinstance.StatusCode;
            }
        }

        private async void buttonTerminate_Click(object sender, EventArgs e)
        {
            DialogResult messageboxresult = MessageBox.Show(dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[1].Value.ToString() + " Silmek istediğinize emin misiniz","Uyarı",MessageBoxButtons.YesNo);
            if (messageboxresult.ToString() == "Yes" )
            {
                if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
                {
                    labelHTTPAZURE.Text = "AZURE HTTP: Terminating...";
                    var responseinstance = await AZUREinstanceCode.AZUREInstanceTerminate(dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[1].Value.ToString());
                    labelHTTPAZURE.Text = "AZURE HTTP: " + responseinstance.StatusCode;
                }
                else if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
                {
                    labelHTTPAWS.Text = "AWS HTTP: Terminating...";
                    var responseinstance = await AWSinstanceCode.AWSterminateInstance();
                    labelHTTPAWS.Text = "AWS HTTP: " + responseinstance.StatusCode;
                }
            }
            
            
        }

        private async void buttonReboot_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {
                labelHTTPAZURE.Text = "AZURE HTTP: Rebooting...";
                var responseinstance = await AZUREinstanceCode.AZUREInstanceRestart(dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[1].Value.ToString());
                labelHTTPAZURE.Text = "AZURE HTTP: " + responseinstance.StatusCode;
            }
            else if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                labelHTTPAWS.Text = "AWS HTTP: Rebooting...";
                var responseinstance = await AWSinstanceCode.AWSrebootInstance();
                labelHTTPAWS.Text = "AWS HTTP: " + responseinstance.StatusCode;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (AWSInstance.Instance.selectedColumnIndex != dataGridView1.CurrentCell.RowIndex)
            {
                AWSInstance.Instance.selectedColumnIndex = dataGridView1.CurrentCell.RowIndex;
                buttonStart.Enabled = true;
                buttonTerminate.Enabled = true;
                buttonReboot.Enabled = true;
                buttonStop.Enabled = true;                
            }

        }
        bool isRefreshing = false;
        public async void dataGridViewRefresh()
        {
            if (isRefreshing == false)
            {
                isRefreshing = true;
                Cloud.instanceDataGridViewList = new List<DataGridViewVM>();
                string AWSresponseinstance = await AWSinstanceCode.AWSDGVListAdd();
                labelHTTPAWS.Text = "AWS HTTP: " + AWSresponseinstance;
                string AZUREresponseinstance = await AZUREinstanceCode.AZUREDGVListAdd();
                labelHTTPAZURE.Text = "AZURE HTTP: " + AZUREresponseinstance;
                dataGridView1.DataSource = Cloud.instanceDataGridViewList.ToList();
                isRefreshing = false;
            }            
        }
    }
}
