namespace WorldWideFloors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectLocation = c.String(),
                        ProjectDescription = c.String(),
                        ProjectTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Glues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialType = c.String(),
                        MaterialAmount = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Price = c.Double(nullable: false),
                        AmountLeft = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectCollections",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        Collection_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.Collection_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.Collections", t => t.Collection_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.Collection_Id);
            
            CreateTable(
                "dbo.MaterialsGlues",
                c => new
                    {
                        Materials_Id = c.Int(nullable: false),
                        Glue_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Materials_Id, t.Glue_Id })
                .ForeignKey("dbo.Materials", t => t.Materials_Id, cascadeDelete: true)
                .ForeignKey("dbo.Glues", t => t.Glue_Id, cascadeDelete: true)
                .Index(t => t.Materials_Id)
                .Index(t => t.Glue_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterialsGlues", "Glue_Id", "dbo.Glues");
            DropForeignKey("dbo.MaterialsGlues", "Materials_Id", "dbo.Materials");
            DropForeignKey("dbo.ProjectCollections", "Collection_Id", "dbo.Collections");
            DropForeignKey("dbo.ProjectCollections", "Project_Id", "dbo.Projects");
            DropIndex("dbo.MaterialsGlues", new[] { "Glue_Id" });
            DropIndex("dbo.MaterialsGlues", new[] { "Materials_Id" });
            DropIndex("dbo.ProjectCollections", new[] { "Collection_Id" });
            DropIndex("dbo.ProjectCollections", new[] { "Project_Id" });
            DropTable("dbo.MaterialsGlues");
            DropTable("dbo.ProjectCollections");
            DropTable("dbo.Materials");
            DropTable("dbo.Glues");
            DropTable("dbo.Projects");
            DropTable("dbo.Collections");
        }
    }
}
