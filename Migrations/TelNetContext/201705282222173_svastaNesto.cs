namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class svastaNesto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ponuda", "dobavljacID", "dbo.dobavljac");
            DropForeignKey("dbo.ponudaProizvoda", "ponudaID", "dbo.ponuda");
            DropForeignKey("dbo.ponudaProizvoda", "proizvodID", "dbo.proizvod");
            DropForeignKey("dbo.statusPonude", "uposlenik_osobaID", "dbo.Osoba");
            DropForeignKey("dbo.narudzbaUsluga", "statusUsluge_statusPonudeID", "dbo.statusPonude");
            DropForeignKey("dbo.ponuda", "statusPonudeID", "dbo.statusPonude");
            DropForeignKey("dbo.proizvod", "tipProizvodaID", "dbo.tipProizvoda");
            DropIndex("dbo.ponuda", new[] { "statusPonudeID" });
            DropIndex("dbo.ponuda", new[] { "dobavljacID" });
            DropIndex("dbo.ponudaProizvoda", new[] { "proizvodID" });
            DropIndex("dbo.ponudaProizvoda", new[] { "ponudaID" });
            DropIndex("dbo.Proizvod", new[] { "tipProizvodaID" });
            DropIndex("dbo.Proizvod", new[] { "dobavljac_dobavljacID" });
            DropIndex("dbo.statusPonude", new[] { "uposlenik_osobaID" });
            DropIndex("dbo.narudzbaUsluga", new[] { "statusUsluge_statusPonudeID" });
            RenameColumn(table: "dbo.Proizvod", name: "tipProizvodaID", newName: "TipProizvoda_tipProizvodaID");
            AlterColumn("dbo.Proizvod", "cijenaProizvoda", c => c.Double(nullable: false));
            AlterColumn("dbo.Proizvod", "TipProizvoda_tipProizvodaID", c => c.Int());
            CreateIndex("dbo.Proizvod", "Dobavljac_dobavljacID");
            CreateIndex("dbo.Proizvod", "TipProizvoda_tipProizvodaID");
            AddForeignKey("dbo.Proizvod", "TipProizvoda_tipProizvodaID", "dbo.tipProizvoda", "tipProizvodaID");
            DropColumn("dbo.narudzbaUsluga", "statusUsluge_statusPonudeID");
            DropColumn("dbo.Proizvod", "kvalitetaProizvoda");
            DropTable("dbo.ponuda");
            DropTable("dbo.ponudaProizvoda");
            DropTable("dbo.statusPonude");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.statusPonude",
                c => new
                    {
                        statusPonudeID = c.Int(nullable: false, identity: true),
                        nazivStatusa = c.String(),
                        datumStatusa = c.DateTime(nullable: false),
                        uposlenikID = c.Int(nullable: false),
                        uposlenik_osobaID = c.Int(),
                    })
                .PrimaryKey(t => t.statusPonudeID);
            
            CreateTable(
                "dbo.ponudaProizvoda",
                c => new
                    {
                        ponudaProizvodaID = c.Int(nullable: false, identity: true),
                        proizvodID = c.Int(nullable: false),
                        ponudaID = c.Int(nullable: false),
                        opis = c.String(),
                    })
                .PrimaryKey(t => t.ponudaProizvodaID);
            
            CreateTable(
                "dbo.ponuda",
                c => new
                    {
                        ponudaID = c.Int(nullable: false, identity: true),
                        ponudaProizvoda = c.Int(nullable: false),
                        ukupnaCijena = c.Single(nullable: false),
                        datumIsporuke = c.DateTime(nullable: false),
                        statusPonudeID = c.Int(nullable: false),
                        dobavljacID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ponudaID);
            
            AddColumn("dbo.Proizvod", "kvalitetaProizvoda", c => c.Int(nullable: false));
            AddColumn("dbo.narudzbaUsluga", "statusUsluge_statusPonudeID", c => c.Int());
            DropForeignKey("dbo.Proizvod", "TipProizvoda_tipProizvodaID", "dbo.tipProizvoda");
            DropIndex("dbo.Proizvod", new[] { "TipProizvoda_tipProizvodaID" });
            DropIndex("dbo.Proizvod", new[] { "Dobavljac_dobavljacID" });
            AlterColumn("dbo.Proizvod", "TipProizvoda_tipProizvodaID", c => c.Int(nullable: false));
            AlterColumn("dbo.Proizvod", "cijenaProizvoda", c => c.Single(nullable: false));
            RenameColumn(table: "dbo.Proizvod", name: "TipProizvoda_tipProizvodaID", newName: "tipProizvodaID");
            CreateIndex("dbo.narudzbaUsluga", "statusUsluge_statusPonudeID");
            CreateIndex("dbo.statusPonude", "uposlenik_osobaID");
            CreateIndex("dbo.Proizvod", "dobavljac_dobavljacID");
            CreateIndex("dbo.Proizvod", "tipProizvodaID");
            CreateIndex("dbo.ponudaProizvoda", "ponudaID");
            CreateIndex("dbo.ponudaProizvoda", "proizvodID");
            CreateIndex("dbo.ponuda", "dobavljacID");
            CreateIndex("dbo.ponuda", "statusPonudeID");
            AddForeignKey("dbo.proizvod", "tipProizvodaID", "dbo.tipProizvoda", "tipProizvodaID", cascadeDelete: true);
            AddForeignKey("dbo.ponuda", "statusPonudeID", "dbo.statusPonude", "statusPonudeID", cascadeDelete: true);
            AddForeignKey("dbo.narudzbaUsluga", "statusUsluge_statusPonudeID", "dbo.statusPonude", "statusPonudeID");
            AddForeignKey("dbo.statusPonude", "uposlenik_osobaID", "dbo.Osoba", "osobaID");
            AddForeignKey("dbo.ponudaProizvoda", "proizvodID", "dbo.proizvod", "proizvodID", cascadeDelete: true);
            AddForeignKey("dbo.ponudaProizvoda", "ponudaID", "dbo.ponuda", "ponudaID", cascadeDelete: true);
            AddForeignKey("dbo.ponuda", "dobavljacID", "dbo.dobavljac", "dobavljacID", cascadeDelete: true);
        }
    }
}
