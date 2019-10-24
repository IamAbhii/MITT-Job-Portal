namespace Mitt_job_posting_portal.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class tblStudentNameAdded : DbMigration
  {
    public override void Up()
    {
      AddColumn("dbo.Students", "Name", c => c.String());
    }

    public override void Down()
    {
      DropColumn("dbo.Students", "Name");
    }
  }
}
