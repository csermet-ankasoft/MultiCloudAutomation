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
    public partial class First_Page : Form
    {
        public First_Page()
        {
            InitializeComponent();
        }

        private void WhenNewFormClose(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void buttonAWSCRED(object sender, EventArgs e)
        {
            this.Hide();
            Forms.AWS_CREDENTIAL AWSCredForm = new Forms.AWS_CREDENTIAL();
            AWSCredForm.Show();
            AWSCredForm.FormClosing += WhenNewFormClose;
        }

        private void buttonAzureCred_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.AZURE_CREDENTIAL AzureCredForm = new Forms.AZURE_CREDENTIAL();
            AzureCredForm.Show();
            AzureCredForm.FormClosing += WhenNewFormClose;
        }

        private void buttonVM_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 VMForm = new Form1();
            VMForm.Show();
            VMForm.FormClosing += WhenNewFormClose;
        }
    }
}
