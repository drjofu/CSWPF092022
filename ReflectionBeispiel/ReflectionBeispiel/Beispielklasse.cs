using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionBeispiel
{
  //[Seminar(3,"C#")]
  [Seminar(AnzahlTeilnehmer = 3, Thema = "C#")]
  class Beispielklasse
  {
    private string geheim = "ganz geheim";

    private int zahl = 42;

    [Description("tolle Zahl")]
    [Category("Seminar")]
    public int Zahl
    {
      get { return zahl; }
      set { zahl = value; }
    }

    [Description("nur so zur Info")]
    [Category("Seminar")]
    public string Info { get; set; } = "nur zur Info";

    public int TuWas(string wasdenn) { Console.WriteLine("Tut was: " + wasdenn); return 42; }

  }
}
