using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger.Azure
{
    public class VMSimpleBody
    {
        public string InstanceName { get; set; }
        public string InstanceState { get; set; }
        public string InstanceType { get; set; }
        public string OSType { get; set; }
        public string PublicIP { get; set; }
    }
}
