using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsCours.Storage
{
    public class StudentsCount
    {
        public readonly string CountFormat;
        public StudentsCount(IStudentStorage studentStorage)
        {
            CountFormat = "Время:"+DateTime.Now + "\tколичество студентов:" + studentStorage.GetAllStudents().Count;
        }
    }
}
