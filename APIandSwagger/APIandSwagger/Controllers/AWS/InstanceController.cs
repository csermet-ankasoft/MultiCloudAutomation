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
    [Route("aws/[controller]")]
    [ApiController]
    public class InstanceController : ControllerBase
    {

        // GET: api/Instance
        [HttpGet]
        public string Get()
        {
            return "hi";
        }

        // GET: api/Instance/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Instance
        [HttpPost]
        public List<string> Post([FromBody] Data.InstanceData instancedata)
        {
            return Class.AWSInstance.CreateInstance(instancedata).Result;
        }

        // PUT: api/Instance/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
