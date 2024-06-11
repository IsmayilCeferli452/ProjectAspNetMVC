using Project.Models;

namespace Project.Services.Interfaces
{
    public interface IInformationService
    {
        Task<IEnumerable<Information>> GetAllAsync();
    }
}
