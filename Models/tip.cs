using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class tip
    {
        public tip()
        {
            this.Osobe = new HashSet<Osoba>();
        }

        public int tipID { get; set; }
        public string nazivTipa { get; set; }

        public ICollection<Osoba> Osobe { get; set; }
    }
}