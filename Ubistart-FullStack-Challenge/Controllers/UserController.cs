using Microsoft.AspNetCore.Mvc;
using Ubistart_FullStack_Challenge.Service.Interfaces;
using Ubistart_FullStack_Challenge.Domain.Dtos;

namespace Ubistart_FullStack_Challenge.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService UserService;
		public UserController(IUserService userService)
		{
			this.UserService = userService;
		}

		[HttpPost("authenticate")]
		public IActionResult Authenticate(AuthenticationRequestDto authenticationRequestDto)
		{
			return Ok(this.UserService.Authenticate(authenticationRequestDto));
		}
		[HttpPost("signup")]
		public IActionResult SignUp(UserSignUpDto userSignUpDto)
		{
			return Ok(this.UserService.SignUp(new UserDto(userSignUpDto)));
		}
	}
}
