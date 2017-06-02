using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class Osoba
    {
        public Osoba()
        {
           this.narudzbeUsluga = new HashSet<narudzbaUsluga>();
        }

        public int osobaID { get; set; }
        public string adresa { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string telefon { get; set; }

        public int tipID { get; set; }

        public virtual tip tip { get; set; }
  public ICollection<narudzbaUsluga> narudzbeUsluga { get; set; }
    }
}