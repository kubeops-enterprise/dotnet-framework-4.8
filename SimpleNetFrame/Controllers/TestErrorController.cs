using System;
using System.Web.Http;

namespace SimpleNetFrame.Controllers
{
    public class TestErrorController : ApiController
    {
        public TestErrorController()
        {

        }
        // GET: TestError
        public IHttpActionResult Get()
        {
            //return Ok( Environment.GetEnvironmentVariable("ARM_THREEPOINTZERO_BETA"));
            throw new System.Exception("Simulate Error");

        }
    }
}