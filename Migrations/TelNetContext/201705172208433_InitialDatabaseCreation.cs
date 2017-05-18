namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.dobavljac",
                c => new
                    {
                        dobavljacID = c.Int(nullable: false, identity: true),
                        naziv = c.String(),
                        adresa = c.String(),
                        ratingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.dobavljacID)
                .ForeignKey("dbo.rating", t => t.ratingID, cascadeDelete: true)
                .Index(t => t.ratingID);
            
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
                .PrimaryKey(t => t.ponudaID)
                .ForeignKey("dbo.dobavljac", t => t.dobavljacID, cascadeDelete: true)
                .ForeignKey("dbo.statusPonude", t => t.statusPonudeID, cascadeDelete: true)
                .Index(t => t.statusPonudeID)
                .Index(t => t.dobavljacID);
            
            CreateTable(
                "dbo.ponudaProizvoda",
                c => new
                    {
                        ponudaProizvodaID = c.Int(nullable: false, identity: true),
                        proizvodID = c.Int(nullable: false),
                        ponudaID = c.Int(nullable: false),
                        opis = c.String(),
                    })
                .PrimaryKey(t => t.ponudaProizvodaID)
                .ForeignKey("dbo.ponuda", t => t.ponudaID, cascadeDelete: true)
                .ForeignKey("dbo.proizvod", t => t.proizvodID, cascadeDelete: true)
                .Index(t => t.proizvodID)
                .Index(t => t.ponudaID);
            
            CreateTable(
                "dbo.proizvod",
                c => new
                    {
                        proizvodID = c.Int(nullable: false, identity: true),
                        kvalitetaProizvoda = c.Int(nullable: false),
                        cijenaProizvoda = c.Single(nullable: false),
                        opisProizvoda = c.String(),
                        tipProizvodaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.proizvodID)
                .ForeignKey("dbo.tipProizvoda", t => t.tipProizvodaID, cascadeDelete: true)
                .Index(t => t.tipProizvodaID);
            
            CreateTable(
                "dbo.tipProizvoda",
                c => new
                    {
                        tipProizvodaID = c.Int(nullable: false, identity: true),
                        nazivTipa = c.String(),
                        proizvodjac = c.String(),
                    })
                .PrimaryKey(t => t.tipProizvodaID);
            
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
                .PrimaryKey(t => t.statusPonudeID)
                .ForeignKey("dbo.Osoba", t => t.uposlenik_osobaID)
                .Index(t => t.uposlenik_osobaID);
            
            CreateTable(
                "dbo.narudzbaUsluga",
                c => new
                    {
                        narudzbaUslugaID = c.Int(nullable: false, identity: true),
                        periodUsluge = c.DateTime(nullable: false),
                        datumPocetkaUsluge = c.DateTime(nullable: false),
                        odobreno = c.Int(nullable: false),
                        datumOdobrenja = c.DateTime(nullable: false),
                        kupacID = c.Int(nullable: false),
                        statusUslugeID = c.Int(nullable: false),
                        UslugaID = c.Int(nullable: false),
                        paketID = c.Int(nullable: false),
                        kupac_osobaID = c.Int(),
                        statusUsluge_statusPonudeID = c.Int(),
                    })
                .PrimaryKey(t => t.narudzbaUslugaID)
                .ForeignKey("dbo.Osoba", t => t.kupac_osobaID)
                .ForeignKey("dbo.usluga", t => t.UslugaID, cascadeDelete: true)
                .ForeignKey("dbo.paket", t => t.paketID, cascadeDelete: true)
                .ForeignKey("dbo.statusPonude", t => t.statusUsluge_statusPonudeID)
                .Index(t => t.UslugaID)
                .Index(t => t.paketID)
                .Index(t => t.kupac_osobaID)
                .Index(t => t.statusUsluge_statusPonudeID);
            
            CreateTable(
                "dbo.Osoba",
                c => new
                    {
                        osobaID = c.Int(nullable: false, identity: true),
                        adresa = c.String(),
                        ime = c.String(),
                        prezime = c.String(),
                        username = c.String(),
                        password = c.String(),
                        datumRodjenja = c.DateTime(nullable: false),
                        telefon = c.String(),
                        tipID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.osobaID)
                .ForeignKey("dbo.tip", t => t.tipID, cascadeDelete: true)
                .Index(t => t.tipID);
            
            CreateTable(
                "dbo.tip",
                c => new
                    {
                        tipID = c.Int(nullable: false, identity: true),
                        nazivTipa = c.String(),
                    })
                .PrimaryKey(t => t.tipID);
            
            CreateTable(
                "dbo.paket",
                c => new
                    {
                        paketID = c.Int(nullable: false, identity: true),
                        nazivPaketa = c.String(),
                        cijenaPaketa = c.Single(nullable: false),
                        opis = c.String(),
                        katalogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.paketID)
                .ForeignKey("dbo.katalog", t => t.katalogID, cascadeDelete: true)
                .Index(t => t.katalogID);
            
            CreateTable(
                "dbo.katalog",
                c => new
                    {
                        katalogID = c.Int(nullable: false, identity: true),
                        nazivKataloga = c.String(),
                        opis = c.String(),
                    })
                .PrimaryKey(t => t.katalogID);
            
            CreateTable(
                "dbo.usluga",
                c => new
                    {
                        uslugaID = c.Int(nullable: false, identity: true),
                        nazivUsluge = c.String(),
                        tipUsluge = c.String(),
                        cijenaUsluge = c.Single(nullable: false),
                        opis = c.String(),
                        katalogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.uslugaID)
                .ForeignKey("dbo.katalog", t => t.katalogID, cascadeDelete: false)
                .Index(t => t.katalogID);
            
            CreateTable(
                "dbo.paketUsluge",
                c => new
                    {
                        paketUslugeID = c.Int(nullable: false, identity: true),
                        paketID = c.Int(nullable: false),
                        uslugaID = c.Int(nullable: false),
                        opisPaketaUsluge = c.String(),
                    })
                .PrimaryKey(t => t.paketUslugeID)
                .ForeignKey("dbo.paket", t => t.paketID, cascadeDelete: true)
                .ForeignKey("dbo.usluga", t => t.uslugaID, cascadeDelete: true)
                .Index(t => t.paketID)
                .Index(t => t.uslugaID);
            
            CreateTable(
                "dbo.rating",
                c => new
                    {
                        ratingID = c.Int(nullable: false, identity: true),
                        rate = c.Single(nullable: false),
                        overview = c.String(),
                        datumRatinga = c.DateTime(nullable: false),
                        datumIstekaRatinga = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ratingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.dobavljac", "ratingID", "dbo.rating");
            DropForeignKey("dbo.ponuda", "statusPonudeID", "dbo.statusPonude");
            DropForeignKey("dbo.narudzbaUsluga", "statusUsluge_statusPonudeID", "dbo.statusPonude");
            DropForeignKey("dbo.narudzbaUsluga", "paketID", "dbo.paket");
            DropForeignKey("dbo.paketUsluge", "uslugaID", "dbo.usluga");
            DropForeignKey("dbo.paketUsluge", "paketID", "dbo.paket");
            DropForeignKey("dbo.narudzbaUsluga", "UslugaID", "dbo.usluga");
            DropForeignKey("dbo.usluga", "katalogID", "dbo.katalog");
            DropForeignKey("dbo.paket", "katalogID", "dbo.katalog");
            DropForeignKey("dbo.Osoba", "tipID", "dbo.tip");
            DropForeignKey("dbo.statusPonude", "uposlenik_osobaID", "dbo.Osoba");
            DropForeignKey("dbo.narudzbaUsluga", "kupac_osobaID", "dbo.Osoba");
            DropForeignKey("dbo.proizvod", "tipProizvodaID", "dbo.tipProizvoda");
            DropForeignKey("dbo.ponudaProizvoda", "proizvodID", "dbo.proizvod");
            DropForeignKey("dbo.ponudaProizvoda", "ponudaID", "dbo.ponuda");
            DropForeignKey("dbo.ponuda", "dobavljacID", "dbo.dobavljac");
            DropIndex("dbo.paketUsluge", new[] { "uslugaID" });
            DropIndex("dbo.paketUsluge", new[] { "paketID" });
            DropIndex("dbo.usluga", new[] { "katalogID" });
            DropIndex("dbo.paket", new[] { "katalogID" });
            DropIndex("dbo.Osoba", new[] { "tipID" });
            DropIndex("dbo.narudzbaUsluga", new[] { "statusUsluge_statusPonudeID" });
            DropIndex("dbo.narudzbaUsluga", new[] { "kupac_osobaID" });
            DropIndex("dbo.narudzbaUsluga", new[] { "paketID" });
            DropIndex("dbo.narudzbaUsluga", new[] { "UslugaID" });
            DropIndex("dbo.statusPonude", new[] { "uposlenik_osobaID" });
            DropIndex("dbo.proizvod", new[] { "tipProizvodaID" });
            DropIndex("dbo.ponudaProizvoda", new[] { "ponudaID" });
            DropIndex("dbo.ponudaProizvoda", new[] { "proizvodID" });
            DropIndex("dbo.ponuda", new[] { "dobavljacID" });
            DropIndex("dbo.ponuda", new[] { "statusPonudeID" });
            DropIndex("dbo.dobavljac", new[] { "ratingID" });
            DropTable("dbo.rating");
            DropTable("dbo.paketUsluge");
            DropTable("dbo.usluga");
            DropTable("dbo.katalog");
            DropTable("dbo.paket");
            DropTable("dbo.tip");
            DropTable("dbo.Osoba");
            DropTable("dbo.narudzbaUsluga");
            DropTable("dbo.statusPonude");
            DropTable("dbo.tipProizvoda");
            DropTable("dbo.proizvod");
            DropTable("dbo.ponudaProizvoda");
            DropTable("dbo.ponuda");
            DropTable("dbo.dobavljac");
        }
    }
}
