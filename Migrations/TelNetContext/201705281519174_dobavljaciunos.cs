namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dobavljaciunos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DobavljacUnos",
                c => new
                    {
                        dobavljacUnosID = c.Int(nullable: false, identity: true),
                        komentar = c.String(),
                        datumUnosa = c.DateTime(nullable: false),
                        rokVazenja = c.DateTime(nullable: false),
                        ratingKvalitet = c.Int(nullable: false),
                        ratingBrzinaIsporuke = c.Int(nullable: false),
                        ratingKomunikacija = c.Int(nullable: false),
                        ratingUkupno = c.Int(nullable: false),
                        dobavljacID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.dobavljacUnosID)
                .ForeignKey("dbo.dobavljac", t => t.dobavljacID, cascadeDelete: true)
                .Index(t => t.dobavljacID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DobavljacUnos", "dobavljacID", "dbo.dobavljac");
            DropIndex("dbo.DobavljacUnos", new[] { "dobavljacID" });
            DropTable("dbo.DobavljacUnos");
        }
    }
}
