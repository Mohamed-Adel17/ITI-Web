using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.School
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subject> EnrolledSubjects { get; set; } = new List<Subject>();
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
