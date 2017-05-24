using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelNet.ViewModels
{
    public class IzabraneUsluge
    {
        public int uslugaID { get; set; }
        public string naziv { get; set; }
        public bool Izabrana { get; set; }
    }
}