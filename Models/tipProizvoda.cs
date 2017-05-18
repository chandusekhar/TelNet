using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class tipProizvoda
    {
        public tipProizvoda()
        {
            this.proizvodi = new HashSet<proizvod>();
        }

        public int tipProizvodaID { get; set; }
        public string nazivTipa { get; set; }
        public string proizvodjac { get; set; }

        public ICollection<proizvod> proizvodi { get; set; }
    }
}