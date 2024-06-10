using FrontProjectAsp.Data;
using Project.Models;
using Project.Services.Interfaces;
using Project.ViewModels;

namespace Project.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;
        public ContactService(AppDbContext context)
        {
            _context = context;
        }
        public async Task SendMessage(ContactVM request)
        {
            await _context.Contacts.AddAsync(new Contact
            {
                Email = request.Email,
                Name = request.Name,
                Subject = request.Subject,
                Message = request.Message
            });
            await _context.SaveChangesAsync();
        }
    }
}
