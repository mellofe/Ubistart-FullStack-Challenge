using Microsoft.AspNetCore.Mvc;
using Ubistart_FullStack_Challenge.Service.Interfaces;
using Ubistart_FullStack_Challenge.Domain.Dtos;

namespace Ubistart_FullStack_Challenge.Controllers
{
	[ApiController]
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
			return Ok(this.TaskService.TaskRegister(taskRegisterDto));
		}
	}
}
