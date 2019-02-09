using System;
using System.Collections.Generic;
using System.IO;
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

namespace PersonelTakip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FileInfo dosya = new FileInfo("sql.txt");
            DatabaseCore.DbOperation.connectionString = System.IO.File.ReadAllText(dosya.ToString());
        }

        private void BtnEmployeeOperations_Click(object sender, RoutedEventArgs e)
        {
            EmployeeOperations employeeOperations = new EmployeeOperations();
            employeeOperations.Show();
        }

        private void BtnRole_Click(object sender, RoutedEventArgs e)
        {
            Roles roles = new Roles();
            roles.Show();

        }
    }
}
