namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewPropertiesToJobpost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "Skills", c => c.String());
            AddColumn("dbo.JobPosts", "Description", c => c.String());
            AddColumn("dbo.JobPosts", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPosts", "Location");
            DropColumn("dbo.JobPosts", "Description");
            DropColumn("dbo.JobPosts", "Skills");
        }
    }
}
