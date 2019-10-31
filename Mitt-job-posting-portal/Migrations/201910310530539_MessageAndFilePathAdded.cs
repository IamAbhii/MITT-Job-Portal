namespace Mitt_job_posting_portal.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class MessageAndFilePathAdded : DbMigration
  {
    public override void Up()
    {
      AddColumn("dbo.JobApplications", "Message", c => c.String());
      AddColumn("dbo.JobApplications", "FilePath", c => c.String());
      DropColumn("dbo.JobApplications", "Title");
    }

    public override void Down()
    {
      AddColumn("dbo.JobApplications", "Title", c => c.String());
      DropColumn("dbo.JobApplications", "FilePath");
      DropColumn("dbo.JobApplications", "Message");
    }
  }
}
