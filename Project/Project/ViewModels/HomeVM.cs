using Project.Models;

namespace Project.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Carousel> Carousels { get; set; }
        public IEnumerable<Information> Informations { get; set; }
        public IEnumerable<About> AboutUs { get; set; }
    }
}
