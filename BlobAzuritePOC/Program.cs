using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AzuriteBlobListApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "UseDevelopmentStorage=true";
            string containerName = "newcontainer"; // Replace with your container name

            BlobServiceClient blobServiceClient = new(connectionString);

            // Get the container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // List all blobs in the container
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine($"Name: {blobItem.Name}");
            }
        }
    }
}
