namespace DemotMail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PogodaDanes", "Temperatura", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PogodaDanes", "Temperatura", c => c.Int(nullable: false));
        }
    }
}
