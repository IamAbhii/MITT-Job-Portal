using Microsoft.AspNet.Identity;
using Mitt_job_posting_portal.Helper;
using Mitt_job_posting_portal.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Mitt_job_posting_portal.Controllers
{
  [Authorize]
  public class JobPostsController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();
    AccountHelper userManager;
    JobPostHelper jobPostHelper;
    public JobPostsController()
    {
      this.userManager = new AccountHelper(db);
      this.jobPostHelper = new JobPostHelper(db);
    }
    // GET: JobPosts
    public ActionResult Index()
    {
      var userId = User.Identity.GetUserId();
      var userRole = userManager.GetUserRole(userId);
      List<JobPost> jobPosts = new List<JobPost>();
      if (userRole == "Employer")
      {
        jobPosts = db.JobPost.Where(jp => jp.EmployerId == userId).Include(j => j.Rounds).ToList();
        return View(jobPosts);
      }
      else if (userRole == "Student")
      {
        var user = userManager.GetStudent(userId);
        jobPosts = db.JobPost.Where(jp => jp.CourseId == user.CourseId).Include(j => j.Rounds).ToList();
        return View(jobPosts);
      }
      else if (userRole == "Instructor")
      {
        jobPosts = jobPostHelper.GetAllJobPostForInstructor(userId);
        return View(jobPosts);
      }
      else
      {
        jobPosts = db.JobPost.ToList();
        return View(jobPosts);
      }
    }

    // GET: JobPosts/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      JobPost jobPost = db.JobPost.Find(id);
      if (jobPost == null)
      {
        return HttpNotFound();
      }
      return View(jobPost);
    }

    // GET: JobPosts/Create
    [Authorize(Roles = "Employer")]
    public ActionResult Create()
    {
      ViewBag.RoundId = new SelectList(db.Round, "Id", "IntakeTitle");
      ViewBag.CourseId = new SelectList(db.Course, "Id", "Name");
      return View();
    }

    // POST: JobPosts/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    // Employer Validation only
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(JobPost jobPost)
    {
      AccountHelper userManager = new AccountHelper(db);
      if (ModelState.IsValid)
      {
        var UserId = User.Identity.GetUserId();
        var user = db.Employer.Find(UserId);
        jobPost.Employer = user;
        db.JobPost.Add(jobPost);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.RoundId = new SelectList(db.Round, "Id", "IntakeTitle", jobPost.RoundId);
      return View(jobPost);
    }

    // GET: JobPosts/Edit/5
    [Authorize(Roles = "Employer")]
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      JobPost jobPost = db.JobPost.Find(id);
      if (jobPost == null)
      {
        return HttpNotFound();
      }
      ViewBag.RoundId = new SelectList(db.Round, "Id", "IntakeTitle", jobPost.RoundId);
      ViewBag.CourseId = new SelectList(db.Course, "Id", "Name", jobPost.CourseId);
      return View(jobPost);
    }

    // POST: JobPosts/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(JobPost jobPost)
    {
      if (ModelState.IsValid)
      {
        var jobpostInDb = db.JobPost.Find(jobPost.Id);
        jobpostInDb.Title = jobPost.Title;
        jobpostInDb.Location = jobPost.Location;
        jobpostInDb.Description = jobPost.Description;
        jobpostInDb.RoundId = jobPost.RoundId;
        jobpostInDb.CourseId = jobPost.CourseId;
        jobpostInDb.Skills = jobPost.Skills;

        //db.Entry(jobPost).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.RoundId = new SelectList(db.Round, "Id", "IntakeTitle", jobPost.RoundId);
      return View(jobPost);
    }

    // GET: JobPosts/Delete/5
    [Authorize(Roles = "Employer, Admin")]

    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      JobPost jobPost = db.JobPost.Find(id);
      if (jobPost == null)
      {
        return HttpNotFound();
      }
      return View(jobPost);
    }

    // POST: JobPosts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      JobPost jobPost = db.JobPost.Find(id);
      db.JobPost.Remove(jobPost);
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
