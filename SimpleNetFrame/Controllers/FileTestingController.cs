using Azure.Storage.Files.Shares;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SimpleNetFrame.Controllers
{
    public class FileTestingController : ApiController
    {
        public string Get()
        {
            try
            {
                ShareClient share = new ShareClient("FileEndpoint=https://wasuwat.file.core.windows.net", "test-file-share");
            
                share.CreateIfNotExists();

                var superDir = share.GetDirectoryClient("super");
                superDir.CreateIfNotExists();

                var fileClient = superDir.GetFileClient("ex_"+DateTime.Now.ToString("dd-MM-yy_HH-mm-ss"));

                MemoryStream ms = new MemoryStream(System.Text.Encoding.ASCII.GetBytes("HelloWord"));
                fileClient.Create(ms.Length);
                fileClient.UploadRange(new Azure.HttpRange(0, ms.Length), ms);

                return "Ok";

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}