namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dobavljaciRokVazenja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.dobavljac", "RokVazenjaRatinga", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.dobavljac", "RokVazenjaRatinga");
        }
    }
}
