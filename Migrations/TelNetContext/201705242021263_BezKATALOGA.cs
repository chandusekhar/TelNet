namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BezKATALOGA : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.paket", "katalogID");
            DropColumn("dbo.usluga", "katalogID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.usluga", "katalogID", c => c.Int(nullable: false));
            AddColumn("dbo.paket", "katalogID", c => c.Int(nullable: false));
        }
    }
}
