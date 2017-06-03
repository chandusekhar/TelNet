namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NarudzbaPaket3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.narudzbaUsluga", name: "paketID", newName: "paket_paketID");
            RenameColumn(table: "dbo.narudzbaUsluga", name: "uslugaID", newName: "usluga_uslugaID");
            RenameIndex(table: "dbo.narudzbaUsluga", name: "IX_paketID", newName: "IX_paket_paketID");
            RenameIndex(table: "dbo.narudzbaUsluga", name: "IX_uslugaID", newName: "IX_usluga_uslugaID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.narudzbaUsluga", name: "IX_usluga_uslugaID", newName: "IX_uslugaID");
            RenameIndex(table: "dbo.narudzbaUsluga", name: "IX_paket_paketID", newName: "IX_paketID");
            RenameColumn(table: "dbo.narudzbaUsluga", name: "usluga_uslugaID", newName: "uslugaID");
            RenameColumn(table: "dbo.narudzbaUsluga", name: "paket_paketID", newName: "paketID");
        }
    }
}
