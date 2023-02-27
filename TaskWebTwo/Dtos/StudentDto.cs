using System.ComponentModel.DataAnnotations;

namespace TaskWebTwo.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Display(Name ="اسم الطالب")]
        [Required(ErrorMessage ="يجب ادخال هذا الحقل")]
        public string Name { get; set; }
        [Display(Name = "العمر")]
        public int? Age { get; set; }
        [Display(Name = "تاريخ الميلاد")]
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        [DataType(dataType:DataType.Date)]
        public DateTime DOB { get; set; }
        [Display(Name = "السنة الدراسية")]
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        public string ClassType { get; set; }
        [Display(Name = "النوع")]
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        public string Gender { get; set; }
    }
}
