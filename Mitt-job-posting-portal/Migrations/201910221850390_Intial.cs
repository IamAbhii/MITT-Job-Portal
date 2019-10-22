namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InternshipStartDate = c.DateTime(nullable: false),
                        InternshipEndDate = c.DateTime(nullable: false),
                        CourseStartDate = c.DateTime(nullable: false),
                        CourseEndeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseInstructors",
                c => new
                    {
                        InstructorId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        Instructor_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.InstructorId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.Instructor_UserId)
                .Index(t => t.CourseId)
                .Index(t => t.Instructor_UserId);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        JobApplication_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobApplications", t => t.JobApplication_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.JobApplication_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CompanyName = c.String(),
                        EmailAdress = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.JobPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        RoundId = c.Int(nullable: false),
                        EmployerId = c.Int(nullable: false),
                        Employer_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.Employer_UserId)
                .ForeignKey("dbo.Rounds", t => t.RoundId, cascadeDelete: true)
                .Index(t => t.RoundId)
                .Index(t => t.Employer_UserId);
            
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Skills = c.String(),
                        JobPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobPosts", t => t.JobPostId, cascadeDelete: true)
                .Index(t => t.JobPostId);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InternshipEndtDate = c.DateTime(nullable: false),
                        InternshipStartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Employers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobPosts", "RoundId", "dbo.Rounds");
            DropForeignKey("dbo.AspNetUsers", "JobApplication_Id", "dbo.JobApplications");
            DropForeignKey("dbo.JobApplications", "JobPostId", "dbo.JobPosts");
            DropForeignKey("dbo.JobPosts", "Employer_UserId", "dbo.Employers");
            DropForeignKey("dbo.Students", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Instructors", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseInstructors", "Instructor_UserId", "dbo.Instructors");
            DropForeignKey("dbo.CourseInstructors", "CourseId", "dbo.Courses");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.JobApplications", new[] { "JobPostId" });
            DropIndex("dbo.JobPosts", new[] { "Employer_UserId" });
            DropIndex("dbo.JobPosts", new[] { "RoundId" });
            DropIndex("dbo.Employers", new[] { "UserId" });
            DropIndex("dbo.Students", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "JobApplication_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Instructors", new[] { "UserId" });
            DropIndex("dbo.CourseInstructors", new[] { "Instructor_UserId" });
            DropIndex("dbo.CourseInstructors", new[] { "CourseId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rounds");
            DropTable("dbo.JobApplications");
            DropTable("dbo.JobPosts");
            DropTable("dbo.Employers");
            DropTable("dbo.Students");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Instructors");
            DropTable("dbo.CourseInstructors");
            DropTable("dbo.Courses");
        }
    }
}
