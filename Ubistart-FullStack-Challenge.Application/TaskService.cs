using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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
		public bool PutEditedTask(TaskDto taskDto)
		{
			return true;
		}
	}
}
