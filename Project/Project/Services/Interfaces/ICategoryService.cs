using Project.Models;

namespace Project.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllAsync();
    }
}
