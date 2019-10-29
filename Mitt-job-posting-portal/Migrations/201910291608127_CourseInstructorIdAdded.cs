namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseInstructorIdAdded : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CourseInstructors");
            AddColumn("dbo.CourseInstructors", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CourseInstructors", "InstructorId", c => c.String());
            AddPrimaryKey("dbo.CourseInstructors", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CourseInstructors");
            AlterColumn("dbo.CourseInstructors", "InstructorId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.CourseInstructors", "id");
            AddPrimaryKey("dbo.CourseInstructors", new[] { "InstructorId", "CourseId" });
        }
    }
}
