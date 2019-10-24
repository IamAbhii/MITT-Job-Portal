namespace Mitt_job_posting_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblEmployeeCompanyDetailsCompanylinksAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employers", "CompanyDetails", c => c.String());
            AddColumn("dbo.Employers", "Companylinks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employers", "Companylinks");
            DropColumn("dbo.Employers", "CompanyDetails");
        }
    }
}
