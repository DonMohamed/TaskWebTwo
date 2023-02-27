using System.ComponentModel.DataAnnotations;

namespace TaskWebTwo.Dtos
{
    public class CourseInfoDto
    {
        [Display(Name ="المادة الدراسية")]
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        public string CourseId { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        [Display(Name = "بداية الدراسة")]
        public DateTime startingCourse { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        [Display(Name = " مدة الدراسة بالشهور")]
        public int StudyPeriod { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        [Display(Name = "المدرس")]
        public string  TeacherNameId { get; set; }


    }
}
