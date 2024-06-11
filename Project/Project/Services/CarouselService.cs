using Educal_MVC.Helpers.Extensions;
using FrontProjectAsp.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Interfaces;
using Project.ViewModels.Carousels;

namespace Project.Services
{
    public class CarouselService : ICarouselService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public CarouselService(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task CreateAsync(CarouselCreateVM request)
        {
            foreach (var image in request.Images)
            {
                string fileName = Guid.NewGuid().ToString() + "-" + image.FileName;

                string path = Path.Combine(_environment.WebRootPath, "img", fileName);

                await image.SaveFileToLocalAsync(path);

                await _context.Carousels.AddAsync(new Models.Carousel { Image = fileName });
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Carousel>> GetAllAsync()
        {
            return await _context.Carousels.ToListAsync();
        }
    }
}
