namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BezPaketaUsluga2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.paket", "katalogID", "dbo.katalog");
            DropForeignKey("dbo.usluga", "katalogID", "dbo.katalog");
            DropIndex("dbo.paket", new[] { "katalogID" });
            DropIndex("dbo.usluga", new[] { "katalogID" });
            DropTable("dbo.katalog");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.katalog",
                c => new
                    {
                        katalogID = c.Int(nullable: false, identity: true),
                        nazivKataloga = c.String(),
                        opis = c.String(),
                    })
                .PrimaryKey(t => t.katalogID);
            
            CreateIndex("dbo.usluga", "katalogID");
            CreateIndex("dbo.paket", "katalogID");
            AddForeignKey("dbo.usluga", "katalogID", "dbo.katalog", "katalogID", cascadeDelete: true);
            AddForeignKey("dbo.paket", "katalogID", "dbo.katalog", "katalogID", cascadeDelete: true);
        }
    }
}
