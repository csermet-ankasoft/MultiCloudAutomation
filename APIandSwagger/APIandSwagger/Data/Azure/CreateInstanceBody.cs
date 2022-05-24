using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger.Azure
{
    public class CreateInstanceBody
    {
        [Required(ErrorMessage = "vmName required", AllowEmptyStrings = false)]
        public string vmName { get; set; }
        [Required(ErrorMessage = "resourceGroup required", AllowEmptyStrings = false)]
        public string resourceGroup { get; set; }
        [Required(ErrorMessage = "region required", AllowEmptyStrings = false)]
        public string region { get; set; }
        [Required(ErrorMessage = "computerName required", AllowEmptyStrings = false)]
        public string computerName { get; set; }
        [Required(ErrorMessage = "size required", AllowEmptyStrings = false)]
        public string size { get; set; }
        [Required(ErrorMessage = "osType required", AllowEmptyStrings = false)]
        public string osType { get; set; }
        [Required(ErrorMessage = "imagepublisher required", AllowEmptyStrings = false)]
        public string imagepublisher { get; set; }
        [Required(ErrorMessage = "imageoffer required", AllowEmptyStrings = false)]
        public string imageoffer { get; set; }
        [Required(ErrorMessage = "imagesku required", AllowEmptyStrings = false)]
        public string imagesku { get; set; }
        /*
        [Required(ErrorMessage = "networkName required", AllowEmptyStrings = false)]        
        public string networkName { get; set; }
        [Required(ErrorMessage = "subnetName required", AllowEmptyStrings = false)]
        public string subnetName { get; set; }
        [Required(ErrorMessage = "publicIP required", AllowEmptyStrings = false)]
        public string publicIP { get; set; }
        [Required(ErrorMessage = "nsgName required", AllowEmptyStrings = false)]
        public string nsgName { get; set; }
        */
        [Required(ErrorMessage = "nicName required", AllowEmptyStrings = false)]
        public string nicName { get; set; }
        [Required(ErrorMessage = "adminUsername required", AllowEmptyStrings = false)]
        public string adminUsername { get; set; }
        [Required(ErrorMessage = "adminpass required", AllowEmptyStrings = false)]
        public string adminpass { get; set; }
    }
}
