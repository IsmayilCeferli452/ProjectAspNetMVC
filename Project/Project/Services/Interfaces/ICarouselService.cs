using Project.Models;

namespace Project.Services.Interfaces
{
    public interface ICarouselService
    {
        Task<IEnumerable<Carousel>> GetAllAsync();
    }
}
