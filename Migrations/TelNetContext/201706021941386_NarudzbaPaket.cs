namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NarudzbaPaket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.narudzbaUsluga", "paket_paketID", "dbo.paket");
            DropIndex("dbo.narudzbaUsluga", new[] { "paket_paketID" });
            RenameColumn(table: "dbo.narudzbaUsluga", name: "paket_paketID", newName: "paketID");
            AlterColumn("dbo.narudzbaUsluga", "paketID", c => c.Int(nullable: false));
            CreateIndex("dbo.narudzbaUsluga", "paketID");
            AddForeignKey("dbo.narudzbaUsluga", "paketID", "dbo.paket", "paketID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.narudzbaUsluga", "paketID", "dbo.paket");
            DropIndex("dbo.narudzbaUsluga", new[] { "paketID" });
            AlterColumn("dbo.narudzbaUsluga", "paketID", c => c.Int());
            RenameColumn(table: "dbo.narudzbaUsluga", name: "paketID", newName: "paket_paketID");
            CreateIndex("dbo.narudzbaUsluga", "paket_paketID");
            AddForeignKey("dbo.narudzbaUsluga", "paket_paketID", "dbo.paket", "paketID");
        }
    }
}
