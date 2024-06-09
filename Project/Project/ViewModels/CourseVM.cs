using Project.Models;

namespace Project.ViewModels
{
    public class CourseVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
