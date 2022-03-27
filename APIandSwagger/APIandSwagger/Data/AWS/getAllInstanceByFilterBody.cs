using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger
{
    public class getAllInstanceByFilterBody
    {
        [Required(ErrorMessage = "Region required")]        
        public string region { get; set; }
        [Required(ErrorMessage = "filterName required")]
        public string filterName { get; set; }
        [Required(ErrorMessage = "filterValue required")]
        public List<string> filterValue { get; set; }
    }
}
