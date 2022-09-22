﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMMini
{
  public class ViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private int zahl1;

    public int Zahl1
    {
      get { return zahl1; }
      set { zahl1 = value; OnPropertyChanged(); }
    }

    private int zahl2;

    public int Zahl2
    {
      get { return zahl2; }
      set { zahl2 = value; OnPropertyChanged(); }
    }

    private int ergebnis;

    public int Ergebnis
    {
      get { return ergebnis; }
      set { ergebnis = value; OnPropertyChanged(); }
    }

    public ActionCommand PlusCommand { get; set; }
    public ActionCommand MinusCommand { get; set; }

    public ViewModel()
    {
      PlusCommand = new ActionCommand(Plus);
      MinusCommand = new ActionCommand(Minus);
    }


    private void Plus()
    {
      // hier würde das Model aufgerufen werden
      Ergebnis = Zahl1 + Zahl2;
      PlusCommand.IsEnabled = false;
    }

    private void Minus()
    {
      Ergebnis = Zahl1 - Zahl2;
      PlusCommand.IsEnabled = true;
    }
  }
}
