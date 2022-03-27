using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger
{
    public class getAllInstanceBody
    {
        [Required(ErrorMessage = "Region required")]
        public string region { get; set; }
    }
}
