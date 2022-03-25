using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIandSwagger.Controllers
{
    [Route("aws/instance/[controller]")]
    [ApiController]
    public class AWSInstanceController : ControllerBase
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
        /*
        public static async void getAllInstance(AmazonEC2Client ec2)
        {
            DescribeInstancesRequest req = new DescribeInstancesRequest();
            List<Amazon.EC2.Model.Reservation> result = ec2.DescribeInstancesAsync(req);

            foreach (Amazon.EC2.Model.Reservation reservation in result)
            {
                foreach (var runningInstance in reservation.Instances)
                {
                    //MessageBox.Show(runningInstance.InstanceId + runningInstance.InstanceType);
                }
            }
        }
        */

        // GET: api/AWSInstance
        [HttpGet]
        public string Get()
        {
            
            AmazonEC2Client ec2 = new AmazonEC2Client();
            //getAllInstance(ec2);
            RunInstancesRequest req = new RunInstancesRequest("ami-0c02fb55956c7d316", 1, 1);

            InstanceType t2 = new InstanceType("t2.micro");
            req.InstanceType = t2;
            return LaunchInstances(ec2, req).Result[0];
            
        }

        // GET: api/AWSInstance/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AWSInstance
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AWSInstance/5
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
