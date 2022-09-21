using System;
using System.Collections.Generic;

#nullable disable

namespace DbBeispiel.Models
{
    public partial class Country
    {
        public int Id { get; set; }
        public string CarCode { get; set; }
        public double Area { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string Government { get; set; }
        public DateTime? IndependenceDate { get; set; }
       
    
        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }
    }
}
