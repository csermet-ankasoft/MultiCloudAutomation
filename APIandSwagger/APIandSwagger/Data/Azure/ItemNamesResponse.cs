using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger.Data.Azure
{
    public class ItemNamesResponse
    {
        [Required(ErrorMessage = "Instance ID required", AllowEmptyStrings = false)]
        public string name { get; set; }
    }
}
