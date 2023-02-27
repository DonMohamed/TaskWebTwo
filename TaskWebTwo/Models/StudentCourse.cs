using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebTwo.Models
{
    
    public class StudentCourse
    {
        public int StudentID { get; set; }
        public int CourseId { get; set; }
        public DateTime startingCourse { get; set; }
        public int StudyPeriod { get; set; }

        [ForeignKey("CourseId")]
        public Course course { get; set; }
        [ForeignKey("StudentID")]
        public Student student { get; set; }
    }
}
