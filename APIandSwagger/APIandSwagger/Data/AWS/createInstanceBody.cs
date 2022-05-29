using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger
{
    public class createInstanceBody
    {
        [Required(ErrorMessage = "Instance Type required",AllowEmptyStrings =false)]
        public string instanceType { get; set; }

        [Required(ErrorMessage = "Region required", AllowEmptyStrings = false)]
        public string region { get; set; }

        [Required(ErrorMessage = "Image ID required", AllowEmptyStrings = false)]
        public string imageID { get; set; }

        public Dictionary<string,string> tagDictionary { get; set; }

        public int minCount { get; set; } = 1;
        
        public int maxCount { get; set; } = 1;
    }
}
