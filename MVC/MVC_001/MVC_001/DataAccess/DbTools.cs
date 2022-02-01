using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MVC_001.Models;

namespace MVC_001.DataAccess
{
    public class DbTools
    {
        private static DbTools _Methods { get; set; }
        
        public static DbTools Methods
        {
            get
            {
                if (_Methods == null)
                    _Methods = new DbTools();
                return _Methods;
            }
        }




        static string strConnection = ConfigurationManager.ConnectionStrings["schooldb"].ConnectionString;
        public static SqlConnection dbConnection = new SqlConnection(strConnection);

        public bool ConnectDB()
        {
            try
            {
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open(); // vt bağlantısını aç.
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool DisconnectDB()
        {
            try
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close(); // vt bağlantısını kapat.
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public object Add(SqlCommand cmd)
        {
            object insertedID = -1;
            try
            {
                if (ConnectDB())
                {
                    insertedID = cmd.ExecuteScalar();
                    DisconnectDB();
                }
            }
            catch
            {
                return insertedID;
                // Hata Logu yaz
            }
            return insertedID;
        }
        public int Execute(SqlCommand cmd)
        {
            int affectedRows = 0;
            try
            {
                if (ConnectDB())
                {
                    affectedRows = cmd.ExecuteNonQuery();
                    DisconnectDB();
                }
            }
            catch
            {
                throw;
            }
            return affectedRows;
        }
    }
}