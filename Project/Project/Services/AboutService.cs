using Educal_MVC.Helpers.Extensions;
using FrontProjectAsp.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Interfaces;
using Project.ViewModels.Abouts;

namespace Project.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutService(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _env = environment;
        }

        public async Task EditAsync(About about, AboutEditVM request)
        {
            if (request.NewImage is not null)
            {
                string oldPath = _env.GenerateFilePath("img", about.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{request.NewImage.FileName}";
                string newPath = _env.GenerateFilePath("img", fileName);
                await request.NewImage.SaveFileToLocalAsync(newPath);
                
                about.Image = fileName;
            }


            about.Title = request.Title.Trim();
            about.Description = request.Description.Trim();

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<IEnumerable<About>> GetAllAsync()
        {
            return await _context.About.ToListAsync();
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _context.About.FindAsync(id);
        }
    }
}
