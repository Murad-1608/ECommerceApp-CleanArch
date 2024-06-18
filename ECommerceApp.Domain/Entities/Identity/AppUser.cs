using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Domain.Entities.Identity
{
    public sealed class AppUser : IdentityUser<string>
    {
        public string RefleshToken { get; set; }
        public DateTime RefleshTokenEndDate { get; set; }
    }
}
