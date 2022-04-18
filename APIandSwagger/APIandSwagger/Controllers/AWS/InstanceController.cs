using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIandSwagger.Controllers.AWS
{
    //aws/instance/[function]
    [Route("aws/[controller]/[action]")]
    [ApiController]
    public class InstanceController : ControllerBase
    {
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
                return Created(result[0],result);
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

        /*
        [HttpPost]
        public IActionResult getAllImage([FromBody] getAllInstanceBody body)
        {
            try
            {
                return Ok(Class.AWSInstance.getAllImage(body).Result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }

        }
        */

    }
}
