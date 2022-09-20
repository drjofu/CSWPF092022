using System;
using System.Collections.Generic;
using System.Linq;

namespace InterfacesUndDelegates
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Konto> konten = new List<Konto>() 
      {
        new Konto { Kontonummer = 77, Inhaber = "Goofy", Saldo = 346 },
        new Konto { Kontonummer = 78, Inhaber = "Daisy", Saldo = 666 }
      };

      konten.Add(new Konto { Kontonummer = 1, Inhaber = "Dagobert", Saldo = 99999999999 });
      konten.Add(new Konto { Kontonummer = 4, Inhaber = "Donald", Saldo = -3456345 });
      konten.Add(new Konto { Kontonummer = 51, Inhaber = "Micky", Saldo = 66464 });
      konten.Add(new Konto { Kontonummer = 101, Inhaber = "Tick", Saldo = 100.5 });
      konten.Add(new Konto { Kontonummer = 104, Inhaber = "Trick", Saldo = 100.1 });
      konten.Add(new Konto { Kontonummer = 103, Inhaber = "Track", Saldo = 100.4 });
      konten.Add(new Konto { Kontonummer = 111, Inhaber = "Panzerknacker", Saldo = -35353 });

      //foreach (Konto konto in konten)
      //{
      //  Console.WriteLine(konto);
      //}

      //Console.WriteLine("******************");

      //IEnumerator<Konto>kontoEnumerator = ((IEnumerable<Konto>)konten).GetEnumerator();
      //while (kontoEnumerator.MoveNext())
      //{
      //  Konto k = kontoEnumerator.Current;
      //  Console.WriteLine(k);
      //}

      //Erweiterungsmethoden.Ausgeben(konten, "Ausgangsliste");

      //new int[] { 1, 324, 2, 2, 562 }.Ausgeben();
      //"Hallo".Ausgeben().Ausgeben("2").Ausgeben("3");

      konten.Ausgeben("als Erweiterungsmethode");

      konten.Sort();
      konten.Ausgeben("Sortiert...");

      Comparison<Konto> vergleichsmethode = new Comparison<Konto>(VergleicheNachSaldo);
      konten.Sort(vergleichsmethode);
      konten.Ausgeben("via Comparison");

      konten.Sort(VergleicheNachSaldo);
      konten.Ausgeben("dito");

      // Anonyme Methode (C# 2.0)
      konten.Sort(delegate (Konto k1, Konto k2)
      {
        return k1.Inhaber.CompareTo(k2.Inhaber);
      });
      konten.Ausgeben("via anonymer Methode");

      // Lambda-Ausdruck (C#3.0)
      konten.Sort((k1, k2) =>         // goes to
      {
        return k1.Kontonummer.CompareTo(k2.Kontonummer);
      });
      konten.Ausgeben("via Lambda-Expression");

      konten.Sort((k1, k2) => k2.Inhaber.CompareTo(k1.Inhaber));
      konten.Ausgeben("Lambda");

      Konto dagobert = konten.Find(k => k.Inhaber == "Dagobert");
      Console.WriteLine($"Gefunden: {dagobert}");

      konten.FindAll(k => k.Inhaber.StartsWith("T")).Ausgeben("Alle mit 'T'");

      var erg = konten
            .Where(k => k.Saldo > 0)
            .OrderBy(k => k.Inhaber)
            .Select(k => new { k.Inhaber, k.Saldo });  // anonymer Typ

      erg.Ausgeben("LINQ extensio methods");
      erg.Ausgeben("LINQ extensio methods");

      dagobert = konten
        .Where(k => k.Inhaber.StartsWith("Da"))
        .SingleOrDefault();
      Console.WriteLine($"Gefunden: {dagobert}");

      dagobert = konten
        .SingleOrDefault(k => k.Inhaber.StartsWith("Da"));
      Console.WriteLine($"Gefunden: {dagobert}");

      var gruppen = konten.GroupBy(k => k.Inhaber[0]);
      foreach (var gruppe in gruppen)
      {
        Console.WriteLine(gruppe.Key);
        Console.WriteLine($"Saldensumme: {gruppe.Sum(k => k.Saldo)}");
        foreach (var k in gruppe)
        {
          Console.WriteLine($"  {k.Inhaber}");
        }
      }

      Console.WriteLine("***************************************");

      // Language integrated query (LINQ) C#3.0
      var erg2 = from k in konten
                 where k.Saldo > 0
                 orderby k.Inhaber descending
                 select new { k.Inhaber, k.Saldo };

      erg2.Ausgeben();


      //var x = new { Name = "Petra", Alter = 66 };
      //Console.WriteLine(x.Name);
      //Console.WriteLine(x.Alter);
      //Console.WriteLine(x);
      ////x.Name = "nein";

      //var t = "Hallo";
      ////t = 17;

      //Console.WriteLine(x.GetType().Name);
      Console.ReadLine();
    }

    static int VergleicheNachSaldo(Konto k1, Konto k2)
    {
      return k1.Saldo.CompareTo(k2.Saldo);
    }
  }
}
