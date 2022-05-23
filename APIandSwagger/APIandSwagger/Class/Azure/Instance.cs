using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Network.Fluent.Models;

namespace APIandSwagger.Azure
{
    public class Instance
    {
        public static void checkAzureCredential()
        {
            if (Credential.clientId == "" || Credential.azure == null)
            {
                throw new KeyNotFoundException();
            }
        }


        public static List<Azure.VMSimpleBody> getVMSimple()
        {
            checkAzureCredential();
            var virtualMachines = Credential.azure.VirtualMachines.List();
            List<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> virtualMachinesList = virtualMachines.ToList();
            List<Azure.VMSimpleBody> vmList = new List<Azure.VMSimpleBody>();
            for (int i = 0; i < virtualMachinesList.Count; i++)
            {
                Azure.VMSimpleBody temp = new Azure.VMSimpleBody();
                temp.InstanceName = virtualMachinesList[i].Name;
                string PowerStateUnFiltered = virtualMachinesList[i].PowerState.Value;
                string PowerStateFiltered = "";
                for (int j = 11; j < PowerStateUnFiltered.Length; j++)
                {
                    PowerStateFiltered += PowerStateUnFiltered[j];
                }
                temp.InstanceState = PowerStateFiltered;
                temp.OSType = virtualMachinesList[i].OSType.ToString();
                temp.InstanceType = virtualMachinesList[i].Size.Value;
                temp.PublicIP = virtualMachinesList[i].GetPrimaryPublicIPAddress().IPAddress;
                temp.VMID = virtualMachinesList[i].VMId;
                vmList.Add(temp);
            }
            return vmList;
        }

