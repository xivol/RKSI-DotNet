using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab10
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            //Debug.WriteLine($"Приложение {GetType()} начало работу");

            // Create the startup window
            MainWindow wnd = new MainWindow();

            // Do stuff here, e.g. to the window
            wnd.Title = "Students";

            // Show the window
            wnd.Show();

        }
    }
}
