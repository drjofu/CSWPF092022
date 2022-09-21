﻿using System;
using System.ComponentModel;
using System.Reflection;
using System.Linq;

namespace ReflectionBeispiel
{
  static class Extensions
  {

    public static T GetAttribute<T>(this Type type) where T : Attribute
    {
      var attributes = type.GetCustomAttributes(typeof(T));
      return (T)attributes.FirstOrDefault();
    }

  }

  class Program
  {
    static void Main(string[] args)
    {
      object obj = new Beispielklasse();
      Analysieren(obj);

      Console.ReadLine();
    }

    private static void Analysieren(object obj)
    {
      Type type = obj.GetType();
      Console.WriteLine(type.Name);
      Console.WriteLine(type.FullName);

      var seminarAttr = type.GetCustomAttribute<SeminarAttribute>();
      Console.WriteLine($"Thema: {seminarAttr.Thema}, Teilnehmer: {seminarAttr.AnzahlTeilnehmer}");

      seminarAttr = type.GetAttribute<SeminarAttribute>();
      Console.WriteLine($"Thema: {seminarAttr.Thema}, Teilnehmer: {seminarAttr.AnzahlTeilnehmer}");


      Console.WriteLine("*** Properties ***");
      foreach (var pi in type.GetProperties())
      {
        Console.WriteLine($"{pi.Name}: {pi.GetValue(obj)} [{pi.PropertyType.Name}]");
        var descriptionAttr = pi.GetCustomAttribute<DescriptionAttribute>();
        if (descriptionAttr != null) Console.WriteLine($"  Description: {descriptionAttr.Description}");
        var categoryAttr = pi.GetCustomAttribute<CategoryAttribute>();
        if (categoryAttr != null) Console.WriteLine($"  Category: {categoryAttr.Category}");
      }

      Console.WriteLine("*** Fields ***");
      type.GetField("geheim", BindingFlags.NonPublic | BindingFlags.Instance)?
        .SetValue(obj, "doch nicht so geheim...");

      foreach (var fi in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
      {
        Console.WriteLine($"{fi.Name}: {fi.GetValue(obj)} [{fi.FieldType.Name}]");
      }

      Console.WriteLine("*** Methods ***");
      object result = type.GetMethod("TuWas")?.Invoke(obj, new object[] { "Reflection lernen" });
      Console.WriteLine(result);
    }
  }
}
