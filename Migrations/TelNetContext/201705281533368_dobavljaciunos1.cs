namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dobavljaciunos1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DobavljacUnos", "dobavljacID", "dbo.dobavljac");
            DropIndex("dbo.DobavljacUnos", new[] { "dobavljacID" });
            RenameColumn(table: "dbo.DobavljacUnos", name: "dobavljacID", newName: "dobavljac_dobavljacID");
            AlterColumn("dbo.DobavljacUnos", "dobavljac_dobavljacID", c => c.Int());
            CreateIndex("dbo.DobavljacUnos", "dobavljac_dobavljacID");
            AddForeignKey("dbo.DobavljacUnos", "dobavljac_dobavljacID", "dbo.dobavljac", "dobavljacID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DobavljacUnos", "dobavljac_dobavljacID", "dbo.dobavljac");
            DropIndex("dbo.DobavljacUnos", new[] { "dobavljac_dobavljacID" });
            AlterColumn("dbo.DobavljacUnos", "dobavljac_dobavljacID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.DobavljacUnos", name: "dobavljac_dobavljacID", newName: "dobavljacID");
            CreateIndex("dbo.DobavljacUnos", "dobavljacID");
            AddForeignKey("dbo.DobavljacUnos", "dobavljacID", "dbo.dobavljac", "dobavljacID", cascadeDelete: true);
        }
    }
}
