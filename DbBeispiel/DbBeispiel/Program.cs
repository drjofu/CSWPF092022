using DbBeispiel.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace DbBeispiel
{
  internal class Program
  {
    static void Main(string[] args)
    {
      //Mondial2022CContext db = ViaEntityFramework();
      ClassicalApproach();
    }

    private static void ClassicalApproach()
    {
      // ADO.NET https://learn.microsoft.com/de-de/dotnet/framework/data/adonet/retrieving-and-modifying-data

      var connStr = "Server=(localdb)\\mssqllocaldb;Database=Mondial2022C;Trusted_Connection=True;";
      var conn = new SqlConnection(connStr);
      conn.Open();

      var command = new SqlCommand("Select * from continents", conn);
      using var reader = command.ExecuteReader();
      while (reader.Read())
      {
        Console.WriteLine(reader["Name"]);
      }

      conn.Close();

    }

    private static Mondial2022CContext ViaEntityFramework()
    {
      // https://learn.microsoft.com/en-us/ef/core/cli/powershell
      var db = new Mondial2022CContext();

      foreach (var continent in db.Continents.Include(c => c.Countries))
      {
        Console.WriteLine(continent.Name);
        foreach (var country in continent.Countries)
        {
          Console.WriteLine($"  {country.Name}");
        }
      }

      db.Continents.Add(new Continent { Name = "Gondwana", Area = 123 });
      db.SaveChanges();
      return db;
    }
  }
}
