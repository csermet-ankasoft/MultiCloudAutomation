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
        [HttpGet]
        public List<Reservation> getAllInstance([FromBody] getAllInstanceBody body)
        {
            return Class.AWSInstance.getAllInstance(body).Result.Reservations;
        }

        //aws/instance/getAllInstanceByFilter
        [HttpGet]
        public List<Reservation> getAllInstanceByFilter([FromBody] getAllInstanceByFilterBody body)
        {
            return Class.AWSInstance.getAllInstanceByFilter(body).Result.Reservations;
        }

        //aws/instance/createInstance
        [HttpGet]
        public List<string> createInstance([FromBody] createInstanceBody body)
        {
            return Class.AWSInstance.CreateInstance(body).Result;
        }
    }
}
