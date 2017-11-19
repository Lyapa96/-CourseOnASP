using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SecondHomework.Models;

namespace SecondHomework.Controllers
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
        public Student Get(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        [Route("Students")]
        [Route("Students/GetAll")]
        [HttpGet]
        public Student[] GetAll()
        {
            return _students.ToArray();
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

        [HttpPost]
        public string Update(int id, int pointsCount)
        {
            var student = _students.FirstOrDefault(x => x.Id == id);
            if (student == null)
                return "Студента с таким id не существует";
            student.PointsCount = pointsCount;

            return "Вы успешно изменили баллы студента";
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