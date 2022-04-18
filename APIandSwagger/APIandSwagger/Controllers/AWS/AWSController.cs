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
    [Route("aws/[action]")]
    [ApiController]
    public class AWSController : ControllerBase
    {
        // POST: api/AWS
        [HttpPost]
        public string setCredential([FromBody] AWSKeyBody value)
        {
            AWSKey.accessKey = value.accessKey;
            AWSKey.secretKey = value.secretKey;
            return "OK";
        }

        [HttpGet]
        public IEnumerable<RegionEndpoint> getAllRegion()
        {
            return RegionEndpoint.EnumerableAllRegions;
        }
        [HttpGet]
        public List<string> getAllInstanceTypes()
        {
            Type typeOfInstancetype = typeof(InstanceType);
            FieldInfo[] fieldOfInstancetype = typeOfInstancetype.GetFields();
            List<string> listOfFieldInstancetype = new List<string>();
            for (int i = 0; i < fieldOfInstancetype.Length; i++)
            {
                listOfFieldInstancetype.Add(fieldOfInstancetype[i].Name);
            }
            return listOfFieldInstancetype;
        }
    }
}
