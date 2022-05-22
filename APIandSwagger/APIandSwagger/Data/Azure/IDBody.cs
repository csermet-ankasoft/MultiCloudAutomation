using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger.Azure
{
    public class IDBody
    {
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string vmid { get; set; }
    }
}
