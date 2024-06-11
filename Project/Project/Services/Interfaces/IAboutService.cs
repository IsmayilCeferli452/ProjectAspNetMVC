using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.ViewModels.Abouts;

namespace Project.Services.Interfaces
{
    public interface IAboutService
    {
        Task<IEnumerable<About>> GetAllAsync();
        Task<About> GetByIdAsync(int id);
        Task<bool> ExistAsync(string name);
        Task EditAsync(About about, AboutEditVM request);
    }
}
