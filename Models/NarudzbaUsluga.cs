using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class narudzbaUsluga
    {
        public int narudzbaUslugaID { get; set; }
        public DateTime periodUsluge { get; set; }
        public DateTime datumPocetkaUsluge { get; set; }
        public int odobreno { get; set; }
        public DateTime datumOdobrenja { get; set; }

        public int kupacID { get; set; }
        public int statusUslugeID { get; set; }
        public int UslugaID { get; set; }
        public int paketID { get; set; }

        public virtual Osoba kupac { get; set; }
        public virtual statusPonude statusUsluge { get; set; }
        public virtual usluga usluga { get; set; }
        public virtual paket paket { get; set; }
    }
}