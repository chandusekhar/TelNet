namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DobavljaciRatinzi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.dobavljac", "ratingID", "dbo.rating");
            DropIndex("dbo.dobavljac", new[] { "ratingID" });
            CreateTable(
                "dbo.ratingdobavljac",
                c => new
                    {
                        rating_ratingID = c.Int(nullable: false),
                        dobavljac_dobavljacID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.rating_ratingID, t.dobavljac_dobavljacID })
                .ForeignKey("dbo.rating", t => t.rating_ratingID, cascadeDelete: true)
                .ForeignKey("dbo.dobavljac", t => t.dobavljac_dobavljacID, cascadeDelete: true)
                .Index(t => t.rating_ratingID)
                .Index(t => t.dobavljac_dobavljacID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ratingdobavljac", "dobavljac_dobavljacID", "dbo.dobavljac");
            DropForeignKey("dbo.ratingdobavljac", "rating_ratingID", "dbo.rating");
            DropIndex("dbo.ratingdobavljac", new[] { "dobavljac_dobavljacID" });
            DropIndex("dbo.ratingdobavljac", new[] { "rating_ratingID" });
            DropTable("dbo.ratingdobavljac");
            CreateIndex("dbo.dobavljac", "ratingID");
            AddForeignKey("dbo.dobavljac", "ratingID", "dbo.rating", "ratingID", cascadeDelete: true);
        }
    }
}
