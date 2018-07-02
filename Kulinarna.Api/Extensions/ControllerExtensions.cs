using Kulinarna.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kulinarna.Api.Controllers
{
	public static class ControllerExtensions
	{
		public static ActionResult<T> HandleServiceResult<T>(this ControllerBase controller, ServiceResult<T> serviceResult)
		{
			if (serviceResult.IsError)
			{
				var result = new ObjectResult(serviceResult.Errors);
				result.StatusCode = 422;
				return result;
			}
			return serviceResult.SuccessResult;
		}
		public static ActionResult HandleServiceResult(this ControllerBase controller, ServiceResult serviceResult)
		{
			if (serviceResult.IsError)
			{
				var result = new ObjectResult(serviceResult.Errors);
				result.StatusCode = 422;
				return result;
			}
			return new OkResult();
		}
	}
}
