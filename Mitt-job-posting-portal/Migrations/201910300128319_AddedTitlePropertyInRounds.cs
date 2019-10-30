namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitlePropertyInRounds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rounds", "Title");
        }
    }
}
