using System.ComponentModel.DataAnnotations;

namespace StudentsCours.Models
{
    public class Student
    {
        [Display(Name = "Идентификатор")]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Display(Name = "Баллы")]
        public int PointsCount { get; set; }
    }
}