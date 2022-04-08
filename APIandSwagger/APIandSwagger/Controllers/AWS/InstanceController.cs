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
            
        }

        //aws/instance/createInstance
        [HttpPost]
        public IActionResult createInstance([FromBody] createInstanceBody body)
        {
            try
            {
                return Created(Class.AWSInstance.CreateInstance(body).Result[0], Class.AWSInstance.CreateInstance(body).Result);
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized();
            }
        }
    }
}
