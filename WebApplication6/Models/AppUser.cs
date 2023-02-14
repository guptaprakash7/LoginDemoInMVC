using Microsoft.AspNetCore.Identity;

namespace WebApplication6.Models
{
	public class AppUser : IdentityUser
	{
		public int MyProperty { get; set; }
	}
}
