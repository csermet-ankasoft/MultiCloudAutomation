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
            checkAWSKey();
            var awskey = new Amazon.Runtime.BasicAWSCredentials(AWSKey.accessKey, AWSKey.secretKey);
            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(body.region);
            AmazonEC2Client ec2Client = new AmazonEC2Client(awskey, regionEndpoint);
            RunInstancesRequest InstanceRequest = new RunInstancesRequest(body.imageID, body.minCount, body.maxCount);
            InstanceRequest.InstanceType = body.instanceType;
            if (body.tagDictionary != null)
            {
                TagSpecification tagSpecification = new TagSpecification();
                tagSpecification.ResourceType = new ResourceType("instance");

                List<Tag> tagList = new List<Tag>();
                foreach (var item in body.tagDictionary)
                {
                    tagList.Add(new Tag(item.Key, item.Value));
                }
                tagSpecification.Tags = tagList;
                InstanceRequest.TagSpecifications.Add(tagSpecification);
            }            
            return LaunchInstances(ec2Client, InstanceRequest);
        }

        private static async Task<List<string>> LaunchInstances(IAmazonEC2 ec2Client, RunInstancesRequest requestLaunch)
        {
            var instanceIds = new List<string>();
            RunInstancesResponse responseLaunch = await ec2Client.RunInstancesAsync(requestLaunch);

            foreach (Instance item in responseLaunch.Reservation.Instances)
            {
                instanceIds.Add(item.InstanceId);
            }

            return instanceIds;
        }

        public static Task<List<InstanceStateChange>> StopInstance(InstanceIDListBody instanceIDBody)
        {
            checkAWSKey();
            var awskey = new Amazon.Runtime.BasicAWSCredentials(AWSKey.accessKey, AWSKey.secretKey);
            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(instanceIDBody.region);
            AmazonEC2Client ec2Client = new AmazonEC2Client(awskey,regionEndpoint);
            StopInstancesRequest InstanceRequest = new StopInstancesRequest(instanceIDBody.instanceList);
            return StopInstances(ec2Client, InstanceRequest);
        }

        

        private static async Task<List<InstanceStateChange>> StopInstances(IAmazonEC2 ec2Client, StopInstancesRequest requestLaunch)
        {
            StopInstancesResponse responseLaunch = await ec2Client.StopInstancesAsync(requestLaunch);
            return responseLaunch.StoppingInstances;
        }

        public static Task<List<InstanceStateChange>> StartInstance(InstanceIDListBody instanceIDBody)
        {
            checkAWSKey();
            var awskey = new Amazon.Runtime.BasicAWSCredentials(AWSKey.accessKey, AWSKey.secretKey);
            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(instanceIDBody.region);
            AmazonEC2Client ec2Client = new AmazonEC2Client(awskey, regionEndpoint);
            StartInstancesRequest InstanceRequest = new StartInstancesRequest(instanceIDBody.instanceList);
            return StartInstances(ec2Client, InstanceRequest);
        }



        private static async Task<List<InstanceStateChange>> StartInstances(IAmazonEC2 ec2Client, StartInstancesRequest requestLaunch)
        {
            StartInstancesResponse responseLaunch = await ec2Client.StartInstancesAsync(requestLaunch);
            return responseLaunch.StartingInstances;
        }

        public static Task<List<InstanceStateChange>> TerminateInstance(InstanceIDListBody instanceIDBody)
        {
            checkAWSKey();
            var awskey = new Amazon.Runtime.BasicAWSCredentials(AWSKey.accessKey, AWSKey.secretKey);
            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(instanceIDBody.region);
            AmazonEC2Client ec2Client = new AmazonEC2Client(awskey, regionEndpoint);
            TerminateInstancesRequest InstanceRequest = new TerminateInstancesRequest(instanceIDBody.instanceList);
            return TerminateInstances(ec2Client, InstanceRequest);
        }



        private static async Task<List<InstanceStateChange>> TerminateInstances(IAmazonEC2 ec2Client, TerminateInstancesRequest requestLaunch)
        {
            TerminateInstancesResponse responseLaunch = await ec2Client.TerminateInstancesAsync(requestLaunch);
            return responseLaunch.TerminatingInstances;
        }

        public static Task<string> RebootInstance(InstanceIDListBody instanceIDBody)
        {
            checkAWSKey();
            var awskey = new Amazon.Runtime.BasicAWSCredentials(AWSKey.accessKey, AWSKey.secretKey);
            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(instanceIDBody.region);
            AmazonEC2Client ec2Client = new AmazonEC2Client(awskey, regionEndpoint);
            RebootInstancesRequest InstanceRequest = new RebootInstancesRequest(instanceIDBody.instanceList);
            return RebootInstances(ec2Client, InstanceRequest);
        }



        private static async Task<string> RebootInstances(IAmazonEC2 ec2Client, RebootInstancesRequest requestLaunch)
        {
            RebootInstancesResponse responseLaunch = await ec2Client.RebootInstancesAsync(requestLaunch);
            return "Rebooting";
        }

        public static Task<DescribeInstancesResponse> getAllInstance(getAllInstanceBody body)
        {
            checkAWSKey();
            var awsKey = new Amazon.Runtime.BasicAWSCredentials(AWSKey.accessKey, AWSKey.secretKey);
            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(body.region);
            AmazonEC2Client ec2Client = new AmazonEC2Client(awsKey, regionEndpoint);
            CancellationToken cancellationToken;
            DescribeInstancesRequest describeInstancesRequest = new DescribeInstancesRequest();
            return ec2Client.DescribeInstancesAsync(describeInstancesRequest, cancellationToken);
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
