using DatabaseCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTakip.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public static List<Department> Select()
        {
            string selectQuery = "SELECT * FROM Departments";
            DataTable dt = DbOperation.GetTable(selectQuery);

            return ConvertDataTableToList(dt);
        }

        private static List<Department> ConvertDataTableToList(DataTable tablo)
        {
            List<Department> Departments = new List<Department>();

            //Todo: bunun kolay yolununu arastir.
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                Department Department = new Department();
                Department.Id = Convert.ToInt32(tablo.Rows[i]["Id"]);
                Department.Name = tablo.Rows[i]["Name"].ToString();

                Departments.Add(Department);
            }

            return Departments;
        }

        public int Insert()
        {
            string insertQuery = " INSERT INTO [dbo].[Departments] ([Name])  VALUES('" + Name + "') ";

            int sonuc = DbOperation.ExecuteCommand(insertQuery);
            if (sonuc > 0)
            {
                //basarili
            }
            else
            {
                //sorun var!!!!!!!
            }

            return sonuc;
        }

        public int Update()
        {
            string updateQuery = " UPDATE [dbo].[Departments] SET [Name] = '" + Name + "'  WHERE Id =  " + Id;

            int sonuc = DbOperation.ExecuteCommand(updateQuery);
            if (sonuc > 0)
            {
                //basarili
            }
            else
            {
                //sorun var!!!!!!!
            }

            return sonuc;
        }

        public int Delete()
        {
            string deleteQuery = " DELETE FROM [dbo].[Departments] WHERE Id =  " + Id;

            int sonuc = DbOperation.ExecuteCommand(deleteQuery);
            if (sonuc > 0)
            {
                //basarili
            }
            else
            {
                //sorun var!!!!!!!
            }

            return sonuc;
        }
    }
}
