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
    public class UserDAL
    {
        private static UserDAL _Methods { get; set; }
        public static UserDAL Methods
        {
            get
            {
                if (_Methods == null)
                    _Methods = new UserDAL();
                return _Methods;
            }
        }

        private static List<User> GetUserList(SqlCommand cmd)
        {
            List<User> UserList = new List<User>();
            IDataReader reader;
            try
            {
                DbTools.Methods.ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserList.Add(
                    new User()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        RoleID = int.Parse(reader["RoleID"].ToString())
                    });
                }
                DbTools.Methods.DisconnectDB();
            }
            catch
            {
                throw;
            }
            return UserList;
        }


        public User GetByID(SqlCommand cmd)
        {
            //string query = $"SELECT * FROM User WHERE ID=@id;";
            //SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
            //cmd.Parameters.AddWithValue("@id", id);
            try
            {
                return GetUserList(cmd)[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetByEmail(string email,string tableName)
        {
            string query = $"SELECT * FROM {tableName} WHERE Email='{email}';";
            SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
            // AddWithValue eklenecek
            try
            {
                return GetUserList(cmd)[0];
            }
            catch (Exception)
            {
                return new User();
            }
        }










        //public User Login(string email, string password,string tableName)
        //{
        //    string query = $"SELECT * FROM {tableName} WHERE Email={email} AND Password={password};";
        //    SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
        //    // TODO: addwithvalue ile parametreler girilecek.
        //    try
        //    {
        //        return GetUserList(cmd)[0];
        //    }
        //    catch (Exception)
        //    {
        //        return new User(); // Boş user döndük.
        //    }
        //}
    }
}