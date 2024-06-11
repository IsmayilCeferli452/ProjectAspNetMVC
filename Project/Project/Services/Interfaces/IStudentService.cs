using Project.Models;

namespace Project.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetWithCoursesAsync(int? id);
        Task<Student> GetByIdAsync(int id);
        Task DeleteAsync(Student request);
    }
}
