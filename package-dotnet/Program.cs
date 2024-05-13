using Azure;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string subscriptionId = "c19d82c6-c1f6-4f4a-bcd8-b3d96af29337";
        string resourceGroupName = "helloworld1dmehnatdunya";
        string location = "westus"; // e.g., "eastus"

        // Authenticate and create the ARM client
        ArmClient armClient = new ArmClient(new DefaultAzureCredential());

        // Get the subscription
        SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

        // Create or update the resource group
        ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
        ResourceGroupData resourceGroupData = new ResourceGroupData(location);
        ArmOperation<ResourceGroupResource> resourceGroupOperation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
        ResourceGroupResource resourceGroup = resourceGroupOperation.Value;

        Console.WriteLine($"Resource Group '{resourceGroupName}' created successfully in location '{location}'.");
    }
}
