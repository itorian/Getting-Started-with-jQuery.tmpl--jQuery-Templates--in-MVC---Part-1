using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcJQueryTemplate.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        [DataType(DataType.Date)]
        public DateTime Founded { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}