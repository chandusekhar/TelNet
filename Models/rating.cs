using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telNet.Models
{
    public class rating
    {
        public rating()
        {
            this.dobavljaci = new HashSet<dobavljac>();
        }

        public int ratingID { get; set; }
        public float rate { get; set; }
        public string overview { get; set; }
        public DateTime datumRatinga { get; set; }
        public DateTime datumIstekaRatinga { get; set; }

        public virtual ICollection<dobavljac> dobavljaci { get; set; }
    }
}