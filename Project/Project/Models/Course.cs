using FiorelloAsp.Models;

namespace Project.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}
