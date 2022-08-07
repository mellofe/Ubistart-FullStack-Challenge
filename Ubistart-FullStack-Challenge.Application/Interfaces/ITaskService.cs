using Ubistart_FullStack_Challenge.Domain.Dtos;

namespace Ubistart_FullStack_Challenge.Service.Interfaces
{
	public interface ITaskService
	{
		public bool TaskRegister(TaskRegisterDto task, int userFk);
	}
}
