using Kulinarna.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Services.Services
{
	public class UserService : IUserService
	{
		public UserService(UserManager<IdentityUser> userManager)
		{
			var user = new IdentityUser("testUser") { Email = "test@example.com"};
			userManager.CreateAsync(user, "qwerty").Wait();
		}
	}
}
