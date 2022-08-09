using Microsoft.AspNetCore.Mvc;
using Ubistart_FullStack_Challenge.Service.Interfaces;
using Ubistart_FullStack_Challenge.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Ubistart_FullStack_Challenge.Service;
using System.Collections.Generic;

namespace Ubistart_FullStack_Challenge.Controllers
{
	[ApiController, Authorize]
	[Route("api/[controller]")]
	public class TaskController : ControllerBase
	{
		private readonly ITaskService TaskService;
		public TaskController(ITaskService taskService)
		{
			this.TaskService = taskService;
		}

		[HttpPost("taskregister")]
		public IActionResult TaskRegister(TaskRegisterDto taskRegisterDto)
		{
			int userFk = int.Parse(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
			return Ok(this.TaskService.TaskRegister(taskRegisterDto, userFk));
		}
		[HttpGet("usertasks")]
		public IActionResult GetUserTasks()
		{
			int userFk = int.Parse(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
			return Ok(this.TaskService.GetUserTasks(userFk));
		}
		[HttpGet("alltasks")]
		public IActionResult GetAllTasks()
		{
			return Ok(this.TaskService.GetAllTasks());
		}
		[HttpPut("edittask")]
		public IActionResult PutEditedTask(TaskDto taskDto)
		{
			return Ok(this.TaskService.PutEditedTask(taskDto));
		}
	}
}
