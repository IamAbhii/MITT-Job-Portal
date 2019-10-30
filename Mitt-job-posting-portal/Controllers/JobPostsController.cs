using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mitt_job_posting_portal.Models;
using Mitt_job_posting_portal.Helper;
using Microsoft.AspNet.Identity;

namespace Mitt_job_posting_portal.Controllers
{
    public class JobPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        AccountHelper userManager;
        public JobPostsController()
        {
            this.userManager=new AccountHelper(db);
        }
        // GET: JobPosts
        public ActionResult Index()
        {
            var jobPost = db.JobPost.Include(j => j.Rounds);
            return View(jobPost.ToList());
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
            return View(jobPost);
        }

        // POST: JobPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,RoundId,EmployerId,Skills,Description,Location")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoundId = new SelectList(db.Round, "Id", "IntakeTitle", jobPost.RoundId);
            return View(jobPost);
        }

        // GET: JobPosts/Delete/5
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
