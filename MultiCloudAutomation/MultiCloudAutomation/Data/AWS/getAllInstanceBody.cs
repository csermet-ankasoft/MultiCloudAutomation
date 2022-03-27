using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.AWS
{
    class getAllInstanceBody
    {
        public string region { get; set; }

        public getAllInstanceBody(string region)
        {
            this.region = region;
        }
    }
}
