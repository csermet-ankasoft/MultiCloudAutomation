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
