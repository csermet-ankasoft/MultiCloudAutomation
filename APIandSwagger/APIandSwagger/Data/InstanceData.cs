using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace APIandSwagger.Data
{
    public class InstanceData
    {
        [Required(ErrorMessage ="Instance Type required")]
        public string instanceType { get; set; }
    }
}
