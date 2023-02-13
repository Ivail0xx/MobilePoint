using Microsoft.AspNetCore.Identity;

namespace MobilePoint.Data
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterOn { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
