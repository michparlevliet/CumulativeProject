using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Cumulative_Project_1.Models
{
    public class SchoolDbContext
    {
        private static string User { get { return "root";  } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "schooldb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }
        /// <summary>
        /// Returns a connection to the school database
        /// </summary>
        /// private SchoolDbContext School = new SchoolDbContext();
        /// MySqlConnection Conn = School.AccessDatabase();
        /// <returns>MySql Connection Object</returns>
        public MySqlConnection AccessDatabase()
        {
            // instantiating the MySqlConnection CLass to create an object
            // the object is a specific connection to our school database on port 3306 of localhost
            return new MySqlConnection(ConnectionString); 
        }

    }
}