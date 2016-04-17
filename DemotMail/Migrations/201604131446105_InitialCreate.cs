namespace DemotMail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Akcjas",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zadanies", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.KomunikatDanes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CzyWyswietlic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Akcjas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MailDanes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Akcjas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Zadanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Waruneks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zadanies", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PogodaDanes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Miasto = c.String(),
                        Temperatura = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Waruneks", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.StronaWwwDanes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Url = c.String(),
                        Tekst = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Waruneks", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Akcjas", "Id", "dbo.Zadanies");
            DropForeignKey("dbo.Waruneks", "Id", "dbo.Zadanies");
            DropForeignKey("dbo.StronaWwwDanes", "Id", "dbo.Waruneks");
            DropForeignKey("dbo.PogodaDanes", "Id", "dbo.Waruneks");
            DropForeignKey("dbo.MailDanes", "Id", "dbo.Akcjas");
            DropForeignKey("dbo.KomunikatDanes", "Id", "dbo.Akcjas");
            DropIndex("dbo.StronaWwwDanes", new[] { "Id" });
            DropIndex("dbo.PogodaDanes", new[] { "Id" });
            DropIndex("dbo.Waruneks", new[] { "Id" });
            DropIndex("dbo.MailDanes", new[] { "Id" });
            DropIndex("dbo.KomunikatDanes", new[] { "Id" });
            DropIndex("dbo.Akcjas", new[] { "Id" });
            DropTable("dbo.StronaWwwDanes");
            DropTable("dbo.PogodaDanes");
            DropTable("dbo.Waruneks");
            DropTable("dbo.Zadanies");
            DropTable("dbo.MailDanes");
            DropTable("dbo.KomunikatDanes");
            DropTable("dbo.Akcjas");
        }
    }
}
