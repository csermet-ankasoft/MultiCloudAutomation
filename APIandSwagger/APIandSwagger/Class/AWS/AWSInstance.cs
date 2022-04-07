using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIandSwagger.Class
{
    public class AWSInstance
    {
        public static void checkAWSKey()
        {
            if (AWSKey.accessKey == "" || AWSKey.secretKey == "")
            {
                throw new KeyNotFoundException();
            }
        }


        public static Task<List<string>> CreateInstance(createInstanceBody body)
        {
            try
            {
                checkAWSKey();
                var awskey = new Amazon.Runtime.BasicAWSCredentials(AWSKey.accessKey, AWSKey.secretKey);
                RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(body.region);
                AmazonEC2Client ec2Client = new AmazonEC2Client(awskey, regionEndpoint);
                RunInstancesRequest runInstanceRequest = new RunInstancesRequest(body.imageID, body.minCount, body.maxCount);
                runInstanceRequest.InstanceType = body.instanceType;
                return LaunchInstances(ec2Client, runInstanceRequest);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            
            
        }

        private static async Task<List<string>> LaunchInstances(IAmazonEC2 ec2Client, RunInstancesRequest requestLaunch)
        {
            checkAWSKey();
            var instanceIds = new List<string>();
            RunInstancesResponse responseLaunch = await ec2Client.RunInstancesAsync(requestLaunch);

            foreach (Instance item in responseLaunch.Reservation.Instances)
            {
                instanceIds.Add(item.InstanceId);
            }

            return instanceIds;
        }

        public static Task<DescribeInstancesResponse> getAllInstance(getAllInstanceBody body)
        {

            try
            {
                checkAWSKey();
                var awsKey = new Amazon.Runtime.BasicAWSCredentials(AWSKey.accessKey, AWSKey.secretKey);
                RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(body.region);
                AmazonEC2Client ec2Client = new AmazonEC2Client(awsKey, regionEndpoint);
                CancellationToken cancellationToken;
                DescribeInstancesRequest describeInstancesRequest = new DescribeInstancesRequest();
                return ec2Client.DescribeInstancesAsync(describeInstancesRequest, cancellationToken);
            }
            catch (KeyNotFoundException)
            {

                throw;
            }
            
        }


        
        public static Task<DescribeInstancesResponse> getAllInstanceByFilter(getAllInstanceByFilterBody body)
        {
            checkAWSKey();
            var awsKey = new Amazon.Runtime.BasicAWSCredentials(AWSKey.accessKey, AWSKey.secretKey);
            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(body.region);
            AmazonEC2Client ec2Client = new AmazonEC2Client(awsKey, regionEndpoint);
            CancellationToken cancellationToken;
            DescribeInstancesRequest describeInstancesRequest;
            if (body.filterValue != null || body.filterName !=null)
            {
                 describeInstancesRequest = new DescribeInstancesRequest { Filters = new List<Filter> { new Filter { Name = body.filterName, Values = body.filterValue } } };
            }
            else
            {
                 describeInstancesRequest = new DescribeInstancesRequest();
            }            
            return ec2Client.DescribeInstancesAsync(describeInstancesRequest, cancellationToken);
        }
        


    }
}
