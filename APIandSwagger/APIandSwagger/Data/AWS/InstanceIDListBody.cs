using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger
{ 
    public class InstanceIDListBody
    {
        [Required(ErrorMessage = "Instance ID List required", AllowEmptyStrings = false)]
        public List<string> instanceList { get; set; }
        [Required(ErrorMessage = "Region required", AllowEmptyStrings = false)]
        public string region { get; set; }  
    }
}
