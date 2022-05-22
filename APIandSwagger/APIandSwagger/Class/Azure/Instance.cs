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
                    virtualMachinesList[i].Deallocate();
                    return true;
                }
            }
            return false;
        }
    }
}
