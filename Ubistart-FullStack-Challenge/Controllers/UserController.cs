using Microsoft.AspNetCore.Mvc;
using Ubistart_FullStack_Challenge.Service.Interfaces;
using Ubistart_FullStack_Challenge.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Ubistart_FullStack_Challenge.Service;
using System.Security.Claims;

namespace Ubistart_FullStack_Challenge.Controllers
{
	[ApiController, Authorize]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService UserService;
		private readonly IMapper Mapper;
		public UserController(IUserService userService, IMapper mapper)
		{
			this.UserService = userService;
			Mapper = mapper;
		}

		[HttpPost("authenticate"), AllowAnonymous]
		public IActionResult Authenticate(AuthenticationRequestDto authenticationRequestDto)
		{
			return Ok(this.UserService.Authenticate(authenticationRequestDto));
		}
		[HttpPost("signup"), AllowAnonymous]
		public IActionResult SignUp(UserSignUpDto userSignUpDto)
		{
			return Ok(this.UserService.SignUp(Mapper.Map<UserDto>(userSignUpDto)));
		}
		[HttpGet("checkadmin")]
		public IActionResult CheckUserIsAdmin()
		{
			int userId = int.Parse(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
			return Ok(this.UserService.CheckUserIsAdmin(userId));
		}
	}
}
