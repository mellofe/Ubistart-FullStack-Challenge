using AutoMapper;
using System.Threading.Tasks;
using Ubistart_FullStack_Challenge.Domain.Dtos;

namespace Ubistart_FullStack_Challenge.Domain.AutoMapper
{
	public class AutoMapperConfiguration : Profile
	{
		public AutoMapperConfiguration()
		{
			CreateMap<Task, TaskDto>();
		}
	}
}
