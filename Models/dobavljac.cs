using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class dobavljac
    {
        public dobavljac()
        {
            this.ponude = new HashSet<ponuda>();
        }
        public int dobavljacID { get; set; }
        public string naziv { get; set; }
        public string adresa { get; set; }
        [Range(1, 5)]
        public int ratingKvalitet { get; set; }
        [Range(1, 5)]
        public int ratingBrzinaIsporuke { get; set; }
        [Range(1, 5)]
        public int ratingKomunikacija { get; set; }
        public int ratingUkupno { get; set; }

        public virtual ICollection<rating> ratings { get; set; }

        public virtual ICollection<ponuda> ponude { get; set; }
    }
}