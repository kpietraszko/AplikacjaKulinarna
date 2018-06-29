using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kulinarna.Data.Models
{
	public class User
	{
		[Required]
		public string EmailAddress { get; set; }
		[Required]
		public string PasswordHash { get; set; }
	}
}
