using Cumulative_Project_1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cumulative_Project_1.Controllers
{
    public class ClassDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Method returns a list of all classes in the school database.
        /// </summary>
        /// <param name="SearchKey">Populates when the search bar recieves an input</param>
        /// <example>/api/classdata/listtclasses</example>
        /// <returns>List of all class names</returns>

        [HttpGet]

        public IEnumerable<Class> ListClasses()
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from Classes";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Class> Classes = new List<Class>();

            while (ResultSet.Read())
            {
                int ClassId = (int)ResultSet["classid"];
                string ClassCode = (string)ResultSet["classcode"];
                Int64 TeacherId = (Int64)ResultSet["teacherid"];
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = (string)ResultSet["classname"];

                Class NewClass = new Class();
                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;
                Classes.Add(NewClass);
            }

            Conn.Close();

            return Classes;
        }

        /// <summary>
        /// Method returns class info as specified by the input {id}.
        /// </summary>
        /// <param name="id">classid of class</param>
        /// <example>/api/classdata/findclass/4</example>
        /// <returns>Class info for Digital Design</returns>

        [HttpGet]
        public Class FindClass(int id)
        {
            Class NewClass = new Class();

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from Classes where classid = @id";
            //cmd.CommandText = "SELECT * FROM classes LEFT JOIN teachers ON classes.teacherid = teacher.teacherid WHERE teachers.teacherid = @id";
            
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();


            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int ClassId = (int)ResultSet["classid"];
                string ClassCode = (string)ResultSet["classcode"];
                Int64 TeacherId = (Int64)ResultSet["teacherid"];
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = (string)ResultSet["classname"];

                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;
            }

            return NewClass;
        }
    }
}
