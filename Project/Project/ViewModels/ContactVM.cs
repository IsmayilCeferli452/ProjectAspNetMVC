using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class ContactVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public Dictionary<string, string> Settings { get; set; }
    }
}
