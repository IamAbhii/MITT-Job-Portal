using Mitt_job_posting_portal.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mitt_job_posting_portal.Helper
{
  public class JobPostHelper
  {
    ApplicationDbContext db;
    public JobPostHelper(ApplicationDbContext db)
    {
      this.db = db;
    }
    public List<JobPost> GetAllJobPostForInstructor(string instructorId)
    {
      List<JobPost> jobPosts = new List<JobPost>();
      var instructor = db.Instructor.Find(instructorId);
      foreach (var course in instructor.Courses)
      {
        var jobPostsForSpecificCourse = db.JobPost.Where(jp => jp.CourseId == course.Id).ToList();
        jobPosts.AddRange(jobPostsForSpecificCourse);
      }
      return jobPosts;
    }
  }
}