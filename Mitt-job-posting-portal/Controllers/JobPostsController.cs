using Mitt_job_posting_portal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mitt_job_posting_portal.Controllers
{
    public class JobPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: JobPosts
        public ActionResult Index()
        {
            var JobPosts = db.JobPost.Include(j => j.Employer).ToList();
            return View(JobPosts);
        }

        public ActionResult Create()
        {

        }
    }
}