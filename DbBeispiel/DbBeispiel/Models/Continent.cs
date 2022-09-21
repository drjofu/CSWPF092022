using System;
using System.Collections.Generic;

#nullable disable

namespace DbBeispiel.Models
{
    public partial class Continent
    {
        public Continent()
        {
            Countries = new HashSet<Country>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string XmlId { get; set; }
        public int Area { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
