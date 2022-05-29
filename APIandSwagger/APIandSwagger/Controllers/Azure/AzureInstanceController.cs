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
    //aws/instance/[function]
    [Route("azure/[action]")]
    [ApiController]
    public class AzureInstanceController : ControllerBase
    {

        [HttpGet][Produces("application/json")]
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

        [HttpPost][Produces("application/json")]
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

        [HttpPost][Produces("application/json")]
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

        [HttpPost][Produces("application/json")]
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

        [HttpPost][Produces("application/json")]
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



        [HttpPost][Produces("application/json")]
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

        [HttpPost][Produces("application/json")]
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

        [HttpPost][Produces("application/json")]
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

        [HttpPost][Produces("application/json")]
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

        [HttpPost][Produces("application/json")]
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
