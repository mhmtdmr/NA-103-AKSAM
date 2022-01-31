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
            List<Student> studentList = new List<Student>();
            IDataReader reader;
            try
            {
                DbTools.Methods.ConnectDB();
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    studentList.Add(
                    new Student() {
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString() });
                }
                DbTools.Methods.DisconnectDB();
            }
            catch
            {
                // Log dosyasına yaz.
            }
            return studentList;
        }
    }
}