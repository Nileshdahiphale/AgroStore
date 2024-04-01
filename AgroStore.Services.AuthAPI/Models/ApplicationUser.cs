using Microsoft.AspNetCore.Identity;

namespace AgroStore.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
