﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public string setCredential([FromBody] Azure.CredentialBody value)
        {
            Credential.clientId = value.clientId;
            Credential.clientSecret = value.clientSecret;
            Credential.tenantId = value.tenantId;
            Credential.subscriptionId = value.subscriptionId;            
            
            return Credential.setCred(); ;
        }

        [HttpGet]
        public IEnumerable<Microsoft.Azure.Management.ResourceManager.Fluent.IResourceGroup> resourceGroupGet()
        {
            var resourceGroups = Credential.azure.ResourceGroups.List();
            return resourceGroups;
        }
    }


    
}