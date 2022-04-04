using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.AWS
{
    class InstanceDataGridView
    {
        public string InstanceId { get; set; }
        public string InstanceState { get; set; }
        public string InstanceType { get; set; }
        public string AvailabilityZone { get; set; }
        public string LaunchTime { get; set; }
        public string PublicIPv4DNS { get; set; }
        public string PublicIPv4Address { get; set; }
    }
}
