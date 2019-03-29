using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            Debug.WriteLine($"Приложение {GetType()} начало работу");

            ICalculator calc = null;

            // Create the startup window
            MainWindow wnd = new MainWindow(calc);

            // Do stuff here, e.g. to the window
            wnd.Title = "Calculator";

            // Show the window
            wnd.Show();

        }

        private void App_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Неожиданная ошибка: " + e.Exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }

        private void App_Deactivated(object sender, EventArgs e)
        {
            Debug.WriteLine($"Приложение {GetType()} не активно");
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            Debug.WriteLine($"Приложение {GetType()} закрывается");
        }

        private void App_Activated(object sender, EventArgs e)
        {
            Debug.WriteLine($"Приложение {GetType()} активно");
        }
    }
}
