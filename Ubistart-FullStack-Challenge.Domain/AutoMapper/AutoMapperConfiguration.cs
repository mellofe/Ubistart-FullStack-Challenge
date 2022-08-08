using AutoMapper;
using Ubistart_FullStack_Challenge.Domain.Dtos;
using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Domain.AutoMapper
{
	public class AutoMapperConfiguration : Profile
	{
		public AutoMapperConfiguration()
		{
			CreateMap<Task, TaskDto>();
			CreateMap<TaskDto, Task>();
			CreateMap<UserDto, User>();
			CreateMap<User, UserDto>();
			CreateMap<UserSignUpDto, UserDto>();
		}
	}
}
