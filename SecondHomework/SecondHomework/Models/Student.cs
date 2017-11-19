using System.ComponentModel.DataAnnotations;

namespace SecondHomework.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PointsCount { get; set; }
    }
}