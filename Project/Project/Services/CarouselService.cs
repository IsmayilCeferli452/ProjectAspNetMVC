using FrontProjectAsp.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Interfaces;

namespace Project.Services
{
    public class CarouselService : ICarouselService
    {
        private readonly AppDbContext _context;
        public CarouselService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Carousel>> GetAllAsync()
        {
            return await _context.Carousels.ToListAsync();
        }
    }
}
