using Microsoft.AspNet.Identity;
using Mitt_job_posting_portal.Helper;
using Mitt_job_posting_portal.Models;
using System.Web.Mvc;

namespace Mitt_job_posting_portal.Controllers
{
  public class HomeController : Controller
  {
    ApplicationDbContext db;
    AccountHelper accountHelper;
    public HomeController()
    {
      db = new ApplicationDbContext();
      accountHelper = new AccountHelper(db);
    }
    [Authorize]
    public ActionResult Index()
    {
      var userId = User.Identity.GetUserId();
      if (userId != null)
      {
        string userRole = accountHelper.GetUserRole(userId);
        if (userRole == "Admin")
        {
          return RedirectToAction("AdminDashboard");
        }
        else if (userRole == "Student")
        {
          return RedirectToAction("StudentDashboard");
        }
        else if (userRole == "Instructor")
        {
          return RedirectToAction("InstructorDashboard");
        }
        else
        {
          return RedirectToAction("EmployerDashboard");
        }
      }
      return View();
    }
    [Authorize(Roles = "Admin")]
    public ActionResult AdminDashboard()
    {
      return View();
    }
    [Authorize(Roles = "Student")]
    public ActionResult StudentDashboard()
    {
      return View();
    }
    [Authorize(Roles = "Instructor")]
    public ActionResult InstructorDashboard()
    {
      return View();
    }
    [Authorize(Roles = "Employer")]
    public ActionResult EmployerDashboard()
    {
      return View();
    }
    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}