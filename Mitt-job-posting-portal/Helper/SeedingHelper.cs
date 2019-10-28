using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mitt_job_posting_portal.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Mitt_job_posting_portal.Helper
{
  public class SeedingHelper
  {
    UserManager<User> userManager;
    RoleManager<IdentityRole> roleManager;
    ApplicationDbContext context;
    public SeedingHelper(ApplicationDbContext context)
    {
      this.context = context;
      userManager = new UserManager<User>(new UserStore<User>(context));
      roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
    }
    public void SeedCourses(string[] courses)
    {
      foreach (string course in courses)
      {
        context.Course.AddOrUpdate(c => c.Id, new Course() { Name = course });
      }
            context.SaveChanges();
    }
    public void SeedRoles(string[] roles)
    {
      foreach (string role in roles)
      {
        if (!roleManager.RoleExists(role))
        {
          var roleresult = roleManager.Create(new IdentityRole(role));
        }
      }
    }
    public void SeedAdmin(string name)
    {
      string userName = name.ToLower() + "@ip.com";
      string password = "Password-1";
      User user = userManager.FindByName(userName);
      if (user == null)
      {
        user = new User()
        {
          UserName = userName,
          Email = userName,
          EmailConfirmed = true
        };
        IdentityResult userResult = userManager.Create(user, password);
        if (userResult.Succeeded)
        {
          var result = userManager.AddToRole(user.Id, "Admin");
          context.Admin.AddOrUpdate(new Admin() { Name = name, User = user });
        }
      }
    }
    public void SeedInstructor(string name, string courseName)
    {
      string userName = name.ToLower() + "@ip.com";
      string password = "Password-1";
      var user = userManager.FindByName(userName);
      if (user == null)
      {
        user = new User()
        {
          UserName = userName,
          Email = userName,
          EmailConfirmed = true
        };
        IdentityResult userResult = userManager.Create(user, password);
        if (userResult.Succeeded)
        {
          var result = userManager.AddToRole(user.Id, "Instructor");
          context.Instructor.AddOrUpdate(new Instructor()
          {
            Name = name,
            Courses = new List<CourseInstructor>()
              {
                new CourseInstructor()
                {
                  Course = context.Course.Where(c=>c.Name==courseName).FirstOrDefault(), InstructorId = user.Id
                }
              },
            User = user
          });
        }
      }
    }
    public void SeedStudent(string name, string courseName)
    {
      string userName = name.ToLower() + "@ip.com";
      string password = "Password-1";
      var user = userManager.FindByName(userName);
      if (user == null)
      {
        user = new User()
        {
          UserName = userName,
          Email = userName,
          EmailConfirmed = true
        };
        IdentityResult userResult = userManager.Create(user, password);
        if (userResult.Succeeded)
        {
          var result = userManager.AddToRole(user.Id, "Student");
          context.Student.AddOrUpdate(new Student()
          {
            Name = name,
            BirthDate = new System.DateTime(1997, 01, 28),
            PreviousEducation = "N/A",
            PreviousEducationDetail = "N/A",
            CourseId = context.Course.Where(c => c.Name == courseName).First().Id,
            User = user
          });
        }
      }
    }
    public void SeedEmployer(string companyName)
    {
      string userName = companyName.ToLower() + "@ip.com";
      string password = "Password-1";
      var user = userManager.FindByName(userName);
      if (user == null)
      {
        user = new User()
        {
          UserName = userName,
          Email = userName,
          EmailConfirmed = true
        };
        IdentityResult userResult = userManager.Create(user, password);
        if (userResult.Succeeded)
        {
          var result = userManager.AddToRole(user.Id, "Employer");
          context.Employer.AddOrUpdate(new Employer()
          {
            CompanyName = companyName,
            CompanyDetails = "N/A",
            Companylinks = "N/A",
            EmailAdress = "N/A",
            User = user
          });
        }
      }
    }

  }
}