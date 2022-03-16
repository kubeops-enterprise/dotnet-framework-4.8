using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleNetFrame.Controllers
{
    public class ReadBlobController : ApiController
    {
        public IHttpActionResult Get()
        {
            var credential = new DefaultAzureCredential();

            var blobClient = new BlobContainerClient(new Uri("https://wasuwat.blob.core.windows.net/test"), credential);

            var blobItems = blobClient.GetBlobs(BlobTraits.None, BlobStates.None, "ex_");

            List<string> allBlobContent = new List<string>();

            foreach (var blobItem in blobItems)
            {
                var blob = blobClient.GetBlobClient(blobItem.Name);
                var blobResult = blob.DownloadContent();

                allBlobContent.Add(Encoding.UTF8.GetString(blobResult.Value.Content.ToArray()));
            }
            //blobClient.UploadBlob("ex_" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss") + ".txt", ms);

            return Ok(allBlobContent);
        }
    }
}