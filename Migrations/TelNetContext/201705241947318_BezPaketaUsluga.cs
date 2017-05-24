namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BezPaketaUsluga : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.paketUsluge", "paketID", "dbo.paket");
            DropForeignKey("dbo.paketUsluge", "uslugaID", "dbo.usluga");
            DropIndex("dbo.paketUsluge", new[] { "paketID" });
            DropIndex("dbo.paketUsluge", new[] { "uslugaID" });
            CreateTable(
                "dbo.uslugapaket",
                c => new
                    {
                        usluga_uslugaID = c.Int(nullable: false),
                        paket_paketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.usluga_uslugaID, t.paket_paketID })
                .ForeignKey("dbo.usluga", t => t.usluga_uslugaID, cascadeDelete: true)
                .ForeignKey("dbo.paket", t => t.paket_paketID, cascadeDelete: true)
                .Index(t => t.usluga_uslugaID)
                .Index(t => t.paket_paketID);
            
            DropTable("dbo.paketUsluge");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.paketUsluge",
                c => new
                    {
                        paketUslugeID = c.Int(nullable: false, identity: true),
                        paketID = c.Int(nullable: false),
                        uslugaID = c.Int(nullable: false),
                        opisPaketaUsluge = c.String(),
                    })
                .PrimaryKey(t => t.paketUslugeID);
            
            DropForeignKey("dbo.uslugapaket", "paket_paketID", "dbo.paket");
            DropForeignKey("dbo.uslugapaket", "usluga_uslugaID", "dbo.usluga");
            DropIndex("dbo.uslugapaket", new[] { "paket_paketID" });
            DropIndex("dbo.uslugapaket", new[] { "usluga_uslugaID" });
            DropTable("dbo.uslugapaket");
            CreateIndex("dbo.paketUsluge", "uslugaID");
            CreateIndex("dbo.paketUsluge", "paketID");
            AddForeignKey("dbo.paketUsluge", "uslugaID", "dbo.usluga", "uslugaID", cascadeDelete: true);
            AddForeignKey("dbo.paketUsluge", "paketID", "dbo.paket", "paketID", cascadeDelete: true);
        }
    }
}
