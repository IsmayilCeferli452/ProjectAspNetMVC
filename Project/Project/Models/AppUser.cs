using Microsoft.AspNetCore.Identity;

namespace FrontProjectAsp.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}
