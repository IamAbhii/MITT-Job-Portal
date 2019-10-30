using Mitt_job_posting_portal.Helper;
using Mitt_job_posting_portal.Models;
using System.Web.Mvc;

namespace Mitt_job_posting_portal.Controllers
{
  public class EmployerController : Controller
  {
    ApplicationDbContext db;
    EmployerHelper employerHelper;
    public EmployerController()
    {
      this.db = new ApplicationDbContext();
      employerHelper = new EmployerHelper(db);
    }
    // GET: Employer
    public ActionResult GetAllEmployer()
    {
      var allEmployer = employerHelper.GetAllEmployer();
      return View(allEmployer);
    }
  }
}