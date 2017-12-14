using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsCours.Models
{
    public class Student
    {
        [Display(Name = "Идентификатор")]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [Column(Order = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [Column(Order = 2)]
        public string LastName { get; set; }

        [Display(Name = "Почта")]
        [Column(Order = 4)]
        public string Email { get; set; }

        [Display(Name = "Баллы")]
        [Column(Order = 5)]
        public int PointsCount { get; set; }

        [Column("Certificates",Order = 1)]
        public bool MicrosoftCertificateCount { get; set; }
    }
}