using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class statusPonude
    {
        public statusPonude()
        {
            this.ponude = new HashSet<ponuda>();
            this.narudzbeUsluga = new HashSet<narudzbaUsluga>();
        }

        public int statusPonudeID { get; set; }
        public string nazivStatusa { get; set; }
        public DateTime datumStatusa { get; set; }

        public int uposlenikID { get; set; }
        public virtual Osoba uposlenik { get; set; }

        public ICollection<ponuda> ponude { get; set; }
        public ICollection<narudzbaUsluga> narudzbeUsluga { get; set; }
    }
}