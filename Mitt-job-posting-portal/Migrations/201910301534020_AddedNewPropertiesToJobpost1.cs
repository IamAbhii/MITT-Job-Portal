namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewPropertiesToJobpost1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobPosts", "EmployerId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobPosts", "EmployerId", c => c.Int(nullable: false));
        }
    }
}
