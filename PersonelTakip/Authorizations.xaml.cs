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
    /// Interaction logic for Authorizations.xaml
    /// </summary>
    public partial class Authorizations : Window
    {
        public Authorizations()
        {
            InitializeComponent();
            LoadAuthorizationsGrid();
            DoorFill();
        }
        private void LoadAuthorizationsGrid()
        {
            dgAuthorizations.ItemsSource = null;
            dgAuthorizations.ItemsSource = Role.Select();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //Role roles = (Role) dgAuthorizations.SelectedItem;
            //Role roles2 = new Role();
            //roles2.Name = roles.Name;


            //if (employee.Id == 0)//insert
            //{
            //    int sonuc = employee.Insert();

            //    if (sonuc > 0)
            //    {
            //        //Son kayidi getir Employee Id sini ogren!
            //        Employee sonEmploye = Employee.SelectLastEmployee();

            //        int employeeRoleKayitSayisi = 0;
            //        int isaretliRoleSayisi = 0;
            //        foreach (CheckBox itemChkEmployeeRole in lstEmployeeRoles.Items)
            //        {
            //            if ((bool)itemChkEmployeeRole.IsChecked)
            //            {
            //                isaretliRoleSayisi++;

            //                EmployeeRole yeniEmployeeRole = new EmployeeRole();
            //                yeniEmployeeRole.RoleId = Convert.ToInt32(itemChkEmployeeRole.Tag);
            //                yeniEmployeeRole.EmployeeId = sonEmploye.Id;
            //                employeeRoleKayitSayisi = employeeRoleKayitSayisi + yeniEmployeeRole.Insert();
            //            }
            //        }

            //        if (employeeRoleKayitSayisi == isaretliRoleSayisi)
            //        {
            //            LoadEmployeesGrid();
            //            MessageBox.Show("Kayit basarili.");
            //            BtnNew_Click(null, null);
            //        }


            //    }
            //    else
            //    {
            //        MessageBox.Show("Hay aksi!!!!");
            //    }
            //}
        }

        private void DoorFill()
        {
            List<Door> authdoors = Door.Select();
            for (int i = 0; i < authdoors.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = authdoors[i].Name;
                checkBox.Tag = authdoors[i].Id;
                lstAuthorizations.Items.Add(checkBox);
            }
        }
        
        private void DgAuthorizations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Role roles = (Role)dgAuthorizations.SelectedItem;

            List<Authorization> Authlist = Authorization.GetAuthorizationListWithRoleId(roles.Id);

            foreach (CheckBox itemChkBox in lstAuthorizations.Items)
            {
                itemChkBox.IsChecked = false;

                foreach (Authorization itemdoor in Authlist)
                {
                    if (Convert.ToInt32(itemChkBox.Tag) == itemdoor.DoorId)
                    {
                        itemChkBox.IsChecked = true;
                    }
                }
            }
        }
    }
}

