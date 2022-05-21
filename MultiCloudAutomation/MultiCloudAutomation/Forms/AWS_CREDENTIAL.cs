using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiCloudAutomation.Forms
{
    public partial class AWS_CREDENTIAL : Form
    {
        public AWS_CREDENTIAL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxAccessKEY.ReadOnly == true)
            {
                textBoxAccessKEY.ReadOnly = false;
                textBoxSecretKEY.ReadOnly = false;
                button2.Text = "Kaydet";
            }
            else
            {
                string dosya_yolu = @"C:\Users\" + Environment.UserName + @"\.aws\credentials\username.txt";
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                try
                {                    
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("AWS CREDENTIAL - Dont Delete This File");
                    sw.WriteLine("AWS CREDENTIAL - Bu Dosyayı Silmeyin");
                    sw.WriteLine("Access Key");
                    sw.WriteLine(textBoxAccessKEY.Text);
                    sw.WriteLine("Secret Key");
                    sw.WriteLine(textBoxSecretKEY.Text);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
                catch (Exception exception)
                {
                    fs.Close();
                    MessageBox.Show("Kaydedilirken bir hata meydana geldi...\n" + exception.Message);
                }
                textBoxAccessKEY.ReadOnly = true;
                textBoxSecretKEY.ReadOnly = true;
                button2.Text = "Düzenle";
            }
        }

        private async void AWS_CREDENTIAL_Load(object sender, EventArgs e)
        {
            credentialRead();
            ResponseClass logintext = await login();
            ResponseClass getallinstances = await getAllInstanceTEST("us-east-1");
            labelTest.Text = "HTTP Kodu : " + getallinstances.StatusCode.ToString();
        }

        public void credentialRead()
        {
            string dosya_yolu = @"C:\Users\" + Environment.UserName + @"\.aws\credentials\username.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            try
            {
                StreamReader sw = new StreamReader(fs);
                while (true)
                {
                    string yazi = sw.ReadLine();
                    if (yazi == "Access Key")
                    {
                        textBoxAccessKEY.Text = sw.ReadLine();
                    }
                    else if (yazi == "Secret Key")
                    {
                        textBoxSecretKEY.Text = sw.ReadLine();
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

        public async Task<ResponseClass> login()
        {
            AWS.LoginBody loginbody = new AWS.LoginBody(textBoxAccessKEY.Text, textBoxSecretKEY.Text);
            string jsonbody = JsonConvert.SerializeObject(loginbody);
            ResponseClass task = await Request.PostRequestAsync("aws/setCredential", jsonbody);
            return task;
        }

        public async Task<ResponseClass> getAllInstanceTEST(string region)
        {
            AWS.getAllInstanceBody body = new AWS.getAllInstanceBody(region);
            string jsonbody = JsonConvert.SerializeObject(body);
            ResponseClass task = await Request.PostRequestAsync("aws/instance/getAllInstance", jsonbody);
            return task;
        }
    }
}
