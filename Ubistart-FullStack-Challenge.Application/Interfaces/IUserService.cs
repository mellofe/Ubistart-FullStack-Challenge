using Ubistart_FullStack_Challenge.Domain.Dtos;
using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Service.Interfaces
{
	public interface IUserService
	{
		public AuthenticationResponseDto Authenticate(AuthenticationRequestDto authenticationRequestDto);
		public bool CheckUserIsAdmin(int userId);
		public bool SignUp(UserDto userDto);
		public User FindUser(string email, string password);
		public User FindUserById(int id);
	}
}
