namespace Mitt_job_posting_portal.Migrations
{
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
      context.Course.AddOrUpdate(c => c.Id,
        new Course() { Name = "Software Developer" },
        new Course() { Name = "Networking" },
        new Course() { Name = "Early Childhood Education" },
        new Course() { Name = "Culinary" });
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data.
    }
  }
}
