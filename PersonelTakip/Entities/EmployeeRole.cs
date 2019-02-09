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
        
        public int Insert()
        {
            string insertQuery = " INSERT INTO [dbo].[EmployeesRoles] ([EmployeeId],[RoleId])  VALUES ('" + EmployeeId + "','" + RoleId + "') ";

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

        private static List<EmployeeRole> ConvertDataTableToList(DataTable tablo)
        {
            List<EmployeeRole> employeeRoles = new List<EmployeeRole>();

            //Todo: bunun kolay yolununu arastir.
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                EmployeeRole employeeRol = new EmployeeRole();
                employeeRol.Id = Convert.ToInt32(tablo.Rows[i]["Id"]);
                employeeRol.EmployeeId = Convert.ToInt32(tablo.Rows[i]["EmployeeId"]);
                employeeRol.RoleId = Convert.ToInt32(tablo.Rows[i]["RoleId"]);

                employeeRoles.Add(employeeRol);
            }

            return employeeRoles;
        }

        public static int DisableEmployeeRoleWithEmployeeId(int employeeId)
        {
            string updateQuery = @"UPDATE [dbo].[EmployeesRoles] SET [Status] = 'False',[EndDate] = getdate() WHERE EmployeeId = " + employeeId;
            return DbOperation.ExecuteCommand(updateQuery);
        }

        public static List<EmployeeRole> GetEmployeRolesListWithEmployeeId(int employeeId)
        {
            string selectQuery = "SELECT * FROM EmployeesRoles WHERE Status = 'True' AND  EmployeeId = " + employeeId;

            DataTable dt = DbOperation.GetTable(selectQuery);

            return ConvertDataTableToList(dt);
        }
    }
}
