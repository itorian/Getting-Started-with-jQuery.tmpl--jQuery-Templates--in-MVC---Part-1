using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcJQueryTemplate.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int TotalScored { get; set; }
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}