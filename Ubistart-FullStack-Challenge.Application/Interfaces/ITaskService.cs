using System.Collections.Generic;
using Ubistart_FullStack_Challenge.Domain.Dtos;

namespace Ubistart_FullStack_Challenge.Service.Interfaces
{
	public interface ITaskService
	{
		public bool TaskRegister(TaskRegisterDto task, int userFk);
		public List<TaskDto> GetUserTasks(int userFk);
	}
}
