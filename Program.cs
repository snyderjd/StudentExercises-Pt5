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
                //Console.WriteLine($"{exercise.Id}: Name: {exercise.Name} Language: {exercise.Language}");
            }

            // Insert a new exercise into the database
            repository.AddExercise(new Exercise(0, "DepartmentEmployees", "C#"));
            // Print out all the exercises to see if the new one was added
            List<Exercise> exercises2 = repository.GetAllExercises();
            foreach(Exercise exercise in exercises2)
            {
                //Console.WriteLine($"{exercise.Id}: Name: {exercise.Name} Language: {exercise.Language}");
            }

            // Print out all the instructors, include their cohort
            List<Instructor> instructors = repository.GetAllInstructors();

            foreach(Instructor instructor in instructors)
            {
                Console.WriteLine($"{instructor.FirstName} {instructor.LastName}");
                Console.WriteLine($"Id: {instructor.Id}");
                Console.WriteLine($"Slack: {instructor.SlackHandle}");
                Console.WriteLine($"Specialty: {instructor.Specialty}");
                Console.WriteLine($"Cohort: {instructor.Cohort.Name}");
                Console.WriteLine();
            }

            // Insert a new instructor into the database. Assign the instructor to an existing cohort
            repository.AddInstructor(new Instructor(-1, "Bill", "Gates", "Bill G", new Cohort(3, ""), "Microsoft"));
            // Print out all the instructors to see if the new one was added
            List<Instructor> instructors2 = repository.GetAllInstructors();
            foreach (Instructor instructor in instructors2)
            {
                Console.WriteLine($"{instructor.FirstName} {instructor.LastName}");
                Console.WriteLine($"Id: {instructor.Id}");
                Console.WriteLine($"Slack: {instructor.SlackHandle}");
                Console.WriteLine($"Specialty: {instructor.Specialty}");
                Console.WriteLine($"Cohort: {instructor.Cohort.Name}");
                Console.WriteLine();
            }



        }
    }
}
