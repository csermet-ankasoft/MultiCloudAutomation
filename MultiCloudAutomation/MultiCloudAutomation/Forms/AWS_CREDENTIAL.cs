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
                textBoxAccessKEY.ReadOnly = true;
                textBoxSecretKEY.ReadOnly = true;
                button2.Text = "Düzenle";
            }
        }

        private void AWS_CREDENTIAL_Load(object sender, EventArgs e)
        {

        
        }
    }
}
