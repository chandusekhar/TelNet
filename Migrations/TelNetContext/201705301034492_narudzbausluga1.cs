namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class narudzbausluga1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.narudzbaUsluga", "paketID", "dbo.paket");
            DropIndex("dbo.narudzbaUsluga", new[] { "paketID" });
            RenameColumn(table: "dbo.narudzbaUsluga", name: "paketID", newName: "paket_paketID");
            AlterColumn("dbo.narudzbaUsluga", "paket_paketID", c => c.Int());
            CreateIndex("dbo.narudzbaUsluga", "paket_paketID");
            AddForeignKey("dbo.narudzbaUsluga", "paket_paketID", "dbo.paket", "paketID");
            DropColumn("dbo.narudzbaUsluga", "datumOdobrenja");
        }
        
        public override void Down()
        {
            AddColumn("dbo.narudzbaUsluga", "datumOdobrenja", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.narudzbaUsluga", "paket_paketID", "dbo.paket");
            DropIndex("dbo.narudzbaUsluga", new[] { "paket_paketID" });
            AlterColumn("dbo.narudzbaUsluga", "paket_paketID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.narudzbaUsluga", name: "paket_paketID", newName: "paketID");
            CreateIndex("dbo.narudzbaUsluga", "paketID");
            AddForeignKey("dbo.narudzbaUsluga", "paketID", "dbo.paket", "paketID", cascadeDelete: true);
        }
    }
}
