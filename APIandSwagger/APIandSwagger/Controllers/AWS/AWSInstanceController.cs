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
    [ApiExplorerSettings(GroupName = "AWS INSTANCE")]
    [Route("aws/[action]")]
    [ApiController]
    public class InstanceController : ControllerBase
    {
        /// <summary>
        /// Tüm Sanal Makineleri Region'a göre Getirir
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     
        ///     { 
        ///         "region":"us-east-1"
        ///     }
        /// </remarks>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
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
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        /// <summary>
        /// Tüm Sanal Makineleri Region'a ve Filtreye göre Getirir
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         "region":"us-east-1",
        ///         "filterName":"instance-type",
        ///         "filterValue":["t2.micro","t1"]
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
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
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        /// <summary>
        /// Sanal Makine Oluşturur
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         "instanceType": "t2.micro",
        ///         "region":"us-east-1",
        ///         "imageID": "ami-0c02fb55956c7d316"
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
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
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makineyi Durdurur
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         "instanceList": ["i-06300121fe4661c6a"],
        ///         "region":"us-east-1"
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
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
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makineyi Başlatır
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         "instanceList": ["i-06300121fe4661c6a"],
        ///         "region":"us-east-1"
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
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
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makineyi Yeniden Başlatır
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         "instanceList": ["i-06300121fe4661c6a"],
        ///         "region":"us-east-1"
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
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
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Sanal Makineyi Siler
        /// </summary>
        /// <param name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     { 
        ///         "instanceList": ["i-06300121fe4661c6a"],
        ///         "region":"us-east-1"
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
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
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }



        /*
        [HttpPost][Produces("application/json")]
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
