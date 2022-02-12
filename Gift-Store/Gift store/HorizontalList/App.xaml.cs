using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HorizontalList
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
    {
        public static ObservableCollection<Product> _Products;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _Products = MyStorage.ReadXml<ObservableCollection<Product>>
             ("Products.xml");
                                          
            if (_Products == null)
                _Products = new ObservableCollection<Product>();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Settings.Default.Save();
            MyStorage.WriteXml(_Products, ("Products.xml"));

        }
    }
}
 