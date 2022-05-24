using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.AZURE
{
    class AddInstancebody
    {        
        public string vmName { get; set; }
        public string resourceGroup { get; set; }
        public string region { get; set; }
        public string computerName { get; set; }
        public string size { get; set; }
        public string osType { get; set; }
        public string imagepublisher { get; set; }
        public string imageoffer { get; set; }
        public string imagesku { get; set; }       
        public string nicName { get; set; }
        public string adminUsername { get; set; }
        public string adminpass { get; set; }

        public AddInstancebody(string vmName, string resourceGroup, string region,string computerName, 
            string size, string osType, string imagepublisher, string imageoffer, string imagesku,
            string nicName, string adminUsername, string adminpass)
        {
            this.vmName = vmName;
            this.resourceGroup = resourceGroup;
            this.computerName = computerName;
            this.size = size;
            this.region = region;
            this.osType = osType;
            this.imagepublisher = imagepublisher;
            this.imageoffer = imageoffer;
            this.imagesku = imagesku;
            this.nicName = nicName;
            this.adminUsername = adminUsername;
            this.adminpass = adminpass;
        }
    }
}
