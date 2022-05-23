using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger.Azure
{
    public class CreateInstanceBody
    {
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string vmName { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string resourceGroup { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string region { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string computerName { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string size { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string osType { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string imagepublisher { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string imageoffer { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string imagesku { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string networkName { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string subnetName { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string publicIP { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string nsgName { get; set; }
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string nicName { get; set; }
    }
}
