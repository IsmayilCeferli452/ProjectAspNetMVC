using Educal_MVC.Helpers.Extensions;
using FrontProjectAsp.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Interfaces;

namespace Project.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public InstructorService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<IEnumerable<Instructor>> GetAllWithCourseAsync()
        {
            IEnumerable<Instructor> instructors = await _context.Instructors.Include(m => m.Course)
                                                                        .OrderByDescending(m => m.Id)
                                                                        .ToListAsync();
            return instructors;
        }

        public async Task<Instructor> GetWithCourseAsync(int? id)
        {
            Instructor instructor = await _context.Instructors.Include(m => m.Course)
                                                         .FirstOrDefaultAsync(m => m.Id == id);

            return instructor;
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _context.Instructors.FindAsync(id);
        }

        public async Task DeleteAsync(Instructor request)
        {
            string imagePath = _env.GenerateFilePath("img", request.Image);

            imagePath.DeleteFileFromLocal();

            _context.Instructors.Remove(request);

            await _context.SaveChangesAsync();
        }
    }
}
