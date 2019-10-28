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
        public string Name { get; set; }
        public string Language { get; set; }
        public Exercise(string name, string language)
        {
            Name = name;
            Language = language;
        }
    }
}


