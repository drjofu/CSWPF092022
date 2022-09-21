using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionBeispiel
{
  [AttributeUsage(AttributeTargets.Class)]
  class SeminarAttribute : Attribute
  {
    public int AnzahlTeilnehmer { get; set; }
    public string Thema { get; set; }

    public SeminarAttribute()
    {

    }

    public SeminarAttribute(int anzahlTeilnehmer, string thema)
    {
      AnzahlTeilnehmer = anzahlTeilnehmer;
      Thema = thema;
    }
  }
}
