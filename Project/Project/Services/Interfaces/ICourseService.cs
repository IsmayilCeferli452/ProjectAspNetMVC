using Project.Models;

namespace Project.Services.Interfaces
{
    public interface ICourseService
    {
        public Task<IEnumerable<Course>> GetAllAsync();
    }
}
