using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class usluga
    {
        public usluga()
        {
            this.Paketi = new List<paket>();
            this.narudzbeUsluga = new List<narudzbaUsluga>();
        }

        public int uslugaID { get; set; }
        public string nazivUsluge { get; set; }
        public string tipUsluge { get; set; }
        public float cijenaUsluge { get; set; }
        public string opis { get; set; }

        public virtual ICollection<paket> Paketi { get; set; }

        public virtual ICollection<narudzbaUsluga> narudzbeUsluga { get; set; }
    }
}