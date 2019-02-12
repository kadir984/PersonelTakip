using DatabaseCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PersonelTakip.Entities
{
    public class Authorization
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int DoorId { get; set; }


        public static List<Authorization> Select()
        {
            string selectQuery = "SELECT * FROM Authorizations";
            DataTable dt = DbOperation.GetTable(selectQuery);

            return ConvertDataTableToList(dt);
        }

        private static List<Authorization> ConvertDataTableToList(DataTable tablo)
        {
            List<Authorization> listauth = new List<Authorization>();

            //Todo: bunun kolay yolununu arastir.
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                Authorization auth = new Authorization();
                auth.Id = Convert.ToInt32(tablo.Rows[i]["Id"]);
                auth.RoleId = Convert.ToInt32(tablo.Rows[i]["RoleId"]);
                auth.DoorId = Convert.ToInt32(tablo.Rows[i]["DoorId"]);

                listauth.Add(auth);
            }

            return listauth;
        }

        public static List<Authorization> GetAuthorizationListWithRoleId(int RoleId)
        {
            string selectQuery = "SELECT * FROM Authorizations WHERE RoleId = " + RoleId;

            DataTable dt = DbOperation.GetTable(selectQuery);

            return ConvertDataTableToList(dt);
        }

        public int Insert()
        {
            string insertQuery = " INSERT INTO [dbo].[Authorizations] ([RoleId],[DoorId])  VALUES ('" + RoleId + "','" + DoorId + "') ";

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
            string updateQuery = " UPDATE [dbo].[Authorizations] SET [RoleId] = '" + RoleId + "',[DoorId] = '" + DoorId + "'  WHERE Id =  " + Id;

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
            string deleteQuery = " DELETE FROM [dbo].[Authorizations] WHERE Id =  " + Id;

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
