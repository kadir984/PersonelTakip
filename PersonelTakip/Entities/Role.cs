using DatabaseCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTakip.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public static List<Role> Select()
        {
            string selectQuery = "SELECT * FROM Roles";
            DataTable dt = DbOperation.GetTable(selectQuery);

            return ConvertDataTableToList(dt);
        }

        private static List<Role> ConvertDataTableToList(DataTable tablo)
        {
            List<Role> roles = new List<Role>();

            //Todo: bunun kolay yolununu arastir.
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                Role role = new Role();
                role.Id = Convert.ToInt32(tablo.Rows[i]["Id"]);
                role.Name = tablo.Rows[i]["Name"].ToString();

                roles.Add(role);
            }

            return roles;
        }
    }
}
