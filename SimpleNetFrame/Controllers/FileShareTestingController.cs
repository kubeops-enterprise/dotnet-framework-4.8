using Azure.Storage.Files.Shares;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SimpleNetFrame.Controllers
{
    public class FileShareTestingController : ApiController
    {
        public IHttpActionResult Get()
        {
            var cred = ConfigurationSettings.AppSettings["blobcred"];

            ShareClient share = new ShareClient(cred, "test-file-share");
            var superDir = share.GetDirectoryClient("super");
            superDir.CreateIfNotExists();

            var fileClient = superDir.GetFileClient("ex_" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss"));

            MemoryStream ms = new MemoryStream(System.Text.Encoding.ASCII.GetBytes("HelloWord"));
            fileClient.Create(ms.Length);
            fileClient.UploadRange(new Azure.HttpRange(0, ms.Length), ms);

            return Ok("Ok");
        }
    }
}