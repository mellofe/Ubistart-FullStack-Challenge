namespace Ubistart_FullStack_Challenge.Domain.Dtos
{
	public class AuthenticationResponseDto
	{
		public AuthenticationResponseDto(UserDto userDto, string token)
		{
			this.UserDto = userDto;
			this.Token = token;
		}

		public UserDto UserDto { get; set; }
		public string Token { get; set; }
	}
}
