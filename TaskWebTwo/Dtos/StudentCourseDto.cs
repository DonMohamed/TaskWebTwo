namespace TaskWebTwo.Dtos
{
    public class StudentCourseDto
    {
        public StudentDto studentDto { get; set; }
        public CourseInfoDto courseInfoDto { get; set; }
        public List<CourseInfoDto> CourseInfoDtos { get; set; }
        public StudentCourseDto()
        {
            CourseInfoDtos = new();
        }
    }
}
