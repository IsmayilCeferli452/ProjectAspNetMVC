using Project.Models;
using Project.ViewModels.Carousels;

namespace Project.Services.Interfaces
{
    public interface ICarouselService
    {
        Task<IEnumerable<Carousel>> GetAllAsync();
        Task CreateAsync(CarouselCreateVM request);
    }
}
