using Mitt_job_posting_portal.Helper;
using Mitt_job_posting_portal.Models;
using System.Web.Mvc;

namespace Mitt_job_posting_portal.Controllers
{
  public class InstructorController : Controller
  {
    ApplicationDbContext db;
    InstructorHelper InstructorHelper;
    public InstructorController()
    {
      this.db = new ApplicationDbContext();
      InstructorHelper = new InstructorHelper(db);
    }
    // GET: Instructor
    public ActionResult GetAllInstructor()
    {
      var allInstructor = InstructorHelper.GetAllInstructor();
      return View(allInstructor);
    }
  }
}