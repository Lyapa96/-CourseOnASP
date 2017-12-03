using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsCours.Models;

namespace StudentsCours.Storage
{
    public class StudentStorage : IStudentStorage
    {
        private List<Student> _students = new List<Student>
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

        private int _currentUniqueId = 2;

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        public void AddStudent(Student student)
        {
            student.Id = ++_currentUniqueId;
            _students.Add(student);
        }

        public void UpdateStudent(Student newStudent)
        {
            DeleteById(newStudent.Id);
            _students.Add(newStudent);
        }

        public void DeleteById(int id)
        {
            _students = _students.Where(x => x.Id != id).ToList();
        }

        public void DeleteAll()
        {
            _students.Clear();
        }
    }
}
