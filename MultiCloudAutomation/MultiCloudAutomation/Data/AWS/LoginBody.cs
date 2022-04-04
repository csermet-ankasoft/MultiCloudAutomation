using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.AWS
{
    class LoginBody
    {
        public string accessKey { get; set; }
        public string secretKey { get; set; }

        public LoginBody(string accessKey, string secretKey)
        {
            this.accessKey = accessKey;
            this.secretKey = secretKey;
        }
    }
}
