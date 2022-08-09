using AutoMapper;
using System;
using System.Collections.Generic;
using Ubistart_FullStack_Challenge.Dao.Interfaces;
using Ubistart_FullStack_Challenge.Domain.Dtos;
using Ubistart_FullStack_Challenge.Domain.Entities;
using Ubistart_FullStack_Challenge.Service.Interfaces;

namespace Ubistart_FullStack_Challenge.Service
{
	public class TaskService : ITaskService
	{
		private readonly ITaskDao TaskDao;
		private readonly IMapper Mapper;
		public UserService UserService;

		public TaskService(ITaskDao taskDao, IUserDao userDao, IMapper mapper)
		{
			TaskDao = taskDao;
			UserService = new UserService(userDao, mapper);
			Mapper = mapper;
		}
		public bool TaskRegister(TaskRegisterDto taskRegisterDto, int userFk)
		{
			User user = this.UserService.FindUserById(userFk);
			TaskDto taskDto = new TaskDto(DateTime.Now, taskRegisterDto.Description, taskRegisterDto.Deadline);
			Task task = new Task(taskDto, user, userFk);
			this.TaskDao.Create(task);
			return true;
		}
		public List<TaskDto> GetUserTasks(int userFk)
		{
			IEnumerable<Task> tasks = this.TaskDao.GetUserTasks(userFk);
			List<TaskDto> tasksList = Mapper.Map<List<TaskDto>>(tasks);
			return tasksList;
		}
		public List<TaskDto> GetAllTasks()
		{
			IEnumerable<Task> tasks = this.TaskDao.GetAllTasks();
			List<TaskDto> tasksList = Mapper.Map<List<TaskDto>>(tasks);
			foreach (TaskDto task in tasksList)
			{
				task.Email = this.UserService.FindUserById(task.UserFK).Email;
			}
			return tasksList;
		}

		public bool PutEditedTask(TaskDto taskDto)
		{
			if (taskDto == null || taskDto.IdTask == default)
			{
				throw new Exception("Task invalida");
			}

			Task task = this.TaskDao.FindWithoutTracking(x => x.IdTask == taskDto.IdTask);
			int userFk = task.UserFK;
			if (task == null)
			{
				return false;
			}

			task = Mapper.Map<Task>(taskDto);
			task.UserFK = userFk;

			this.TaskDao.Update(task);

			return true;
		}
	}
}
