using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Repository
{
    public static class IdentitySeed
    {
		public static void SeedUser(UserManager<IdentityUser> userManager)
		{
			var user = new IdentityUser("testUser") { Email = "test@example.com"};
			userManager.CreateAsync(user, "qwerty").Wait();
		}
    }
}
