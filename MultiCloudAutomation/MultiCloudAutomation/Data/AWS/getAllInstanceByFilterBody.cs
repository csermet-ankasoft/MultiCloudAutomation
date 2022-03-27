using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.AWS
{
    class getAllInstanceByFilterBody
    {  
        public string region { get; set; }
        public string filterName { get; set; }
        public List<string> filterValue { get; set; }
    }
}
