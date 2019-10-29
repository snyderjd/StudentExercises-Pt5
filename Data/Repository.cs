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

        ///<summary>Final all the exercises in the database by language</summary>
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

        ///<summary>Adds an exercise to the database</summary>
        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Exercise (Name, Language) VALUES (@name, @language)";
                    cmd.Parameters.Add(new SqlParameter("@name", exercise.Name));
                    cmd.Parameters.Add(new SqlParameter("@language", exercise.Language));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ******************************
        // Instructor
        // ******************************

        /// <summary>Gets all instructors from the database, including their Cohort</summary>
        public List<Instructor> GetAllInstructors()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT i.Id, i.FirstName, i.LastName, i.CohortId, i.SlackHandle, i.Specialty, c.Name" +
                        "              FROM Instructor i LEFT JOIN Cohort c on i.CohortId = c.Id";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();
                    while (reader.Read())
                    {
                        Instructor instructor = new Instructor(
                            reader.GetInt32(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("SlackHandle")),
                            new Cohort(reader.GetInt32(reader.GetOrdinal("CohortId")),
                                        reader.GetString(reader.GetOrdinal("Name"))),
                            reader.GetString(reader.GetOrdinal("Specialty")));

                        instructors.Add(instructor);
                        instructors.Add(instructor);
                    }

                    reader.Close();

                    return instructors;
                }
            }
        }


        ///<summary>Adds an instructor to the database</summary>
        public void AddInstructor(Instructor instructor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Instructor (FirstName, LastName, CohortId, Specialty, SlackHandle)" +
                        "              VALUES (@firstName, @lastName, @cohortId, @specialty, @slackHandle)";
                    cmd.Parameters.Add(new SqlParameter("@firstName", instructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", instructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@cohortId", instructor.Cohort.Id));
                    cmd.Parameters.Add(new SqlParameter("@specialty", instructor.Specialty));
                    cmd.Parameters.Add(new SqlParameter("slackHandle", instructor.SlackHandle));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>Assigns an existing exercise to an existing student</summary>
        public void AssignExercise(int exerciseId, int studentId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (@StudentId, @ExerciseId)";
                    cmd.Parameters.Add(new SqlParameter("@StudentId", studentId));
                    cmd.Parameters.Add(new SqlParameter("@ExerciseId", exerciseId));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public void AddExercise(Exercise exercise)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = "INSERT INTO Exercise (Name, Language) VALUES (@name, @language)";
        //            cmd.Parameters.Add(new SqlParameter("@name", exercise.Name));
        //            cmd.Parameters.Add(new SqlParameter("@language", exercise.Language)); 
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
 
    }
}
