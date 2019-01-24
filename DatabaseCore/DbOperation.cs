using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseCore
{
    public class DbOperation
    {
        public static string connectionString = "";
        public static SqlConnection sqlConnection;

        //Todo:baglanti acma / kapatma metodu
        private static void OpenConnection()
        {
            sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (Exception)
                {
                    //todo: Txtye log yaz .
                }
            }
        }
        private static void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //todo: Txtye log yaz .
                }
            }
        }

        //Todo:Update, İnsert, Delete işlemleri
        public static int ExecuteCommand(string commandQuery)
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(connectionString, sqlConnection);
            int islemSonuc = sqlCommand.ExecuteNonQuery();
            CloseConnection();
            return islemSonuc;
        }

        //Todo:Select işlemleri
        public static DataTable GetTable(string selectQuery)
        {
            OpenConnection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectQuery,sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            CloseConnection();
            return dataTable;
        }

    }
}
