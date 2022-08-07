using Ubistart_FullStack_Challenge.Domain.Dtos;

namespace Ubistart_FullStack_Challenge.Service.Interfaces
{
	public interface IUserService
	{
		public AuthenticationResponseDto Authenticate(AuthenticationRequestDto authenticationRequestDto);
		public bool SignUp(UserDto userDto);
	}
}
