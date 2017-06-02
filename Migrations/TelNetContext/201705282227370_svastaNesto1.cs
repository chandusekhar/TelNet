namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class svastaNesto1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Proizvod", "Dobavljac_dobavljacID", "dbo.dobavljac");
            DropForeignKey("dbo.Proizvod", "TipProizvoda_tipProizvodaID", "dbo.tipProizvoda");
            DropIndex("dbo.Proizvod", new[] { "Dobavljac_dobavljacID" });
            DropIndex("dbo.Proizvod", new[] { "TipProizvoda_tipProizvodaID" });
            RenameColumn(table: "dbo.Proizvod", name: "Dobavljac_dobavljacID", newName: "dobavljacID");
            RenameColumn(table: "dbo.Proizvod", name: "TipProizvoda_tipProizvodaID", newName: "TipProizvodaID");
            AlterColumn("dbo.Proizvod", "dobavljacID", c => c.Int(nullable: false));
            AlterColumn("dbo.Proizvod", "TipProizvodaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Proizvod", "TipProizvodaID");
            CreateIndex("dbo.Proizvod", "dobavljacID");
            AddForeignKey("dbo.Proizvod", "dobavljacID", "dbo.dobavljac", "dobavljacID", cascadeDelete: true);
            AddForeignKey("dbo.Proizvod", "TipProizvodaID", "dbo.tipProizvoda", "tipProizvodaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proizvod", "TipProizvodaID", "dbo.tipProizvoda");
            DropForeignKey("dbo.Proizvod", "dobavljacID", "dbo.dobavljac");
            DropIndex("dbo.Proizvod", new[] { "dobavljacID" });
            DropIndex("dbo.Proizvod", new[] { "TipProizvodaID" });
            AlterColumn("dbo.Proizvod", "TipProizvodaID", c => c.Int());
            AlterColumn("dbo.Proizvod", "dobavljacID", c => c.Int());
            RenameColumn(table: "dbo.Proizvod", name: "TipProizvodaID", newName: "TipProizvoda_tipProizvodaID");
            RenameColumn(table: "dbo.Proizvod", name: "dobavljacID", newName: "Dobavljac_dobavljacID");
            CreateIndex("dbo.Proizvod", "TipProizvoda_tipProizvodaID");
            CreateIndex("dbo.Proizvod", "Dobavljac_dobavljacID");
            AddForeignKey("dbo.Proizvod", "TipProizvoda_tipProizvodaID", "dbo.tipProizvoda", "tipProizvodaID");
            AddForeignKey("dbo.Proizvod", "Dobavljac_dobavljacID", "dbo.dobavljac", "dobavljacID");
        }
    }
}
