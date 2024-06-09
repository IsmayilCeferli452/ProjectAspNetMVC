﻿using FiorelloAsp.Models;

namespace Project.Models
{
    public class Information : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}