using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIandSwagger.Controllers.AWS
{
    [ApiExplorerSettings(GroupName = "AWS")]
    [Route("aws/[action]")]
    [ApiController]
    public class AWSController : ControllerBase
    {

        /// <summary>
        /// Login İşlemini Gerçekleştirir
        /// </summary>
        /// <param  name="body"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     
        ///     { 
        ///         "accessKey":"************"
        ///         "secretKey":"************"
        ///     }
        /// </remarks>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        public IActionResult setCredential([FromBody] AWSKeyBody body)
        {            
            try
            {
                AWSKey.accessKey = body.accessKey;
                AWSKey.secretKey = body.secretKey;
                return Ok("OK");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Tüm Region'ları Getirir
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        public IActionResult getAllRegion()
        {
            try
            {
                return Ok(RegionEndpoint.EnumerableAllRegions);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        /// <summary>
        /// Tüm Sanal Makine Tiplerini Getirir
        /// </summary>
        [HttpGet][Produces("application/json")]
        public IActionResult getAllInstanceTypes()
        {
            try
            {
                Type typeOfInstancetype = typeof(InstanceType);
                FieldInfo[] fieldOfInstancetype = typeOfInstancetype.GetFields();
                List<string> listOfFieldInstancetype = new List<string>();
                for (int i = 0; i < fieldOfInstancetype.Length; i++)
                {
                    listOfFieldInstancetype.Add(fieldOfInstancetype[i].Name);
                }
                return Ok(listOfFieldInstancetype);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            
        }
    }
}
