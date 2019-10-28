using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises5.Models
{
    class NSSPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SlackHandle { get; set; }
        public Cohort Cohort { get; set; }
    }
}
