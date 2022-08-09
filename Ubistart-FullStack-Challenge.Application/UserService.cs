using Ubistart_FullStack_Challenge.Service.Interfaces;
using Ubistart_FullStack_Challenge.Domain.Dtos;
using Ubistart_FullStack_Challenge.Domain.Entities;
using Ubistart_FullStack_Challenge.Dao.Interfaces;
using System;
using AutoMapper;

namespace Ubistart_FullStack_Challenge.Service
{
	public class UserService : IUserService
	{
		private readonly IUserDao UserDao;
		private readonly IMapper Mapper;

		public UserService(IUserDao userDao, IMapper mapper)
		{
			UserDao = userDao;
			Mapper = mapper;
		}

		public AuthenticationResponseDto Authenticate(AuthenticationRequestDto authenticationRequestDto)
		{
			User user = FindUser(authenticationRequestDto.Email, authenticationRequestDto.Password);

			if (user == null)
			{
				throw new System.Exception("Invalid user parameters.");
			}
			return new AuthenticationResponseDto(Mapper.Map<UserDto>(user), TokenService.GenerateToken(user));
		}
		public bool SignUp(UserDto userDto)
		{
			if (userDto.IdUser != default)
				throw new Exception("UserId must be empty.");

			User user = new User(userDto);
			this.UserDao.Create(user);
			return true;
		}
		public User FindUser(string email, string password)
		{
			User user = this.UserDao.Find(x => x.Email.ToLower() == email.ToLower()
											&& x.Password.ToLower() == password.ToLower());
			return user;
		}
		public User FindUserById(int id)
		{
			User user = this.UserDao.Find(x => x.IdUser == id);

			return user;
		}
	}
}
