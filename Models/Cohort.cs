using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises5.Models
{
    class Cohort
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Student> Students { get; set; }
        public List<Instructor> Instructors { get; set; }

        public Cohort(int id, string name)
        {
            Id = id;
            Name = name;
            Students = new List<Student>();
            Instructors = new List<Instructor>();
        }
    }
}
