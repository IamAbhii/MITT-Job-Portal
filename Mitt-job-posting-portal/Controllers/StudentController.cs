using Mitt_job_posting_portal.Helper;
using Mitt_job_posting_portal.Models;
using System.Web.Mvc;

namespace Mitt_job_posting_portal.Controllers
{
  public class StudentController : Controller
  {
    ApplicationDbContext db;
    StudentHelper studentHelper;
    public StudentController()
    {
      this.db = new ApplicationDbContext();
      studentHelper = new StudentHelper(db);
    }
    // GET: Student
    public ActionResult GetAllStudent()
    {
      var students = studentHelper.GetAllStudent();
      return View(students);
    }
  }
}