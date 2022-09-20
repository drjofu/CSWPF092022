using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesUndDelegates
{
  static class Erweiterungsmethoden
  {
    // Extension Method
    public static IEnumerable<T> Ausgeben<T>(this IEnumerable<T> liste, string titel = "")
    {
      Console.WriteLine($"************ {titel} ***********");
      foreach (T element in liste)
      {
        Console.WriteLine(element);
      }

      Console.WriteLine("*************************************************");
      return liste;
    }

    //public static void AAA(this object obj)
    //{

    //}
  }
}
