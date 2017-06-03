namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NarudzbaPaket6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.narudzbaUsluga", "paketID", "dbo.paket");
            DropIndex("dbo.narudzbaUsluga", new[] { "paketID" });
            CreateTable(
                "dbo.NarudzbaPaket",
                c => new
                    {
                        NarudzbaPaketID = c.Int(nullable: false, identity: true),
                        datumNarudzbe = c.DateTime(nullable: false),
                        komentar = c.String(),
                        imePrezimeKupca = c.String(),
                        adresaKupca = c.String(),
                        odgovornaOsobaID = c.String(),
                        paketID = c.Int(),
                    })
                .PrimaryKey(t => t.NarudzbaPaketID)
                .ForeignKey("dbo.paket", t => t.paketID)
                .Index(t => t.paketID);
            
            DropColumn("dbo.narudzbaUsluga", "paketID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.narudzbaUsluga", "paketID", c => c.Int());
            DropForeignKey("dbo.NarudzbaPaket", "paketID", "dbo.paket");
            DropIndex("dbo.NarudzbaPaket", new[] { "paketID" });
            DropTable("dbo.NarudzbaPaket");
            CreateIndex("dbo.narudzbaUsluga", "paketID");
            AddForeignKey("dbo.narudzbaUsluga", "paketID", "dbo.paket", "paketID");
        }
    }
}
