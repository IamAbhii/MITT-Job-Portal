namespace Mitt_job_posting_portal.Migrations
{
  using Microsoft.AspNet.Identity;
  using Microsoft.AspNet.Identity.EntityFramework;
  using Mitt_job_posting_portal.Helper;
  using Mitt_job_posting_portal.Models;
  using System.Data.Entity.Migrations;

  internal sealed class Configuration : DbMigrationsConfiguration<Mitt_job_posting_portal.Models.ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(Mitt_job_posting_portal.Models.ApplicationDbContext context)
    {
      SeedingHelper seedingHelper = new SeedingHelper(context);
      var userManager = new UserManager<User>(new UserStore<User>(context));
      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

      //Add Courses
      var courses = new string[] { "Software Developer", "Networking", "Early Childhood Education", "Culinary" };
      seedingHelper.SeedCourses(courses);

      //Add roles
      var roles = new string[] { "Admin", "Instructor", "Student", "Employer" };
      seedingHelper.SeedRoles(roles);

      //add Admin
      seedingHelper.SeedAdmin("Admin");

      //add Instructor
      seedingHelper.SeedInstructor("Instructor1", "Software Developer");
      seedingHelper.SeedInstructor("Instructor2", "Networking");

      //add Students
      seedingHelper.SeedStudent("SDStudent1", "Software Developer");
      seedingHelper.SeedStudent("SDStudent2", "Software Developer");
      seedingHelper.SeedStudent("SDStudent3", "Software Developer");
      seedingHelper.SeedStudent("SDStudent4", "Software Developer");
      seedingHelper.SeedStudent("NStudent1", "Networking");
      seedingHelper.SeedStudent("NStudent2", "Networking");
      seedingHelper.SeedStudent("NStudent3", "Networking");
      seedingHelper.SeedStudent("NStudent4", "Networking");

      //add Employer
      seedingHelper.SeedEmployer("Infosys");
      seedingHelper.SeedEmployer("MITT");
      seedingHelper.SeedEmployer("Ibex");
      seedingHelper.SeedEmployer("COFW");
      seedingHelper.SeedEmployer("IndianTech");

    }
  }
}
