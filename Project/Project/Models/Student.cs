using FiorelloAsp.Models;

namespace Project.Models
{
    public class Student : BaseEntity
    {
        public string Fullname { get; set; }
        public string Profession { get; set; }
        public string StudentInfo { get; set; }
        public string Image { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
