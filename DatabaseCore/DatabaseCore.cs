using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseCore
{
    class DatabaseCore
    {
        public static string ConnectionString = "";
        public static SqlConnection SqlConnection;
        //Todo:baglanti acma / kapatma metodu
        private static void OpenConnection()
        {
            if (SqlConnection.State == ConnectionState.Closed)
            {
                try
                {
                    SqlConnection.Open();
                }
                catch (Exception)
                {
                    //todo: Txtye log yaz .
                }
            }
        }
        private static void CloseConnection()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    SqlConnection.Close();
                }
                catch (Exception)
                {
                    //todo: Txtye log yaz .
                }
            }
        }
        //Crud
        //Todo:Update, İnsert, Delete işlemleri

        public static int ExecuteCommand()
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(ConnectionString, SqlConnection);
            int islemSonuc = sqlCommand.ExecuteNonQuery();
            CloseConnection();
            return islemSonuc;
        }
        //Todo:Select işlemleri
        public static DataTable GetTable()
        {
            OpenConnection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            CloseConnection();
            return dataTable;
        }

    }
}
