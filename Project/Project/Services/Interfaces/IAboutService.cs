using Project.Models;

namespace Project.Services.Interfaces
{
    public interface IAboutService
    {
        public Task<IEnumerable<About>> GetAllAsync();
    }
}
