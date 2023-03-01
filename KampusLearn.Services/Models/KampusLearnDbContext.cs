using Microsoft.EntityFrameworkCore;

namespace KampusLearn.Services.Models
{
    public class KampusLearnDbContext:DbContext
    {
        public KampusLearnDbContext(DbContextOptions<KampusLearnDbContext> options):base(options)
        {

        }

        public DbSet<Course>     Courses { get; set; }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Batch> Batches { get; set; }

    }
}
