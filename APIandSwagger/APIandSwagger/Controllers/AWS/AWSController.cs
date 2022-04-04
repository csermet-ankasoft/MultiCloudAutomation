using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
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
    }
}
