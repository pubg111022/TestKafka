using Confluent.Kafka;
using Manonero.MessageBus.Kafka.Abstractions;
using TestKafka.Core.Database.InMemory;
using TestKafka.Settings;
using System.Text;
using System.Text.Json;
using TestKafka.Core.Models;

namespace TestKafka.BackgroundTasks
{
    public class CashConsumingTask : IConsumingTask<string, string>
    {
        private StudentMemory _student;
        public CashConsumingTask(StudentMemory student) {
            _student = student;
        }
        public void Execute(ConsumeResult<string, string> result)
        {
            var student = JsonSerializer.Deserialize<Student>(result.Message.Value);
            _student.Memory.Add(student.Id, student);
        }
    }

}
