namespace XceedTaskEMEMP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLTask : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SelectAllEmployees",body: @"SELECT E.empName, E.phoneNumber, c.CountryName, e.age
            FROM dbo.Employees E, dbo.Countries C");
        }
        
        public override void Down()
        {
        }
    }
}
