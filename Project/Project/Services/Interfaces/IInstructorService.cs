using Project.Models;

namespace Project.Services.Interfaces
{
    public interface IInstructorService
    {
        public Task<IEnumerable<Instructor>> GetAllAsync();
    }
}
