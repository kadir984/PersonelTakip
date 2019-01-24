using DatabaseCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTakip.Entities
{
    public class EmployeeRole
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }

        public static List<EmployeeRole> Select()
        {
            string selectQuery = "SELECT * FROM EmployeesRoles";
            DataTable dt = DbOperation.GetTable(selectQuery);

            return ConvertDataTableToList(dt);
        }

        public static List<EmployeeRole> Select(string sqlKisit)
        {
            string selectQuery = "SELECT * FROM EmployeesRoles WHERE " + sqlKisit;
            DataTable dt = DbOperation.GetTable(selectQuery);



            return ConvertDataTableToList(dt);
        }

        private static List<EmployeeRole> ConvertDataTableToList(DataTable tablo)
        {
            List<EmployeeRole> employeeRoles = new List<EmployeeRole>();

            //Todo: bunun kolay yolununu arastir.
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                EmployeeRole employee = new EmployeeRole();
                employee.Id = Convert.ToInt32(tablo.Rows[i]["Id"]);
                employee.EmployeeId = Convert.ToInt32(tablo.Rows[i]["EmployeeId"]);
                employee.RoleId = Convert.ToInt32(tablo.Rows[i]["RoleId"]);

                employeeRoles.Add(employee);
            }

            return employeeRoles;
        }


        public int Insert()
        {
            string insertQuery = " INSERT INTO [dbo].[EmployeesRoles] ([EmployeeId],[RoleId])  VALUES('" + EmployeeId + "','" + RoleId + "') ";

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
    }
}
