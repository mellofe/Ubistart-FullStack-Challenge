using System;
using Ubistart_FullStack_Challenge.Dao.Interfaces;
using Ubistart_FullStack_Challenge.Domain.Dtos;
using Ubistart_FullStack_Challenge.Domain.Entities;
using Ubistart_FullStack_Challenge.Service.Interfaces;

namespace Ubistart_FullStack_Challenge.Service
{
	public class TaskService : ITaskService
	{
		private readonly ITaskDao TaskDao;
		public UserService UserService;

		public TaskService(ITaskDao taskDao, IUserDao userDao)
		{
			TaskDao = taskDao;
			UserService = new UserService(userDao);
		}
		public bool TaskRegister(TaskRegisterDto taskRegisterDto)
		{
			int userFk = 1;
			User user = this.UserService.FindUserById(userFk);
			TaskDto taskDto = new TaskDto(DateTime.Now, taskRegisterDto.Description, taskRegisterDto.Deadline, user, userFk);
			Task task = new Task(taskDto);
			this.TaskDao.Create(task);
			return true;
		}
	}
}
