namespace Shop_Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Category = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 2000),
                        Price = c.Double(nullable: false),
                        BatchNo = c.String(nullable: false),
                        ManufactureDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        NetWt = c.Double(nullable: false),
                        WtUnit = c.String(),
                        Image = c.Binary(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
