namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proizvodi : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Proizvod", new[] { "TipProizvodaID" });
            CreateIndex("dbo.Proizvod", "tipProizvodaID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Proizvod", new[] { "tipProizvodaID" });
            CreateIndex("dbo.Proizvod", "TipProizvodaID");
        }
    }
}
