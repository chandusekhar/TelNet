namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dobavljaciRatings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.dobavljac", "ratingKvalitet", c => c.Int(nullable: false));
            AddColumn("dbo.dobavljac", "ratingBrzinaIsporuke", c => c.Int(nullable: false));
            AddColumn("dbo.dobavljac", "ratingKomunikacija", c => c.Int(nullable: false));
            AddColumn("dbo.dobavljac", "ratingUkupno", c => c.Int(nullable: false));
            DropColumn("dbo.dobavljac", "ratingID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.dobavljac", "ratingID", c => c.Int(nullable: false));
            DropColumn("dbo.dobavljac", "ratingUkupno");
            DropColumn("dbo.dobavljac", "ratingKomunikacija");
            DropColumn("dbo.dobavljac", "ratingBrzinaIsporuke");
            DropColumn("dbo.dobavljac", "ratingKvalitet");
        }
    }
}
