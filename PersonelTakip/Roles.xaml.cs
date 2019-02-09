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
using PersonelTakip.Entities;

namespace PersonelTakip
{
    /// <summary>
    /// Interaction logic for Roles.xaml
    /// </summary>
    public partial class Roles : Window
    {
        public Roles()
        {
            InitializeComponent();
            RoleFill();
        }

        private void RoleFill()
        {
            List<Role> roles = Role.Select();
            dgRoles.ItemsSource = roles;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            tbxRoleId.Text = "0";
            tbxRoleName.Text = "";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Role role = new Role();
            role.Id = Convert.ToInt32(tbxRoleId.Text);
            role.Name = tbxRoleName.Text;

            if (role.Id==0 && tbxRoleName.Text!="")//insert
            {
                int sonuc = role.Insert();
                MessageBox.Show("Kayıt Başarılı.");
                RoleFill();
                BtnNew_Click(null, null);
            }
            else if (role.Id!=0)//update
            {
                int sonuc = role.Update();
                MessageBox.Show("Güncelleme Başarılı.");
                RoleFill();
                BtnNew_Click(null, null);
            }
            else
            {
                MessageBox.Show("Role ismi yazınız.");
            }
            RoleFill();
            BtnNew_Click(null, null);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Role roles = new Role();
            roles.Id = Convert.ToInt32( tbxRoleId.Text);
            if (roles.Id != 0)
            {
                roles.Delete();
                LoadRolesGrid();
                BtnNew_Click(null, null);
                MessageBox.Show("Silindi.");
            }
            else if (roles.Id == 0)
            {
                MessageBox.Show("Role Seçiniz.");
            }
        }

        private void DgRoles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Role role = (Role)dgRoles.SelectedItem;
            tbxRoleId.Text = role.Id.ToString();
            tbxRoleName.Text = role.Name.ToString();
        }

        private void LoadRolesGrid()
        {
            dgRoles.ItemsSource = null;
            dgRoles.ItemsSource = Role.Select();
        }
    }
}
