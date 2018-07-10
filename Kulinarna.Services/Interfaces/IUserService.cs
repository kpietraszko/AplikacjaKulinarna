using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Services.Interfaces
{
	public interface IUserService
	{
		void SeedUser();
		ServiceResult<bool> SignIn(string username, string password);
		ServiceResult LogOut();
	}
}
