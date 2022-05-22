using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation
{
    class DataGridViewVM
    {
        [DisplayName("Cloud Type")]
        public string CloudType { get; set; }
        [DisplayName("ID")]
        public string VMID { get; set; }
        [DisplayName("Name")]
        public string InstanceName { get; set; }
        [DisplayName("State")]
        public string InstanceState { get; set; }
        [DisplayName("Type")]
        public string InstanceType { get; set; }
        [DisplayName("OS Type")]
        public string OSType { get; set; }
        [DisplayName("Public IP")]
        public string PublicIP { get; set; }

    }
}
