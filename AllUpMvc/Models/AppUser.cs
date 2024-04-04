using Microsoft.AspNetCore.Identity;

namespace AllUpMVC.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}
