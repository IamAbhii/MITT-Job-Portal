namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseInstructorExtraIdFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseInstructors", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseInstructors", "Instructor_UserId", "dbo.Instructors");
            DropIndex("dbo.CourseInstructors", new[] { "CourseId" });
            DropIndex("dbo.CourseInstructors", new[] { "Instructor_UserId" });
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_UserId = c.String(nullable: false, maxLength: 128),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_UserId, t.Course_Id })
                .ForeignKey("dbo.Instructors", t => t.Instructor_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Instructor_UserId)
                .Index(t => t.Course_Id);
            
            DropTable("dbo.CourseInstructors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseInstructors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        InstructorId = c.String(),
                        CourseId = c.Int(nullable: false),
                        Instructor_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.InstructorCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_UserId", "dbo.Instructors");
            DropIndex("dbo.InstructorCourses", new[] { "Course_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_UserId" });
            DropTable("dbo.InstructorCourses");
            CreateIndex("dbo.CourseInstructors", "Instructor_UserId");
            CreateIndex("dbo.CourseInstructors", "CourseId");
            AddForeignKey("dbo.CourseInstructors", "Instructor_UserId", "dbo.Instructors", "UserId");
            AddForeignKey("dbo.CourseInstructors", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
