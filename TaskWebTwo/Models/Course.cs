namespace TaskWebTwo.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        public ICollection<StudentCourse> students { get; set; }
        public ICollection<Teacher> teachers { get;}
    }
}
