using Project.Models;
using Project.ViewModels;

namespace Project.Services.Interfaces
{
    public interface IContactService
    {
        Task SendMessage(ContactVM request);
    }
}
