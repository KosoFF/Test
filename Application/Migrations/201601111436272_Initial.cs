namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FoundationYear = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.DateTime(nullable: false),
                        ModelManufacturer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ModelManufacturer_Id)
                .Index(t => t.ModelManufacturer_Id);
            
            CreateTable(
                "dbo.Things",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Serial = c.Int(nullable: false),
                        model_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.model_Id)
                .Index(t => t.model_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Things", "model_Id", "dbo.Models");
            DropForeignKey("dbo.Models", "ModelManufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.Things", new[] { "model_Id" });
            DropIndex("dbo.Models", new[] { "ModelManufacturer_Id" });
            DropTable("dbo.Things");
            DropTable("dbo.Models");
            DropTable("dbo.Manufacturers");
        }
    }
}
