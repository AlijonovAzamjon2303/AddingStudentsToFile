using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Brokers.FileBrokers
{
    public class JsonFileBroker : IFileBroker
    {
        readonly string path = "students.json";
        public JsonFileBroker()
        {
            this.EnsureFileExsists();
        }
        public Student Add(Student student)
        {
            List<Student> list = this.Get();
            list.Add(student);
            this.WriteAllStudents(list);

            return student;
        }

        public Student Delete(int id)
        {
            List<Student> students = new List<Student>();
            students = this.Get();
            Student student = new Student();
            for(int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    student = students[i];
                    students.RemoveAt(i);
                    break;
                }
            }

            return student;
        }

        public List<Student> Get()
        {
            List<Student> students = new List<Student>();
            string stringStudents = File.ReadAllText(path);
            students = JsonSerializer.Deserialize<List<Student>>(stringStudents);

            return students;
        }

        public Student Update(Student student)
        {
            throw new NotImplementedException();
        }
         
        void EnsureFileExsists()
        {
            if(!File.Exists(path))
            {
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
            }
        }
        void WriteAllStudents(List<Student> students)
        {
            string stringStudenst = JsonSerializer.Serialize(students);
            File.WriteAllText(path, stringStudenst);
        }
    }
}
