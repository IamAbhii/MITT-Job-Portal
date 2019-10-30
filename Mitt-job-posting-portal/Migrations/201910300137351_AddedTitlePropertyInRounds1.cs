namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitlePropertyInRounds1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "IntakeTitle", c => c.String());
            AddColumn("dbo.Rounds", "InternshipEndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Rounds", "Title");
            DropColumn("dbo.Rounds", "InternshipEndtDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rounds", "InternshipEndtDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rounds", "Title", c => c.String());
            DropColumn("dbo.Rounds", "InternshipEndDate");
            DropColumn("dbo.Rounds", "IntakeTitle");
        }
    }
}
