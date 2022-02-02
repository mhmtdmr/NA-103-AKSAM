using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVC_001.Models;
using MVC_001.ModelBase;

namespace MVC_001.DataAccess
{
    public class RoleDAL
    {
        private static RoleDAL _Methods { get; set; }
        public static RoleDAL Methods
        {
            get
            {
                if (_Methods == null)
                    _Methods = new RoleDAL();
                return _Methods;
            }
        }

        private static List<Role> GetRoleList(SqlCommand cmd)
        {
            List<Role> RoleList = new List<Role>();
            IDataReader reader;
            try
            {
                DbTools.Methods.ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RoleList.Add(
                    new Role()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader["Name"].ToString()
                    });
                }
                DbTools.Methods.DisconnectDB();
            }
            catch
            {
                throw;
            }
            return RoleList;
        }


        public Role GetByID(int id)
        {
            string query = $"SELECT * FROM Role WHERE ID={id};";
                SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
            try
            {
                return GetRoleList(cmd)[0];
            }
            catch (Exception)
            {
                return new Role();
            }
        }
      
    }
}