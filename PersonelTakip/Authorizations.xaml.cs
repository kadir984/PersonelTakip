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
            AuthFill();
            LoadAuthorizationsGrid();
        }
        private void LoadAuthorizationsGrid()
        {
            dgAuthorizations.ItemsSource = null;
            dgAuthorizations.ItemsSource = Authorization.Select();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //Authorization authorization = new Authorization();
            //authorization.RoleId = Convert.ToInt32(.Text);
            //authorization.DoorId = Convert.ToInt32(tbxRoleId.Text);

            //if (role.Id == 0 && tbxRoleName.Text != "")//insert
            //{
            //    int sonuc = role.Insert();
            //    MessageBox.Show("Kayıt Başarılı.");
            //    LoadRolesGrid();
            //}
            //else if (role.Id != 0)//update
            //{
            //    int sonuc = role.Update();
            //    MessageBox.Show("Güncelleme Başarılı.");
            //    LoadRolesGrid();
            //}
            //else
            //{
            //    MessageBox.Show("Role ismi yazınız.");

        }

        private void AuthFill()
        {
            List<Authorization> auth = Authorization.Select();
            for (int i = 0; i < auth.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = auth[i].RoleId;
                checkBox.Tag = auth[i].DoorId;
                lstAuthorizations.Items.Add(checkBox);
            }
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DgAuthorizations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

