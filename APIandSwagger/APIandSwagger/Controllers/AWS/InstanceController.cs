using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        private static async Task<List<string>> LaunchInstances(IAmazonEC2 ec2Client, RunInstancesRequest requestLaunch)
        {
            var instanceIds = new List<string>();
            RunInstancesResponse responseLaunch = await ec2Client.RunInstancesAsync(requestLaunch);

            //MessageBox.Show("\nNew instances have been created.");
            foreach (Instance item in responseLaunch.Reservation.Instances)
            {
                instanceIds.Add(item.InstanceId);
                //MessageBox.Show($"  New instance: {item.InstanceId}");
            }

            return instanceIds;
        }





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
        public string Post([FromBody] Data.InstanceData value)
        {
            AmazonEC2Client ec2 = new AmazonEC2Client();
            //getAllInstance(ec2);
            RunInstancesRequest req = new RunInstancesRequest("ami-0c02fb55956c7d316", 1, 1);

            InstanceType t2 = new InstanceType(value.instanceType);
            Console.Write(value.ToString());
            Console.Write(value.instanceType.ToString());
            req.InstanceType = t2;
            return LaunchInstances(ec2, req).Result[0];
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
