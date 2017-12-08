using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsCours.Models;

namespace StudentsCours.Storage
{
    public sealed class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
    }
}
