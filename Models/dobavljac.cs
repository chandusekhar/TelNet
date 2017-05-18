using System;
using System.Collections.Generic;
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

        public int ratingID { get; set; }

        public virtual ICollection<rating> ratings { get; set; }

        public virtual ICollection<ponuda> ponude { get; set; }
    }
}