using Microsoft.AspNet.Identity;
using Mitt_job_posting_portal.Helper;
using Mitt_job_posting_portal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Mitt_job_posting_portal.Controllers
{
  [Authorize(Roles = "Instructor, Admin")]
  public class StudentController : Controller
  {
    ApplicationDbContext db;
    StudentHelper studentHelper;
    AccountHelper userManager;
    public StudentController()
    {
      this.db = new ApplicationDbContext();
      studentHelper = new StudentHelper(db);
      userManager = new AccountHelper(db);
    }
    // GET: Student
    public ActionResult GetAllStudent()
    {
      var userId = User.Identity.GetUserId();
      var userRole = userManager.GetUserRole(userId);
      if (userRole == "Admin")
      {
        var students = studentHelper.GetAllStudent();
        return View(students);
      }
      else
      {
        var instructor = userManager.GetInstructor(userId);
        List<Student> students = new List<Student>();
        foreach (var course in instructor.Courses)
        {
          students.AddRange(course.Students.ToList());
        }
        return View(students);
      }

    }
  }
}