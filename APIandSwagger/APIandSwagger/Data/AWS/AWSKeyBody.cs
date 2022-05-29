using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger
{
    public class AWSKeyBody
    {
        [Required(AllowEmptyStrings = false)]
        public string accessKey { get; set; } = "";
        [Required(AllowEmptyStrings = false)]
        public string secretKey { get; set; } = "";
    }
}
