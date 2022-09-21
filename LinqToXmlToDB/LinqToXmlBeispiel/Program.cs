using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LinqToXmlBeispiel
{
  class Program
  {
    static void Main(string[] args)
    {
      XDocument xDoc = XDocument.Load("mondial.xml");
      var xContinents = xDoc
        .Root
        .Elements("continent")
        .OrderBy(xContinent => (int)xContinent.Element("area"));

      foreach (XElement xContinent in xContinents)
      {
        Console.WriteLine($"{xContinent.Attribute("id").Value,-10} " +
          $"{xContinent.Element("name").Value,-20} " +
          $"{xContinent.Element("area").Value,10} km²");
      }

      Console.WriteLine("***************************");

      IEnumerable<Country> countries =
        xDoc
        .Root
        .Elements("country")
        .Where(xCountry => xCountry
          .Element("encompassed")
            .Attribute("continent").Value == "asia")
        .Select(xCountry => new Country
        {
          Name = xCountry.Element("name").Value,
          CarCode = xCountry.Attribute("car_code").Value,
          Area = (double)xCountry.Attribute("area"),
          Government = xCountry.Element("government")?.Value,
          Population = (int)xCountry.Element("population"),
          IndependenceDate = (DateTime?)xCountry.Element("indep_date")
        });

      foreach (var country in countries)
      {
        Console.WriteLine($"{country.Name,-20}" +
          $" {country.CarCode,-5}" +
          $" {country.Area} km² " +
          $" {country.Government}" +
          $" {country.Population} pops" +
          $" {country.IndependenceDate:D}");
      }

      Console.ReadLine();
    }
  }
}
