using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using telNet.Models;

namespace TelNet.DAL
{
    public class TelNetInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TelNetContext>
    {

        protected override void Seed(TelNetContext context)
        {
        }
    }
}