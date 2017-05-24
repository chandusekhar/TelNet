using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class paket
    {
        public paket()
        {
            this.Usluge = new HashSet<usluga>();
            this.narudzbeUsluga = new HashSet<narudzbaUsluga>();
        }

        public int paketID { get; set; }
        public string nazivPaketa { get; set; }
        public float cijenaPaketa { get; set; }
        public string opis { get; set; }

      
     
        public virtual ICollection<usluga> Usluge { get; set; }
        public ICollection<narudzbaUsluga> narudzbeUsluga { get; set; }
    }
}