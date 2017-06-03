using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using telNet.Models;
using TelNet.Models;
namespace TelNet.DAL
{
    public class TelNetContext:DbContext
    {
        public TelNetContext() : base("TelNetContext")
        {
        }
        public DbSet<dobavljac> Dobavljaci { get; set; }
        public DbSet<narudzbaUsluga> NarudzbeUsluga { get; set; }
        public DbSet<NarudzbaPaket> NarudzbePaketa { get; set; }

        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<paket> Paketi { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<rating> Ratinzi { get; set; }
         public DbSet<tip> Tipovi { get; set; }
        public DbSet<tipProizvoda> TipoviProizvoda { get; set; }
        public DbSet<usluga> Usluge { get; set; }

        public DbSet<DobavljacUnos> UnosiDobavljaca { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
         
            modelBuilder.Entity<narudzbaUsluga>().HasOptional(m => m.usluga).WithMany(m => m.narudzbeUsluga).HasForeignKey(m => m.uslugaID);
            modelBuilder.Entity<NarudzbaPaket>().HasOptional(m => m.paket).WithMany(m => m.narudzbePaketa).HasForeignKey(m => m.paketID);

            modelBuilder.Entity<paket>()
                .HasMany(c => c.Usluge).WithMany(i => i.Paketi)
                .Map(t => t.MapLeftKey("paketID")
                    .MapRightKey("uslugaID")
                    .ToTable("PaketiUsluga"));
        
    }
    }
}

