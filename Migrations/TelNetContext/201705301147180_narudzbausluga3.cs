namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class narudzbausluga3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.narudzbaUsluga", "UslugaID", "dbo.usluga");
            DropIndex("dbo.narudzbaUsluga", new[] { "UslugaID" });
            RenameColumn(table: "dbo.narudzbaUsluga", name: "UslugaID", newName: "usluga_uslugaID");
            AlterColumn("dbo.narudzbaUsluga", "usluga_uslugaID", c => c.Int());
            CreateIndex("dbo.narudzbaUsluga", "usluga_uslugaID");
            AddForeignKey("dbo.narudzbaUsluga", "usluga_uslugaID", "dbo.usluga", "uslugaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.narudzbaUsluga", "usluga_uslugaID", "dbo.usluga");
            DropIndex("dbo.narudzbaUsluga", new[] { "usluga_uslugaID" });
            AlterColumn("dbo.narudzbaUsluga", "usluga_uslugaID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.narudzbaUsluga", name: "usluga_uslugaID", newName: "UslugaID");
            CreateIndex("dbo.narudzbaUsluga", "UslugaID");
            AddForeignKey("dbo.narudzbaUsluga", "UslugaID", "dbo.usluga", "uslugaID", cascadeDelete: true);
        }
    }
}
