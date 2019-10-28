using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudentExercises5.Data
{
    class Repository
    {
        ///<summary>
        /// Creates a tunnel to connect the application to the database. All communication between the application and the database
        /// passes through this connection.
        ///</summary>
        public SqlConnection Connection
        {
            get
            {
                // This is the "address" of the database
                string _connectionString = "Data Source=DESKTOP-TFEHV46\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);                
            }
        }

        ///<summary>
        ///Returns a list of all the exercises in the database
        ///</summary>
    }
}
