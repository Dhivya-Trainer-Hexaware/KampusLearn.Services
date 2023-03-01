using System.ComponentModel.DataAnnotations.Schema;

namespace KampusLearn.Services.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        [Column(TypeName ="varchar(30)")]
        public string TrainerName { get; set; }
        [Column(TypeName = "varchar(30)")]

        public string Skills { get; set; }

        public int YearsOfExperience { get; set; }
        public long Contact { get; set; }
        [Column(TypeName = "varchar(30)")]

        public string Email { get; set; }
    }
}
