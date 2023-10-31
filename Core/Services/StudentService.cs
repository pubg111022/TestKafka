using Confluent.Kafka;
using Manonero.MessageBus.Kafka.Abstractions;
using System.Text.Json;
using TestKafka.Application;
using TestKafka.Core.Database.InMemory;
using TestKafka.Core.IServices;
using TestKafka.Core.Models;

namespace TestKafka.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IKafkaProducerManager _producerManager;
        private readonly StudentMemory _inMem;
        public StudentService(StudentMemory inMem,IKafkaProducerManager producerManager)
        {
            _inMem = inMem;
            _producerManager = producerManager;
        }
        public Student Add(Student student)
        {
            var kafkaProducer = _producerManager.GetProducer<string, string>(Constants.CashSettingId);
            var message = new Message<string, string>();
            message.Key = Guid.NewGuid().ToString();
            message.Value = JsonSerializer.Serialize(student);
            kafkaProducer.Produce(message);
            return student;
        }

        public List<Student> Get()
        {
            return _inMem.Memory.Values.ToList();
        }
    }
}
