namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class narudzbausluga4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.narudzbaUsluga", "usluga_uslugaID", "dbo.usluga");
            DropIndex("dbo.narudzbaUsluga", new[] { "usluga_uslugaID" });
            RenameColumn(table: "dbo.narudzbaUsluga", name: "usluga_uslugaID", newName: "uslugaID");
            AlterColumn("dbo.narudzbaUsluga", "uslugaID", c => c.Int(nullable: false));
            CreateIndex("dbo.narudzbaUsluga", "uslugaID");
            AddForeignKey("dbo.narudzbaUsluga", "uslugaID", "dbo.usluga", "uslugaID", cascadeDelete: true);
            DropTable("dbo.User");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.narudzbaUsluga", "uslugaID", "dbo.usluga");
            DropIndex("dbo.narudzbaUsluga", new[] { "uslugaID" });
            AlterColumn("dbo.narudzbaUsluga", "uslugaID", c => c.Int());
            RenameColumn(table: "dbo.narudzbaUsluga", name: "uslugaID", newName: "usluga_uslugaID");
            CreateIndex("dbo.narudzbaUsluga", "usluga_uslugaID");
            AddForeignKey("dbo.narudzbaUsluga", "usluga_uslugaID", "dbo.usluga", "uslugaID");
        }
    }
}
