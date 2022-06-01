using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger.Azure
{
    public class CredentialBody
    {
        [Required]
        public string clientId { get; set; } = "";
        [Required]
        public string clientSecret { get; set; } = "";
        [Required]
        public string tenantId { get; set; } = "";
        [Required]
        public string subscriptionId { get; set; } = "";
    }
}
