namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblStudentBirthDateAndEducationDetailAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "PreviousEducation", c => c.String());
            AddColumn("dbo.Students", "PreviousEducationDetail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "PreviousEducationDetail");
            DropColumn("dbo.Students", "PreviousEducation");
            DropColumn("dbo.Students", "BirthDate");
        }
    }
}
