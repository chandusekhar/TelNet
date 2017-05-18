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
        public DbSet<katalog> Katalozi { get; set; }
        public DbSet<narudzbaUsluga> NarudzbeUsluga { get; set; }
        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<paket> Paketi { get; set; }
        public DbSet<paketUsluge> PaketiUsluga { get; set; }
        public DbSet<ponuda> Ponude { get; set; }
        public DbSet<ponudaProizvoda> PonudeProizvoda { get; set; }
        public DbSet<proizvod> Proizvodi { get; set; }
        public DbSet<rating> Ratinzi { get; set; }
        public DbSet<statusPonude> StatusiPonuda { get; set; }
        public DbSet<tip> Tipovi { get; set; }
        public DbSet<tipProizvoda> TipoviProizvoda { get; set; }
        public DbSet<usluga> Usluge { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

