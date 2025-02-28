// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagedNetworkFabric;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ManagedNetworkFabric.Samples
{
    public partial class Sample_NetworkFabricControllerCollection
    {
        // NetworkFabricControllers_Create_MaximumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate_NetworkFabricControllersCreateMaximumSetGen()
        {
            // Generated from example definition: specification/managednetworkfabric/resource-manager/Microsoft.ManagedNetworkFabric/stable/2023-06-15/examples/NetworkFabricControllers_Create_MaximumSet_Gen.json
            // this example is just showing the usage of "NetworkFabricControllers_Create" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "1234ABCD-0A1B-1234-5678-123456ABCDEF";
            string resourceGroupName = "example-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this NetworkFabricControllerResource
            NetworkFabricControllerCollection collection = resourceGroupResource.GetNetworkFabricControllers();

            // invoke the operation
            string networkFabricControllerName = "example-networkController";
            NetworkFabricControllerData data = new NetworkFabricControllerData(new AzureLocation("eastus"))
            {
                Annotation = "annotation",
                InfrastructureExpressRouteConnections =
{
new ExpressRouteConnectionInformation(new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.Network/expressRouteCircuits/expressRouteCircuitName"))
{
ExpressRouteAuthorizationKey = "1234ABCD-0A1B-1234-5678-123456ABCDEF",
}
},
                WorkloadExpressRouteConnections =
{
new ExpressRouteConnectionInformation(new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.Network/expressRouteCircuits/expressRouteCircuitName"))
{
ExpressRouteAuthorizationKey = "xxxxx",
}
},
                ManagedResourceGroupConfiguration = new ManagedResourceGroupConfiguration()
                {
                    Name = "managedResourceGroupName",
                    Location = new AzureLocation("eastus"),
                },
                IsWorkloadManagementNetworkEnabled = IsWorkloadManagementNetworkEnabled.True,
                IPv4AddressSpace = "172.253.0.0/19",
                IPv6AddressSpace = "::/60",
                NfcSku = NetworkFabricControllerSKU.Standard,
            };
            ArmOperation<NetworkFabricControllerResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, networkFabricControllerName, data);
            NetworkFabricControllerResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            NetworkFabricControllerData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // NetworkFabricControllers_Get_MaximumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_NetworkFabricControllersGetMaximumSetGen()
        {
            // Generated from example definition: specification/managednetworkfabric/resource-manager/Microsoft.ManagedNetworkFabric/stable/2023-06-15/examples/NetworkFabricControllers_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "NetworkFabricControllers_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "1234ABCD-0A1B-1234-5678-123456ABCDEF";
            string resourceGroupName = "example-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this NetworkFabricControllerResource
            NetworkFabricControllerCollection collection = resourceGroupResource.GetNetworkFabricControllers();

            // invoke the operation
            string networkFabricControllerName = "example-networkController";
            NetworkFabricControllerResource result = await collection.GetAsync(networkFabricControllerName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            NetworkFabricControllerData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // NetworkFabricControllers_Get_MaximumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Exists_NetworkFabricControllersGetMaximumSetGen()
        {
            // Generated from example definition: specification/managednetworkfabric/resource-manager/Microsoft.ManagedNetworkFabric/stable/2023-06-15/examples/NetworkFabricControllers_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "NetworkFabricControllers_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "1234ABCD-0A1B-1234-5678-123456ABCDEF";
            string resourceGroupName = "example-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this NetworkFabricControllerResource
            NetworkFabricControllerCollection collection = resourceGroupResource.GetNetworkFabricControllers();

            // invoke the operation
            string networkFabricControllerName = "example-networkController";
            bool result = await collection.ExistsAsync(networkFabricControllerName);

            Console.WriteLine($"Succeeded: {result}");
        }

        // NetworkFabricControllers_ListByResourceGroup_MaximumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll_NetworkFabricControllersListByResourceGroupMaximumSetGen()
        {
            // Generated from example definition: specification/managednetworkfabric/resource-manager/Microsoft.ManagedNetworkFabric/stable/2023-06-15/examples/NetworkFabricControllers_ListByResourceGroup_MaximumSet_Gen.json
            // this example is just showing the usage of "NetworkFabricControllers_ListByResourceGroup" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "1234ABCD-0A1B-1234-5678-123456ABCDEF";
            string resourceGroupName = "example-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this NetworkFabricControllerResource
            NetworkFabricControllerCollection collection = resourceGroupResource.GetNetworkFabricControllers();

            // invoke the operation and iterate over the result
            await foreach (NetworkFabricControllerResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                NetworkFabricControllerData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
