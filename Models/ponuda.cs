using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class ponuda
    {
        public ponuda()
        {
            this.ponudeProizvoda = new HashSet<ponudaProizvoda>();
        }

        public int ponudaID { get; set; }
        public int ponudaProizvoda { get; set; }
        public float ukupnaCijena { get; set; }
        public DateTime datumIsporuke { get; set; }

        public int statusPonudeID { get; set; }
        public int dobavljacID { get; set; }

        public virtual dobavljac dobavljac { get; set; }
        public virtual statusPonude statusPonude { get; set; }

        public ICollection<ponudaProizvoda> ponudeProizvoda { get; set; }
    }
}