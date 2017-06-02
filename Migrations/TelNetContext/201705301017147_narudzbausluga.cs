namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class narudzbausluga : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.narudzbaUsluga", name: "kupac_osobaID", newName: "Osoba_osobaID");
            RenameIndex(table: "dbo.narudzbaUsluga", name: "IX_kupac_osobaID", newName: "IX_Osoba_osobaID");
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.narudzbaUsluga", "datumNarudzbe", c => c.DateTime(nullable: false));
            AddColumn("dbo.narudzbaUsluga", "komentar", c => c.String());
            AddColumn("dbo.narudzbaUsluga", "odgovornaOsobaID", c => c.String());
            DropColumn("dbo.narudzbaUsluga", "periodUsluge");
            DropColumn("dbo.narudzbaUsluga", "datumPocetkaUsluge");
            DropColumn("dbo.narudzbaUsluga", "odobreno");
            DropColumn("dbo.narudzbaUsluga", "kupacID");
            DropColumn("dbo.narudzbaUsluga", "statusUslugeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.narudzbaUsluga", "statusUslugeID", c => c.Int(nullable: false));
            AddColumn("dbo.narudzbaUsluga", "kupacID", c => c.Int(nullable: false));
            AddColumn("dbo.narudzbaUsluga", "odobreno", c => c.Int(nullable: false));
            AddColumn("dbo.narudzbaUsluga", "datumPocetkaUsluge", c => c.DateTime(nullable: false));
            AddColumn("dbo.narudzbaUsluga", "periodUsluge", c => c.DateTime(nullable: false));
            DropColumn("dbo.narudzbaUsluga", "odgovornaOsobaID");
            DropColumn("dbo.narudzbaUsluga", "komentar");
            DropColumn("dbo.narudzbaUsluga", "datumNarudzbe");
            DropTable("dbo.User");
            RenameIndex(table: "dbo.narudzbaUsluga", name: "IX_Osoba_osobaID", newName: "IX_kupac_osobaID");
            RenameColumn(table: "dbo.narudzbaUsluga", name: "Osoba_osobaID", newName: "kupac_osobaID");
        }
    }
}
