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

        /*
        public InstanceDataGridView(string InstanceId, string InstanceState, 
            string InstanceType, string AvailabilityZone, 
            string LaunchTime, string IPv4DNS, string IPv4Address)
        {
            this.InstanceId = InstanceId;
            this.InstanceState = InstanceState;
            this.InstanceType = InstanceType;
            this.AvailabilityZone = this.AvailabilityZone;
            this.LaunchTime = LaunchTime;
            this.PublicIPv4DNS = IPv4DNS;
            this.PublicIPv4Address = IPv4Address;
        }
        */
    }
}
