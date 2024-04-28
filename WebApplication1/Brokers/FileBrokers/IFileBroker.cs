using WebApplication1.Models;

namespace WebApplication1.Brokers.FileBrokers
{
    public interface IFileBroker
    {
        Student Add(Student student);
        Student Update(Student student);
        Student Delete(int id);
        List<Student> Get();
    }
}
