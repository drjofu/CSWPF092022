using System;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {

      TuWas("abc");
      TuWas("abc", "C# lernen", 45);
      TuWas("abc", null, 11);
      //TuWas("geht nicht", null);
      TuWas("abc", "VB vergessen");
      TuWas("abc", wieLange: 30);
      TuWas(wieLange: 60, wasDenn: "C# lernen", fest: "abc");

      string t = "100";
      // int i = int.Parse(t);

      //int i;
      if (int.TryParse(t, out int i))
        Console.WriteLine($"Zahl ist: {i}" );
      else
        Console.WriteLine($"{t} ist keine gültige Zahl");

      Console.WriteLine(i);



      DateTime jetzt = DateTime.Now;
      Console.WriteLine($"{jetzt:dddd, dd.MM.yy}");

      Console.WriteLine(jetzt.Month);
      DateTime heute = DateTime.Today;
      Console.WriteLine(heute);

      TimeSpan ts = jetzt - heute;
      Console.WriteLine(ts);
      Console.WriteLine(ts.Minutes);
      Console.WriteLine(ts.TotalMinutes);

      Console.WriteLine(jetzt.ToUniversalTime().Kind);
      Console.WriteLine(jetzt.Kind);

      DateTime dt = new DateTime(1999, 2, 20);
      Console.WriteLine(dt);
      Console.WriteLine(dt.Kind);

      Console.WriteLine(Math.Round(1.5,MidpointRounding.AwayFromZero));
      Console.WriteLine(Math.Round(2.5, MidpointRounding.AwayFromZero));
      Console.WriteLine(Math.Round(3.5, MidpointRounding.AwayFromZero));
      Console.WriteLine(Math.Round(4.5, MidpointRounding.AwayFromZero));

      Console.WriteLine($"{1.5:0}, {2.5:0}");


      string t1 = "Hallo";
      string t2 = " Welt";
      string t3 = t1 + t2;

      Console.WriteLine(t3 == "Hallo Welt");

      Konto[] konten = new Konto[10];
      int[] zahlen = new int[10];

      Hund h = new Hund();
      h.Bellen();
      IHund hund = h;
      hund.Bellen();
      ISteuerobjekt steuerobjekt = h;
      steuerobjekt.SteuerAbführen();

      Console.ReadLine();
    }

    static void TuWas(string fest, string wasDenn = "nix", int wieLange = 20)
    {
      Console.WriteLine("Tut was: {0}, {1} Minuten lang", wasDenn, wieLange);
    }
  }

  interface ISteuerobjekt
  {
    void SteuerAbführen();
  }

  interface IHund
  {
    void Bellen();
  }

  class Hund : ISteuerobjekt, IHund
  {
    public void Bellen()
    {
      throw new NotImplementedException();
    }

    void ISteuerobjekt.SteuerAbführen()
    {
      throw new NotImplementedException();
    }
  }

  class Konto { }
}
