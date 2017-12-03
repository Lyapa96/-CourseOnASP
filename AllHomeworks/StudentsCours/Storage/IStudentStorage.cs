using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsCours.Models;

namespace StudentsCours.Storage
{
    public interface IStudentStorage
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student newStudent);
        void DeleteById(int id);
        void DeleteAll();
    }
}
