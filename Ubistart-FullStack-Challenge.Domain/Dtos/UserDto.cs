using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Domain.Dtos
{
	public class UserDto
	{
		public int IdUser { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool IsAdmin { get; set; }
		public UserDto(User user)
		{
			IdUser = user.IdUser;
			Name = user.Name;
			Email = user.Email;
			Password = user.Password;
			IsAdmin = user.IsAdmin;
		}
		public UserDto(UserSignUpDto user)
		{
			Name = user.Name;
			Email = user.Email;
			Password = user.Password;
			IsAdmin = false;
		}
	}
}
