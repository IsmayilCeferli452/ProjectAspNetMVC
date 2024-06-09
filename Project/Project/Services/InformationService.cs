using FrontProjectAsp.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Interfaces;

namespace Project.Services
{
    public class InformationService : IInformationService
    {
        private readonly AppDbContext _context;
        public InformationService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Information>> GetAllAsync()
        {
            return await _context.Informations.ToListAsync();
        }
    }
}