        public static string createInstance(Azure.CreateInstanceBody body)
        {
            checkAzureCredential();

            try
            {
                Microsoft.Azure.Management.Network.Fluent.INetwork              network     = createNetwork(body.networkName, body.region, body.resourceGroup, body.subnetName);
                Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress      PublicIP    = createPublicIP(body.publicIP, body.region, body.resourceGroup);
                Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup NSG         = createNSG(body.nsgName, body.region, body.resourceGroup);
                Microsoft.Azure.Management.Network.Fluent.INetworkInterface     nic         = createNic(body.nicName, body.region, body.resourceGroup, body.subnetName, network, PublicIP, NSG);

                var createdVirtualMachine = Credential.azure.VirtualMachines
                    .Define(body.vmName)
                    .WithRegion(body.region)
                    .WithExistingResourceGroup(body.resourceGroup)
                    .WithExistingPrimaryNetworkInterface(nic)
                    .WithLatestWindowsImage("MicrosoftWindowsServer", "WindowsServer", "2012-R2-Datacenter")
                    //.WithLatestLinuxImage().WithRootUsername().WithRootPassword()
                    .WithAdminUsername("adminnO1!hda")
                    .WithAdminPassword("notAllow!Pass")
                    .WithComputerName(body.computerName)
                    .WithSize(VirtualMachineSizeTypes.StandardB1s).Create();
                return "true";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public static Microsoft.Azure.Management.Network.Fluent.INetwork createNetwork(string name, string region, string resourceGroup,string subnetName)
        {
            try
            {
                var network = Credential.azure.Networks.Define(name)
                .WithRegion(region)
                .WithExistingResourceGroup(resourceGroup)
                .WithAddressSpace("172.16.0.0/16")
                .WithSubnet(subnetName, "172.16.0.0/24")
                .Create();

                return network;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress createPublicIP(string name, string region, string resourceGroup)
        {
            try
            {

                var publicIP = Credential.azure.PublicIPAddresses.Define(name)
                    .WithRegion(region)
                    .WithExistingResourceGroup(resourceGroup)
                    .Create();

                return publicIP;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup createNSG(string name, string region, string resourceGroup)
        {
            try
            {

                var nsg = Credential.azure.NetworkSecurityGroups.Define(name)
                    .WithRegion(region)
                    .WithExistingResourceGroup(resourceGroup)
                    .Create();


                return nsg;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Microsoft.Azure.Management.Network.Fluent.INetworkInterface createNic(string name, string region, string resourceGroup, string subnetName,
            Microsoft.Azure.Management.Network.Fluent.INetwork network,
            Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress publicIP,
            Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup nsg)
        {
            try
            {

                var nic = Credential.azure.NetworkInterfaces.Define(name)
                         .WithRegion(region)
                         .WithExistingResourceGroup(resourceGroup)
                         .WithExistingPrimaryNetwork(network)
                         .WithSubnet(subnetName)
                         .WithPrimaryPrivateIPAddressDynamic()
                         .WithExistingPrimaryPublicIPAddress(publicIP)
                         .WithExistingNetworkSecurityGroup(nsg)
                         .Create();
                return nic;
            }
            catch (Exception)
            {
                throw;                
            }
        }



        public static bool StartInstance(Azure.IDBody vmid)
        {
            checkAzureCredential();
            var virtualMachines = Credential.azure.VirtualMachines.List();
            List<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> virtualMachinesList = virtualMachines.ToList();
            List<Azure.VMSimpleBody> vmList = new List<Azure.VMSimpleBody>();
            for (int i = 0; i < virtualMachinesList.Count; i++)
            {
                if (virtualMachinesList[i].VMId == vmid.vmid)
                {
                    virtualMachinesList[i].Start();
                    return true;
                }
            }
            return false;
        }
        public static bool RestartInstance(Azure.IDBody vmid)
        {
            checkAzureCredential();
            var virtualMachines = Credential.azure.VirtualMachines.List();
            List<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> virtualMachinesList = virtualMachines.ToList();
            List<Azure.VMSimpleBody> vmList = new List<Azure.VMSimpleBody>();
            for (int i = 0; i < virtualMachinesList.Count; i++)
            {
                if (virtualMachinesList[i].VMId == vmid.vmid)
                {
                    virtualMachinesList[i].Restart();
                    return true;
                }
            }
            return false;
        }
        
        public static bool StopInstance(Azure.IDBody vmid)
        {
            checkAzureCredential();
            var virtualMachines = Credential.azure.VirtualMachines.List();
            List<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> virtualMachinesList = virtualMachines.ToList();
            List<Azure.VMSimpleBody> vmList = new List<Azure.VMSimpleBody>();
            for (int i = 0; i < virtualMachinesList.Count; i++)
            {
                if (virtualMachinesList[i].VMId == vmid.vmid)
                {
                    virtualMachinesList[i].PowerOff();
                    return true;
                }
            }
            return false;
        }

        public static bool TerminateInstance(Azure.IDBody vmid)
        {
            checkAzureCredential();
            var virtualMachines = Credential.azure.VirtualMachines.List();
            List<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> virtualMachinesList = virtualMachines.ToList();
            List<Azure.VMSimpleBody> vmList = new List<Azure.VMSimpleBody>();
            for (int i = 0; i < virtualMachinesList.Count; i++)
            {
                if (virtualMachinesList[i].VMId == vmid.vmid)
                {
                    Credential.azure.VirtualMachines.DeleteById(virtualMachinesList[i].Id);
                    return true;
                }
            }
            return true;
        }
        /*
        public static bool createInstance(Azure.IDBody vmid)
        {
            checkAzureCredential();
            var virtualMachines = Credential.azure.VirtualMachines.List();
            List<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> virtualMachinesList = virtualMachines.ToList();
            List<Azure.VMSimpleBody> vmList = new List<Azure.VMSimpleBody>();
            for (int i = 0; i < virtualMachinesList.Count; i++)
            {
                if (virtualMachinesList[i].VMId == vmid.vmid)
                {
                    Credential.azure.VirtualMachines.DeleteById(virtualMachinesList[i].Id);
                    return true;
                }
            }
            return true;
        }
        */
    }
}
