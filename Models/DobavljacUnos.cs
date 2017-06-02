using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using telNet.Models;

namespace TelNet.Models
{
    public class DobavljacUnos
    {
        public int dobavljacUnosID { get; set; }
        public string komentar { get; set; }
        public DateTime datumUnosa { get; set; }
        public DateTime rokVazenja {get;set;}
        [Range(1, 5)]
        public int ratingKvalitet { get; set; }
        [Range(1, 5)]
        public int ratingBrzinaIsporuke { get; set; }
        [Range(1, 5)]
        public int ratingKomunikacija { get; set; }
        public int ratingUkupno { get; set; }
        public virtual dobavljac dobavljac { get; set; }
        public DobavljacUnos()
        {

        }
        public DobavljacUnos(string komentar, DateTime datumUnosa, DateTime rokVazenja, int ratingKvalitet, int ratingBrzinaIsporuke, int ratingKomunikacija, int ratingUkupno, dobavljac Dobavljac)
        {
            this.komentar = komentar;
            this.datumUnosa = datumUnosa;
            this.rokVazenja = rokVazenja;
            this.ratingBrzinaIsporuke = ratingBrzinaIsporuke;
            this.ratingKomunikacija = ratingKomunikacija;
            this.ratingKvalitet = ratingKvalitet;
            this.ratingUkupno = ratingUkupno;
            this.dobavljac = Dobavljac;
        }
    }
}