namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobpostModelModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobPosts", "CourseId");
            AddForeignKey("dbo.JobPosts", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobPosts", "CourseId", "dbo.Courses");
            DropIndex("dbo.JobPosts", new[] { "CourseId" });
            DropColumn("dbo.JobPosts", "CourseId");
        }
    }
}
