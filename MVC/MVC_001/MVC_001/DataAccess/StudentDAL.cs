using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVC_001.Models;

namespace MVC_001.DataAccess
{
    public class StudentDAL
    {
        private static StudentDAL _Methods { get; set; }
        public static StudentDAL Methods
        {
            get
            {
                if (_Methods == null)
                    _Methods = new StudentDAL();
                return _Methods;
            }
        }

        public object Add(Student student)
        {
            string query = $"INSERT INTO Student (Name,Surname) VALUES(@name,@surname); SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
            cmd.Parameters.AddWithValue("@name", student.Name);          
            cmd.Parameters.AddWithValue("@surname", student.Surname);

            return DbTools.Methods.Add(cmd);

        }

        public List<Student> List()
        {
            string query = $"SELECT * FROM Student;";
            SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
            return GetStudentList(cmd);
        }

        private static List<Student> GetStudentList(SqlCommand cmd)
        {
            List<Student> studentList = new List<Student>();
            IDataReader reader;
            try
            {
                DbTools.Methods.ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    studentList.Add(
                    new Student()
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
            return studentList;
        }

        public Student GetByID(int id)
        {
            string query = $"SELECT * FROM Student WHERE ID=@id;";
            SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                return GetStudentList(cmd)[0];
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Student Login(string email,string password)
        {
            string query = $"SELECT * FROM Student WHERE Email='{email}' AND Password='{password}'"; ;
            SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
            // Addwithvalue eklenecek.
            try
            {
                return GetStudentList(cmd)[0];
            }
            catch (Exception)
            {
                throw;
            }
        }



        public int Update(Student student)
        {
            string query = $"UPDATE Student SET Name=@name,Surname=@surname WHERE ID=@id;";
            SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@surname", student.Surname);
            cmd.Parameters.AddWithValue("@id", student.ID);
            return DbTools.Methods.Execute(cmd);

        }
        public int Delete(int id)
        {
            string query = $"DELETE FROM Student WHERE ID=@id;";
            SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
            cmd.Parameters.AddWithValue("@id", id);
            return DbTools.Methods.Execute(cmd);
        }

        public List<Student> Search(string searchterm)
        {
            string query = $"SELECT * FROM Student WHERE Name LIKE '%' + @searchterm + '%' OR Surname LIKE '%' + @searchterm + '%';";
            SqlCommand cmd = new SqlCommand(query, DbTools.dbConnection);
            cmd.Parameters.AddWithValue("@searchterm", searchterm);
            try
            {
                return GetStudentList(cmd);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}