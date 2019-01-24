using DatabaseCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTakip.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Insert()
        {
            string insertQuery = " INSERT INTO [dbo].[Employees] ([FirstName],[LastName])  VALUES('" + FirstName + "','" + LastName + "') ";

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
            string updateQuery = " UPDATE [dbo].[Employees] SET [FirstName] = '" + FirstName + "' ,[LastName] = '" + LastName + "' WHERE Id =  " + Id;

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
            string deleteQuery = " DELETE FROM [dbo].[Employees] WHERE Id =  " + Id;

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


        public static List<Employee> Select()
        {
            string selectQuery = "SELECT * FROM Employees";
            DataTable dt = DbOperation.GetTable(selectQuery);

            return ConvertDataTableToList(dt);
        }

        public static List<Employee> Select(string sqlKisit)
        {
            string selectQuery = "SELECT * FROM Employees WHERE " + sqlKisit;
            DataTable dt = DbOperation.GetTable(selectQuery);



            return ConvertDataTableToList(dt);
        }

        private static List<Employee> ConvertDataTableToList(DataTable tablo)
        {
            List<Employee> employees = new List<Employee>();

            //Todo: bunun kolay yolununu arastir.
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(tablo.Rows[i]["Id"]);
                employee.FirstName = tablo.Rows[i]["FirstName"].ToString();
                employee.LastName = tablo.Rows[i]["LastName"].ToString();

                employees.Add(employee);
            }

            return employees;
        }
    }
}
