namespace WebAPI.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using WebAPI.Models;
    public class DepartmentController : ApiController
    {
        EntityModel context = new EntityModel();
        public IHttpActionResult Get(int id)
        {
            Department department = context.Departments.Where(p => p.DepartmentId == id).FirstOrDefault();
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        public IHttpActionResult Post(Department department)
        {
            if (department != null)
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = department.DepartmentId }, department);
            }
            return BadRequest();
        }
        public IHttpActionResult Put(Department department)
        {
            if (department != null)
            {
                // Do some work .
                return Content(HttpStatusCode.Accepted, department);
            }
            return BadRequest();
        }
    }
}
