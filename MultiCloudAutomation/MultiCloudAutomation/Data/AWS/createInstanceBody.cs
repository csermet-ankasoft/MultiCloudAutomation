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
        public Dictionary<string, string> tagDictionary;
        public int minCount = 1;
        public int maxCount = 1;

        public createInstanceBody(string instanceType, string region, string imageID,int count = 1)
        {
            this.instanceType = instanceType;
            this.region = region;
            this.imageID = imageID;
            this.minCount = count;
            this.maxCount = count;
        }
    }
}
