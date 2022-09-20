using System;

namespace VererbungBeispiel
{

  class A
  {
    public A(string text)
    {
      Console.WriteLine("ctor A");
      //MachWas();
    }
    public void TuWas() { Console.WriteLine("Tut was: A"); }
    public virtual void MachWas() { Console.WriteLine("Machwas: A"); }
  }

   class B : A
  {
    public B(string text) : base(text)
    {
      Console.WriteLine("ctor B");
    }
    public new void TuWas() { Console.WriteLine("Tut was: B"); }
    public  override void MachWas()
    {
      Console.WriteLine("Machwas B");
    }
  }

  //class C : B { }
  // abstract sealed class D { }
  static class D { }
  // MustInherit NotInheritable
  class Program
  {
    static void Main(string[] args)
    {
      B b = new B("abc");
      A a = b;

      a.TuWas();
      b.TuWas();

      a.MachWas();
      b.MachWas();

      Console.ReadLine();
    }
  }
}
