using Ubistart_FullStack_Challenge.Service.Interfaces;
using Ubistart_FullStack_Challenge.Domain.Dtos;
using Ubistart_FullStack_Challenge.Domain.Entities;
using Ubistart_FullStack_Challenge.Dao.Interfaces;
using System;

namespace Ubistart_FullStack_Challenge.Service
{
	public class UserService : IUserService
	{
		private readonly IUserDao UserDao;

		public UserService(IUserDao userDao)
		{
			UserDao = userDao;
		}

		public AuthenticationResponseDto Authenticate(AuthenticationRequestDto authenticationRequestDto)
		{
			User user = this.UserDao.Find(x => x.Email.ToLower() == authenticationRequestDto.Email.ToLower()
											&& x.Password.ToLower() == authenticationRequestDto.Password.ToLower());
			if (user == null)
			{
				throw new System.Exception("");
			}
			return new AuthenticationResponseDto(new UserDto(user), TokenService.GenerateToken(user));
		}
		public bool SignUp(UserDto userDto)
		{
			if (userDto.IdUser != default)
				throw new Exception("UserID must be empty");

			User user = new User(userDto);
			this.UserDao.Create(user);
			return true;
		}
	}
}
