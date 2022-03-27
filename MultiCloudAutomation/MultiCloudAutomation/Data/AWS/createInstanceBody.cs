using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.AWS
{
    class createInstanceBody
    {
        public string instanceType { get; set; }
        public string region { get; set; }
        public string imageID { get; set; }
        public int minCount = 1;
        public int maxCount = 1;
    }
}
