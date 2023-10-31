using TestKafka.Core.Models;

namespace TestKafka.Core.IServices
{
    public interface IStudentService
    {
        public Student Add(Student student);
        public List<Student> Get();
    }
}
