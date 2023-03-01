using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KampusLearn.Services.Models
{
    public class Course
    {


        public int CourseId { get; set; }
        [Column(TypeName = "varchar(30)")]

        public string CourseName { get; set; }//json courseName

        [Column(TypeName = "varchar(30)")]
        public string Technology { get; set; }//json technology
         [Required]
         [Range(1000,100000)]
        public int? Price { get; set; }//price it will take the default value of int ==>0  ===>null
        public int DurationinHours { get; set; }//json  durationInHours
    }
}
