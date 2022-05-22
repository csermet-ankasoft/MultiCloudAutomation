using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.AZURE
{
    class IDBody
    {
        public string vmid { get; set; }

        public IDBody(string vmid)
        {
            this.vmid = vmid;
        }
    }
}
