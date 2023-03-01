namespace KampusLearn.Services.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public int CourseId { get; set; }
        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; }

        public Course Course { get; set; }
    }
}
