using FiorelloAsp.Models;

namespace Project.Models
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        //public ICollection<Information> Infos { get; set; }
    }
}
