using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcJQueryTemplate.Models
{
    public class IPLContext : DbContext
    {
        public DbSet<MvcJQueryTemplate.Models.Team> Teams { get; set; }
        public DbSet<MvcJQueryTemplate.Models.Player> Players { get; set; }
    }
}