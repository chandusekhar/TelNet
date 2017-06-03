using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using telNet.Models;

namespace TelNet.Models
{
    public class NarudzbaPaket
    {
        public int NarudzbaPaketID { get; set; }
        public DateTime datumNarudzbe { get; set; }
        public string komentar { get; set; }
        public string imePrezimeKupca { get; set; }
        public string adresaKupca { get; set; }
        public string odgovornaOsobaID { get; set; }

        public int? paketID { get; set; }
        public virtual paket paket { get; set; }
    }
}