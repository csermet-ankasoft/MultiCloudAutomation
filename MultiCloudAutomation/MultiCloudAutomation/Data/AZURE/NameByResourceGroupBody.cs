using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.AZURE
{
    class NameByResourceGroupBody
    {

        public string resourceGroup { get; set; }

        public NameByResourceGroupBody(string resourceGroup)
        {
            this.resourceGroup = resourceGroup;
        }
    }
}
