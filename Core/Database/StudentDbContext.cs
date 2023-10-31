using Microsoft.EntityFrameworkCore;
using TestKafka.Core.Database.EntitiesTypeConfigurations;
using TestKafka.Core.Models;
using static Confluent.Kafka.ConfigPropertyNames;

namespace TestKafka.Core.Database
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Student>(new StudentEntityTypeConfiguration());
        }
    }
}
