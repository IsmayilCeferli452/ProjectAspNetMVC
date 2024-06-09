using FiorelloAsp.Models;

namespace Project.Models
{
    public class Instructor : BaseEntity
    {
        public string Fullname { get; set; }
        public string Profession { get; set; }
        public string Image { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
