using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using telNet.Models;

namespace TelNet.Models
{
    public class Proizvod
    {
        public int proizvodID { get; set; }
        public double cijenaProizvoda { get; set; }
        public string opisProizvoda { get; set; }
        
        public int tipProizvodaID { get; set; }
        public int dobavljacID { get; set; }
        public  tipProizvoda TipProizvoda {get;set;}
        public dobavljac Dobavljac { get; set; }

    }
}