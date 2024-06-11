using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.ViewModels.Categories;

namespace Project.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetAllWithCoursesAsync();
        Task<Category> GetWithCoursesAsync(int? id);
        Task CreateAsync(CategoryCreateVM request);
        Task<bool> ExistAsync(string name);
        Task<Category> GetByIdAsync(int id);
        Task DeleteAsync(Category request);
        Task EditAsync(Category category, CategoryEditVM request);
    }
}
