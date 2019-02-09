using PersonelTakip.Entities;
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
using System.Windows.Shapes;

namespace PersonelTakip
{
    /// <summary>
    /// Interaction logic for Departments.xaml
    /// </summary>
    public partial class Departments : Window
    {
        public Departments()
        {
            InitializeComponent();
            DepartmentFill();
        }

        private void DepartmentFill()
        {
            List<Department> departments = Department.Select();
            dgDepartment.ItemsSource = departments;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            tbxDepartmentId.Text = "0";
            tbxDepartmentName.Text = "";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Department departments = new Department();
            departments.Id = Convert.ToInt32(tbxDepartmentId.Text);
            departments.Name = tbxDepartmentName.Text;

            if (departments.Id == 0 && tbxDepartmentName.Text != "")//insert
            {
                int sonuc = departments.Insert();
                MessageBox.Show("Kayıt Başarılı.");
                DepartmentFill();
                BtnNew_Click(null, null);
            }
            else if (departments.Id != 0)//update
            {
                int sonuc = departments.Update();
                MessageBox.Show("Güncelleme Başarılı.");
                DepartmentFill();
                BtnNew_Click(null, null);
            }
            else
            {
                MessageBox.Show("Department ismi yazınız.");
            }
            DepartmentFill();
            BtnNew_Click(null, null);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Department departments = new Department();
            departments.Id = Convert.ToInt32(tbxDepartmentId.Text);
            if (departments.Id != 0)
            {
                departments.Delete();
                LoadDepartmentGrid();
                BtnNew_Click(null, null);
                MessageBox.Show("Silindi.");
            }
            else if (departments.Id == 0)
            {
                MessageBox.Show("Department Seçiniz.");
            }
        }

        private void DgDepartment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Department departments = (Department)dgDepartment.SelectedItem;
            tbxDepartmentId.Text = departments.Id.ToString();
            tbxDepartmentName.Text = departments.Name.ToString();
        }

        private void LoadDepartmentGrid()
        {
            dgDepartment.ItemsSource = null;
            dgDepartment.ItemsSource = Department.Select();
        }

        
    }
}
