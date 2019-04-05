using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab10
{
    class User
        {
            public static int[] Courses = new int[] { 1, 2, 3, 4 };

            public string FullName { get; set; }
            public int Course { get; set; }
            public int Group { get; set; }
            public string Track { get; set; }
        }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            List<User> users = new List<User>();
            users.Add(new User { FullName = "B d d", Course = 1, Group = 2, Track = "ПОКС" });
            dataGrid.ItemsSource = users;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
