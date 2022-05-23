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
            var resourceGroups = Credential.azure.ResourceGroups.List();
            return Ok(resourceGroups);
        }

        [HttpGet]
        public IActionResult t()
        {
            if (!checkAzureCredential())
                return Unauthorized();// Microsoft.Azure.Management.Compute.Fluent
            var resourceGroups = Credential.azure.VirtualMachineImages.ListByRegion("australiaeast");
            return Ok(resourceGroups);
        }


        /*
        [HttpGet]
        public IActionResult NetworksGet()
        {
            if (!checkAzureCredential())
                return Unauthorized();
            var resourceGroups = Credential.azure.Networks.List();
            return Ok(resourceGroups);
        }

        [HttpGet]
        public IActionResult PublicIPAddressesGet()
        {
            if (!checkAzureCredential())
                return Unauthorized();
            var resourceGroups = Credential.azure.PublicIPAddresses.List();
            return Ok(resourceGroups);
        }

        [HttpGet]
        public IActionResult NetworkSecurityGroupsGet()
        {
            if (!checkAzureCredential())
                return Unauthorized();
            var resourceGroups = Credential.azure.NetworkSecurityGroups.List();
            return Ok(resourceGroups);
        }

        [HttpGet]
        public IActionResult NetworkInterfacesGet()
        {
            if (!checkAzureCredential())
                return Unauthorized();
            var resourceGroups = Credential.azure.NetworkInterfaces.get("cloud-shell-storage-westeurope","test").Id;
            return Ok(resourceGroups);
        }
        */
    }



}
