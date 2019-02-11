using DatabaseCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTakip.Entities
{
    public class Door
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }


        public static List<Door> Select()
        {
            string selectQuery = "SELECT * FROM Doors";
            DataTable dt = DbOperation.GetTable(selectQuery);

            return ConvertDataTableToList(dt);
        }

        private static List<Door> ConvertDataTableToList(DataTable tablo)
        {
            List<Door> listdoors = new List<Door>();

            //Todo: bunun kolay yolununu arastir.
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                Door door = new Door();
                door.Id = Convert.ToInt32(tablo.Rows[i]["Id"]);
                door.Name = tablo.Rows[i]["Name"].ToString();
                door.DepartmentId = Convert.ToInt32(tablo.Rows[i]["DepartmentId"]);

                listdoors.Add(door);
            }

            return listdoors;
        }
        
        public int Insert()
        {
            string insertQuery = " INSERT INTO [dbo].[Doors] ([Name],[DepartmentId])  VALUES ('" + Name + "','" + DepartmentId + "') ";

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
            string updateQuery = " UPDATE [dbo].[Doors] SET [Name] = '" + Name + "',[DepartmentId] = '" + DepartmentId + "'  WHERE Id =  " + Id;

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
            string deleteQuery = " DELETE FROM [dbo].[Doors] WHERE Id =  " + Id;

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
