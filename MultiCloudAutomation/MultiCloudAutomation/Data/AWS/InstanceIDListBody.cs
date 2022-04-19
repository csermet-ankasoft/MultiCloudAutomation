using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.AWS
{
    class InstanceIDListBody
    {
        public List<string> instanceList { get; set; }
        public string region { get; set; }

        public InstanceIDListBody(List<string> instanceList,string region)
        {
            this.instanceList = instanceList;
            this.region = region;
        }
    }
}
