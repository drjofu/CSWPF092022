using System.Windows;

namespace Datenbindung2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = new Firma();
    }

    private void AlterÄndern(object sender, RoutedEventArgs e)
    {
      var liste = ((Firma)DataContext).Mitarbeiter;
      foreach (var mitarbeiter in liste)
      {
        mitarbeiter.Alter++;
      }
    }

    private void NeuerMitarbeiter(object sender, RoutedEventArgs e)
    {
      var liste = ((Firma)DataContext).Mitarbeiter;
      liste.Add(new Person { Name = "der Neue", Alter = 18, Wohnort = "hier" });
    }
  }
}
