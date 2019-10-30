namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedJoppostController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "InternshipEndtDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Rounds", "IntakeTitle");
            DropColumn("dbo.Rounds", "InternshipEndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rounds", "InternshipEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rounds", "IntakeTitle", c => c.String());
            DropColumn("dbo.Rounds", "InternshipEndtDate");
        }
    }
}
