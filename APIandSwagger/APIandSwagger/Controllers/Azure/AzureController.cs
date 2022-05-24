using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger.Controllers.AWS
{
    [Route("azure/[action]")]
    [ApiController]
    public class AzureController : ControllerBase
    {

        public static bool checkAzureCredential()
        {
            if (Credential.clientId == "" || Credential.azure == null)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        public IActionResult setCredential([FromBody] Azure.CredentialBody value)
        {
            Credential.clientId = value.clientId;
            Credential.clientSecret = value.clientSecret;
            Credential.tenantId = value.tenantId;
            Credential.subscriptionId = value.subscriptionId;            
            
            return Ok(Credential.setCred());
        }

        [HttpGet]
        public IActionResult ResourceGroupsGet()
        {
            if (!checkAzureCredential())
                return Unauthorized();
            var resourceGroups = Credential.azure.ResourceGroups.List().ToList();
            return Ok(resourceGroups);
        }

    }



}
