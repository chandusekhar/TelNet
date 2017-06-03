namespace TelNet.Migrations.TelNetContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NarudzbaKupac : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.narudzbaUsluga", "imePrezimeKupca", c => c.String());
            AddColumn("dbo.narudzbaUsluga", "adresaKupca", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.narudzbaUsluga", "adresaKupca");
            DropColumn("dbo.narudzbaUsluga", "imePrezimeKupca");
        }
    }
}
