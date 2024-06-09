using FiorelloAsp.Models;
using FrontProjectAsp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace FrontProjectAsp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<About> About { get; set; }
    }
}
