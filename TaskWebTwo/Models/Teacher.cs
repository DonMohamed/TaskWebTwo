using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebTwo.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CourseId { get; set; }

        public ICollection<TeacherStudent> students { get; set; }

        [ForeignKey("CourseId")]
        public Course courses { get; set; }


    }
}
