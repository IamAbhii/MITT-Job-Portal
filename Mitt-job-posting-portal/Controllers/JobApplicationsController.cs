using Microsoft.AspNet.Identity;
using Mitt_job_posting_portal.Helper;
using Mitt_job_posting_portal.Models;
using Mitt_job_posting_portal.Models.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mitt_job_posting_portal.Controllers
{
  [Authorize]
  public class JobApplicationsController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();
    AttachmentHelper attachmentHelper;
    public JobApplicationsController()
    {
      attachmentHelper = new AttachmentHelper();
    }

    // GET: JobApplications
    public ActionResult Index()
    {
      var jobApplication = db.JobApplication.Include(j => j.JobPosts);
      return View(jobApplication.ToList());
    }
    [Authorize(Roles = "Admin, Employer, Instructor")]
    public ActionResult ViewAllJobApplication(int id)
    {
      var jobApplication = db.JobApplication.Where(application => application.JobPostId == id).Include(j => j.JobPosts);
      return View("Index", jobApplication.ToList());
    }

    public ActionResult Download(int id)
    {
      var path = db.JobApplication.Find(id).FilePath.ToString();
      var mime = MimeMapping.GetMimeMapping(path);
      return File(path, mime);
    }
    // GET: JobApplications/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      JobApplication jobApplication = db.JobApplication.Find(id);
      if (jobApplication == null)
      {
        return HttpNotFound();
      }
      return View(jobApplication);
    }

    // GET: JobApplications/Create
    [Authorize(Roles = "Student")]
    public ActionResult Create(int id)
    {
      var viewModel = new ApplicationViewModel()
      {
        JobPostId = id,
      };
      return View(viewModel);
    }

    // POST: JobApplications/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ApplicationViewModel jobApplication)
    {
      if (ModelState.IsValid)
      {
        var filePath = attachmentHelper.saveFile(jobApplication.File);
        var jobApplicationToAdd = new JobApplication()
        {
          StudentId = User.Identity.GetUserId(),
          FilePath = filePath,
          JobPostId = jobApplication.JobPostId,
          Message = jobApplication.Message,
          Skills = jobApplication.Skills,
        };
        db.JobApplication.Add(jobApplicationToAdd);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.JobPostId = new SelectList(db.JobPost, "Id", "Title", jobApplication.JobPostId);
      return View(jobApplication);
    }

    // GET: JobApplications/Edit/5
    [Authorize(Roles = "Student")]
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      JobApplication jobApplication = db.JobApplication.Find(id);
      if (jobApplication == null)
      {
        return HttpNotFound();
      }
      ViewBag.JobPostId = new SelectList(db.JobPost, "Id", "Title", jobApplication.JobPostId);
      return View(jobApplication);
    }

    // POST: JobApplications/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Skills,Message,FilePath,JobPostId")] JobApplication jobApplication)
    {
      if (ModelState.IsValid)
      {
        db.Entry(jobApplication).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.JobPostId = new SelectList(db.JobPost, "Id", "Title", jobApplication.JobPostId);
      return View(jobApplication);
    }

    // GET: JobApplications/Delete/5
    [Authorize(Roles = "Student")]
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      JobApplication jobApplication = db.JobApplication.Find(id);
      if (jobApplication == null)
      {
        return HttpNotFound();
      }
      return View(jobApplication);
    }

    // POST: JobApplications/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      JobApplication jobApplication = db.JobApplication.Find(id);
      db.JobApplication.Remove(jobApplication);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
