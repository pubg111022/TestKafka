using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static Confluent.Kafka.ConfigPropertyNames;
using TestKafka.Core.Models;

namespace TestKafka.Core.Database.EntitiesTypeConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.Age).HasColumnName("Age");
            builder.Property(p => p.Birthday).HasColumnName("Birthday");

        }
    }
}
