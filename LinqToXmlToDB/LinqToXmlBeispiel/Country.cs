using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToXmlBeispiel
{
  class Country
  {
    public int Id { get; set; }

    public string CarCode { get; set; }
    public double Area { get; set; }
    public string Name { get; set; }
    public int Population { get; set; }
    public string Government { get; set; }
    public DateTime? IndependenceDate { get; set; }

  }
}
