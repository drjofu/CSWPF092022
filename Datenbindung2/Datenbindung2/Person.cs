using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Datenbindung2
{
  class Person : INotifyPropertyChanged
  {
    private int alter;

    public string Name { get; set; }
    public string Wohnort { get; set; }
    public int Alter
    {
      get { return alter; }
      set
      {
        if (alter == value) return;
        alter = value;
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alter"));
        OnPropertyChanged();
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IstErfahren"));
        OnPropertyChanged(nameof(IstErfahren));
      }
    }

    protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public bool IstErfahren => Alter >= 50;

    public event PropertyChangedEventHandler PropertyChanged;
  }

  class Firma
  {
    public string Name { get; set; } = "Hinz & Kunz";
    public ObservableCollection<Person> Mitarbeiter { get; set; } = new ObservableCollection<Person>
    {
      new Person{Name="Petra", Wohnort="Berlin", Alter=44},
      new Person{Name="Peter", Wohnort="Köln", Alter=33},
      new Person{Name="Uwe", Wohnort="Kiel", Alter=56},
      new Person{Name="Marie", Wohnort="München", Alter=49},
      new Person{Name="Elke", Wohnort="Berlin", Alter=60}
    };

  }
}
