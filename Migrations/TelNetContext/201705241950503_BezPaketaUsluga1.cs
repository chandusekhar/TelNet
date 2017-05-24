namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BezPaketaUsluga1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.uslugapaket", newName: "PaketiUsluga");
            RenameColumn(table: "dbo.PaketiUsluga", name: "usluga_uslugaID", newName: "uslugaID");
            RenameColumn(table: "dbo.PaketiUsluga", name: "paket_paketID", newName: "paketID");
            RenameIndex(table: "dbo.PaketiUsluga", name: "IX_paket_paketID", newName: "IX_paketID");
            RenameIndex(table: "dbo.PaketiUsluga", name: "IX_usluga_uslugaID", newName: "IX_uslugaID");
            DropPrimaryKey("dbo.PaketiUsluga");
            AddPrimaryKey("dbo.PaketiUsluga", new[] { "paketID", "uslugaID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PaketiUsluga");
            AddPrimaryKey("dbo.PaketiUsluga", new[] { "usluga_uslugaID", "paket_paketID" });
            RenameIndex(table: "dbo.PaketiUsluga", name: "IX_uslugaID", newName: "IX_usluga_uslugaID");
            RenameIndex(table: "dbo.PaketiUsluga", name: "IX_paketID", newName: "IX_paket_paketID");
            RenameColumn(table: "dbo.PaketiUsluga", name: "paketID", newName: "paket_paketID");
            RenameColumn(table: "dbo.PaketiUsluga", name: "uslugaID", newName: "usluga_uslugaID");
            RenameTable(name: "dbo.PaketiUsluga", newName: "uslugapaket");
        }
    }
}
