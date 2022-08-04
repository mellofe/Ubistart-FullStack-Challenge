using System;
using System.ComponentModel.DataAnnotations;

namespace Ubistart_FullStack_Challenge.Domain.Entities
{
	public class User
	{
		[Key]
		public int IdUser { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool IsAdmin { get; set; }

	}
}
