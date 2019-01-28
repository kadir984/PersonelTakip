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
    // <summary>
    // Interaction logic for EmployeeOperations.xaml
    // </summary>
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

            foreach (CheckBox item in lstEmployeeRoles.Items)
            {
                item.IsChecked=false;
            }
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

                if (sonuc > 0)
                {
                    //Son kayidi getir Employee Id sini ogren!
                    Employee sonEmploye = Employee.SelectLastEmployee();

                    int employeeRoleKayitSayisi = 0;
                    int isaretliRoleSayisi = 0;
                    foreach (CheckBox itemChkEmployeeRole in lstEmployeeRoles.Items)
                    {
                        if ((bool)itemChkEmployeeRole.IsChecked)
                        {
                            isaretliRoleSayisi++;

                            EmployeeRole yeniEmployeeRole = new EmployeeRole();
                            yeniEmployeeRole.RoleId = Convert.ToInt32(itemChkEmployeeRole.Tag);
                            yeniEmployeeRole.EmployeeId = sonEmploye.Id;
                            employeeRoleKayitSayisi = employeeRoleKayitSayisi + yeniEmployeeRole.Insert();
                        }
                    }

                    if (employeeRoleKayitSayisi == isaretliRoleSayisi)
                    {
                        LoadEmployeesGrid();
                        MessageBox.Show("Kayit basarili.");
                        BtnNew_Click(null, null);
                    }


                }
                else
                {
                    MessageBox.Show("Hay aksi!!!!");
                }
            }
            else if (employee.Id > 0) //update
            {
                int sonuc = employee.Update();
                if (sonuc > 0)
                {
                    //1.Adim Mevcut EmployeeRolelerini Sonlandir(Status = false ve EndDate ver.)
                    int sonlananRoleSayisi = EmployeeRole.DisableEmployeeRoleWithEmployeeId(employee.Id);
                    //2.Adim Secili olan CheckBoxtaki rolleri insert et.
                    int employeeRoleKayitSayisi = 0;
                    int isaretliRoleSayisi = 0;
                    foreach (CheckBox itemChkEmployeeRole in lstEmployeeRoles.Items)
                    {
                        if ((bool)itemChkEmployeeRole.IsChecked)
                        {
                            isaretliRoleSayisi++;

                            EmployeeRole yeniEmployeeRole = new EmployeeRole();
                            yeniEmployeeRole.RoleId = Convert.ToInt32(itemChkEmployeeRole.Tag);
                            yeniEmployeeRole.EmployeeId = employee.Id;
                            employeeRoleKayitSayisi = employeeRoleKayitSayisi + yeniEmployeeRole.Insert();
                        }
                    }

                    if (employeeRoleKayitSayisi == isaretliRoleSayisi)
                    {
                        LoadEmployeesGrid();
                        MessageBox.Show("Update basarili.");
                        BtnNew_Click(null, null);
                    }
                }
            }
        }

        private void DgEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee employee = (Employee)dgEmployees.SelectedItem;
            tbxId.Text = employee.Id.ToString();
            tbxFirstName.Text = employee.FirstName;
            tbxLastName.Text = employee.LastName;

            List<EmployeeRole> employeeRoles = EmployeeRole.GetEmployeRolesListWithEmployeeId(employee.Id);

            foreach (CheckBox itemChkBox in lstEmployeeRoles.Items)
            {
                itemChkBox.IsChecked = false;

                foreach (EmployeeRole itemEmployeeRole in employeeRoles)
                {
                    if (Convert.ToInt32(itemChkBox.Tag) == itemEmployeeRole.RoleId)
                    {
                        itemChkBox.IsChecked = true;
                    }
                }
            }
        }
    }
}
