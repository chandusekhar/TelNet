using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class ponudaProizvoda
    {
        public int ponudaProizvodaID { get; set; }
        public int proizvodID { get; set; }
        public int ponudaID { get; set; }
        public string opis { get; set; }

        public proizvod proizvod { get; set; }
        public ponuda ponuda { get; set; }

    }
}