using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TelNet.Models;

namespace telNet.Models
{
    public class narudzbaUsluga
    {
        public int narudzbaUslugaID { get; set; }
        public DateTime datumNarudzbe { get; set; }
        public string komentar { get; set; }
        public string odgovornaOsobaID { get; set; }
        public int uslugaID { get; set; }
        public virtual usluga usluga { get; set; }
       
    }
}