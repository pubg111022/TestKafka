using TestKafka.Core.Models;
using static Confluent.Kafka.ConfigPropertyNames;

namespace TestKafka.Core.Database.InMemory
{
    public class StudentMemory
    {
        public Dictionary<string, Student> Memory { get; set; }

        public StudentMemory()
        {
            Memory = new Dictionary<string, Student>();
        }
    }
}
