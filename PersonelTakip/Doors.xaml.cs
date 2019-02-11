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
    /// Interaction logic for Doors.xaml
    /// </summary>
    public partial class Doors : Window
    {
        public Doors()
        {
            InitializeComponent();
            LoadDoorsGrid();
            BtnNew_Click(null, null);
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            tbxDoorId.Text = "0";
            tbxDoorName.Text = "";
            tbxDepartmentId.Text = "";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Door door = new Door();
            door.Id = Convert.ToInt32(tbxDoorId.Text);
            
            if (door.Id == 0 && tbxDoorName.Text != "" && tbxDepartmentId.Text != "")//insert
            {
                door.Name = tbxDoorName.Text;
                door.DepartmentId = Convert.ToInt32(tbxDepartmentId.Text);
                int sonuc = door.Insert();
                MessageBox.Show("Kayıt Başarılı.");
                LoadDoorsGrid();
                BtnNew_Click(null, null);
            }
            else if (door.Id != 0)//update
            {
                int sonuc = door.Update();
                MessageBox.Show("Güncelleme Başarılı.");
                LoadDoorsGrid();
                BtnNew_Click(null, null);
            }
            else
            {
                MessageBox.Show("Door ismi ve Department Id yazınız.");
            }
            LoadDoorsGrid();
            BtnNew_Click(null, null);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Door door = new Door();
            door.Id = Convert.ToInt32(tbxDoorId.Text);

            if (door.Id != 0)
            {
                door.Delete();
                LoadDoorsGrid();
                BtnNew_Click(null, null);
                MessageBox.Show("Silindi.");
            }
            else if (door.Id == 0)
            {
                MessageBox.Show("Kapı Seçiniz.");
            }
        }

        private void LoadDoorsGrid()
        {
            dgDoors.ItemsSource = null;
            dgDoors.ItemsSource = Door.Select();
        }

        private void DgDoors_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Door door = (Door)dgDoors.SelectedItem;
            tbxDoorId.Text = door.Id.ToString();
            tbxDoorName.Text = door.Name;
            tbxDepartmentId.Text = door.DepartmentId.ToString();
        }
    }
}
