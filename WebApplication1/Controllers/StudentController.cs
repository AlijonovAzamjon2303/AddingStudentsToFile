using Microsoft.AspNetCore.Mvc;
using WebApplication1.Brokers.FileBrokers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        IFileBroker fileBroker;
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            fileBroker = new JsonFileBroker();
            _logger = logger;
        }
        [HttpGet(Name = "GetStudensts")]
        public IEnumerable<Student> GetStudents()
        {
            return fileBroker.Get().ToArray();
        }

        [HttpPost(Name = "AddStudent")]
        public Student AddStudent(Student student)
        {
            return fileBroker.Add(student);
        }
    }
}
