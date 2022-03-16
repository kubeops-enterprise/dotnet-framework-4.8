using Azure.Storage.Files.Shares;
using Azure.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Azure.Storage.Blobs;

namespace SimpleNetFrame.Controllers
{
    public class FileTestingController : ApiController
    {
        public string Get()
        {

            try
            {
                string userAssignedClientId = "3c221eb4-d9cf-4cf6-85e0-d931accf544c";

                var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = userAssignedClientId });

                var blobClient = new BlobClient(new Uri("https://wasuwat.blob.core.windows.net/test"), credential);

                if (blobClient.CanGenerateSasUri)
                {
                    return "OK";
                } else
                {
                    return "NOT OK";
                }

                //ShareClient share = new ShareClient("FileEndpoint=https://wasuwat.file.core.windows.net", "test-file-share");

                //ShareClient share = new ShareClient("https://wasuwat.file.core.windows.net/test-file-share", credential);


                //share.CreateIfNotExists();

                //var superDir = share.GetDirectoryClient("super");
                //superDir.CreateIfNotExists();

                //var fileClient = superDir.GetFileClient("ex_"+DateTime.Now.ToString("dd-MM-yy_HH-mm-ss"));

                //MemoryStream ms = new MemoryStream(System.Text.Encoding.ASCII.GetBytes("HelloWord"));
                //fileClient.Create(ms.Length);
                //fileClient.UploadRange(new Azure.HttpRange(0, ms.Length), ms);

                return "Ok";

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}