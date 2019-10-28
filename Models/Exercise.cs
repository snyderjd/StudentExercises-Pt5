using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises5.Models
{
    // ## Exercise

    // You must define a type for representing an exercise in code.An exercise can be assigned to many students.

    // 1. Name of exercise
    // 1. Language of exercise (JavaScript, Python, CSharp, etc.)
    class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public Exercise(int id, string name, string language)
        {
            Id = id;
            Name = name;
            Language = language;
        }
    }
}


