﻿using FiorelloAsp.Models;

namespace Project.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
