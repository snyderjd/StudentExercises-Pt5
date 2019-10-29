using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises5.Models
{
    class Student : NSSPerson
    {
        public List<Exercise> Exercises { get; set; }
        public int Id { get; set; }

        public Student(int id, string firstName, string lastName, string slackHandle, Cohort cohort)
        {
            Exercises = new List<Exercise>();
            FirstName = firstName;
            LastName = lastName;
            SlackHandle = slackHandle;
            Cohort = cohort;
            Id = id;
        }
    }
}
