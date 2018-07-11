using Kulinarna.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Services.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public void SeedUser()
		{
			var user = new IdentityUser("testUser") { Email = "test@example.com"};
			user.LockoutEnabled = false;
			_userManager.CreateAsync(user, "qwerty").Wait();
		}

		public ServiceResult<bool> SignIn(string username, string password)
		{
			if (String.IsNullOrWhiteSpace(username))
			{
				return new ServiceResult<bool>("Username can not be empty");
			}
			if (String.IsNullOrWhiteSpace(password))
			{
				return new ServiceResult<bool>("Password can not be empty");
			}

			var signInResult = _signInManager.PasswordSignInAsync(username, password, false, false).Result;
			return new ServiceResult<bool>(signInResult.Succeeded);
		}

		public ServiceResult LogOut()
		{
			_signInManager.SignOutAsync().Wait();
			return new ServiceResult();
		}
	}
}
