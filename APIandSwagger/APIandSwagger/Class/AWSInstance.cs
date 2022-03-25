using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger.Class
{
    public class AWSInstance
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

        public static Task<List<string>> CreateInstance(Data.InstanceData instancedata)
        {
            var awskey = new Amazon.Runtime.BasicAWSCredentials(AWSKey.accessKey, AWSKey.secretKey);
            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(instancedata.region);
            AmazonEC2Client ec2Client = new AmazonEC2Client(awskey, regionEndpoint);
            RunInstancesRequest runInstanceRequest = new RunInstancesRequest(instancedata.imageID, 1, 1);
            runInstanceRequest.InstanceType = instancedata.instanceType;
            return LaunchInstances(ec2Client, runInstanceRequest);
        }


    }
}
