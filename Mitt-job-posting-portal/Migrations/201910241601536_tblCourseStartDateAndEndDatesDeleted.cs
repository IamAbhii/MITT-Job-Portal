namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblCourseStartDateAndEndDatesDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "InternshipStartDate");
            DropColumn("dbo.Courses", "InternshipEndDate");
            DropColumn("dbo.Courses", "CourseStartDate");
            DropColumn("dbo.Courses", "CourseEndeDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CourseEndeDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "CourseStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "InternshipEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "InternshipStartDate", c => c.DateTime(nullable: false));
        }
    }
}
