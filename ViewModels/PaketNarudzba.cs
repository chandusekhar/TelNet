using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using telNet.Models;

namespace TelNet.ViewModels
{
    public class PaketNarudzba
    {
        public paket paket { get; set; }
        public string komentar { get; set; }
        public DateTime datum { get; set; }
        public string imePrezimeKupca { get; set; }
        public string adresaKupca { get; set; }
    }
}