using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class proizvod
    {
        public proizvod()
        {
            this.ponudeProizvoda = new HashSet<ponudaProizvoda>();
        }

        public int proizvodID { get; set; }
        public int kvalitetaProizvoda { get; set; }
        public float cijenaProizvoda { get; set; }
        public string opisProizvoda { get; set; }

        public int tipProizvodaID { get; set; }

        public tipProizvoda tipProizvoda { get; set; }

        public ICollection<ponudaProizvoda> ponudeProizvoda { get; set; }
    }
}