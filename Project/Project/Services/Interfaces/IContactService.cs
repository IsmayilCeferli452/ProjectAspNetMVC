using Project.Models;
using Project.ViewModels;

namespace Project.Services.Interfaces
{
    public interface IContactService
    {
        public Task SendMessage(ContactVM request);
    }
}
