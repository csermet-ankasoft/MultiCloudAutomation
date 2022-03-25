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
        public void setCredential([FromBody] Data.AWSKeyBody value)
        {
            Class.AWSKey.accessKey = value.accessKey;
            Class.AWSKey.secretKey = value.secretKey;
        }

        [HttpGet]
        public IEnumerable<RegionEndpoint> getAllRegion()
        {
            return RegionEndpoint.EnumerableAllRegions;
        }
    }
}
