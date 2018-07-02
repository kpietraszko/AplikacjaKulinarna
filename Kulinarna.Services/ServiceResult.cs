using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Services
{
	public class ServiceResult
	{
		public string[] Errors { get; set; }
		public bool IsError { get { return Errors?.Length > 0; } }

		public ServiceResult()
		{
			Errors = null;
		}
		public ServiceResult(params string[] errors)
		{
			Errors = errors;
		}
	}
	public class ServiceResult<T> : ServiceResult
	{
		public T SuccessResult { get; set; }

		public ServiceResult(T successResult)
		{
			SuccessResult = successResult;
		}
		public ServiceResult(params string[] errors) : base(errors) { }
	}
}
