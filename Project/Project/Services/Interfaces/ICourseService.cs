using Project.Models;

namespace Project.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task DeleteAsync(Course request);
    }
}
