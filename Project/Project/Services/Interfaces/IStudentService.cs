using Project.Models;

namespace Project.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetAllAsync();
    }
}
