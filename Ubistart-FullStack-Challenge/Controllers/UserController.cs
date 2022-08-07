using Microsoft.AspNetCore.Mvc;
using Ubistart_FullStack_Challenge.Service.Interfaces;
using Ubistart_FullStack_Challenge.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Ubistart_FullStack_Challenge.Controllers
{
	[ApiController, Authorize]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService UserService;
		public UserController(IUserService userService)
		{
			this.UserService = userService;
		}

		[HttpPost("authenticate"), AllowAnonymous]
		public IActionResult Authenticate(AuthenticationRequestDto authenticationRequestDto)
		{
			return Ok(this.UserService.Authenticate(authenticationRequestDto));
		}
		[HttpPost("signup"), AllowAnonymous]
		public IActionResult SignUp(UserSignUpDto userSignUpDto)
		{
			return Ok(this.UserService.SignUp(new UserDto(userSignUpDto)));
		}
	}
}
