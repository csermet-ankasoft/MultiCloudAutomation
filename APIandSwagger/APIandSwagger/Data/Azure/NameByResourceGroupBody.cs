using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger.Azure
{
    public class NameByResourceGroupBody
    {
        [Required(ErrorMessage = "ResourceGroup required", AllowEmptyStrings = false)]
        public string resourceGroup { get; set; }
    }
}
