using System.Collections.Generic;
using System.Linq;
using StudentsCours.Models;

namespace StudentsCours.Storage
{
    public class StudentStorage : IStudentStorage
    {
        private readonly CourseContext _context;

        public StudentStorage(CourseContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student newStudent)
        {
            var oldStudent = GetStudentById(newStudent.Id);
            oldStudent.Email = newStudent.Email;
            oldStudent.FirstName = newStudent.FirstName;
            oldStudent.LastName = newStudent.LastName;
            oldStudent.PointsCount = newStudent.PointsCount;

            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var student = _context.Students.First(x => x.Id == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            _context.Students.RemoveRange(_context.Students);
            _context.SaveChanges();
        }
    }
}