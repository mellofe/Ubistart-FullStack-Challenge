using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ubistart_FullStack_Challenge.Domain.Dtos;

namespace Ubistart_FullStack_Challenge.Domain.Entities
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdUser { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool IsAdmin { get; set; }

		public User(UserDto user)
		{
			IdUser = user.IdUser;
			Name = user.Name;
			Email = user.Email;
			Password = user.Password;
			IsAdmin = user.IsAdmin;
		}
		public User() { }
	}
}
