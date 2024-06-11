using Project.Models;

namespace Project.Services.Interfaces
{
    public interface IInstructorService
    {
        Task<IEnumerable<Instructor>> GetAllAsync();
        Task<IEnumerable<Instructor>> GetAllWithCourseAsync();
        Task<Instructor> GetWithCourseAsync(int? id);
        Task<Instructor> GetByIdAsync(int id);
        Task DeleteAsync(Instructor request);
    }
}
