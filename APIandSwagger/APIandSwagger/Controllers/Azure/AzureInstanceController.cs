using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Network.Fluent.Models;


namespace APIandSwagger.Controllers.AWS
{
    [ApiExplorerSettings(GroupName = "AZURE INSTANCE")]
    [Route("azure/[action]")]
    [ApiController]
    public class AzureInstanceController : ControllerBase
    {

        /// <summary>
        /// Sanal Makinelerin Basit Bilgilerini Getirir
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpGet]
        public IActionResult getVMSimple()
        {
            try
            {
                return Ok(Azure.Instance.getVMSimple());
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message + " Exception Type:" + exception.GetType().ToString());
            }            
        }

        /// <summary>
        /// Sanal Makinelerin Network İsimlerini Getirir
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         "resourceGroup": "Test"
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult networknames([FromBody] Azure.NameByResourceGroupBody body)
        {
            try
            {
                var result = Azure.Instance.networknames(body);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makinelerin Public IP İsimlerini Getirir
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         "resourceGroup": "Test"
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult publicIPAddressnames([FromBody] Azure.NameByResourceGroupBody body)
        {
            try
            {
                var result = Azure.Instance.publicIPAddressnames(body);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makinelerin Network Security Group İsimlerini Getirir
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         "resourceGroup": "Test"
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult networkSecurityGroupnames([FromBody] Azure.NameByResourceGroupBody body)
        {
            try
            {
                var result = Azure.Instance.networkSecurityGroupnames(body);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makinelerin Network Interface İsimlerini Getirir
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         "resourceGroup": "Test"
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult networkInterfacenames([FromBody] Azure.NameByResourceGroupBody body)
        {
            try
            {
                var result = Azure.Instance.networkInterfacenames(body);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }



        /// <summary>
        /// Sanal Makine oluşturma
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         {
        ///             "size": "StandardB1s",
        ///             "osType": "Windows",
        ///             "region": "australiaeast",
        ///             "vmName": "TT2",
        ///             "imagesku": "2012-R2-Datacenter",
        ///             "imageoffer": "WindowsServer",
        ///             "imagepublisher":"MicrosoftWindowsServer",
        ///             "resourceGroup": "Test",
        ///             "computerName": "CTT",
        ///             "nicName": "Nic3",
        ///             "adminpass": "Test242141",
        ///             "adminUsername": "TestAdmin123"
        ///         }
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult createInstance([FromBody] Azure.CreateInstanceBody body)
        {
            try
            {
                var result = Azure.Instance.createInstance(body);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makine Başlatma
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         {
        ///             "vmid": "c90d7034-0c8f-45bb-b068-77f6011bfb57"
        ///         }
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult startInstance([FromBody] Azure.IDBody body)
        {
            try
            {
                var result = Azure.Instance.StartInstance(body);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makine Yeniden Başlatma
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         {
        ///             "vmid": "c90d7034-0c8f-45bb-b068-77f6011bfb57"
        ///         }
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult restartInstance([FromBody] Azure.IDBody body)
        {
            try
            {
                var result = Azure.Instance.RestartInstance(body);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makine Durdurma
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         {
        ///             "vmid": "c90d7034-0c8f-45bb-b068-77f6011bfb57"
        ///         }
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult stopInstance([FromBody] Azure.IDBody body)
        {
            try
            {
                var result = Azure.Instance.StopInstance(body);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makine Silme
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         {
        ///             "vmid": "c90d7034-0c8f-45bb-b068-77f6011bfb57"
        ///         }
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult terminateInstance([FromBody] Azure.IDBody body)
        {
            try
            {
                var result = Azure.Instance.TerminateInstance(body);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
