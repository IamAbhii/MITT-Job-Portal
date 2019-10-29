namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserExtraIdFix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "JobApplication_Id" });
            AddColumn("dbo.Students", "JobApplication_Id", c => c.Int());
            CreateIndex("dbo.Students", "JobApplication_Id");
            DropColumn("dbo.AspNetUsers", "JobApplication_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "JobApplication_Id", c => c.Int());
            DropIndex("dbo.Students", new[] { "JobApplication_Id" });
            DropColumn("dbo.Students", "JobApplication_Id");
            CreateIndex("dbo.AspNetUsers", "JobApplication_Id");
        }
    }
}
