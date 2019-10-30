using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mitt_job_posting_portal.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mitt_job_posting_portal.Helper
{
  public class StudentHelper
  {
    UserManager<User> userManager;
    RoleManager<IdentityRole> roleManager;
    ApplicationDbContext context;

    public StudentHelper(ApplicationDbContext context)
    {
      this.context = context;
      userManager = new UserManager<User>(new UserStore<User>(context));
      roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
    }
    public List<Student> GetAllStudent()
    {
      var students = context.Student.ToList();
      return students;
    }
  }
}