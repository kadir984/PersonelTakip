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
    /// Interaction logic for EmployeeOperations.xaml
    /// </summary>
    public partial class EmployeeOperations : Window
    {
        public EmployeeOperations()
        {
            InitializeComponent();

            LoadEmployeesGrid();
            RoleFill();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            tbxId.Text = "0";
            tbxFirstName.Text = "";
            tbxLastName.Text = "";
        }

        private void RoleFill()
        {
            List<Role> roles = Role.Select();
            for (int i = 0; i < roles.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = roles[i].Name;
                checkBox.Tag = roles[i].Id;
                lstEmployeeRoles.Items.Add(checkBox);
            }

        }

        private void LoadEmployeesGrid()
        {
            dgEmployees.ItemsSource = null;
            dgEmployees.ItemsSource = Employee.Select();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.Id = Convert.ToInt32(tbxId.Text);
            employee.FirstName = tbxFirstName.Text;
            employee.LastName = tbxLastName.Text;

            if (employee.Id == 0)//insert
            {
                int sonuc = employee.Insert();
                //todo: employeeroles e kayitlari yolla
                if (sonuc > 0)
                {
                    LoadEmployeesGrid();
                    MessageBox.Show("Kayit basarili.");
                    BtnNew_Click(null, null);
                }
            }
            else if (employee.Id > 0) //update
            {
                int sonuc = employee.Update();
                if (sonuc > 0)
                {
                    LoadEmployeesGrid();
                    MessageBox.Show("Update basarili.");
                    BtnNew_Click(null, null);
                }
            }
        }

        private void DgEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee employee = (Employee)dgEmployees.SelectedItem;
            tbxId.Text = employee.Id.ToString();
            tbxFirstName.Text = employee.FirstName;
            tbxLastName.Text = employee.LastName;


            List<EmployeeRole> employeeRoles = EmployeeRole.Select("EmployeeId="+ employee.Id);

            #region checkbox

            for (int i = 0; i < lstEmployeeRoles.Items.Count; i++)
            {
                ((CheckBox)lstEmployeeRoles.Items[i]).IsChecked = false;

                for (int j = 0; j < employeeRoles.Count; j++)
                {
                    if (((CheckBox)lstEmployeeRoles.Items[i]).Tag.ToString() == employeeRoles[j].RoleId.ToString())

                    {
                        ((CheckBox)lstEmployeeRoles.Items[i]).IsChecked = true;
                    }
                }
            }

            #endregion
        }
    }
}
