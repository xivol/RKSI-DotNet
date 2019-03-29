using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ICalculator calc)
        {
            InitializeComponent();

            //foreach (UIElement c in MainGrid.Children)
            //{
            //    if (c is Button btn)
            //    {
            //        btn.Click += Button_Click;
            //    }
            //}
        }

        public void Button_Click(object sender, RoutedEventArgs args)
        {
            string data = (sender as Button).Content.ToString();
            output.Text += data;

            //throw new NotImplementedException("Пример необработанного исключения");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены что хотите закрыть приложение?", "Закрытие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = false;
            }
        }

    }
}
