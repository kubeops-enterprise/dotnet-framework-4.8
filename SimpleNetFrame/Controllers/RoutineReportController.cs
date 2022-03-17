using SimpleNetFrame.Context;
using SimpleNetFrame.Context.Models;
using System.Configuration;
using System.Linq;
using System.Web.Http;

namespace SimpleNetFrame.Controllers
{
    public class RoutineReportController : ApiController
    {
        public IHttpActionResult Get()
        {
            var db = new KubeExContext();
            //var conStr = ConfigurationManager.AppSettings.GetValues("kubeexuser").FirstOrDefault();

            var record = new RoutineReport() { Body = "TestBody", Topic = "FirstTopic", CreatedDate = System.DateTimeOffset.Now };

            db.RoutineReports.Add(record);

            db.SaveChanges();

            return Ok();
        }
    }
}