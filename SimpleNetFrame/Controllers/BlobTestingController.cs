using Azure.Identity;
using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Text;
using System.Web.Http;

namespace SimpleNetFrame.Controllers
{
    public class BlobTestingController : ApiController
    {
        public IHttpActionResult Get()
        {
            var credential = new DefaultAzureCredential();

            var blobClient = new BlobContainerClient(new Uri("https://wasuwat.blob.core.windows.net/test"), credential);

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes("HelloWord"));

            blobClient.UploadBlob("ex_" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss") + ".txt", ms);

            return Ok("Ok");
        }
        
    }
}