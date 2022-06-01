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
    public partial class AZURE_CREDENTIAL : Form
    {
        public AZURE_CREDENTIAL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxClientID.ReadOnly == true)
            {
                textBoxClientID.ReadOnly = false;
                textBoxClientSecret.ReadOnly = false;
                textBoxTenantID.ReadOnly = false;
                textBoxSubscriptionID.ReadOnly = false;
                button2.Text = "Kaydet";
            }
            else
            {
                string dosya_yolu = @"C:\Users\" + Environment.UserName + @"\.azure\account.txt";
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                try
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("AZURE CREDENTIAL - Dont Delete This File");
                    sw.WriteLine("AZURE CREDENTIAL - Bu Dosyayı Silmeyin");
                    sw.WriteLine("Client ID");
                    sw.WriteLine(textBoxClientID.Text);
                    sw.WriteLine("Client Secret");
                    sw.WriteLine(textBoxClientSecret.Text);
                    sw.WriteLine("Tenant ID");
                    sw.WriteLine(textBoxTenantID.Text);
                    sw.WriteLine("Subscription ID");
                    sw.WriteLine(textBoxSubscriptionID.Text);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
                catch (Exception exception)
                {
                    fs.Close();
                    MessageBox.Show("Kaydedilirken bir hata meydana geldi...\n" + exception.Message);
                }
                textBoxClientID.ReadOnly = true;
                textBoxClientSecret.ReadOnly = true;
                textBoxTenantID.ReadOnly = true;
                textBoxSubscriptionID.ReadOnly = true;
                labelTest.Text = "Bağlantı Test ediliyor...";
                labelTest.ForeColor = Color.Black;
                loginAndText();
                button2.Text = "Düzenle";
            }
            
        }

        private void AZURE_CREDENTIAL_Load(object sender, EventArgs e)
        {
            credentialRead();
            loginAndText();
        }

        public async void loginAndText()
        {
            ResponseClass logintext = await loginAzure();
            var VMNameGettest = await VMNameGetTest();
            if (VMNameGettest.StatusCode.ToString() == "OK")
            {
                labelTest.Text = "Bağlantı Sağlandı";
                labelTest.ForeColor = Color.DarkGreen;
            }
            else if (VMNameGettest.StatusCode.ToString() == "BadRequest")
            {
                labelTest.Text = "Bağlantı Sağlanamadı";
                labelTest.ForeColor = Color.DarkRed;
            }
            else
            {
                labelTest.Text = "HTTP Kodu : " + VMNameGettest.StatusCode.ToString();
            }
        }


        public void credentialRead()
        {
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
                        textBoxClientID.Text = sw.ReadLine();
                    }
                    else if (yazi == "Client Secret")
                    {
                        textBoxClientSecret.Text = sw.ReadLine();
                    }
                    else if (yazi == "Tenant ID")
                    {
                        textBoxTenantID.Text = sw.ReadLine();
                    }
                    else if (yazi == "Subscription ID")
                    {
                        textBoxSubscriptionID.Text = sw.ReadLine();
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
        }

        public async Task<ResponseClass> VMNameGetTest()
        {
            ResponseClass task = await Request.GetRequestAsync("azure/getVMSimple");
            return task;
        }

        public async Task<ResponseClass> loginAzure()
        {
            AZURE.LoginBody loginbody = new AZURE.LoginBody(textBoxClientID.Text, textBoxClientSecret.Text, textBoxTenantID.Text, textBoxSubscriptionID.Text);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            ResponseClass task = await Request.PostRequestAsync("azure/setCredential", jsonbody);
            return task;
        }
    }
}
