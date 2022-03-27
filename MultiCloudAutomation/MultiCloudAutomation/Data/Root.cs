using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation.Data
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Architecture
    {
        public string value { get; set; }
    }

    public class Status
    {
        public string value { get; set; }
    }

    public class Ebs
    {
        public DateTime attachTime { get; set; }
        public bool deleteOnTermination { get; set; }
        public Status status { get; set; }
        public string volumeId { get; set; }
    }

    public class BlockDeviceMapping
    {
        public string deviceName { get; set; }
        public Ebs ebs { get; set; }
    }

    public class CapacityReservationPreference
    {
        public string value { get; set; }
    }

    public class CapacityReservationSpecification
    {
        public CapacityReservationPreference capacityReservationPreference { get; set; }
        public object capacityReservationTarget { get; set; }
    }

    public class CpuOptions
    {
        public int coreCount { get; set; }
        public int threadsPerCore { get; set; }
    }

    public class EnclaveOptions
    {
        public bool enabled { get; set; }
    }

    public class HibernationOptions
    {
        public bool configured { get; set; }
    }

    public class Hypervisor
    {
        public string value { get; set; }
    }

    public class InstanceType
    {
        public string value { get; set; }
    }

    public class HttpEndpoint
    {
        public string value { get; set; }
    }

    public class HttpProtocolIpv6
    {
        public string value { get; set; }
    }

    public class HttpTokens
    {
        public string value { get; set; }
    }

    public class InstanceMetadataTags
    {
        public string value { get; set; }
    }

    public class State
    {
        public string value { get; set; }
        public int code { get; set; }
        public Name name { get; set; }
    }

    public class MetadataOptions
    {
        public HttpEndpoint httpEndpoint { get; set; }
        public HttpProtocolIpv6 httpProtocolIpv6 { get; set; }
        public int httpPutResponseHopLimit { get; set; }
        public HttpTokens httpTokens { get; set; }
        public InstanceMetadataTags instanceMetadataTags { get; set; }
        public State state { get; set; }
    }

    public class Monitoring
    {
        public State state { get; set; }
    }

    public class Attachment
    {
        public string attachmentId { get; set; }
        public DateTime attachTime { get; set; }
        public bool deleteOnTermination { get; set; }
        public int deviceIndex { get; set; }
        public int networkCardIndex { get; set; }
        public Status status { get; set; }
    }

    public class Group
    {
        public string groupId { get; set; }
        public string groupName { get; set; }
    }

    public class PrivateIpAddress
    {
        public object association { get; set; }
        public bool primary { get; set; }
        public string privateDnsName { get; set; }
        public string privateIpAddress { get; set; }
    }

    public class NetworkInterface
    {
        public object association { get; set; }
        public Attachment attachment { get; set; }
        public object description { get; set; }
        public List<Group> groups { get; set; }
        public string interfaceType { get; set; }
        public List<object> ipv4Prefixes { get; set; }
        public List<object> ipv6Addresses { get; set; }
        public List<object> ipv6Prefixes { get; set; }
        public string macAddress { get; set; }
        public string networkInterfaceId { get; set; }
        public string ownerId { get; set; }
        public string privateDnsName { get; set; }
        public string privateIpAddress { get; set; }
        public List<PrivateIpAddress> privateIpAddresses { get; set; }
        public bool sourceDestCheck { get; set; }
        public Status status { get; set; }
        public string subnetId { get; set; }
        public string vpcId { get; set; }
    }

    public class Tenancy
    {
        public string value { get; set; }
    }

    public class Placement
    {
        public object affinity { get; set; }
        public string availabilityZone { get; set; }
        public object groupName { get; set; }
        public object hostId { get; set; }
        public object hostResourceGroupArn { get; set; }
        public int partitionNumber { get; set; }
        public object spreadDomain { get; set; }
        public Tenancy tenancy { get; set; }
    }

    public class HostnameType
    {
        public string value { get; set; }
    }

    public class PrivateDnsNameOptions
    {
        public bool enableResourceNameDnsAAAARecord { get; set; }
        public bool enableResourceNameDnsARecord { get; set; }
        public HostnameType hostnameType { get; set; }
    }

    public class RootDeviceType
    {
        public string value { get; set; }
    }

    public class SecurityGroup
    {
        public string groupId { get; set; }
        public string groupName { get; set; }
    }

    public class Name
    {
        public string value { get; set; }
    }

    public class StateReason
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class VirtualizationType
    {
        public string value { get; set; }
    }

    public class Root
    {
        public int amiLaunchIndex { get; set; }
        public Architecture architecture { get; set; }
        public List<BlockDeviceMapping> blockDeviceMappings { get; set; }
        public object bootMode { get; set; }
        public object capacityReservationId { get; set; }
        public CapacityReservationSpecification capacityReservationSpecification { get; set; }
        public object clientToken { get; set; }
        public CpuOptions cpuOptions { get; set; }
        public bool ebsOptimized { get; set; }
        public List<object> elasticGpuAssociations { get; set; }
        public List<object> elasticInferenceAcceleratorAssociations { get; set; }
        public bool enaSupport { get; set; }
        public EnclaveOptions enclaveOptions { get; set; }
        public HibernationOptions hibernationOptions { get; set; }
        public Hypervisor hypervisor { get; set; }
        public object iamInstanceProfile { get; set; }
        public string imageId { get; set; }
        public string instanceId { get; set; }
        public object instanceLifecycle { get; set; }
        public InstanceType instanceType { get; set; }
        public object ipv6Address { get; set; }
        public object kernelId { get; set; }
        public string keyName { get; set; }
        public DateTime launchTime { get; set; }
        public List<object> licenses { get; set; }
        public MetadataOptions metadataOptions { get; set; }
        public Monitoring monitoring { get; set; }
        public List<NetworkInterface> networkInterfaces { get; set; }
        public object outpostArn { get; set; }
        public Placement placement { get; set; }
        public object platform { get; set; }
        public string platformDetails { get; set; }
        public string privateDnsName { get; set; }
        public PrivateDnsNameOptions privateDnsNameOptions { get; set; }
        public string privateIpAddress { get; set; }
        public List<object> productCodes { get; set; }
        public object publicDnsName { get; set; }
        public object publicIpAddress { get; set; }
        public object ramdiskId { get; set; }
        public string rootDeviceName { get; set; }
        public RootDeviceType rootDeviceType { get; set; }
        public List<SecurityGroup> securityGroups { get; set; }
        public bool sourceDestCheck { get; set; }
        public object spotInstanceRequestId { get; set; }
        public object sriovNetSupport { get; set; }
        public State state { get; set; }
        public StateReason stateReason { get; set; }
        public string stateTransitionReason { get; set; }
        public string subnetId { get; set; }
        public List<object> tags { get; set; }
        public string usageOperation { get; set; }
        public DateTime usageOperationUpdateTime { get; set; }
        public VirtualizationType virtualizationType { get; set; }
        public string vpcId { get; set; }
    }


}
