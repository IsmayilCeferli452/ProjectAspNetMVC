using Educal_MVC.Helpers.Extensions;
using FrontProjectAsp.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Interfaces;

namespace Project.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CourseService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(m=> m.StudentCourses).Include(m=> m.Instructors).ToListAsync();
        }
        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }
        public async Task DeleteAsync(Course request)
        {
            string imagePath = _env.GenerateFilePath("img", request.Image);

            imagePath.DeleteFileFromLocal();

            _context.Courses.Remove(request);

            await _context.SaveChangesAsync();
        }
    }
}
