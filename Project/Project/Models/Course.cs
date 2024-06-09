using FiorelloAsp.Models;

namespace Project.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
        public decimal Duration { get; set; }

    }
}
