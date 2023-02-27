using Microsoft.EntityFrameworkCore;

namespace TaskWebTwo.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public int ClassType { get; set; }
        public int Gender { get; set; }

        public ICollection<StudentCourse> courses { get; set; }
        public ICollection<TeacherStudent> teachers { get; set; }

    }
}

