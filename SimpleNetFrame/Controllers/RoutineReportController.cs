using SimpleNetFrame.Context;
using SimpleNetFrame.Context.Models;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Linq;

namespace SimpleNetFrame.Controllers
{
    public class RoutineReportController : ApiController
    {
        private readonly KubeExContext _kubeContext;
        public RoutineReportController()
        {
            var conStr = ConfigurationManager.ConnectionStrings["kubeexuser"];
            _kubeContext = new KubeExContext();
        }
        public IHttpActionResult Get(int id)
        {

            //var conStr = ConfigurationManager.AppSettings.GetValues("kubeexuser").FirstOrDefault();

            return Ok(_kubeContext.RoutineReports.FirstOrDefault(a => a.Id == id));
        }

        public IHttpActionResult Post(string topic, string body)
        {
            var record = new RoutineReport() { Body = body, Topic = topic, CreatedDate = System.DateTimeOffset.Now };

            _kubeContext.RoutineReports.Add(record);

            _kubeContext.SaveChanges();

            return Ok();
        }
    }
}