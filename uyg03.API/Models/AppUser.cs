using Microsoft.AspNetCore.Identity;

namespace uyg03.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
