using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskWebTwo.Dtos;
using TaskWebTwo.Models;

namespace TaskWebTwo.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentCourseTaskContext _context;
        private static List<CourseInfoDto> AllCources { get; set; } = new();

        public StudentController(ILogger<HomeController> logger, StudentCourseTaskContext context)
        {
            _logger = logger;
            _context = context;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.ClassType = _context.Classes.Select(r => new SelectListItem
            {
                Text = r.ClassName,
                Value = r.ClassId.ToString()
            }).ToList();
            ViewBag.Gender = _context.Genders.Select(r => new SelectListItem
            {
                Text = r.GenderName,
                Value = r.GenderId.ToString()
            }).ToList();
            ViewBag.CourseId = _context.Courses.Select(r => new SelectListItem
            {
                Text = r.CourseName,
                Value = r.Id.ToString()
            }).ToList();
            ViewBag.TeacherNameId = _context.Teachers.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            }).ToList();
            
            return View(new StudentCourseDto{});
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCourseDto stdData)
        {
                 bool success = true;
                 var d= ModelState.Values;
                if (!AllCources.Any())
                {
                    success = false;
                }
                else
                {
                    var student = new Student
                    {
                        Age = stdData.studentDto.Age ?? 0,
                        ClassType = Convert.ToInt32(stdData.studentDto.ClassType),
                        DOB = stdData.studentDto.DOB,
                        Gender= Convert.ToInt32(stdData.studentDto.Gender),
                        Name=stdData.studentDto.Name,
                    };
                  await  _context.AddAsync(student);
                   await _context.SaveChangesAsync();

                    List<StudentCourse> stdCourses = new();
                    List<TeacherStudent> stdTechersCoursec = new();

                    foreach (var item in AllCources)
                    {
                        stdCourses.Add(new StudentCourse
                        {
                            course = _context.Courses.SingleOrDefault(r => r.Id == Convert.ToInt32(item.CourseId)),
                            startingCourse = item.startingCourse,
                            student = student,
                            StudyPeriod=item.StudyPeriod,
                        });
                        stdTechersCoursec.Add(new TeacherStudent { 
                        student=student,
                        teacher=_context.Teachers.SingleOrDefault(r=>r.Id==Convert.ToInt32(item.TeacherNameId))
                        
                        });

                    }
                   await _context.AddRangeAsync(stdCourses);
                   await _context.AddRangeAsync(stdTechersCoursec);
                   await _context.SaveChangesAsync();

                    AllCources = new();
                }
            
            

            return Json(new{ success = success});
        }
        
        /// <summary>
        /// adding course to My List 
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveCourse(CourseInfoDto courseInfoDto)
        {
            if (courseInfoDto != null)
            AllCources.Add(courseInfoDto);
            return PartialView("_CouesesList", AllCources);
        }
        /// <summary>
        /// deleting item course from AllCources List
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteRecordFromTable(int index)
        {
            AllCources.RemoveAt(index);
            return PartialView("_CouesesList", AllCources);
        }
        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
