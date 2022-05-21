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









        //aws/instance/getAllInstance
        [HttpPost]
        public IActionResult getAllInstance([FromBody] getAllInstanceBody body)
        {
            try
            {
                return Ok(Class.AWSInstance.getAllInstance(body).Result.Reservations);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception a)
            {
                return BadRequest(a.Message);
            }

        }

        //aws/instance/getAllInstanceByFilter
        [HttpPost]
        public IActionResult getAllInstanceByFilter([FromBody] getAllInstanceByFilterBody body)
        {
            try
            {
                return Ok(Class.AWSInstance.getAllInstanceByFilter(body).Result.Reservations);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception a)
            {
                return BadRequest(a.Message);
            }

        }

        //aws/instance/createInstance
        [HttpPost]
        public IActionResult createInstance([FromBody] createInstanceBody body)
        {
            try
            {
                var result = Class.AWSInstance.CreateInstance(body).Result;
                return Created(result[0], result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception a)
            {
                return BadRequest(a.Message);
            }
        }

        [HttpPost]
        public IActionResult stopInstance([FromBody] InstanceIDListBody body)
        {
            try
            {
                var result = Class.AWSInstance.StopInstance(body).Result;
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception a)
            {
                return BadRequest(a.Message);
            }
        }

        [HttpPost]
        public IActionResult startInstance([FromBody] InstanceIDListBody body)
        {
            try
            {
                var result = Class.AWSInstance.StartInstance(body).Result;
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception a)
            {
                return BadRequest(a.Message);
            }
        }

        [HttpPost]
        public IActionResult rebootInstance([FromBody] InstanceIDListBody body)
        {
            try
            {
                var result = Class.AWSInstance.RebootInstance(body).Result;
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception a)
            {
                return BadRequest(a.Message);
            }
        }

        [HttpPost]
        public IActionResult terminateInstance([FromBody] InstanceIDListBody body)
        {
            try
            {
                var result = Class.AWSInstance.TerminateInstance(body).Result;
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception a)
            {
                return BadRequest(a.Message);
            }
        }


    }
}
