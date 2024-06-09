using Project.Models;

namespace Project.ViewModels
{
    public class AboutVM
    {
        public IEnumerable<Information> Informations { get; set; }
        public IEnumerable<About> About { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
    }
}
