using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels.Carousels
{
    public class CarouselCreateVM
    {
        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
