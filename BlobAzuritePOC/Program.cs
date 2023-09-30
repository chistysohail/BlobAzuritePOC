//using System;
//using System.IO;
//using System.Threading.Tasks;
//using Azure.Storage.Blobs;

//namespace AzuriteBlobUploadApp
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            string connectionString = "UseDevelopmentStorage=true";
//            string containerName = "newcontainer";
//            string blobName = "uploadedfile.txt";
//            string filePath = "C:\\Users\\db\\Documents\\testtxtfile\\test.txt"; // Replace with the path to your local file

//            BlobServiceClient blobServiceClient = new(connectionString);

//            // Create a new container
//            BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

//            // Get a reference to a blob
//            BlobClient blobClient = containerClient.GetBlobClient(blobName);

//            // Open the file and upload its data
//            using FileStream uploadFileStream = File.OpenRead(filePath);
//            await blobClient.UploadAsync(uploadFileStream, true);
//            uploadFileStream.Close();

//            Console.WriteLine($"Blob was created successfully. Check the '{containerName}' in your Azurite Blob storage.");
//        }
//    }
//}

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
