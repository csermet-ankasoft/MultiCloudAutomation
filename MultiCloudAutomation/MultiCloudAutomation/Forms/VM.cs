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
        
        private async void startInstance_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {

            }
            else if(dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                await AWSinstanceCode.AWSstartInstance();
            }
                
        }

        private async void stopInstance_Click(object sender, EventArgs e)
        {            
            if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {

            }
            else if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                await AWSinstanceCode.AWSstopInstance();
            }
        }

        private async void buttonTerminate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {

            }
            else if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                await AWSinstanceCode.AWSterminateInstance();
            }
            
        }

        private async void buttonReboot_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AZURE")
            {

            }
            else if (dataGridView1.Rows[AWSInstance.Instance.selectedColumnIndex].Cells[0].Value.ToString() == "AWS")
            {
                await AWSinstanceCode.AWSrebootInstance();
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

        public async void dataGridViewRefresh()
        {
            Cloud.instanceDataGridViewList = new List<DataGridViewVM>();
            string AWSstatuscode = await AWSinstanceCode.AWSDGVListAdd();
            labelHTTPAWS.Text = "AWS HTTP: " + AWSstatuscode;
            string AZUREstatuscode = await AZUREinstanceCode.AZUREDGVListAdd();
            labelHTTPAZURE.Text = "AZURE HTTP: " + AZUREstatuscode;
            dataGridView1.DataSource = Cloud.instanceDataGridViewList.ToList();
        }
    }
}
