namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentRealtionFixedInJobApplication : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "JobApplication_Id", "dbo.JobApplications");
            DropIndex("dbo.Students", new[] { "JobApplication_Id" });
            AddColumn("dbo.JobApplications", "StudentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.JobApplications", "StudentId");
            AddForeignKey("dbo.JobApplications", "StudentId", "dbo.Students", "UserId");
            DropColumn("dbo.Students", "JobApplication_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "JobApplication_Id", c => c.Int());
            DropForeignKey("dbo.JobApplications", "StudentId", "dbo.Students");
            DropIndex("dbo.JobApplications", new[] { "StudentId" });
            DropColumn("dbo.JobApplications", "StudentId");
            CreateIndex("dbo.Students", "JobApplication_Id");
            AddForeignKey("dbo.Students", "JobApplication_Id", "dbo.JobApplications", "Id");
        }
    }
}
