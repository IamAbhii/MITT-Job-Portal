using Mitt_job_posting_portal.Models;
using System.Collections.Generic;

namespace Mitt_job_posting_portal.Helper
{
  public class CourseHelper
  {
    ApplicationDbContext db;
    public CourseHelper(ApplicationDbContext db)
    {
      this.db = db;
    }
    public List<Course> GetCourses(int[] courseIds)
    {
      var result = new List<Course>();
      foreach (int id in courseIds)
      {
        result.Add(db.Course.Find(id));
      }
      return result;
    }
  }
}