using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger
{
    public class createInstanceBody
    {
        [Required(ErrorMessage = "Instance Type required")]
        public string instanceType { get; set; }
        [Required(ErrorMessage = "Region required")]
        public string region { get; set; }
        [Required(ErrorMessage = "Image ID required")]
        public string imageID { get; set; }
        public int minCount = 1;
        public int maxCount = 1;
    }
}
