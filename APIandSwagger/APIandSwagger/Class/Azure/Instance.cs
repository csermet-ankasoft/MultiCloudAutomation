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


        public static IEnumerable<string> vmNameGet()
        {
            checkAzureCredential();
            var virtualMachines = Credential.azure.VirtualMachines.List();
            List<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> virtualMachinesList = virtualMachines.ToList();
            List<string> vmNameList = new List<string>();
            for (int i = 0; i < virtualMachinesList.Count; i++)
            {
                vmNameList.Add(virtualMachinesList[i].Name);
            }
            return vmNameList;
        }
    }
}
