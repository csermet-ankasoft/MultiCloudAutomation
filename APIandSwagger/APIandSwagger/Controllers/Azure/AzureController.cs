using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger.Controllers.AWS
{
    [ApiExplorerSettings(GroupName = "AZURE")]
    [Route("azure/[action]")]
    [ApiController]
    public class AzureController : ControllerBase
    {

        public static string checkAzureCredential()
        {
            if (Credential.clientId == "" || Credential.azure == null)
            {
                return "Failed";
            }
            return "Completed";
        }

        /// <summary>
        /// Azure Giriş Bilgileri
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         {
        ///             "clientId": "....",
        ///             "clientSecret": "....",
        ///             "tenantId": "....",
        ///             "subscriptionId": "...."
        ///         }
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult setCredential([FromBody] Azure.CredentialBody body)
        {
            Credential.clientId = body.clientId;
            Credential.clientSecret = body.clientSecret;
            Credential.tenantId = body.tenantId;
            Credential.subscriptionId = body.subscriptionId;            
            
            return Ok(Credential.setCred());
        }

        /// <summary>
        /// Tüm Resource'ları getirir
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpGet]
        public IActionResult ResourceGroupsGet()
        {
            if (checkAzureCredential() == "Failed")
                return Unauthorized();
            var resourceGroups = Credential.azure.ResourceGroups.List().ToList();
            return Ok(resourceGroups);
        }

    }



}
