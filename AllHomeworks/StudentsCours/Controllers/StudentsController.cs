using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using StudentsCours.Models;
using StudentsCours.Storage;

namespace StudentsCours.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentStorage _studentStorage;

        public StudentsController(IStudentStorage studentStorage)
        {
            _studentStorage = studentStorage;
        }

        [HttpGet]
        public IActionResult Get([FromServices] IStudentStorage storage, int id)
        {
            var student = storage.GetStudentById(id);
            return View(student);
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        [Route("Students")]
        [Route("Students/GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentStorage.GetAllStudents().ToArray();
            return View(students);
        }

        [HttpGet]
        public string Count()
        {
            var count = ActivatorUtilities
                .CreateInstance<StudentsCount>(HttpContext.RequestServices);

            return count.CountFormat;
        }

        [HttpPost]
        public string Create(string firstName, string lastName, string email)
        {
            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            _studentStorage.AddStudent(student);

            return $"Студент {lastName} {firstName} с id = {student.Id} успешно создан";
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            var storage = HttpContext
                .RequestServices
                .GetService<IStudentStorage>();

            if (ModelState.IsValid)
            {
                storage.AddStudent(student);
                return Json(student);
            }

            return BadRequest(ModelState);
        }

        public IActionResult Update(int id)
        {
            var student = _studentStorage.GetStudentById(id);
            if (student == null)
                return BadRequest(404);

            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student updatedStudent)
        {
            if (!ModelState.IsValid)
            {
                return Update(updatedStudent.Id);
            }

            _studentStorage.UpdateStudent(updatedStudent);

            return RedirectToAction("Get", updatedStudent);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            _studentStorage.DeleteById(id);

            return $"Студент удален с id = {id}";
        }

        [HttpDelete]
        public string DeleteAll()
        {
            _studentStorage.DeleteAll();
            return "Вы успешно удалили всех студентов";
        }
    }
}