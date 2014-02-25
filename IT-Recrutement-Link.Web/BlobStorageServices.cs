using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
namespace IT_Recrutement_Link.Web
{
    public class BlobStorageService
    {
        private static CloudBlobContainer GetCloudBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.
                Parse(RoleEnvironment.GetConfigurationSettingValue("Microsoft.WindowsAzure.Blob"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("container");
            if (blobContainer.CreateIfNotExists())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions { 
                    PublicAccess = BlobContainerPublicAccessType.Blob 
                }
                );
            }
            return blobContainer;
        }
        public IList<string> getAllObjectsURIs()
        {
            CloudBlobContainer blobContainer = GetCloudBlobContainer();
            List<string> blobs = new List<string>();
            foreach (var blobItem in blobContainer.ListBlobs())
            {
                blobs.Add(blobItem.Uri.ToString());
            }
            return blobs;
        }
        public string Upload(HttpPostedFileBase uploadedFile)
        {
            if (uploadedFile.ContentLength > 0)
            {
                CloudBlobContainer blobContainer = GetCloudBlobContainer();
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(uploadedFile.FileName);
                blob.UploadFromStream(uploadedFile.InputStream);
                return blob.Uri.ToString();
            }
            else
            {
                throw new EmptyFileException();
            }
        }
        public void DeleteFile(string uriStr)
        {
            Uri uri = new Uri(uriStr);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);
            CloudBlobContainer blobContainer = GetCloudBlobContainer();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(filename);
            blob.Delete();
        }
    }
}