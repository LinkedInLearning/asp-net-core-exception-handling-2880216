using System;

namespace School.API.Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime DataOfBirth { get; set; }
    }
}
