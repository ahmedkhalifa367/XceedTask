namespace XceedTaskEMEMP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        empID = c.Int(nullable: false, identity: true),
                        empName = c.String(nullable: false, maxLength: 30),
                        age = c.Int(),
                        phoneNumber = c.String(nullable: false),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.empID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CountryID", "dbo.Countries");
            DropIndex("dbo.Employees", new[] { "CountryID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Countries");
        }
    }
}
