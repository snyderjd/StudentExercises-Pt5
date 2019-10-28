using System;
using System.Collections.Generic;
using StudentExercises5.Data;
using StudentExercises5.Models;

namespace StudentExercises5
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            // Query the database for all exercises and print each one to the console
            List<Exercise> exercises = repository.GetAllExercises();

            foreach(Exercise exercise in exercises)
            {
                //Console.WriteLine($"{exercise.Id}: Name: {exercise.Name} Language: {exercise.Language}");
            }

            // Find all the exercises in the database where the language is JavaScript.
            List<Exercise> javascriptExercises = repository.GetExercisesByLanguage("JavaScript");

            foreach(Exercise exercise in javascriptExercises)
            {
                Console.WriteLine($"{exercise.Id}: Name: {exercise.Name} Language: {exercise.Language}");
            }
        }
    }
}
