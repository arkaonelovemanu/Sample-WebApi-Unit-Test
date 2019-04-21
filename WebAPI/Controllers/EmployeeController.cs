namespace WebAPI.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WebAPI.Models;
    public class EmployeeController : ApiController
    {
        EntityModel context = new EntityModel();

        public HttpResponseMessage Get(int id)
        {
            
            // var employee = context.Employees.Where(p => p.Id == id).FirstOrDefault();
            // if (employee == null)
            // {
            //     return Request.CreateResponse(HttpStatusCode.NotFound);
            // }
            return Request.CreateResponse(HttpStatusCode.OK, new Employee(){Id=1,Name="Mouna"});
        }

        public HttpResponseMessage Post(Employee employee)
        {
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            employee = context.Employees.Add(employee);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
