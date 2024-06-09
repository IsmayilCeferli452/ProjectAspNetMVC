using Project.Models;

namespace Project.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Carousel> Carousels { get; set; }
        public IEnumerable<Information> Informations { get; set; }
        public IEnumerable<About> About { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
