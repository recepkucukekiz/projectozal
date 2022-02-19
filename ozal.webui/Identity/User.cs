#nullable disable
using Microsoft.AspNetCore.Identity;

namespace ozal.webui.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set;}
        public string LastName { get; set; }
    }
}
