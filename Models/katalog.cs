using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class katalog
    {
        public katalog()
        {
            this.usluge = new HashSet<usluga>();
            this.paketi = new HashSet<paket>();
        }

        public int katalogID { get; set; }
        public string nazivKataloga { get; set; }
        public string opis { get; set; }

        public ICollection<usluga> usluge { get; set; }
        public ICollection<paket> paketi { get; set; }
    }
}