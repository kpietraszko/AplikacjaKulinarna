using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kulinarna.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kulinarna.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
		private readonly IUserService _userService;

		public AuthenticationController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpPost("[action]")]
		public ActionResult<bool> SignIn(string username, string password)
		{
			return this.HandleServiceResult(_userService.SignIn(username, password));
		}
		[HttpPost("[action]")]
		public ActionResult LogOut()
		{
			return this.HandleServiceResult(_userService.LogOut());
		}
    }
}