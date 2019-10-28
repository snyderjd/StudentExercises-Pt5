using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using StudentExercises5.Models;
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
                string _connectionString = "Data Source=DESKTOP-TFEHV46\\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);                
            }
        }

        // ******************************
        // Exercises
        // ******************************

        ///<summary>
        ///Returns a list of all the exercises in the database
        ///</summary>
        public List<Exercise> GetAllExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Language FROM Exercise";
                    SqlDataReader reader = cmd.ExecuteReader();

                    Exercise exercise = null;
                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        exercise = new Exercise(reader.GetInt32(reader.GetOrdinal("Id")), 
                                                reader.GetString(reader.GetOrdinal("Name")),
                                                reader.GetString(reader.GetOrdinal("Language")));

                        exercises.Add(exercise);
                    }

                    reader.Close();
                    return exercises;
                }
            }
        }

        //Find all the exercises in the database where the language is JavaScript.
        public List<Exercise> GetExercisesByLanguage(string language)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Language FROM Exercise WHERE Language = @language";
                    cmd.Parameters.Add(new SqlParameter("@language", language));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Exercise exercise = null;
                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        exercise = new Exercise(reader.GetInt32(reader.GetOrdinal("Id")),
                                                reader.GetString(reader.GetOrdinal("Name")),
                                                reader.GetString(reader.GetOrdinal("Language")));

                        exercises.Add(exercise);
                    }

                    reader.Close();
                    return exercises;
                }
            }
        }

        // Example from DepartmentsEmployees

        //public List<Employee> GetAllEmployees()
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT Id, FirstName, LastName FROM Employee";
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            Employee employee = null;
        //            List<Employee> employees = new List<Employee>();
        //            while (reader.Read())
        //            {
        //                employee = new Employee
        //                {
        //                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
        //                    LastName = reader.GetString(reader.GetOrdinal("LastName"))
        //                };

        //                employees.Add(employee);
        //            }

        //            reader.Close();

        //            return employees;
        //        }
        //    }
        //}

    }
}
