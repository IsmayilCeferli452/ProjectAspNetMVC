using Educal_MVC.Helpers.Extensions;
using FrontProjectAsp.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Interfaces;

namespace Project.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public StudentService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetWithCoursesAsync(int? id)
        {
            Student student = await _context.Students.Include(m => m.StudentCourses)
                                                         .FirstOrDefaultAsync(m => m.Id == id);

            return student;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task DeleteAsync(Student request)
        {
            string imagePath = _env.GenerateFilePath("img", request.Image);

            imagePath.DeleteFileFromLocal();

            _context.Students.Remove(request);

            await _context.SaveChangesAsync();
        }
    }
}
