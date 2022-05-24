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
        


        public static List<string> networknames(Azure.NameByResourceGroupBody body)
        {
            try
            {
                List<Microsoft.Azure.Management.Network.Fluent.INetwork> network = Credential.azure.Networks.List().ToList();
                List<string> networknames = new List<string>();
                foreach (var item in network)
                {
                    if (item.ResourceGroupName == body.resourceGroup)
                    {
                        networknames.Add(item.Name);
                    }
                    
                }
                return networknames;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> publicIPAddressnames(Azure.NameByResourceGroupBody body)
        {
            try
            {
                List<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> publicIPAddress = Credential.azure.PublicIPAddresses.List().ToList();
                List<string> publicIPAddressnames = new List<string>();
                foreach (var item in publicIPAddress)
                {
                    if (item.ResourceGroupName == body.resourceGroup)
                    {
                        publicIPAddressnames.Add(item.Name);
                    }

                }
                return publicIPAddressnames;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> networkSecurityGroupnames(Azure.NameByResourceGroupBody body)
        {
            try
            {
                List<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup> networkSecurityGroup = Credential.azure.NetworkSecurityGroups.List().ToList();
                List<string> networkSecurityGroupnames = new List<string>();
                foreach (var item in networkSecurityGroup)
                {
                    if (item.ResourceGroupName == body.resourceGroup)
                    {
                        networkSecurityGroupnames.Add(item.Name);
                    }

                }
                return networkSecurityGroupnames;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> networkInterfacenames(Azure.NameByResourceGroupBody body)
        {
            try
            {
                List<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> networkInterface = Credential.azure.NetworkInterfaces.List().ToList();
                List<string> networkInterfacenames = new List<string>();
                foreach (var item in networkInterface)
                {
                    if (item.ResourceGroupName == body.resourceGroup)
                    {
                        networkInterfacenames.Add(item.Name);
                    }

                }
                return networkInterfacenames;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Microsoft.Azure.Management.Network.Fluent.INetworkInterface networkInterfaceFind(string nicName)
        {
            try
            {
                List<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> networkInterface = Credential.azure.NetworkInterfaces.List().ToList();
                List<string> networkInterfacenames = new List<string>();
                foreach (var item in networkInterface)
                {
                    if (item.Name == nicName)
                    {
                        networkInterfacenames.Add(item.Name);
                        return item;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }





        public static string createInstance(Azure.CreateInstanceBody body)
        {
            checkAzureCredential();

            try
            {
                var nic = networkInterfaceFind(body.nicName);
                if (body.osType == "Linux")
                {
                    var createdVirtualMachine = Credential.azure.VirtualMachines
                    .Define(body.vmName)
                    .WithRegion(body.region)
                    .WithExistingResourceGroup(body.resourceGroup)
                    .WithExistingPrimaryNetworkInterface(nic)
                    .WithLatestLinuxImage(body.imagepublisher, body.imageoffer, body.imagesku).WithRootUsername(body.adminUsername).WithRootPassword(body.adminpass)
                    .WithComputerName(body.computerName)
                    .WithSize(body.size).Create();
                    return "Created";
                }
                else if (body.osType == "Windows")
                {
                    var createdVirtualMachine = Credential.azure.VirtualMachines
                    .Define(body.vmName)
                    .WithRegion(body.region)
                    .WithExistingResourceGroup(body.resourceGroup)
                    .WithExistingPrimaryNetworkInterface(nic)
                    .WithLatestWindowsImage(body.imagepublisher, body.imageoffer, body.imagesku)
                    .WithAdminUsername(body.adminUsername)
                    .WithAdminPassword(body.adminpass)
                    .WithComputerName(body.computerName)
                    .WithSize(body.size).Create();
                    return "Created";
                }
                else
                {
                    return "?";
                }
                
                
                
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
    }
}
