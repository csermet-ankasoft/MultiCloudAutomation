using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void First_Page_Load(object sender, EventArgs e)
        {
            AzurecredentialRead();
            AWScredentialRead();
        }

        public async void AWScredentialRead()
        {
            string accessKey = "", secretKey = "";
            string dosya_yolu = @"C:\Users\" + Environment.UserName + @"\.aws\credentials\username.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                StreamReader sw = new StreamReader(fs);
                while (true)
                {
                    string yazi = sw.ReadLine();
                    if (yazi == "Access Key")
                    {
                        accessKey = sw.ReadLine();
                    }
                    else if (yazi == "Secret Key")
                    {
                        secretKey = sw.ReadLine();
                    }
                    else if (yazi == null)
                    {
                        break;
                    }
                }
                sw.Close();
                fs.Close();
            }
            catch (Exception exception)
            {
                fs.Close();
                MessageBox.Show("Credential Dosyası okunurken bir hata meydana geldi...\n" + exception.Message);
            }
            try
            {
                AWS.LoginBody loginbody = new AWS.LoginBody(accessKey, secretKey);
                string jsonbody = JsonConvert.SerializeObject(loginbody);
                ResponseClass task = await Request.PostRequestAsync("aws/setCredential", jsonbody);
            }
            catch (Exception exception)
            {
                MessageBox.Show("AWS " + exception.Message);
            }
            


            
        }


            public async void AzurecredentialRead()
        {
            string clientID = "", ClientSecret = "", TenantID = "", SubsID = "";
            string dosya_yolu = @"C:\Users\" + Environment.UserName + @"\.azure\account.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                StreamReader sw = new StreamReader(fs);
                while (true)
                {
                    string yazi = sw.ReadLine();
                    if (yazi == "Client ID")
                    {
                        clientID = sw.ReadLine();
                    }
                    else if (yazi == "Client Secret")
                    {
                        ClientSecret = sw.ReadLine();
                    }
                    else if (yazi == "Tenant ID")
                    {
                        TenantID = sw.ReadLine();
                    }
                    else if (yazi == "Subscription ID")
                    {
                        SubsID = sw.ReadLine();
                    }
                    else if (yazi == null)
                    {
                        break;
                    }
                }
                sw.Close();
                fs.Close();
            }
            catch (Exception exception)
            {
                fs.Close();
                MessageBox.Show("Credential Dosyası okunurken bir hata meydana geldi...\n" + exception.Message);
            }
            try
            {
                AZURE.LoginBody loginbody = new AZURE.LoginBody(clientID, ClientSecret, TenantID, SubsID);
                string jsonbody = JsonConvert.SerializeObject(loginbody);
                ResponseClass task = await Request.PostRequestAsync("azure/setCredential", jsonbody);
            }
            catch (Exception exception)
            {
                MessageBox.Show("AZURE " + exception.Message);
            }
            
        }
    }
}
