using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels.Categories
{
    public class CategoryEditVM
    {
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
    }
}
