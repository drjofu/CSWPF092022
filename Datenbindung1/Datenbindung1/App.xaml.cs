using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Datenbindung1
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    static App()
    {
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

      FrameworkElement.LanguageProperty.OverrideMetadata(
        typeof(FrameworkElement),
        new FrameworkPropertyMetadata(
          XmlLanguage.GetLanguage(
            CultureInfo.CurrentCulture.Name)
          )
        );

    }
  }
}
