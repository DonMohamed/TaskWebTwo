using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebTwo.Models
{

    public class TeacherStudent
    {
        public int TeacherId { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student student { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher teacher { get; set; }


    }
}
