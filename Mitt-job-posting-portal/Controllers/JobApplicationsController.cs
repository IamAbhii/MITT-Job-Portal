using Microsoft.AspNet.Identity;
using Mitt_job_posting_portal.Models;
using Mitt_job_posting_portal.Models.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Mitt_job_posting_portal.Controllers
{
  public class JobApplicationsController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: JobApplications
    public ActionResult Index()
    {
      var jobApplication = db.JobApplication.Include(j => j.JobPosts);
      return View(jobApplication.ToList());
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
    public ActionResult Create([Bind(Include = "Id,Skills,Message,FilePath,JobPostId")] JobApplication jobApplication)
    {
      if (ModelState.IsValid)
      {
        jobApplication.StudentId = User.Identity.GetUserId();
        db.JobApplication.Add(jobApplication);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.JobPostId = new SelectList(db.JobPost, "Id", "Title", jobApplication.JobPostId);
      return View(jobApplication);
    }

    // GET: JobApplications/Edit/5
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
