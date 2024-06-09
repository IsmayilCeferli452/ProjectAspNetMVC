using Project.Models;

namespace Project.Services.Interfaces
{
    public interface IInformationService
    {
        public Task<IEnumerable<Information>> GetAllAsync();
    }
}
