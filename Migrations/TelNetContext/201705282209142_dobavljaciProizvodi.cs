namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dobavljaciProizvodi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.proizvod", "dobavljac_dobavljacID", c => c.Int());
            CreateIndex("dbo.proizvod", "dobavljac_dobavljacID");
            AddForeignKey("dbo.proizvod", "dobavljac_dobavljacID", "dbo.dobavljac", "dobavljacID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.proizvod", "dobavljac_dobavljacID", "dbo.dobavljac");
            DropIndex("dbo.proizvod", new[] { "dobavljac_dobavljacID" });
            DropColumn("dbo.proizvod", "dobavljac_dobavljacID");
        }
    }
}
