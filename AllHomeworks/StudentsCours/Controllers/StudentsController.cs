using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentsCours.Models;

namespace StudentsCours.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> _students = new List<Student>
        {
            new Student
            {
                Email = "email1",
                FirstName = "Bruce",
                LastName = "Lee",
                Id = 1,
                PointsCount = 10
            },
            new Student
            {
                Email = "email2",
                FirstName = "Steven",
                LastName = "Seagal",
                Id = 2,
                PointsCount = 15
            }
        };

        private static int _currentUniqueId = 2;

        [HttpGet]
        public IActionResult Get(int id)
        {
            var student = _students.FirstOrDefault(x => x.Id == id);
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
            var students = _students.ToArray();
            return View(students);
        }

        [HttpGet]
        public int Count()
        {
            return _students.Count();
        }

        [HttpPost]
        public string Create(string firstName, string lastName, string email)
        {
            _students.Add(new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Id = ++_currentUniqueId
            });

            return $"Студент {lastName} {firstName} с id = {_currentUniqueId} успешно создан";
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = ++_currentUniqueId;
                _students.Add(student);
                return Json(student);
            }

            return BadRequest(ModelState);
        }

        public IActionResult Update(int id)
        {
            var student = _students.FirstOrDefault(x => x.Id == id);
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

            var student = _students.First(x => x.Id == updatedStudent.Id);
            _students.Remove(student);
            _students.Add(updatedStudent);

            return RedirectToAction("Get", updatedStudent);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            _students = _students.Where(x => x.Id != id).ToList();

            return $"Студент удален с id = {id}";
        }

        [HttpDelete]
        public string DeleteAll()
        {
            _students.Clear();
            return "Вы успешно удалили всех студентов";
        }
    }
}