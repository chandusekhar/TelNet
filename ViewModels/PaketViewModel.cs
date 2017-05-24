using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using telNet.Models;

namespace TelNet.ViewModels
{
    public class PaketViewModel
    {
        public IEnumerable<paket> Paketi { get; set; }
        public IEnumerable<usluga> Usluge { get; set; }
       
    }
}
