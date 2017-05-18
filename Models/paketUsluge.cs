using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class paketUsluge
    {
        public int paketUslugeID { get; set; }
        public int paketID { get; set; }
        public int uslugaID { get; set; }
        public string opisPaketaUsluge { get; set; }

        public virtual paket paket { get; set; }
        public virtual usluga usluga { get; set; }

    }
}