using Educal_MVC.Helpers.Extensions;
using FrontProjectAsp.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Interfaces;
using Project.ViewModels.Categories;

namespace Project.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(m => m.Courses).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllWithCoursesAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.Include(m => m.Courses)
                                                                        .OrderByDescending(m => m.Id)
                                                                        .ToListAsync();
            return categories;
        }

        public async Task<Category> GetWithCoursesAsync(int? id)
        {
            Category category = await _context.Categories.Include(m => m.Courses)
                                                         .FirstOrDefaultAsync(m => m.Id == id);

            return category;
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task CreateAsync(CategoryCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Categories.AddAsync(new Category { Name = request.Name, Image = fileName });

            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task DeleteAsync(Category request)
        {
            string imagePath = _env.GenerateFilePath("img", request.Image);

            imagePath.DeleteFileFromLocal();

            _context.Categories.Remove(request);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Category category, CategoryEditVM request)
        {
            if (request.NewImage is not null)
            {
                string oldPath = _env.GenerateFilePath("img", category.Image);

                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{request.NewImage.FileName}";

                string newPath = _env.GenerateFilePath("img", fileName);

                await request.NewImage.SaveFileToLocalAsync(newPath);

                category.Image = fileName;
            }

            category.Name = request.Name.Trim();

            await _context.SaveChangesAsync();
        }
    }
}
