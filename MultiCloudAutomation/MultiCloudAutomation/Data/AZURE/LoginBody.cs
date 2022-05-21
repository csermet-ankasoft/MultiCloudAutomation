using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.AZURE
{
    class LoginBody
    {
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string tenantId { get; set; }
        public string subscriptionId { get; set; }

        public LoginBody(string clientId, string clientSecret, string tenantId, string subscriptionId)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.tenantId = tenantId;
            this.subscriptionId = subscriptionId;
        }
    }
}
