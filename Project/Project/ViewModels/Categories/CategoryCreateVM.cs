using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels.Categories
{
    public class CategoryCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
